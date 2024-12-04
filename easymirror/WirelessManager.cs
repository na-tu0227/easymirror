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
    public class WirelessManager
    {
        private readonly ProcessManager processManager;
        private readonly Dictionary<string, string> commandDict;
        private CommandList commandList;
      


        private String adbPath = ".\\scrcpy\\adb.exe";
        //private String scrcpyPath = ".\\scrcpy\\scrcpy.exe";
        private String jsonPath = ".\\CommandList.json";




        public WirelessManager()
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
        public void ConnectTarget(string ipAddress)
        {

            //無線接続の準備(TCP/IPポートの開放、Ipアドレスに紐づけ)
            processManager.StartProcess(adbPath, $"tcpip 5555", redirectOutput: true);
            processManager.StartProcess(adbPath, $"connect \"{ipAddress}\":5555", redirectOutput: true);



        }

        

        public void WirelessDisconnect(string deviceId)
        {
            processManager.StartProcess(adbPath, "disconnect", redirectOutput: true);
        }


    }
}
