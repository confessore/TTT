using System.Threading.Tasks;
using TTT.Models;

namespace TTT.Services.Interfaces
{
    public interface IEventService
    {
        Task<bool> IsGameOver(Map map);
    }
}
