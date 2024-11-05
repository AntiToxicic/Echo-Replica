using TelegramHistoryExtractor.Entities;

namespace TelegramHistoryExtractor.UnitTests;

public class HtmlParser
{
    private readonly string _htmlFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../../TelegramHistoryExtractor.UnitTests/htmls/SimpleTelegramHistory.html");

    [Fact]
    public void GetTextMessages_ReturnsOnlyTextMessages()
    {
        // Arrange
        var parser = new TelegramHistoryExtractor.HtmlParser();

        // Act
        var textMessages = parser.GetTextMessages(new List<string> { _htmlFilePath }).ToList();

        // Assert
        Assert.Single(textMessages);
        Assert.Single(textMessages[0]);
        Assert.IsType<TextMessage>(textMessages[0].First());
        Assert.Equal("Hello world!", textMessages[0].First().Text);
        Assert.Equal("Александр", textMessages[0].First().UserName);
    }

    [Fact]
    public void GetAudioMessages_ReturnsOnlyAudioMessages()
    {
        // Arrange
        var parser = new TelegramHistoryExtractor.HtmlParser();

        // Act
        var audioMessages = parser.GetAudioMessages(new List<string> { _htmlFilePath }).ToList();

        // Assert
        Assert.Single(audioMessages);
        Assert.Single(audioMessages[0]);
        Assert.IsType<AudioMessage>(audioMessages[0].First());
        Assert.Equal("voice_messages/audio_1@06-03-2021_15-26-04.ogg", audioMessages[0].First().FilePath);
        Assert.Equal("Александр", audioMessages[0].First().UserName);
    }
}