﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easymirror
{
    public class MainProc
    {

        private readonly ProcessManager processManager;
        private readonly WirelessManager wirelessManager;
        private Dictionary<string, string> commandDict;
        //private RewindRecorder rewindRecorder;
        private Process process;
        private MainDTO mainDTO;
        private CustomDTO customDTO;
        private CommandList commandList;


        public MainProc()
        {
            processManager = new ProcessManager();
            wirelessManager = new WirelessManager();
            commandList = new CommandList();
            mainDTO = new MainDTO();
            commandDict = commandList.Commandget(mainDTO.jsonPath);
            //rewindRecorder = new RewindRecorder(scrcpyPath, commandDict);

            // 保存用フォルダがない場合は作成
            if (!Directory.Exists(mainDTO.recPath))
            {
                Directory.CreateDirectory(mainDTO.recPath);
            }

        }

        // Scrcpyを起動
        public void StartScrcpy(string deviceId)
        {

            string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start");
            process = processManager.StartProcess(mainDTO.scrcpyPath, command, redirectOutput: true);
        }

        // Scrcpyを停止
        public void StopScrcpy()
        {

            processManager.StopProcess(process);

        }

        public void StartWireless(string deviceId, CustomDTO customDTO)
        {
            this.customDTO = customDTO;
            wirelessManager.ConnectTarget(deviceId);

            // USBを抜くようにユーザーに指示するメッセージボックスを表示
            var dialogResult = MessageBox.Show("無線接続の準備が整いました。USBケーブルを抜いてください。",
                                                "USBを抜いてください",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information,
                                                MessageBoxDefaultButton.Button1,
                                                MessageBoxOptions.DefaultDesktopOnly);


            //接続するプロセスを起動
            if (dialogResult == DialogResult.OK)
            {
                string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start", customDTO.display, "max-fps", customDTO.fps, "bitrate", customDTO.bitrate, customDTO.buffer, customDTO.movie, customDTO.audio);
                process = processManager.StartProcess(mainDTO.scrcpyPath, command, redirectOutput: true);
                

            }

        }
        public void StartRecordWireless(string deviceId, CustomDTO customDTO)
        {
            this.customDTO = customDTO;
            wirelessManager.ConnectTarget(deviceId);
            // USBを抜くようにユーザーに指示するメッセージボックスを表示
            var dialogResult = MessageBox.Show("無線接続の準備が整いました。USBケーブルを抜いてください。",
                                                "USBを抜いてください",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information,
                                                MessageBoxDefaultButton.Button1,
                                                MessageBoxOptions.DefaultDesktopOnly);
            string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start", customDTO.display, "max-fps", customDTO.fps, "bitrate", customDTO.bitrate, customDTO.buffer, customDTO.movie, customDTO.audio);
            process = processManager.StartProcess(mainDTO.scrcpyPath, command, redirectOutput: true);

        }




        public string CreateRecPath()
        {
            // 現在の日時でファイル名を作成
            string fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".mp4";
            string filePath = Path.Combine(mainDTO.recPath, fileName);

            return filePath;
        }



        // Scrcpyを全画面表示
        public void FullScreen(string deviceId)
        {
            string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start", "fullscreen");
            process = processManager.StartProcess(mainDTO.scrcpyPath, command, redirectOutput: true);
            processManager.LogMessage("start:fullscreen");
        }

        // 録画を開始
        public void Recording(string deviceId)
        {
            string recPath = CreateRecPath();
            string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start", "aac", "record", recPath);
            process = processManager.StartProcess(mainDTO.scrcpyPath, command, redirectOutput: true);
            processManager.LogMessage("start:Recording");
        }

        ////巻き戻し録画
        //public async void RewindRecorder()
        //{

        //    //await rewindRecorder.StartRecordingAsync();

        //}

        //public async void SaveRewindRecorder()
        //{
        //    // 現在の日時でファイル名を作成
        //    string fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".mp4";
        //    string filePath = Path.Combine(mainDTO.recPath, fileName);
        //    //await rewindRecorder.SaveBufferedRecordingAsync(filePath);
        //}
        

        public void Screenshot(string deviceId)
        {
            
            Process ssProcess = null;
            processManager.LogMessage("screenshotwait...");
            try
            {
                // ADBコマンドを実行してスクリーンショットを取得
                string adbCommand = commandList.BuildCommand( commandDict,"-s", deviceId,"screen-shot");

                ssProcess = processManager.StartProcess(mainDTO.adbPath, adbCommand, redirectOutput: true);

                // スクリーンショットの保存フォルダーとファイルパスを設定
               
                string ssFileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".png";
                string ssPath = Path.Combine(mainDTO.recPath, ssFileName);

                // バイナリデータをファイルに保存
                using (var memoryStream = new MemoryStream())
                {
                    ssProcess.StandardOutput.BaseStream.CopyTo(memoryStream);
                    File.WriteAllBytes(ssPath, memoryStream.ToArray());
                }

                // ログ出力
                MessageBox.Show(
                    $"スクリーンショットが保存されました: {Path.GetFileName(ssPath)}",
                    "確認",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1
                );
                processManager.LogMessage("success:screenshot");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"スクリーンショットの保存に失敗しました: {ex.Message}",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    
                );
                processManager.LogError("error:screenshot");
            }
            finally
            {
                ssProcess?.Dispose();
            }

        }







        // ADB再起動
        public void AdbStop()
        {
            string command = commandList.BuildCommand(commandDict, "adbstop");
            processManager.StartProcess(mainDTO.adbPath, command, redirectOutput: true);
            processManager.LogMessage("restart:adb");
        }



        //カスタマイズ設定からの起動
        public void CustomStart(string deviceId, CustomDTO customDTO)
        {
            this.customDTO = customDTO;
            string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start", customDTO.display, "max-fps", customDTO.fps, "bitrate", customDTO.bitrate, customDTO.buffer, customDTO.movie, customDTO.audio);
            process = processManager.StartProcess(mainDTO.scrcpyPath, command, redirectOutput: true);
            processManager.LogMessage("start:custom");

        }

        public void CustomRecordStart(string deviceId, CustomDTO customDTO)
        {
            this.customDTO = customDTO;
            String recPath = CreateRecPath();
            string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start", customDTO.display, "max-fps", customDTO.fps, "bitrate", customDTO.bitrate, customDTO.buffer, customDTO.movie, customDTO.audio, "record", recPath);
            process = processManager.StartProcess(mainDTO.scrcpyPath, command, redirectOutput: true);
            processManager.LogMessage("start:customrecord");
        }

        


        //フォルダーを開くメソッド
        public void OpenFolder()
        {

            // エクスプローラーでビデオフォルダを開く
            Process.Start("explorer.exe", mainDTO.recPath);
        }








    }
}
