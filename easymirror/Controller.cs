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
        private CustomDTO customDTO;
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


        public void GetEasyStart(MainProc mainProc, string deviceId)
        {
            this.mainProc = mainProc;
            this.deviceId = deviceId;

        }
        public void GetCustomStart(MainProc mainProc, string deviceId, CustomDTO customDTO)
        {
            this.mainProc = mainProc;
            this.deviceId = deviceId;
            this.customDTO = customDTO;

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
            avMuteButton.Enabled = false;
            this.deviceId = deviceId;


        }

        public void NoMirror()
        {

            var dialogResult = MessageBox.Show("現在画面を隠して起動しています。解除する場合はOKを押してください。",
                                               "確認",
                                               MessageBoxButtons.OK,
                                               MessageBoxIcon.Information,
                                               MessageBoxDefaultButton.Button1,
                                               MessageBoxOptions.DefaultDesktopOnly);
            if (dialogResult == DialogResult.OK)
            {
                if (recordFlag == true)
                {
                    ToggleRecordMode();
                }

                mainProc.StartScrcpy(deviceId);

                this.Show();
            }

        }





        //全画面表示
        private void FullscreenButtonClick(object sender, EventArgs e)
        {
            mainProc.StopScrcpy();
            ToggleFullscreenMode();

        }



        // コントローラーが閉じられるときにスタート画面に戻る
        private void ControllerFormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();

            mainProc.StopScrcpy();
            if (recordFlag == true)
            {
                MessageBox.Show("録画が終了しました。",
                                                "録画",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information,
                                                MessageBoxDefaultButton.Button1,
                                                MessageBoxOptions.DefaultDesktopOnly);

            }

        }




        private void ControllerKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && fullscreenFlag)
            {
                mainProc.StopScrcpy();
                ToggleFullscreenMode();
            }
        }




        //フォルダーを開く
        private void FolderButtonClick(object sender, EventArgs e)
        {

            mainProc.OpenFolder();

        }


        //スクリーンショット撮影
        private void ScreenshotButtonClick(object sender, EventArgs e)
        {

            mainProc.Screenshot(deviceId);
        }


        //録画開始ボタン
        private void RecordButtonClick(object sender, EventArgs e)
        {

            mainProc.StopScrcpy();
            ToggleRecordMode();

        }


        //録画機能の切り替えを処理する共有メソッド
        private void ToggleRecordMode()
        {
            this.Hide();


           

            if (recordFlag)
            {
                if(customDTO != null)
                {
                    mainProc.CustomStart(deviceId, customDTO);
                }
                else
                {
                    mainProc.StartScrcpy(deviceId); 

                }
               
                FullscreenButton.Enabled = true;
                CustomSettingButton.Enabled = true;
                avMuteButton.Enabled = true;
                recPicture.Visible = false;
                RecordButton.Text = "録画開始";
                MessageBox.Show("録画が停止されました", "録画停止", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);



            }
            else
            {
                if (customDTO != null)
                {
                    mainProc.CustomRecordStart(deviceId, customDTO);
                }
                else
                {
                    // Scrcpyで録画を開始
                    mainProc.Recording(deviceId);

                }
                
                
                FullscreenButton.Enabled = false;
                CustomSettingButton.Enabled = false;
                avMuteButton.Enabled = false;
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


            if (fullscreenFlag)
            {
                if (customDTO != null)
                {
                    customDTO.display = "";
                    mainProc.CustomStart(deviceId, customDTO);

                }
                else
                {
                    mainProc.StartScrcpy(deviceId); // 通常モードで再起動
                }



                RecordButton.Enabled = true;
                FullscreenButton.BackgroundImage = Properties.Resources.全画面アイコン;
                ToolTip.SetToolTip(FullscreenButton, "全画面表示");
                this.TopMost = false;


            }
            else
            {
                if (customDTO != null)
                {

                    customDTO.display = "-f";
                    mainProc.CustomStart(deviceId, customDTO);

                }
                else
                {
                    mainProc.FullScreen(deviceId); 
                }
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



        private void CustomSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomSettingWindow customSettingWindow = new CustomSettingWindow();

            customSettingWindow.GetControllerMainProc(mainProc, deviceId, isWirelessInitialized, this);

            customSettingWindow.ShowDialog();
           



        }

        private void av_muteButton_Click(object sender, EventArgs e)
        {
            mainProc.StopScrcpy();
            this.Hide();

            var dialogResult = MessageBox.Show("現在ミュート中です解除する場合はOKを押してください。",
                                                "ミュート",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information,
                                                MessageBoxDefaultButton.Button1,
                                                MessageBoxOptions.DefaultDesktopOnly);
            if (dialogResult == DialogResult.OK)
            {
                if (customDTO != null)
                {
                    mainProc.CustomStart(deviceId, customDTO);

                }
                else if (fullscreenFlag == true)
                {
                    fullscreenFlag = false;
                    ToggleFullscreenMode();
                }
                else
                {
                    mainProc.StartScrcpy(deviceId);
                }
                this.Show();
            }
        }
    }
}
