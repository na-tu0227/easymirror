using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easymirror
{
    public class MainDTO
    {
       public string scrcpyPath {  get; set; }  
       public string adbPath { get; set; }
       public string recPath { get; set; }
       public string jsonPath { get; set; }
        public MainDTO() { 
            scrcpyPath = ".\\scrcpy\\scrcpy.exe";
            adbPath = ".\\scrcpy\\adb.exe";
            recPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos) + "\\easymirror";
            jsonPath = ".\\CommandList.json";
        }
    }
}
