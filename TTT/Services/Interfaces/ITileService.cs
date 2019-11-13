using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;
using TTT.Models;

namespace TTT.Services.Interfaces
{
    public interface ITileService
    {
        Task DebugTiles(Map map);
        Task UpdateTile(MouseState mouseState);
    }
}
