using System;
using System.Threading.Tasks;
using TTT.Models;
using TTT.Services.Interfaces;

namespace TTT.Services
{
    public class TileService : ITileService
    {
        public Task DebugTiles(Map map)
        {
            foreach (var tile in map.Tiles)
                Console.WriteLine($"{tile.X} {tile.Y} {tile.Occupied} {tile.Player}");
            return Task.CompletedTask;
        }
    }
}
