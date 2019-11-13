using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Threading.Tasks;
using TTT.Enums;
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

        public async Task UpdateTile(MouseState mouseState)
        {
            var rect = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
            var tile = TTT.Map.Tiles.ToList().FirstOrDefault(x => rect.Intersects(x.SpriteRectangle));
            foreach (var t in TTT.Map.Tiles)
            {
                Console.WriteLine(t.position);
                Console.WriteLine(TTT.WorldToMouse(t, mouseState));
            }
            TTT.Map.Tiles.Remove(tile);
            await tile.Update(Player.Human);
            TTT.Map.Tiles.Add(tile);
        }
    }
}
