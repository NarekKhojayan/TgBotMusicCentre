using MyTelegramBot.Presentation;

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string token = "YourBotToken"; 

        var bot = new BotHandler(token);
        await bot.StartAsync();
    }
}
