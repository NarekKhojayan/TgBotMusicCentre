using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ModelsForBot
{
    public class ModelDetails
    {
        // --- 🎤 Singing Section ---
        public async Task ShowSingingTeachersAsync(ITelegramBotClient client, ChatId chatId, int messageId)
        {
            var text = "👩‍🏫 *Singing Teachers*\n\n" +
                       "🎵 *Sophia Clark* — Vocal coach with 10+ years of stage experience.\n" +
                       "🎶 *James Miller* — Professional performer and voice technique specialist.\n" +
                       "🎤 *Olivia Harris* — Teaches pop and classical singing techniques.\n\n" +
                       "Each teacher focuses on developing your voice, breathing, and musical expression.";

            await client.EditMessageTextAsync(chatId, messageId, text,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: CommonButtons("singing"));
        }

        public async Task ShowSingingScheduleAsync(ITelegramBotClient client, ChatId chatId, int messageId)
        {
            var text = "🕒 *Singing Schedule*\n\n" +
                       "🎼 Monday – Friday: 10:00 - 19:00\n" +
                       "🎙️ Saturday: 12:00 - 17:00\n" +
                       "📍 Studio 1, MeccoTiana School\n\n" +
                       "Contact us to book your session!";

            await client.EditMessageTextAsync(chatId, messageId, text,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: CommonButtons("singing"));
        }

        // --- 🎨 Painting Section ---
        public async Task ShowPaintingTeachersAsync(ITelegramBotClient client, ChatId chatId, int messageId)
        {
            var text = "👩‍🏫 *Painting Teachers*\n\n" +
                       "🎨 *Daniel Green* — Specialist in watercolor and oil painting.\n" +
                       "🖌️ *Emily Davis* — Teaches drawing fundamentals and realism.\n" +
                       "🌈 *Michael Turner* — Focuses on creative abstract techniques.\n\n" +
                       "All teachers have years of experience and help students express their inner artist.";

            await client.EditMessageTextAsync(chatId, messageId, text,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: CommonButtons("painting"));
        }

        public async Task ShowPaintingScheduleAsync(ITelegramBotClient client, ChatId chatId, int messageId)
        {
            var text = "🕒 *Painting Schedule*\n\n" +
                       "🎨 Monday – Thursday: 11:00 - 18:00\n" +
                       "🖌️ Saturday: 13:00 - 17:00\n" +
                       "📍 Art Room 2, MeccoTiana School\n\n" +
                       "You can join group or individual lessons.";

            await client.EditMessageTextAsync(chatId, messageId, text,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: CommonButtons("painting"));
        }

        // --- 🎧 Recording Section ---
        public async Task ShowRecordingTeachersAsync(ITelegramBotClient client, ChatId chatId, int messageId)
        {
            var text = "👩‍🏫 *Recording Studio Mentors*\n\n" +
                       "🎧 *Anna Smith* — Sound engineer with 15+ years of experience.\n" +
                       "🎚️ *Mark Johnson* — Producer and music arrangement expert.\n" +
                       "🎛️ *Lisa Brown* — Specialist in vocal mixing and mastering.\n\n" +
                       "Our mentors help you record, mix, and publish your own music!";

            await client.EditMessageTextAsync(chatId, messageId, text,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: CommonButtons("recording"));
        }

        public async Task ShowRecordingScheduleAsync(ITelegramBotClient client, ChatId chatId, int messageId)
        {
            var text = "🕒 *Recording Schedule*\n\n" +
                       "🎧 Monday – Sunday: 10:00 - 21:00\n" +
                       "🎶 Studio available by appointment.\n" +
                       "📍 Recording Room, MeccoTiana School\n\n" +
                       "Reserve your time slot in advance!";

            await client.EditMessageTextAsync(chatId, messageId, text,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: CommonButtons("recording"));
        }

        // --- Общие кнопки ---
        private InlineKeyboardMarkup CommonButtons(string section)
        {
            return new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("⬅️ Back", $"{section}_back")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("💬 Contact Us", "contact")
                }
            });
        }
    }
}
