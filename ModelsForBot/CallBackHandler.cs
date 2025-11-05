using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ModelsForBot
{
    public class CallBackHandler
    {
        private readonly ModelInterface _interface;
        private readonly ModelDetails _details;

        public CallBackHandler()
        {
            _interface = new ModelInterface();
            _details = new ModelDetails();
        }

        public async Task HandleCallbackAsync(CallbackQuery callback, ITelegramBotClient client)
        {
            var chatId = callback.Message!.Chat.Id;
            var messageId = callback.Message.MessageId;

            switch (callback.Data)
            {
              
                case "back_to_menu":
                    await _interface.PutStartButtons(client, chatId, messageId);
                    break;

             
                case "about":
                    await _interface.ShowAboutAsync(client, chatId, messageId);
                    break;

                case "Singing":
                    await _interface.ShowSingingAsync(client, chatId, messageId);
                    break;

                case "Painting":
                    await _interface.ShowPaintingAsync(client, chatId, messageId);
                    break;

                case "Recording":
                    await _interface.ShowRecordingAsync(client, chatId, messageId);
                    break;

             
                case "singing_teachers":
                    await _details.ShowSingingTeachersAsync(client, chatId, messageId);
                    break;

                case "painting_teachers":
                    await _details.ShowPaintingTeachersAsync(client, chatId, messageId);
                    break;

                case "recording_teachers":
                    await _details.ShowRecordingTeachersAsync(client, chatId, messageId);
                    break;

           
                case "singing_schedule":
                    await _details.ShowSingingScheduleAsync(client, chatId, messageId);
                    break;

                case "painting_schedule":
                    await _details.ShowPaintingScheduleAsync(client, chatId, messageId);
                    break;

                case "recording_schedule":
                    await _details.ShowRecordingScheduleAsync(client, chatId, messageId);
                    break;

              
                case "singing_back":
                    await _interface.ShowSingingAsync(client, chatId, messageId);
                    break;

                case "painting_back":
                    await _interface.ShowPaintingAsync(client, chatId, messageId);
                    break;

                case "recording_back":
                    await _interface.ShowRecordingAsync(client, chatId, messageId);
                    break;

                case "contact":
                    await _interface.ShowContactsAsync(client, chatId, messageId);
                    break;

                default:
                    await client.AnswerCallbackQueryAsync(callback.Id, "❓ Unknown command");
                    break;
            }

       
            await client.AnswerCallbackQueryAsync(callback.Id);
        }
    }
}
