using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TTT.Services;
using TTT.Services.Interfaces;

namespace TTT.Debug
{
    class Program
    {
        readonly IServiceProvider services;

        Program()
        {
            services = ConfigureServices();
        }

        static void Main(string[] args) =>
            new Program().MainAsync().GetAwaiter().GetResult();

        async Task MainAsync()
        {
            services.GetRequiredService<TTT>().Run();
            await Task.Delay(-1);
        }

        IServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton<TTT>()
                .AddSingleton<IContentService, ContentService>()
                .AddSingleton<ITileService, TileService>()
                .AddSingleton<IMapService, MapService>()
                .AddSingleton<IEventService, EventService>()
                .AddSingleton<EventHandlerService>()
                .AddSingleton<IRegistrationService, RegistrationService>()
                .BuildServiceProvider();
        }
    }
}
