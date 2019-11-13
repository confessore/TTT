using Microsoft.Xna.Framework;
using System.Linq;
using System.Threading.Tasks;
using TTT.Enums;
using TTT.Models;
using TTT.Services.Interfaces;

namespace TTT.Services
{
    public class MapService : IMapService
    {
        readonly IEventService eventService;

        public MapService(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public Task<Map> GenerateNewMap()
        {
            var map = new Map(new Vector2(16, 16));
            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 3; y++)
                    map.Tiles.Add(new Tile(new Vector2(x, y)));
            return Task.FromResult(map);
        }

        public async Task<Map> UpdateMap(Map map)
        {
            //map = await ChangeMap(map);
            await eventService.IsGameOver(map);
            return map;
        }

        Task<Map> ChangeMap(Map map)
        {
            var tiles = map.Tiles.Where(x => (x.X == 2 && x.Y == 0) || (x.X == 1 && x.Y == 1) || (x.X == 0 && x.Y == 2));
            foreach (var tile in tiles.ToArray())
            {
                map.Tiles.Remove(tile);
                tile.Player = Player.Human;
                map.Tiles.Add(tile);
            }
            return Task.FromResult(map);
        }
    }
}
