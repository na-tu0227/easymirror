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
        private readonly int bufferDuration; // 例：30秒分のバッファ
        private readonly Dictionary<string, string> commandDict;
        private readonly int frameRate = 30; // フレームレート (fps)
        private readonly ConcurrentQueue<byte[]> bufferQueue;
        private CancellationTokenSource cancellationTokenSource;

        public RewindRecorder(string scrcpyPath, Dictionary<string, string> commandDict)
        {
            this.scrcpyPath = scrcpyPath;
            this.commandDict = commandDict;

            bufferDuration = 30;
            bufferQueue = new ConcurrentQueue<byte[]>();
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

        // リモコンのボタンで呼び出され、バッファを保存する
        public async Task SaveBufferedRecordingAsync(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
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

        }

        private async Task SaveRawDataAsync(string filePath)
        {
            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                while (bufferQueue.TryDequeue(out var frameData))
                {
                    await fileStream.WriteAsync(frameData, 0, frameData.Length);
                }
            }
        }

        private void CaptureScrcpyStream(CancellationToken token)
        {
            CommandList commandList = new CommandList();

            string command = commandList.BuildCommand(commandDict, "start", "aac", "record", "-");

            Process process = new Process
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

            using (var stream = process.StandardOutput.BaseStream)
            {
                var frameSize = EstimateFrameSize();
                byte[] buffer = new byte[frameSize];

                while (!token.IsCancellationRequested)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        // 読み込んだフレームをバッファに追加
                        byte[] frameData = new byte[bytesRead];
                        Array.Copy(buffer, frameData, bytesRead);
                        bufferQueue.Enqueue(frameData);

                        // バッファが指定秒数を超えた場合、古いデータを削除
                        while (bufferQueue.Count > frameRate * bufferDuration)
                        {
                            bufferQueue.TryDequeue(out _);
                        }
                    }
                }
            }

            process.WaitForExit();
        }

        // FFmpegを使って変換
        private async Task ConvertWithFFmpegAsync(string inputFilePath, string outputFilePath)
        {
            var ffmpegPath = "ffmpeg"; // FFmpegのパス
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

            using (var process = Process.Start(processStartInfo))
            {
                var output = await process.StandardOutput.ReadToEndAsync();
                var error = await process.StandardError.ReadToEndAsync();

                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"FFmpegエラー: {error}");
                }
            }
        }


        // フレームサイズを推定する（フレームサイズは画質に依存するため要調整）
        private int EstimateFrameSize()
        {
            // 画質や解像度によってサイズは変わるため、仮のサイズを指定
            // 例: 1920x1080 30fps の場合、約1MB/frame
            return 1024 * 1024;
        }
    }
}
