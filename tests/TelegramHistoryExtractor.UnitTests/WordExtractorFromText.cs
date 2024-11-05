using TelegramHistoryExtractor;
using TelegramHistoryExtractor.Entities;

namespace TelegramHistoryExtractor.UnitTests;

public class WordExtractorTests
{
    [Fact]
    public void ExtractWordsFromTextMessage_SimpleText_ReturnsCorrectWords()
    {
        // Arrange
        var messages = new List<TextMessage>
        {
            new TextMessage("User1", System.DateTime.Now, "Hello, мир! Это high-quality тест.")
        };
        var wordExtractor = new WordExtractor("");
        var expectedWords = new List<string> { "Hello", "мир", "Это", "high-quality", "тест" };

        // Act
        var actualWords = wordExtractor.ExtractWordsFromTextMessage(messages);

        // Assert
        Assert.Equal(expectedWords, new List<string>(actualWords));
    }

    [Fact]
    public void ExtractWordsFromTextMessage_WithMixedLanguageAndHyphen_ReturnsCorrectWords()
    {
        // Arrange
        var messages = new List<TextMessage>
        {
            new TextMessage("User2", System.DateTime.Now, "The well-known автор программы написал этот код.")
        };
        var wordExtractor = new WordExtractor("");
        var expectedWords = new List<string> { "The", "well-known", "автор", "программы", "написал", "этот", "код" };

        // Act
        var actualWords = wordExtractor.ExtractWordsFromTextMessage(messages);

        // Assert
        Assert.Equal(expectedWords, new List<string>(actualWords));
    }

    [Fact]
    public void ExtractWordsFromTextMessage_WithSpecialCharacters_ReturnsOnlyWords()
    {
        // Arrange
        var messages = new List<TextMessage>
        {
            new TextMessage("User3", System.DateTime.Now, "Тест! Проверка, строки с: символами {и} спец.знаками?")
        };
        var wordExtractor = new WordExtractor("");
        var expectedWords = new List<string> { "Тест", "Проверка", "строки", "с", "символами", "и", "спец", "знаками" };

        // Act
        var actualWords = wordExtractor.ExtractWordsFromTextMessage(messages);

        // Assert
        Assert.Equal(expectedWords, new List<string>(actualWords));
    }
    
    [Fact]
    public void ExtractWordsFromTextMessage_SimpleTestFromChat_ReturnsCorrectWords()
    {
        // Arrange
        var messages = new List<TextMessage>
        {
            new TextMessage("User3", System.DateTime.Now, "1.5 за 20 рублей")
        };
        var wordExtractor = new WordExtractor("");
        var expectedWords = new List<string> { "за", "рублей" };

        // Act
        var actualWords = wordExtractor.ExtractWordsFromTextMessage(messages);

        // Assert
        Assert.Equal(expectedWords, new List<string>(actualWords));
    }
}