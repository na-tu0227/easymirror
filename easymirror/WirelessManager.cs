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
        private MainDTO mainDTO;
        private CommandList commandList;
      




        public WirelessManager()
        {
            mainDTO = new MainDTO();
            processManager = new ProcessManager();
            commandList = new CommandList();
            commandDict = commandList.Commandget(mainDTO.jsonPath);



        }

        public string GetIPAddressADB(string deviceId)
        {
            // ADBコマンドで無線LANインターフェース(wlan0)の情報を取得
            string adbOutput = processManager.StartWireless(mainDTO.adbPath, $"-s \"{deviceId}\" shell ip addr show wlan0");

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
            processManager.StartProcess(mainDTO.adbPath, $"tcpip 5555", redirectOutput: true);
            processManager.StartProcess(mainDTO.adbPath, $"connect \"{ipAddress}\":5555", redirectOutput: true);



        }

        

        public void WirelessDisconnect(string deviceId)
        {
            processManager.StartProcess(mainDTO.adbPath, "disconnect", redirectOutput: true);
        }


    }
}
