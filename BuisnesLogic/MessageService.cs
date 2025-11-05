using ModelsForBot;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace MyTelegramBot.BusinessLogic
{
    public class MessageService
    {
        private readonly ModelInterface startButtons;

        public MessageService()
        {
            startButtons = new ModelInterface();
        }

        public string HandleText(string text)
        {
            if (text.Contains("Hello") || text == "Hello")
            {
                return "Hi! 😊";
            }
            else
            {

                return $"Ты написал: {text}";
            }
        }

        public async Task SendStartIntro(ITelegramBotClient client, ChatId chatId)
        {
            await startButtons.PutStartButtons(client, chatId);
        }
    }
}
