using System;
using System.Numerics;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Net.Mime.MediaTypeNames;

namespace ModelsForBot
{
    public class ModelInterface
    {
        public async Task PutStartButtons(ITelegramBotClient client, ChatId chatId, int? messageId = null)
        {
            var buttons = new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("📖 Singing" , "Singing"),
                    InlineKeyboardButton.WithCallbackData("🎨 Painting", "Painting"),
                    InlineKeyboardButton.WithCallbackData("🎧 Recording", "Recording"),
                },
                new[]
                {
                    InlineKeyboardButton.WithUrl("🌐 Instagram", "https://www.instagram.com/"),
                    InlineKeyboardButton.WithCallbackData("🆘 Help", "help")
                },
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("📖 About", "about"),
                },
            };

            var keyboard = new InlineKeyboardMarkup(buttons);
            var text = "Welcome! 👋 Please choose an option:";

            if (messageId != null)
            {
                await client.EditMessageTextAsync(
                    chatId: chatId,
                    messageId: messageId.Value,
                    text: text,
                    replyMarkup: keyboard
                );
            }
            else
            {
                await client.SendTextMessageAsync(
                    chatId: chatId,
                    text: text,
                    replyMarkup: keyboard
                );
            }
        }

        public async Task ShowAboutAsync(ITelegramBotClient client, ChatId chatId, int messageId)
        {
            await client.EditMessageTextAsync(
                chatId: chatId,
                messageId: messageId,
                text: "📖 About Us\n\n" +
                        "We are a passionate team of musicians and artists helping people discover their creative talents. 🎶\n\n" +
                        "🎹 We teach music starting from the age of 6.\n" +
                        "🎨 Our goal is to make learning fun, inspiring, and accessible for everyone!\n\n" +
                        "Join our creative family today 🚀"
,
                replyMarkup: new InlineKeyboardMarkup( new[]
                {
                  new[] {
                    InlineKeyboardButton.WithCallbackData("📞 Contact Us", "contact"),
                    InlineKeyboardButton.WithCallbackData("⬅️ Back", "back_to_menu"),
                    }
                  }
                )
            );
        }

        public async Task ShowSingingAsync(ITelegramBotClient client, ChatId chatId, int messageId)
        {
            await client.EditMessageTextAsync(
                chatId: chatId,
                messageId: messageId,
                text: "🎤 Welcome to our Singing Classes!\n\n" +
                    "Here you’ll learn how to use your voice with confidence and emotion. " +
                    "Our professional vocal coaches will help you improve your tone, breathing, and stage performance.\n\n" +
                    "✨ Classes available for all ages and levels — from beginners to advanced performers.",
                replyMarkup: new InlineKeyboardMarkup(new[]

                {   InlineKeyboardButton.WithCallbackData("👩‍🏫 Teachers", "singing_teachers"),
                    InlineKeyboardButton.WithCallbackData("🕒 Schedule", "singing_schedule"),
                    InlineKeyboardButton.WithCallbackData("📖 Start Lesson", "start_lesson"),
                    InlineKeyboardButton.WithCallbackData("📞 Contact Us", "contact"),
                    InlineKeyboardButton.WithCallbackData("⬅️ Back", "back_to_menu"),
                })
            );
        }

        public async Task ShowPaintingAsync(ITelegramBotClient client, ChatId chatId, int messageId)
        {
            await client.EditMessageTextAsync(
                chatId: chatId,
                messageId: messageId,
                text: "🎨 Welcome to our Painting Studio!\n\n" +
                    "Unleash your creativity and learn to paint with professional artists. " +
                    "You’ll explore color theory, composition, and techniques used by masters.\n\n" +
                    "🖌️ Classes available 5 days a week — join us and express yourself through art!",
                replyMarkup: new InlineKeyboardMarkup(new[]
                {
                    InlineKeyboardButton.WithCallbackData("👩‍🏫 Teachers", "painting_teachers"),
                    InlineKeyboardButton.WithCallbackData("🕒 Schedule", "painting_schedule"),
                    InlineKeyboardButton.WithCallbackData("🎨 Start Lesson", "start_lesson"),
                    InlineKeyboardButton.WithCallbackData("📞 Contact Us", "contact"),
                    InlineKeyboardButton.WithCallbackData("⬅️ Back", "back_to_menu"),
                })
            );
        }

        public async Task ShowRecordingAsync(ITelegramBotClient client, ChatId chatId, int messageId)
        {
            await client.EditMessageTextAsync(
                chatId: chatId,
                messageId: messageId,
                text: "🎧 Welcome to our Recording Studio!\n\n" +
                        "Here you can learn how to record, mix, and produce your own music. " +
                        "Our experienced sound engineers will guide you through every step of the process.\n\n" +
                        "🎵 Create your first song with professional equipment and support!",
                replyMarkup: new InlineKeyboardMarkup(new[]
                {   InlineKeyboardButton.WithCallbackData("👩‍🏫 Teachers", "recording_teachers"),
                    InlineKeyboardButton.WithCallbackData("🕒 Schedule", "recording_schedule"),
                    InlineKeyboardButton.WithCallbackData("🎧 Start Lesson", "start_lesson"),
                    InlineKeyboardButton.WithCallbackData("📞 Contact Us", "contact"),
                    InlineKeyboardButton.WithCallbackData("⬅️ Back", "back_to_menu"),
                })
            );
        }


        public async Task ShowContactsAsync(ITelegramBotClient client, ChatId chatId, int messageId)
        {
            await client.EditMessageTextAsync(
                        chatId: chatId,
                        messageId: messageId,
                        text: "📞 Contact us via Telegram: @YourMusicSchool\n" +
                              "📧 Email: music@school.com\n" +
                              "🌐 Website: www.music-school.com",
                         replyMarkup: new InlineKeyboardMarkup(new[]
                         {   
                    InlineKeyboardButton.WithCallbackData("⬅️ Back", "back_to_menu"),
                         })
            );
        }
    }
}
