using System;
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
            Console.WriteLine("Game Over!");
            return Task.CompletedTask;
        }
    }
}
