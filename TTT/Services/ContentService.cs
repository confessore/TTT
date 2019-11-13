using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Threading.Tasks;
using TTT.Enums;
using TTT.Services.Interfaces;

namespace TTT.Services
{
    public class ContentService : IContentService
    {
        public Task LoadContent(ContentManager contentManager)
        {
            Texture2D boards = contentManager.Load<Texture2D>("board");
            Texture2D players = contentManager.Load<Texture2D>("sprites");
            TTT.BoardTextures = new Dictionary<Board, (Texture2D, Vector2)>
            {
                { Board.Normal, (boards, new Vector2(0, 0)) },
                { Board.Holiday, (boards, new Vector2(1, 0)) },
                { Board.Special, (boards, new Vector2(2, 0)) },
            };
            TTT.PlayerTextures = new Dictionary<Player, (Texture2D, Vector2)>
            {
                { Player.None, (players, new Vector2(0, 0)) },
                { Player.Human, (players, new Vector2(1, 0)) },
                { Player.Computer, (players, new Vector2(2, 0)) },
            };
            return Task.CompletedTask;
        }
    }
}
