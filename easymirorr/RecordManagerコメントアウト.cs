//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ScrcpyApp
//{
//    //録画機能の処理
//    public class RecordManager
//    {
//        //プロセスの開始
//        public Process StartRecord(string filePath, string arguments = "", bool redirectOutput = false, bool createNoWindow = true)
//        {

//            Process process = new Process
//            {
//                StartInfo = new ProcessStartInfo
//                {
//                    FileName = filePath,
//                    Arguments = arguments,
//                    UseShellExecute = !redirectOutput,
//                    RedirectStandardOutput = redirectOutput,
//                    RedirectStandardError = redirectOutput,
//                    CreateNoWindow = createNoWindow
//                }
//            };

//            process.Start();
//            return process;
//        }
//    }
//}
