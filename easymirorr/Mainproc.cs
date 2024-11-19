using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easymirorr
{
    public class MainProc
    {
        
        private readonly ProcessManager processManager;
        private readonly DeviceManager deviceManager;
        private  Dictionary<string, string> commandDict;
        private RewindRecorder rewindRecorder;
        private Process process;
        private CommandList commandList;

        private String scrcpyPath = ".\\scrcpy\\scrcpy.exe";
        private String adbPath = ".\\scrcpy\\adb.exe";
        // ユーザーのビデオフォルダのパスを取得
        private String recPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) + "\\MirorrApp";
        private String jsonPath = ".\\CommandList.json";


        public MainProc()
        {
            processManager = new ProcessManager();
            deviceManager = new DeviceManager(adbPath);
            commandList = new CommandList();
            commandDict = commandList.Commandget(jsonPath);
            rewindRecorder = new RewindRecorder(scrcpyPath, commandDict);
        }

        // Scrcpyを起動
        public void StartScrcpy(string deviceId)
        {
            
            string command =commandList.BuildCommand(commandDict, "serial",deviceId,"start");
            process =  processManager.StartProcess(scrcpyPath,command, redirectOutput: true);
        }

        // Scrcpyを停止
        public void StopScrcpy()
        {

             processManager.StopProcess(process);

        }

        public string CreateRecPath()
        {
            // 現在の日時でファイル名を作成
            string fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".mp4";
            string filePath = Path.Combine(recPath, fileName);

            return filePath;
        }



        // Scrcpyを全画面表示
        public void FullScreen(string deviceId)
        {
            string command = commandList.BuildCommand(commandDict, "serial",deviceId, "start", "fullscreen");
            process =  processManager.StartProcess(scrcpyPath, command, redirectOutput: true);
        }

        // 録画を開始
        public void Recording(string deviceId)
        {
            string recPath = CreateRecPath();
            string command = commandList.BuildCommand(commandDict,"serial", deviceId, "start", "aac", "record",recPath) ;
            process =  processManager.StartProcess(scrcpyPath, command, redirectOutput: true);
        }

        //巻き戻し録画
        public async void RewindRecorder()
        {

            await rewindRecorder.StartRecordingAsync();

        }

        public async void SaveRewindRecorder()
        {
            // 現在の日時でファイル名を作成
            string fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".mp4";
            string filePath = Path.Combine(recPath, fileName);
            await rewindRecorder.SaveBufferedRecordingAsync(filePath);
        }


        public void Screenshot()
        {
            try
            {
                // shot.exe のパスを指定
                string shotPath = ".\\shot.exe";

                // Processを使ってshot.exeを起動
                Process process = new Process();
                process.StartInfo.FileName = shotPath;
                process.StartInfo.Arguments = recPath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                // プロセスの出力を取得
                string result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();  // shot.exeの完了まで待機

                MessageBox.Show(result, "完了", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"スクリーンショットの撮影に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // ADB再起動
        public void AdbRestart()
        {
            string command =  commandList.BuildCommand( commandDict,"adbstop");
             processManager.StartProcess(adbPath, command, redirectOutput: true);
        }

       

        //カスタマイズ設定からの起動
        public void CustomStart(string deviceId,string fps,string bitrate,string buffer,string size,string display,string movie,string audio)
        {
            string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start",display,"max-fps",fps,"bitrate",bitrate,buffer,movie,audio);
            process = processManager.StartProcess(scrcpyPath, command, redirectOutput: true);

        }

        public void CustomRecordStart(string deviceId, string fps, string bitrate, string buffer, string size, string display, string movie, string audio)
        {
           String recPath = CreateRecPath();
            string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start", display, "max-fps", fps, "bitrate", bitrate, buffer, movie, audio,"record",recPath);
            process = processManager.StartProcess(scrcpyPath, command, redirectOutput: true);
        }

       
        //フォルダーを開くメソッド
        public void OpenFolder()
        {
            

            // ディレクトリが存在するか確認し、存在しなければ作成
            if (!Directory.Exists(recPath))
            {
                Directory.CreateDirectory(recPath);
                Console.WriteLine("ビデオフォルダを作成しました: " + recPath);
            }

            // エクスプローラーでビデオフォルダを開く
            Process.Start("explorer.exe", recPath);
        }


      





    }
}
