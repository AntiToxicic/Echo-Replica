namespace TelegramHistoryParser.Entities;

public abstract class Message
{
    public Message(string userName, DateTime dateTime)
    {
        UserName = userName;
        DateTime = dateTime;
    }

    public string UserName { get; set; }
    
    public DateTime DateTime { get; set; }
}