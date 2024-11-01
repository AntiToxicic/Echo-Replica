namespace TelegramHistoryParser;

public class FileManager
{
    private string _chatExportFolderPath;
    private const string _AUDIOFOLDER = "voice_messages";

    public FileManager(string chatExportFolderPath)
    {
        _chatExportFolderPath = chatExportFolderPath;
    }

    public IReadOnlyCollection<string> GetAllHtmlFiles() =>
        Directory.GetFiles(_chatExportFolderPath, "*.html").ToList();
    
    public IReadOnlyCollection<string> GetAllOggFiles() =>
        Directory.GetFiles($"{_chatExportFolderPath}/{_AUDIOFOLDER}", "*.ogg").ToList();

}