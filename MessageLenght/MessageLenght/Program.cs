using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

namespace MessageLenght
{
    class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.Unicode;

            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services))
                .UseConsoleLifetime()
                .Build();

            Console.WriteLine("Service Start");

            await host.RunAsync();

            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITelegramBotClient>(Provider => new TelegramBotClient("5375499146:AAENzmZ8qYH6wnGW5wayU4E0GcPYulUswig"));
            services.AddHostedService<Bot>();
        }
    }
}
