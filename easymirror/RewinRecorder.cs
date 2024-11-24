using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace easymirror
{
    public class RewindRecorder
    {
        private readonly string scrcpyPath;
        private readonly string ffmpegPath = "ffmpeg"; // FFmpegのパス
        private readonly int bufferDuration; // バッファリングする秒数 (例: 30秒)
        private readonly Dictionary<string, string> commandDict;
        private readonly int frameRate = 30; // フレームレート (fps)
        private readonly ConcurrentQueue<byte[]> bufferQueue = new();
        private CancellationTokenSource cancellationTokenSource;

        public RewindRecorder(string scrcpyPath, Dictionary<string, string> commandDict)
        {
            if (string.IsNullOrEmpty(scrcpyPath))
                throw new ArgumentException("scrcpyPath は空または null にできません。", nameof(scrcpyPath));

            this.scrcpyPath = scrcpyPath;
            this.commandDict = commandDict ?? throw new ArgumentNullException(nameof(commandDict));
            bufferDuration = 30;
        }

        // 録画の開始
        public async Task StartRecordingAsync()
        {
            cancellationTokenSource = new CancellationTokenSource();
            await Task.Run(() => CaptureScrcpyStream(cancellationTokenSource.Token));
        }

        // 録画の停止
        public void StopRecording()
        {
            cancellationTokenSource?.Cancel();
        }

        // バッファデータを保存する
        public async Task SaveBufferedRecordingAsync(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("filePath は空または null にできません。", nameof(filePath));

            string directory = Path.GetDirectoryName(filePath);
            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // 一時的な生データファイルを作成
            string rawFilePath = Path.ChangeExtension(filePath, ".raw");
            await SaveRawDataAsync(rawFilePath);

            // FFmpegを使って変換
            string convertedFilePath = Path.ChangeExtension(filePath, ".mp4"); // 最終出力ファイル
            await ConvertWithFFmpegAsync(rawFilePath, convertedFilePath);

            // 生データファイルを削除
            if (File.Exists(rawFilePath))
            {
                File.Delete(rawFilePath);
            }
        }

        private async Task SaveRawDataAsync(string filePath)
        {
            using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            while (bufferQueue.TryDequeue(out var frameData))
            {
                await fileStream.WriteAsync(frameData, 0, frameData.Length);
            }
        }

        private void CaptureScrcpyStream(CancellationToken token)
        {
            if (commandDict == null)
                throw new InvalidOperationException("commandDict が初期化されていません。");

            var command = BuildScrcpyCommand();

            using Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = scrcpyPath,
                    Arguments = command,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            process.Start();

            using var stream = process.StandardOutput.BaseStream;
            int frameSize = EstimateFrameSize();
            byte[] buffer = new byte[frameSize];

            try
            {
                while (!token.IsCancellationRequested)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        // フレームデータをバッファに追加
                        var frameData = new byte[bytesRead];
                        Array.Copy(buffer, frameData, bytesRead);
                        bufferQueue.Enqueue(frameData);

                        // 古いデータを削除してバッファを管理
                        while (bufferQueue.Count > frameRate * bufferDuration)
                        {
                            bufferQueue.TryDequeue(out _);
                        }
                    }
                }
            }
            catch (IOException ex) when (token.IsCancellationRequested)
            {
                // キャンセルされた場合は例外を無視
            }
            finally
            {
                process.WaitForExit();
            }
        }

        // Scrcpy用のコマンドを作成
        private string BuildScrcpyCommand()
        {
            // commandDict から必要なコマンドを組み立てるロジックを記述
            return "scrcpy-command-example"; // 例: 実際の組み立てロジックに置き換え
        }

        // FFmpegを使って変換
        private async Task ConvertWithFFmpegAsync(string inputFilePath, string outputFilePath)
        {
            string arguments = $"-i \"{inputFilePath}\" -vcodec libx264 -pix_fmt yuv420p \"{outputFilePath}\"";

            var processStartInfo = new ProcessStartInfo
            {
                FileName = ffmpegPath,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using var process = Process.Start(processStartInfo);
            if (process == null)
                throw new InvalidOperationException("FFmpeg プロセスの開始に失敗しました。");

            string error = await process.StandardError.ReadToEndAsync();
            await process.StandardOutput.ReadToEndAsync(); // 出力を読み取る

            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new Exception($"FFmpegエラー: {error}");
            }
        }

        // フレームサイズを推定
        private int EstimateFrameSize()
        {
            // 解像度と画質に応じた適切な値を返すように設定
            return 1024 * 1024; // 例: 1920x1080, 30fps の場合約1MB/フレーム
        }
    }
}
