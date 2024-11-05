using System.Globalization;
using HtmlAgilityPack;
using TelegramHistoryExtractor.Entities;

namespace TelegramHistoryExtractor;

public class HtmlParser
{
    public IEnumerable<IReadOnlyCollection<TextMessage>> GetTextMessages(IReadOnlyCollection<string> htmlFiles)
    {
        foreach (var messagesBatch in ExtractMessagesFromHtml(htmlFiles, message => message is TextMessage))
        {
            yield return messagesBatch.ConvertAll(message => (TextMessage)message);
        }
    }

    public IEnumerable<IReadOnlyCollection<AudioMessage>> GetAudioMessages(IReadOnlyCollection<string> htmlFiles)
    {
        foreach (var messagesBatch in ExtractMessagesFromHtml(htmlFiles, message => message is AudioMessage))
        {
            yield return messagesBatch.ConvertAll(message => (AudioMessage)message);
        }
    }

    private IEnumerable<List<Message>> ExtractMessagesFromHtml(
        IReadOnlyCollection<string> htmlFiles,
        Func<Message, bool> filter)
    {
        foreach (var htmlFile in htmlFiles)
        {
            var doc = new HtmlDocument();
            doc.Load(htmlFile);

            var messageNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'message')]");
            if (messageNodes == null) continue;

            var messagesBatch = new List<Message>();

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

                Message? message = null;

                // Проверка на текстовое сообщение
                var textNode = messageNode.SelectSingleNode(".//div[@class='text']");
                if (textNode != null)
                {
                    var textContent = textNode.InnerText.Trim();
                    message = new TextMessage(userName, dateTime, textContent);
                }
                else
                {
                    // Проверка на аудиосообщение
                    var audioNode = messageNode.SelectSingleNode(".//a[contains(@class, 'media_voice_message')]");
                    if (audioNode != null)
                    {
                        var audioPath = audioNode.Attributes["href"]?.Value ?? "Unknown Path";
                        message = new AudioMessage(userName, dateTime, audioPath);
                    }
                }

                if (message != null && filter(message))
                {
                    messagesBatch.Add(message);
                }
            }

            if (messagesBatch.Count > 0)
            {
                yield return messagesBatch;
            }
        }
    }
}