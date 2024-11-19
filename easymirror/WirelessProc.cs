using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easymirror
{
    public class WirelessProc
    {
        Process process;
        private readonly ProcessManager processManager;
        private readonly Dictionary<string, string> commandDict;
        private CommandList commandList;
      


        private String adbPath = ".\\scrcpy\\adb.exe";
        private String scrcpyPath = ".\\scrcpy\\scrcpy.exe";
        private String jsonPath = ".\\CommandList.json";




        public WirelessProc()
        {
            processManager = new ProcessManager();
            commandList = new CommandList();
            commandDict = commandList.Commandget(jsonPath);



        }

        public string GetIPAddressADB(string deviceId)
        {
            // ADBコマンドで無線LANインターフェース(wlan0)の情報を取得
            string adbOutput = processManager.StartWireless(adbPath, $"-s \"{deviceId}\" shell ip addr show wlan0");

            // 正規表現でIPアドレスを抽出
            Regex ipRegex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            MatchCollection matches = ipRegex.Matches(adbOutput);


            // 最初の有効なIPアドレスを返す
            foreach (Match match in matches)
            {
                string ipAddress = match.Value;
                if (!ipAddress.StartsWith("127"))  // ローカルループバックアドレスを除外
                {
                    return ipAddress;
                }
            }

            return null;
        }


        //端末と接続するメソッド
        private void ConnectTarget(string ipAddress)
        {

            //無線接続の準備(TCP/IPポートの開放、Ipアドレスに紐づけ)
            processManager.StartProcess(adbPath, $"tcpip 5555", redirectOutput: true);
            processManager.StartProcess(adbPath, $"connect \"{ipAddress}\":5555", redirectOutput: true);



        }

        //無線接続を開始するメソッド
        //public void WirelessStart(string deiceId)
        //{
        //    string ipAddress = GetIPAddressADB(deiceId);
        //    ConnectTarget(ipAddress);
        //    // USBを抜くようにユーザーに指示するメッセージボックスを表示
        //    var dialogResult = MessageBox.Show("無線接続の準備が整いました。USBケーブルを抜いてください。",
        //                                        "USBを抜いてください",
        //                                        MessageBoxButtons.OK,
        //                                        MessageBoxIcon.Information,
        //                                        MessageBoxDefaultButton.Button1,
        //                                        MessageBoxOptions.DefaultDesktopOnly);


        //    //接続するプロセスを起動
        //    if (dialogResult == DialogResult.OK)
        //    {
        //        string commnad = commandList.BuildCommand(commandDict, "serial", ipAddress, "start");
        //        process=processManager.StartProcess(scrcpyPath, commnad, redirectOutput: true);

        //    }
        //    wirelessflag = true;
        //    this.ipAddress = ipAddress;
           
        //}

        public void CustomWirelessStart(string deviceId, string fps, string bitrate, string buffer,string size,string display,string movie, string audio)
        { 
            ConnectTarget(deviceId);

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
                string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start", display, "max-fps", fps, "bitrate", bitrate, buffer, movie, audio);
                process=processManager.StartProcess(scrcpyPath, command, redirectOutput: true);

            }
            
         
            
            


        }

        public void CustomRecordWirelessStart(string deviceId, string fps, string bitrate, string buffer, string size, string display, string movie, string audio)
        {
            ConnectTarget(deviceId);

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
                MainProc mainProc = new MainProc();
                string recPath = mainProc.CreateRecPath();
                mainProc = null;
                
                string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start", display, "max-fps", fps, "bitrate", bitrate, buffer, movie, audio, "record", recPath);
                process=processManager.StartProcess(scrcpyPath, command, redirectOutput: true);

            }
            
            
           



        }

        public void CustomWirelessReStart(string deviceId, string fps, string bitrate, string buffer, string size, string display, string movie, string audio)
        {
            WirelessStop();
            string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start", display, "max-fps", fps, "bitrate", bitrate, buffer, movie, audio);
            process = processManager.StartProcess(scrcpyPath, command, redirectOutput: true);

        }
        public void CustomRecordWirelessReStart(string deviceId, string fps, string bitrate, string buffer, string size, string display, string movie, string audio)
        {
            WirelessStop();
            MainProc mainProc = new MainProc();
            string recPath = mainProc.CreateRecPath();
            mainProc = null;

            string command = commandList.BuildCommand(commandDict, "serial", deviceId, "start", display, "max-fps", fps, "bitrate", bitrate, buffer, movie, audio, "record", recPath);
            process = processManager.StartProcess(scrcpyPath, command, redirectOutput: true);

        }

        //無線接続された最初のscrcpyの画面を止めるメソッド
        //画面を終了させたらmainProcにipAddressを渡す。
        public void WirelessStop()
        {
            processManager.StopProcess(process);


        }

        public void WirelessDisconnect(string deviceId)
        {
            processManager.StartProcess(adbPath, "disconnect", redirectOutput: true);
        }


    }
}
