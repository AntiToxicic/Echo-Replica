using System.IO.Abstractions;

namespace TelegramHistoryExtractor;

public class FileManager
{
    private readonly string _chatExportFolderPath;
    private readonly IFileSystem _fileSystem;
    private const string _AUDIOFOLDER = "voice_messages";

    public FileManager(string chatExportFolderPath, IFileSystem fileSystem)
    {
        _chatExportFolderPath = chatExportFolderPath;
        _fileSystem = fileSystem;
    }

    public IReadOnlyCollection<string> GetAllHtmlFiles() =>
        _fileSystem.Directory.GetFiles(_chatExportFolderPath, "*.html").ToList();
    
    public IReadOnlyCollection<string> GetAllOggFiles() =>
        _fileSystem.Directory.GetFiles($"{_chatExportFolderPath}/{_AUDIOFOLDER}", "*.ogg").ToList();
}