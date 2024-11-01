using System.Globalization;
using HtmlAgilityPack;
using TelegramHistoryParser.Entities;

namespace TelegramHistoryParser;

public class HtmlParser
{
    private readonly FileManager _fileManager;

    public HtmlParser(FileManager fileManager)
    {
        _fileManager = fileManager;
    }

    public IEnumerable<Message> GetMessagesForEachHtml()
    {
        var htmlFiles = _fileManager.GetAllHtmlFiles();

        foreach (var htmlFile in htmlFiles)
        {
            var doc = new HtmlDocument();
            doc.Load(htmlFile);

            var messageNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'message')]");

            if (messageNodes == null)
            {
                continue;
            }

            foreach (var messageNode in messageNodes)
            {
                var userNode = messageNode.SelectSingleNode(".//div[@class='from_name']");
                var userName = userNode != null ? userNode.InnerText.Trim() : "Unknown User";

                var dateNode = messageNode.SelectSingleNode(".//div[contains(@class, 'date')]");
                DateTime dateTime = DateTime.MinValue;

                if (dateNode != null && dateNode.Attributes["title"] != null)
                {
                    var dateString = dateNode.Attributes["title"].Value;
                    DateTime.TryParseExact(dateString, "dd.MM.yyyy HH:mm:ss",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);
                }

                var textNode = messageNode.SelectSingleNode(".//div[@class='text']");
                if (textNode != null)
                {
                    var textContent = textNode.InnerText.Trim();
                    var textMessage = new TextMessage(userName, dateTime, textContent);
                    yield return textMessage; // Возвращаем текстовое сообщение
                    continue;
                }

                var mediaNode = messageNode.SelectSingleNode(".//div[contains(@class, 'media_audio')]");
                if (mediaNode != null)
                {
                    var audioPath = mediaNode.Attributes["src"]?.Value ?? "Unknown Path";
                    var audioMessage = new AudioMessage(userName, dateTime, audioPath);
                    yield return audioMessage; // Возвращаем аудио сообщение
                }
            }
        }
    }
}