using System.Threading.Tasks;
using TTT.Models;

namespace TTT.Services.Interfaces
{
    public interface IMapService
    {
        Task<Map> GenerateNewMap();
        Task<Map> UpdateMap(Map map);
    }
}
