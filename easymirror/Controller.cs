using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace easymirror
{
    public partial class Controller : Form
    {
        private MainProc mainProc;
        private bool isWirelessInitialized = false;
        private string deviceId;
        private bool fullscreenFlag = false;
        private bool recordFlag = false;


        public Controller()
        {
            InitializeComponent();

            // KeyPreviewを有効にしてキーイベントを受け取る
            this.KeyPreview = true;

        }


        public void GetMainProc(MainProc mainProc, string deviceId, bool isWirelessInitialized)
        {
            this.mainProc = mainProc;
            this.deviceId = deviceId;
            this.isWirelessInitialized = isWirelessInitialized;

        }
        public void GetWirelessProc(WirelessManager wirelessProc, string ipAddress, bool isWirelessInitialized)
        {

            this.isWirelessInitialized = isWirelessInitialized;
            this.deviceId = ipAddress;

        }

        public void StartFull(string deviceId)
        {
            fullscreenFlag = true;
            FullscreenButton.BackgroundImage = Properties.Resources.縮小アイコン;
            ToolTip.SetToolTip(FullscreenButton, "縮小する");
            RecordButton.Enabled = false;
            this.TopMost = true;
            this.deviceId = deviceId;
        }


        //カスタムウィンドウから録画が開始されたときの処理
        public void StartRec(string deviceId)
        {
            recordFlag = true;
            CustomSettingButton.Enabled = false;
            RecordButton.Text = "録画停止";
            recPicture.Visible = true;
            FullscreenButton.Enabled = false;
            this.deviceId = deviceId;


        }





        //全画面表示
        private void FullscreenButtonClick(object sender, EventArgs e)
        {

            ToggleFullscreenMode();

        }



        // コントローラーが閉じられるときにスタート画面に戻る
        private void ControllerFormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();

            mainProc.StopScrcpy();





        }




        private void ControllerKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && fullscreenFlag)
            {
                ToggleFullscreenMode();
            }
        }




        //フォルダーを開く
        private void FolderButtonClick(object sender, EventArgs e)
        {

            mainProc.OpenFolder();

        }


        //スクリーンショット撮影
        private async void  ScreenshotButtonClick(object sender, EventArgs e)
        {

           await mainProc.ScreenshotAsync();
        }


        //録画開始ボタン
        private void RecordButtonClick(object sender, EventArgs e)
        {

            ToggleRecordMode();

        }


        //録画機能の切り替えを処理する共有メソッド
        private void ToggleRecordMode()
        {
            this.Hide();


            mainProc.StopScrcpy();





            if (recordFlag)
            {
                mainProc.StartScrcpy(deviceId); // 通常モードで再起動
                FullscreenButton.Enabled = true;
                CustomSettingButton.Enabled = true;
                recPicture.Visible = false;
                RecordButton.Text = "録画開始";
                MessageBox.Show("録画が停止されました", "録画停止", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);



            }
            else
            {
                // Scrcpyで録画を開始
                mainProc.Recording(deviceId);
                FullscreenButton.Enabled = false;
                CustomSettingButton.Enabled = false;
                recPicture.Visible = true;
                RecordButton.Text = "録画停止";
                MessageBox.Show("録画が開始されました ", "録画開始", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

            recordFlag = !recordFlag;
            Thread.Sleep(1000);
            this.Show();




        }


        // 全画面モード切り替えを処理する共通メソッド
        private void ToggleFullscreenMode()
        {
            this.Hide();


            mainProc.StopScrcpy();



            if (fullscreenFlag)
            {
                mainProc.StartScrcpy(deviceId); // 通常モードで再起動
                RecordButton.Enabled = true;
                FullscreenButton.BackgroundImage = Properties.Resources.全画面アイコン;
                ToolTip.SetToolTip(FullscreenButton, "全画面表示");
                this.TopMost = false;


            }
            else
            {
                mainProc.FullScreen(deviceId);
                RecordButton.Enabled = false;
                FullscreenButton.BackgroundImage = Properties.Resources.縮小アイコン;
                ToolTip.SetToolTip(FullscreenButton, "縮小する");
                this.TopMost = true;
            }

            FullscreenButton.BackgroundImageLayout = ImageLayout.Zoom;
            fullscreenFlag = !fullscreenFlag;

            Thread.Sleep(1000);
            this.Show();
        }

        private void SaveRewindRecording_Click(object sender, EventArgs e)
        {


            mainProc.SaveRewindRecorder();
        }

        private void CustomSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomSettingWindow customSettingWindow = new CustomSettingWindow();

            customSettingWindow.GetControllerMainProc(mainProc, deviceId, isWirelessInitialized, this);


            customSettingWindow.ShowDialog();


        }
    }
}
