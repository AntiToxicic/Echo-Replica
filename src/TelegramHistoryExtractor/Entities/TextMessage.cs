namespace TelegramHistoryParser.Entities;

public class TextMessage : Message
{
    public TextMessage(string userName, DateTime dateTime, string text) : base(userName, dateTime)
    {
        Text = text;
    }

    public string Text { get; set; }
}