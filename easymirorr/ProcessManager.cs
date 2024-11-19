using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace easymirorr
{
    public class ProcessManager
    {
        public Process StartProcess(string filePath, string arguments = "", bool redirectOutput = false, bool createNoWindow = true)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filePath,
                    Arguments = arguments,
                    UseShellExecute = !redirectOutput,
                    RedirectStandardOutput = redirectOutput,
                    RedirectStandardError = redirectOutput,
                    CreateNoWindow = createNoWindow
                }
            };

            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"プロセスの起動に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                process.Dispose();
                return null;
            }

            return process;
        }

        public string StartWireless(string filePath, string arguments)
        {
            using (Process process = StartProcess(filePath, arguments, redirectOutput: true))
            {
                if (process == null) return null;

                try
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    return output;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"無線接続の実行に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                finally
                {
                    process.Dispose();
                }
            }
        }

        public void StopProcess(Process process)
        {
            if (process == null) return;

            try
            {
                if (!process.HasExited)
                {
                    process.CloseMainWindow();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"プロセスの停止に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                process.Dispose();
            }
        }

        
    }
}
