using System;
using System.Linq;
using System.Threading.Tasks;
using TTT.Enums;
using TTT.Models;
using TTT.Services.Interfaces;

namespace TTT.Services
{
    public class EventService : IEventService
    {
        public static event Func<Task> GameOver;

        public Task<bool> IsGameOver(Map map)
        {
            var xs = map.Tiles.GroupBy(x => x.X);
            if (xs.Any(x => x.Count(y => y.Player == Player.Human) > 2 || x.Count(y => y.Player == Player.Computer) > 2))
            {
                GameOver?.Invoke();
                return Task.FromResult(true);
            }
            var ys = map.Tiles.GroupBy(x => x.Y);
            if (ys.Any(x => x.Count(y => y.Player == Player.Human) > 2 || x.Count(y => y.Player == Player.Computer) > 2))
            {
                GameOver?.Invoke();
                return Task.FromResult(true);
            }
            var zs = map.Tiles.GroupBy(x => x.X == x.Y);
            if (zs.Any(x => x.Count(y => y.Player == Player.Human) > 2 || x.Count(y => y.Player == Player.Computer) > 2))
            {
                GameOver?.Invoke();
                return Task.FromResult(true);
            }
            var @as = map.Tiles.GroupBy(x => (x.X == 2 && x.Y == 0) || (x.X == 1 && x.Y == 1) || (x.X == 0 && x.Y == 2));
            if (@as.Any(x => x.Count(y => y.Player == Player.Human) > 2 || x.Count(y => y.Player == Player.Computer) > 2))
            {
                GameOver?.Invoke();
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
