using ModelsForBot;
using MyTelegramBot.BusinessLogic;
using System.Runtime.CompilerServices;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace MyTelegramBot.Presentation
{
    public class BotHandler
    {
        private readonly ITelegramBotClient _botClient;
        private readonly CommandService _commandService;
        private readonly MessageService _messageService;
        private readonly CallBackHandler _callBack;

        public BotHandler(string token)
        {
            _botClient = new TelegramBotClient(token);
            _commandService = new CommandService();
            _messageService = new MessageService();
            _callBack = new CallBackHandler();
        }

        public async Task StartAsync()
        {
            var cts = new CancellationTokenSource();

            _botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandleErrorAsync,
                cancellationToken: cts.Token
                
            );

            var me = await _botClient.GetMeAsync();
            Console.WriteLine($"🤖 Бот @{me.Username} запущен!");
            await Task.Delay(-1, cts.Token);
        }

       
        
        private async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken token)
        {
            if (update.Type == UpdateType.Message && update.Message!.Type == MessageType.Text)
            {
                var message = update.Message;
                var text = message.Text!.Trim().ToLower();

                if (text.StartsWith("/"))
                    await _commandService.HandleCommandAsync(text, message.Chat.FirstName, bot, message.Chat.Id);
                else
                {
                    var response = _messageService.HandleText(text);
                    await bot.SendTextMessageAsync(message.Chat.Id, response);
                }
            }
            else if (update.Type == UpdateType.CallbackQuery)
            {
                await _callBack.HandleCallbackAsync(update.CallbackQuery!, bot);
            }
            
        }

        private Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken token)
        {
            Console.WriteLine($"❌ Exception: {exception.Message}");
            return Task.CompletedTask;
        }
    }
}
