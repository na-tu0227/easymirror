using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easymirror
{
    public partial class CustomSettingWindow : Form
    {
        private MainProc mainProc;
        private WirelessManager wirelessManager;
        private Controller controller;
        private DeviceManager deviceManager;
        private string deviceId, fps, bitrate, buffer, size, display, movie, audio;
        private bool isWirelessInitialized = false;
        private bool isMainWindowAccess;

        ErrorProvider errorProvider = new ErrorProvider();

        //コンストラクター
        public CustomSettingWindow()
        {

            controller = new Controller();
            mainProc = new MainProc();
            deviceManager = new DeviceManager(".\\scrcpy\\adb.exe");  // adbパスを適宜指定
            // アイコンを点滅なしに設定する
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            InitializeComponent();
        }


        //MainwindowからFlagを取得
        public void MainwindowFlag(bool isMainWindowAcces)
        {
            this.isMainWindowAccess = isMainWindowAcces;
        }


        //MainProcからプロセスを取得
        public void GetControllerMainProc(MainProc mainproc, String deviceId, bool isWirelessInitialized, Controller controller)
        {
            this.controller = controller;
            this.mainProc = mainproc;
            this.deviceId = deviceId;
            this.isWirelessInitialized = isWirelessInitialized;
            WirelessKillButton.Enabled = isWirelessInitialized;


        }

        //コントローラーの情報からWirelessProcプロセスを取得
        public void GetControllerWirelessProc(WirelessManager wirelessproc, String ipAdress, bool isWirelessInitialized, Controller controller)
        {
            this.controller = controller;
            this.wirelessManager = wirelessproc;
            deviceId = ipAdress;
            this.isWirelessInitialized = isWirelessInitialized;
            WirelessKillButton.Enabled = isWirelessInitialized;
        }

        //Windowが開いた時の処理（コンストラクターとは別）
        //初期値の格納に使用
        private void CustomSettingWindow_Load(object sender, EventArgs e)
        {
            fps = "60";
            bitrate = "8M";
            size = "1024";
            buffer = "--display-buffer=0";
            display = "";
            movieCodec.SelectedIndex = 0;
            audioCodec.SelectedIndex = 0;

            if (isWirelessInitialized)
            {
                WirelessKillButton.Enabled = true;
                WirelessButton.Checked = true;
                WirelessButton.Enabled = false;
            }



        }



        //Windowの閉じる処理
        private void CustomSettingWindow_FormClosing(object sender, FormClosingEventArgs e)
        {



            if (isMainWindowAccess)
            {
                // メインウィンドウからアクセスされた場合はメインウィンドウを表示
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                isMainWindowAccess = false;
            }
            else
            {
                controller.GetMainProc(mainProc, deviceId, isWirelessInitialized);


                controller.Show();

            }
        }


        //テキストが切り替えられた時の処理
        private void maxFps_Leave(object sender, EventArgs e)
        {
            ConfirmMaxfpsInput();

        }

        private void maxBitrate_Leave(object sender, EventArgs e)
        {
            ConfirmMaxBitrateInput();

        }
        private void videoBuffer_Leave(object sender, EventArgs e)
        {
            ConfirmMaxVideoBufferInput();

        }
        private void sizeParam_Leave(object sender, EventArgs e)
        {
            ConfirmSizeParamInput();
        }



        //数値入力関連の処理
        //最大FPS
        private string ConfirmMaxfpsInput()
        {
            if (int.TryParse(maxFps.Text, out int castFps))
            {
                // 許容範囲外の場合エラーメッセージを表示
                if (castFps == 0)
                {
                    fps = "60";
                    errorProvider.SetError(maxFps, "");
                    maxFps.BackColor = Color.White;

                    return fps;

                }
                if (castFps > 120)
                {

                    maxFps.Text = "0"; // デフォルトの値に戻す
                    fps = "60";

                    maxFps.SelectionStart = maxFps.Text.Length;
                    errorProvider.SetError(maxFps, "規定内の数値を入力してください");
                    maxFps.BackColor = Color.LightPink;
                    return fps;
                }
                else
                {

                    fps = maxFps.Text;
                    errorProvider.SetError(maxFps, "");
                    maxFps.BackColor = Color.White;
                    return fps;
                }

            }
            return "";

        }

        //最大ビットレート
        private string ConfirmMaxBitrateInput()
        {

            if (int.TryParse(maxBitrate.Text, out int castBitrate))
            {

                if (castBitrate == 0)
                {
                    bitrate = "8M";
                    errorProvider.SetError(maxBitrate, "");
                    maxBitrate.BackColor = Color.White;

                    return bitrate;

                }
                if (castBitrate > 40)
                {

                    maxBitrate.Text = "0"; // デフォルトの値に戻す
                    bitrate = "8M";

                    maxBitrate.SelectionStart = maxBitrate.Text.Length;
                    errorProvider.SetError(maxBitrate, "規定内の数値を入力してください");
                    maxBitrate.BackColor = Color.LightPink;

                    return bitrate;

                }
                else
                {
                    // 許容範囲内の数値の場合にbitrateを設定
                    bitrate = castBitrate + "M";
                    errorProvider.SetError(maxBitrate, "");
                    maxBitrate.BackColor = Color.White;

                    return bitrate;
                }
            }
            return "";

        }


        //ビデオバッファ
        private string ConfirmMaxVideoBufferInput()
        {
            if (int.TryParse(videoBuffer.Text, out int castBuffer))
            {

                if (castBuffer == 0)
                {
                    buffer = "--display-buffer=0";
                    errorProvider.SetError(videoBuffer, "");
                    videoBuffer.BackColor = Color.White;
                    return buffer;

                }
                if (castBuffer > 10000)
                {

                    videoBuffer.Text = "0"; // デフォルトの値に戻す
                    buffer = "--display-buffer=0";

                    videoBuffer.SelectionStart = videoBuffer.Text.Length;
                    errorProvider.SetError(videoBuffer, "規定内の数値を入力してください");
                    videoBuffer.BackColor = Color.LightPink;
                    return buffer;

                }
                else
                {
                    // 許容範囲内の数値の場合にbitrateを設定
                    buffer = "--display-buffer=" + castBuffer;
                    errorProvider.SetError(videoBuffer, "");
                    videoBuffer.BackColor = Color.White;
                    return buffer;
                }

            }
            return "";

        }

        //画面サイズ（テキスト指定）
        private string ConfirmSizeParamInput()
        {
            if (int.TryParse(sizeParam.Text, out int castSize))
            {
                // 許容範囲外の場合エラーメッセージを表示
                if (castSize == 0)
                {
                    size = "1024";
                    errorProvider.SetError(sizeParam, "");
                    sizeParam.BackColor = Color.White;

                    return size;

                }
                if (castSize > 10000)
                {

                    sizeParam.Text = "0"; // デフォルトの値に戻す
                    size = "1024";

                    sizeParam.SelectionStart = sizeParam.Text.Length;
                    errorProvider.SetError(sizeParam, "規定内の数値を入力してください");
                    sizeParam.BackColor = Color.LightPink;
                    return size;

                }
                else
                {
                    // 許容範囲内の数値の場合にbitrateを設定
                    size = sizeParam.Text;
                    errorProvider.SetError(sizeParam, "");
                    sizeParam.BackColor = Color.White;
                    return size;
                }

            }
            return "";

        }

        private void WirelessKill_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("無線接続を切断しますか？（スマートフォンの映像も切断されます。）",
                                               "無線接続の切断",
                                               MessageBoxButtons.OKCancel,
                                               MessageBoxIcon.Information,
                                               MessageBoxDefaultButton.Button1,
                                               MessageBoxOptions.DefaultDesktopOnly);

            if (dialogResult == DialogResult.OK)
            {
                wirelessManager.WirelessDisconnect(deviceId);
                WirelessKillButton.Enabled = false;
                WirelessButton.Enabled = true;
                WirelessButton.Checked = false;
                wirelessManager = null;
                isWirelessInitialized = false; // WirelessKill時に再初期化フラグをリセット
                MessageBox.Show("無線接続を切断しました", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }



        //映像、音声関連の処理
        //コンボボックスからのデータ取得処理
        private void selectConboBox()
        {
            switch (movieCodec.SelectedIndex)
            {
                case 0:
                    movie = "h264";
                    break;
                case 1:
                    movie = "h265";
                    break;


            }

            switch (audioCodec.SelectedIndex)
            {
                case 0:
                    audio = "aac";
                    break;
                case 1:
                    audio = "opus;";
                    break;

                case 2:
                    audio = "noaudio";
                    break;

            }


        }




        //画面サイズの指定
        private void MaxWindowButton_CheckedChanged(object sender, EventArgs e)
        {
            if (maxWindowButton.Checked)
            {
                sizeParam.Enabled = true;
            }
            else
            {
                sizeParam.Text = "0";
                sizeParam.Enabled = false;
            }


        }



        //画面サイズグループのチェック処理
        private string sizeGroupproc()
        {
            if (defaultSizeButton.Checked)
            {
                size = "1024";
                return size;

            }
            else if (fullScreenButton.Checked)
            {
                display = "-f";
                return display;

            }
            else if (noMirrorButton.Checked)
            {
                display = "-Nr";
                return display;
            }
            return size;
        }










        //各種テキストボックスの入力判定
        private void TxNumOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                return;
            }
            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                e.Handled = true;
            }


        }
        private void Tx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmMaxBitrateInput();
                ConfirmMaxfpsInput();
                ConfirmMaxVideoBufferInput();
                ConfirmSizeParamInput();
            }
        }



        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            controller.Hide();

            // サイズとエンコード設定の取得
            sizeGroupproc();
            selectConboBox();

            MessageBox.Show("USB接続を行いデバッグモードを有効にしてください。", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            // 複数デバイスが接続されている場合、選択フォームを表示
            var devices = deviceManager.ListDeviceDetails();
            deviceId = deviceManager.ShowDeviceSelectionForm();
            //無線ボタンにチェックが入っているか
            if (WirelessButton.Checked && deviceManager.DeviceConnected() && !string.IsNullOrEmpty(deviceId))
            {
                //無線での初回起動の条件分岐
                if (!isWirelessInitialized)
                {
                    mainProc?.StopScrcpy();
                    mainProc?.AdbRestart();
                    wirelessManager = new WirelessManager();

                    // 初回IPアドレス取得
                    deviceId = wirelessManager.GetIPAddressADB(deviceId);
                    isWirelessInitialized = true;




                    if (CustomRecordButton.Checked)
                    {
                        mainProc.StartRecordWireless(deviceId, fps, bitrate, buffer, size, display, movie, audio);
                        controller.StartRec(deviceId);

                    }
                    else
                    {
                        mainProc.StartWireless(deviceId, fps, bitrate, buffer, size, display, movie, audio);

                    }
                    controller.GetMainProc(mainProc, deviceId, isWirelessInitialized);
                    controller.Show();

                }
                else
                {
                    if (mainProc != null)
                    {
                        mainProc.StopScrcpy();
                    }

                    // 無線接続が既に起動されている場合は、設定の再起動のみを行う
                    if (CustomRecordButton.Checked)
                    {

                        mainProc.CustomRecordStart(deviceId, fps, bitrate, buffer, size, display, movie, audio);
                        controller.StartRec(deviceId);
                    }
                    else
                    {

                        mainProc.CustomStart(deviceId, fps, bitrate, buffer, size, display, movie, audio);

                    }
                    if (display.Equals("-f"))
                    {
                        controller.StartFull(deviceId);
                    }

                    controller.GetMainProc(mainProc, deviceId, isWirelessInitialized);
                    controller.Show();
                }
            }

            //有線接続
            else if (deviceManager.DeviceConnected() && !string.IsNullOrEmpty(deviceId))
            {

                mainProc?.StopScrcpy();
                mainProc?.AdbRestart();



                mainProc = new MainProc();
                //deviceManagerでデバイスIdを取得し実行。
                //Scrcpyとリモコンが表示される

                //録画にチェックが入っていれば
                if (CustomRecordButton.Checked)
                {

                    mainProc.CustomRecordStart(deviceId, fps, bitrate, buffer, size, display, movie, audio);
                    controller.StartRec(deviceId);


                }

                else
                {
                    mainProc.CustomStart(deviceId, fps, bitrate, buffer, size, display, movie, audio);

                }
                controller.GetMainProc(mainProc, deviceId, isWirelessInitialized);  // MainProcとデバイスIdをControllerに渡す
                if (display.Equals("-f"))
                {
                    controller.StartFull(deviceId);
                }

                controller.Show();
            }


            else if (string.IsNullOrEmpty(deviceId))
            {
                MessageBox.Show("スマートフォンが接続されていないか、デバッグモードが有効ではありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();

            }
            else
            {
                MessageBox.Show("スマートフォンが接続されていないか、デバッグモードが有効ではありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }

        }






        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}
