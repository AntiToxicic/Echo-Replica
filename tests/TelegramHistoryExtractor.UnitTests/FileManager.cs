using System.IO.Abstractions.TestingHelpers;
using TelegramHistoryExtractor;

namespace TelegramHistoryExtractor.UnitTests;

public class FileManagerTests
{
    [Fact]
    public void GetAllHtmlFiles_ReturnsAllHtmlFilesInDirectory()
    {
        // Arrange
        var mockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { @"c:\chatexport\file1.html", new MockFileData("<html></html>") },
            { @"c:\chatexport\file2.html", new MockFileData("<html></html>") },
            { @"c:\chatexport\file3.txt", new MockFileData("This is a text file") },
            { @"c:\chatexport\voice_messages\audio1.ogg", new MockFileData("Audio data") },
        });
        var fileManager = new FileManager(@"c:\chatexport", mockFileSystem);

        // Act
        var htmlFiles = fileManager.GetAllHtmlFiles();

        // Assert
        Assert.Equal(2, htmlFiles.Count);
        Assert.Contains(@"c:\chatexport\file1.html", htmlFiles);
        Assert.Contains(@"c:\chatexport\file2.html", htmlFiles);
    }

    [Fact]
    public void GetAllOggFiles_ReturnsAllOggFilesInVoiceMessagesFolder()
    {
        // Arrange
        var mockFileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { @"c:\chatexport\file1.html", new MockFileData("<html></html>") },
            { @"c:\chatexport\voice_messages\audio1.ogg", new MockFileData("Audio data") },
            { @"c:\chatexport\voice_messages\audio2.ogg", new MockFileData("Audio data") },
            { @"c:\chatexport\voice_messages\audio3.mp3", new MockFileData("MP3 data") },
        });
        var fileManager = new FileManager(@"c:\chatexport", mockFileSystem);

        // Act
        var oggFiles = fileManager.GetAllOggFiles();

        // Assert
        Assert.Equal(2, oggFiles.Count);
        Assert.Contains(@"c:\chatexport\voice_messages\audio1.ogg", oggFiles);
        Assert.Contains(@"c:\chatexport\voice_messages\audio2.ogg", oggFiles);
    }
}