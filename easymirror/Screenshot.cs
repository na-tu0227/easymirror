//using System;
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.Runtime.InteropServices;
//using System.Windows.Forms;

//namespace ScrcpyApp
//{
//    public class Screenshot
//    {
//        // Win32 APIを使ってウィンドウハンドルとウィンドウの位置・サイズを取得
//        [DllImport("user32.dll", SetLastError = true)]
//        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

//        [DllImport("user32.dll", SetLastError = true)]
//        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

//        // RECT構造体
//        [StructLayout(LayoutKind.Sequential)]
//        private struct RECT
//        {
//            public int Left;
//            public int Top;
//            public int Right;
//            public int Bottom;
//        }

//        public void CaptureScrcpyWindow(string filePath, int width, int height)
//        {
//            try
//            {
//                // Scrcpyウィンドウのハンドルを取得
//                IntPtr hWnd = FindWindow(null, "mirror"); // Scrcpyのウィンドウタイトルを指定

//                if (hWnd == IntPtr.Zero)
//                {
//                    MessageBox.Show("Scrcpyウィンドウが見つかりませんでした。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return;
//                }

//                // ウィンドウの位置を取得
//                if (GetWindowRect(hWnd, out RECT windowRect))
//                {
//                    // 指定されたサイズでスクリーンショットをキャプチャ
//                    Bitmap screenshot = new Bitmap(width, height);
//                    using (Graphics g = Graphics.FromImage(screenshot))
//                    {
//                        g.CopyFromScreen(windowRect.Left, windowRect.Top, 0, 0, new Size(width, height));
//                    }

//                    // PNG形式で保存
//                    screenshot.Save(filePath, ImageFormat.Png);
//                    MessageBox.Show("スクリーンショットが保存されました: " + filePath, "スクリーンショット", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"スクリーンショットの取得に失敗しました: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//    }
//}
