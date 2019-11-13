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
            var s2w = TTT.ScreenToWorld(mouseState.Position.ToVector2());
            var rect = new Rectangle((int)s2w.X, (int)s2w.Y, 1, 1);
            var tile = TTT.Map.Tiles.ToList().FirstOrDefault(x => rect.Intersects(x.SpriteRectangle));
            Console.WriteLine(tile != null);
            if (tile != null)
            {
                Console.WriteLine(tile.position);
                TTT.Map.Tiles.Remove(tile);
                await tile.Update(Player.Human);
                TTT.Map.Tiles.Add(tile);
            }
        }
    }
}
