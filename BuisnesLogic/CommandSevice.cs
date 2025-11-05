using Telegram.Bot;
using Telegram.Bot.Types;
using MyTelegramBot.BusinessLogic;
using System.Threading.Tasks;

namespace MyTelegramBot.BusinessLogic
{
    public class CommandService
    {
        private readonly MessageService message;

        public CommandService()
        {
            message = new MessageService();
        }

        public async Task HandleCommandAsync(string command, string? userName, ITelegramBotClient client, ChatId chatId)
        {
            switch (command)
            {
                case "/start":
                    await client.SendTextMessageAsync(chatId, $"👋 Hi , {userName}!");
                    await message.SendStartIntro(client, chatId);
                    break;

                case "/about":
                    await client.SendTextMessageAsync(chatId, "🤖 Этот бот создан для примера чистой архитектуры на C#.");
                    break;

                default:
                    await client.SendTextMessageAsync(chatId, "❓ Неизвестная команда. Введите /start");
                    break;
            }
        }
    }
}
