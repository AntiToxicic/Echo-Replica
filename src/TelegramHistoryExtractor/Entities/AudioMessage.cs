namespace TelegramHistoryParser.Entities;

public class AudioMessage : Message
{
    public AudioMessage(string userName, DateTime dateTime, string filePath) : base(userName, dateTime)
    {
        FilePath = filePath;
    }

    public string FilePath { get; set; }
}