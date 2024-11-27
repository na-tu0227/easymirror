using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace easymirror
{
    public class DeviceManager
    {
        private readonly ProcessManager processManager;
        private  string adbPath = ".\\scrcpy\\adb.exe";

        public DeviceManager()
        {
            processManager = new ProcessManager();
        }

        // デバイスが接続されているか確認するメソッド
        public bool DeviceConnected()
        {
            Process adbProcess = null;
            try
            {
                // adbプロセスを生成
                adbProcess = processManager.StartProcess(adbPath, "devices", redirectOutput: true);

                // 結果を取得
                string output = adbProcess.StandardOutput.ReadToEnd();
                adbProcess.WaitForExit();

                // 接続デバイスが存在するか確認
                return output.Split('\n').Any(line => line.Trim().EndsWith("device"));
            }
            catch (Exception ex)
            {
                //失敗したらfalseを返す
                MessageBox.Show($"ADBコマンドの実行に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //adbの停止
                processManager.StartProcess(adbPath, "kill-server");
                return false;
            }
        }

        // デバイスIDとデバイス名を取得
        public List<(string id, string name)> ListDeviceDetails()
        {
            //リストの生成
            List<(string id, string name)> deviceDetails = new List<(string id, string name)>();
            Process adbProcess = null;
            try
            {
                //adbプロセスの生成
                adbProcess = processManager.StartProcess(adbPath, "devices", redirectOutput: true);
                //adbの実行結果を変数に格納
                string output = adbProcess.StandardOutput.ReadToEnd();
                adbProcess.WaitForExit();

                //Listに格納する処理
                var lines = output.Split('\n').Skip(1); // 最初の行をスキップ
                foreach (string line in lines)
                {
                    var columns = line.Split('\t');

                    if (columns.Length > 1 && columns[1].Trim() == "device")
                    {
                        string deviceId = columns[0].Trim();
                        string deviceName = GetDeviceName(deviceId);
                        deviceDetails.Add((deviceId, deviceName));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"デバイス情報の取得に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //adbの停止
                processManager.StartProcess(adbPath, "kill-server");
            }
            return deviceDetails;
        }

        // 指定されたデバイスIDのデバイス名を取得
        private string GetDeviceName(string deviceId)
        {
            Process adbProcess = null;
            try
            {
                adbProcess = processManager.StartProcess(adbPath, $"-s {deviceId} shell getprop ro.product.model", redirectOutput: true);
                string output = adbProcess.StandardOutput.ReadToEnd().Trim();
                adbProcess.WaitForExit();
                return output;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"デバイス名の取得に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //adbの停止
                processManager.StartProcess(adbPath, "kill-server");
                return "Unknown Device";
            }
        }

        // デバイスを選択するUI表示メソッド
        public string ShowDeviceSelectionForm()
        {
            //作成したListを生成
            List<(string id, string name)> devices = ListDeviceDetails();
            string getId = null;

            if (devices.Count > 1)
            {
                //Formを表示
                Form deviceSelectionForm = new Form();
                deviceSelectionForm.Text = "デバイス選択";
                FlowLayoutPanel panel = new FlowLayoutPanel() { Dock = DockStyle.Fill };

                //接続されているデバイスが表示されトグルボタンで選択する
                foreach (var device in devices)
                {
                    RadioButton toggleButton = new RadioButton()
                    {
                        Text = $"{device.name} ({device.id})",
                        AutoSize = true
                    };
                    toggleButton.CheckedChanged += (s, e) =>
                    {
                        //選択された端末idを格納
                        if (toggleButton.Checked)
                        {
                            MessageBox.Show($"{device.name} ({device.id}) が選択されました", "デバイス選択", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getId = device.id;
                            deviceSelectionForm.Close();
                        }
                    };
                    panel.Controls.Add(toggleButton);
                }

                deviceSelectionForm.Controls.Add(panel);

                // Formが閉じられたときの処理
                deviceSelectionForm.FormClosing += (s, e) =>
                {
                    //getIdの中身が空なら
                    if (string.IsNullOrEmpty(getId))
                    {
                        MessageBox.Show("デバイスが選択されませんでした。", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };

                deviceSelectionForm.ShowDialog();
                //端末Idを返す
                return getId;
            }
            //端末数が1個のときの処理
            else if (devices.Count == 1)
            {
                var device = devices[0];
                getId = device.id;
                return device.id;
            }
            //端末が無いとき
            else
            {   
                return null;
            }
        }
    }
}
