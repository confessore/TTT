using System.Threading.Tasks;

namespace TTT.Services
{
    public class EventHandlerService
    {
        public EventHandlerService()
        {
            EventService.GameOver += OnGameOver;
        }

        Task OnGameOver()
        {

            return Task.CompletedTask;
        }
    }
}
