using System.Diagnostics;

namespace TelegramHistoryExtractor
{
    public static class AudioConverter
    {
        public static string ConvertOggOpusToWav(string oggFilePath)
        {
            if (!File.Exists(oggFilePath))
            {
                throw new FileNotFoundException($"File not found: {oggFilePath}");
            }

            var wavFilePath = Path.ChangeExtension(oggFilePath, ".wav");

            // Configure the ffmpeg process
            var ffmpeg = new ProcessStartInfo
            {
                FileName = "ffmpeg",  // Ensure 'ffmpeg' is in your PATH or provide the full path here
                Arguments = $"-i \"{oggFilePath}\" \"{wavFilePath}\" -y",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Start the process
            using (var process = new Process { StartInfo = ffmpeg })
            {
                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    throw new Exception($"ffmpeg conversion failed: {error}");
                }
            }

            Console.WriteLine($"WAV file created at {wavFilePath}");
            return wavFilePath;
        }
    }
}