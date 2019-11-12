using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using TTT.Services.Interfaces;

namespace TTT.Services
{
    public class RegistrationService : IRegistrationService
    {
        readonly IServiceProvider services;
        readonly IMapService mapService;

        public RegistrationService(
            IServiceProvider services,
            IMapService mapService)
        {
            this.services = services;
            this.mapService = mapService;
        }

        public async Task InitializeAsync()
        {
            await RegisterServices();
        }

        Task RegisterServices()
        {
            services.GetRequiredService<IContentService>();
            services.GetRequiredService<ITileService>();
            services.GetRequiredService<IMapService>();
            services.GetRequiredService<IEventService>();
            services.GetRequiredService<EventHandlerService>();
            services.GetRequiredService<IRegistrationService>();
            return Task.CompletedTask;
        }
    }
}
