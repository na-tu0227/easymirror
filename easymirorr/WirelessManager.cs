//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//namespace ScrcpyApp
//{

//    public class WirelessManager
//    {
//        private readonly ProcessManager processManager;
//        private readonly string adbPath;
//        private readonly string scrcpyPath;

//        //adb.exeのパス参照
//        public WirelessManager(string adbPath, string scrcpyPath)
//        {
//            this.processManager = new ProcessManager();
//            this.adbPath = adbPath;
//            this.scrcpyPath = scrcpyPath;
//        }

//        public string GetIPAddressFromADB()
//        {
//            // ADBコマンドで無線LANインターフェース(wlan0)の情報を取得
//            string adbOutput = processManager.StartWireless(adbPath, "shell ip addr show wlan0");

//            // 正規表現でIPアドレスを抽出
//            Regex ipRegex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
//            MatchCollection matches = ipRegex.Matches(adbOutput);


//            // 最初の有効なIPアドレスを返す
//            foreach (Match match in matches)
//            {
//                string ipAddress = match.Value;
//                if (!ipAddress.StartsWith("127"))  // ローカルループバックアドレスを除外
//                {
//                    return ipAddress;
//                }
//            }

//            return "IPアドレスが見つかりません";
//        }
//        public void ConnectTarget(string ipAddress)
//        {


//            processManager.StartProcess(adbPath, $"tcpip 5555", redirectOutput: true);
//            processManager.StartProcess(adbPath, $"connect \"{ipAddress}\":5555", redirectOutput: true);

//            // USBを抜くようにユーザーに指示するメッセージボックスを表示
//            var dialogResult = MessageBox.Show("無線接続の準備が整いました。USBケーブルを抜いてください。",
//                                                "USBを抜いてください",
//                                                MessageBoxButtons.OK,
//                                                MessageBoxIcon.Information,
//                                                MessageBoxDefaultButton.Button1,
//                                                MessageBoxOptions.DefaultDesktopOnly);

//            if (dialogResult == DialogResult.OK)
//            {
//                var process = processManager.StartProcess(scrcpyPath, $"-s\"{ipAddress}\" --window-title=MirrorApp", redirectOutput: true);
               
//            }

//        }
//    }
//}

