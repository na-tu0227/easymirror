using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Linq;
using System.Windows.Forms;

namespace easymirror
{
    //jsonファイルに格納しているコマンドを取得するプログラム
    public class CommandList
    {
        //jsonファイルの中身を取得してDictionaryに格納する
        public static Dictionary<string, string> ReadJson(string jsonPath)
        {
            if (!File.Exists(jsonPath))
            {
                return new Dictionary<string, string>();
            }
            try
            {
                // ファイル内容を読み込んでから、リスト形式としてデシリアライズ
                string jsonContent = File.ReadAllText(jsonPath);
                var list = JsonSerializer.Deserialize<List<List<string>>>(jsonContent, GetOption());

                // List<List<string>>からDictionary<string, string>に変換
                var dict = new Dictionary<string, string>();
                foreach (var pair in list)
                {
                    if (pair.Count == 2)
                    {
                        dict[pair[0]] = pair[1];
                    }
                }
                return dict;
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message);
                return new Dictionary<string, string>();
            }
        }

        //文字コードを統一するメソッド
        private static JsonSerializerOptions GetOption()
        {
            // ユニコードのレンジ指定で日本語も正しく表示、インデントされるように指定
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            return options;
        }

        public Dictionary<string, string> Commandget(string jsonPath)
        {
            var dict = ReadJson(jsonPath);
            return dict;
        }

        //コマンドの実行文を作成する。
        public string BuildCommand(Dictionary<string, string> commandDict, params string[] commandParts)
        {

            return string.Join(" ", commandParts.Select(part => commandDict.ContainsKey(part) ? commandDict[part] : part));

        }

    }
}
