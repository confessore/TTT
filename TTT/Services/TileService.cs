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
        readonly IEventService eventService;

        public TileService(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public Task DebugTiles(Map map)
        {
            foreach (var tile in map.Tiles)
                Console.WriteLine($"{tile.X} {tile.Y} {tile.Occupied} {tile.Player}");
            return Task.CompletedTask;
        }

        public async Task UpdateTile(MouseState mouseState, Player player)
        {
            var s2w = TTT.ScreenToWorld(mouseState.Position.ToVector2());
            var rect = new Rectangle((int)s2w.X, (int)s2w.Y, 1, 1);
            var tile = TTT.Map.Tiles.FirstOrDefault(x => rect.Intersects(x.SpriteRectangle));
            if (tile != null && tile.Player == Player.None)
            {
                TTT.Map.Tiles.Remove(tile);
                await tile.Update(player);
                TTT.Map.Tiles.Add(tile);
                await eventService.IsGameOver(TTT.Map);
                if (player == Player.Human)
                    TTT.Turn = Player.Computer;
                else
                    TTT.Turn = Player.Human;
            }
        }
        public async Task UpdateRandomTile(Player player)
        {
            var tiles = TTT.Map.Tiles.Where(x => x.Player == Player.None);
            var tile = tiles.ElementAtOrDefault(TTT.Random.Next(0, tiles.Count()));
            if (tile != null && tile.Player == Player.None)
            {
                TTT.Map.Tiles.Remove(tile);
                await tile.Update(player);
                TTT.Map.Tiles.Add(tile);
                await eventService.IsGameOver(TTT.Map);
                if (player == Player.Computer)
                    TTT.Turn = Player.Human;
                else
                    TTT.Turn = Player.Computer;
            }
        }
    }
}
