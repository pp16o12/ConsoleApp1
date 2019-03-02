using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace ConsoleApp1
{
    class Program
    {
        static TelegramBotClient botClient;
        readonly static string connectionString = @"Data Source=10.2.2.212;Initial Catalog=ptpjam_db;Persist Security Info=True;User ID=student;Pooling=False";
        static void Main(string[] args)
        {
            try
            {
                botClient = new TelegramBotClient("796076908:AAHZHCLWXbEWmSAt0riWj-wN5hXsZIEOlIc");
                var bot = botClient.GetMeAsync().Result;
                Console.WriteLine(bot.Username);

                botClient.OnMessage += getMessage;
                botClient.StartReceiving();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }

        private static async void getMessage(object sender, MessageEventArgs e)
        {
            try {
                switch (e.Message.Text)
                {
                    case "/start":
                        {
                            await botClient.SendPhotoAsync(e.Message.Chat.Id, "https://yandex.com/collections/card/5b4b28972628a200889973aa/", $"Добро пожаловать, в мою игру!");
                            break;
                        }
                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            /*
             * смайлы брать тут
             * https://ru.piliapp.com/facebook-symbols/
             */
        }
    
}
}
