using TelegramHistoryExtractor.Entities;

namespace TelegramHistoryExtractor.UnitTests;

public class WordExtractorFromAudio
{
    [Fact]
    public void ExtractWordsFromAudio_ReturnsWords_WhenAudioContainsSpeech()
    {
        // Arrange
        var extractor = new WordExtractor("C:\\Users\\truhi\\Downloads\\vosk-model-small-ru-0.22");
        var testAudioFilePath = "C:\\_Alex\\Code\\Echo-Replica\\tests\\TelegramHistoryExtractor.UnitTests\\Audios\\TestAudio.ogg"; // Укажите путь к тестовому .ogg файлу

        // Создаем коллекцию сообщений с одним аудиофайлом
        var messages = new List<AudioMessage>
        {
            new("TestUser", DateTime.Now, testAudioFilePath)
        };

        // Act
        var words = extractor.ExtractWordsFromAudioMessage(messages).ToList();

        // Assert
        Assert.NotEmpty(words); // Тест пройден, если есть хотя бы одно слово
    }
}