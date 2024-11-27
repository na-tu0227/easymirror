using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace easymirror
{
    public class ProcessManager
    {
        private readonly string logFilePath = ".\\log.txt";

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
                string errorMessage = $"error: {ex.Message}";
                LogError(errorMessage);
                MessageBox.Show(errorMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string errorMessage = $"errorwireless: {ex.Message}";
                    LogError(errorMessage);
                    MessageBox.Show(errorMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string errorMessage = $"error: {ex.Message}";
                LogError(errorMessage);
                MessageBox.Show(errorMessage, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                process.Dispose();
            }
        }

        public void LogMessage(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [INFO] {message}");
            }
        }

        public void LogError(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [ERROR] {message}");
            }
        }
    }
}
