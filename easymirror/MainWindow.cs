using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easymirror
{
    public partial class MainWindow : Form
    {
        private MainProc mainProc;
        private Controller controller;
        private DeviceManager deviceManager;
        private bool isWirelessInitialized;


        //コンストラクター
        public MainWindow()
        {
            InitializeComponent();
            mainProc = new MainProc();
            controller = new Controller();
            deviceManager = new DeviceManager();  // adbパスを適宜指定
        }


        //Mainwindowが終了したらアプリ全体を落とす
        private void MainWindowFormClosing(object sender, FormClosingEventArgs e)
        {
            mainProc.AdbStop();
            Environment.Exit(0);
        }


        
        private  void StartButtonClick(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("USB接続を行いデバッグモードを有効にしてください。", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            // 複数デバイスが接続されている場合、選択フォームを表示
            var devices = deviceManager.ListDeviceDetails();
            string deviceId = deviceManager.ShowDeviceSelectionForm(); // デバイス選択フォームの表示

       
            if (deviceManager.DeviceConnected() && !string.IsNullOrEmpty(deviceId))
            {
                //deviceManagerでデバイスIdを取得し実行。
                //Scrcpyとリモコンが表示される
                 mainProc.StartScrcpy(deviceId);
                controller.GetEasyStart(mainProc, deviceId);  // MainProcとデバイスIdをControllerに渡す
          
                controller.Show();
            }
            
            //デバイスIdが取得されていなければMainwindowを表示する。
            else if(string.IsNullOrEmpty(deviceId))
            {
                //接続されていなかった場合はMainwindowに戻す。
                MessageBox.Show("スマートフォンが接続されていないか、デバッグモードが有効ではありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();

            }
            else
            {
                //接続されていなかった場合はMainwindowに戻す。
                MessageBox.Show("スマートフォンが接続されていないか、デバッグモードが有効ではありません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }


        //録画の保存場所を開く
        private void FolderButtonClick(object sender, EventArgs e)
        {
            mainProc.OpenFolder();
        }

        //カスタム設定を開く
        private void CustomSettingButton_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            CustomSettingWindow customSettingWindow = new CustomSettingWindow();
            bool MainWindowFlag = true;
            customSettingWindow.MainwindowFlag(MainWindowFlag, isWirelessInitialized);
            customSettingWindow.Show();

        }

        public void getWirelessInitialized(bool isWirelessInitialized)
        {
            this.isWirelessInitialized = isWirelessInitialized;
        }



    }
}
