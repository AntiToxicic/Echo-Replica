using System.Text.RegularExpressions;
using NAudio.Wave;
using TelegramHistoryExtractor.Entities;
using Vosk;

namespace TelegramHistoryExtractor;

public class WordExtractor
{
    private readonly string _modelPath;

    public WordExtractor(string modelPath)
    {
        _modelPath = modelPath;
    }
    
    public IEnumerable<string> ExtractWordsFromTextMessage(IReadOnlyCollection<TextMessage> messages)
    {
        var wordPattern = new Regex(@"\b[a-zA-Zа-яА-Я]+(?:-[a-zA-Zа-яА-Я]+)?\b");

        foreach (var message in messages)
        {
            var matches = wordPattern.Matches(message.Text);

            foreach (Match match in matches)
            {
                yield return match.Value;
            }
        }
    }
    
    public IEnumerable<string> ExtractWordsFromAudioMessage(IEnumerable<AudioMessage> messages)
    {
        var wordPattern = new Regex(@"\b[a-zA-Zа-яА-Я]+(?:-[a-zA-Zа-яА-Я]+)?\b");

        // Инициализация модели
        Vosk.Vosk.SetLogLevel(0);
        var model = new Model(_modelPath);

        foreach (var message in messages)
        {
            if (!File.Exists(message.FilePath))
            {
                Console.WriteLine($"Audio file not found: {message.FilePath}");
                continue;
            }
            Console.WriteLine($"Processing file: {message.FilePath}");
            // Открываем аудиофайл
            using var waveReader = new WaveFileReader(AudioConverter.ConvertOggOpusToWav(message.FilePath));
            using var recognizer = new VoskRecognizer(model, waveReader.WaveFormat.SampleRate);

            // Чтение и распознавание
            while (waveReader.Position < waveReader.Length)
            {
                var buffer = new byte[4096];
                int bytesRead = waveReader.Read(buffer, 0, buffer.Length);
                if (recognizer.AcceptWaveform(buffer, bytesRead))
                {
                    var resultText = recognizer.Result();
                    foreach (Match match in wordPattern.Matches(resultText))
                    {
                        if (match.Value == "text")
                            continue;
                        
                        yield return match.Value;
                    }
                }
            }
        }
    }
}