using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;
using TTT.Enums;

namespace TTT.Models
{
    public class Tile : Object
    {
        public Tile() : base(new Vector2(), 0) { this.sprite = TTT.PlayerTextures[Player]; }

        public Tile(Vector2 position) : base(position, 0)
        {
            X = position.X;
            Y = position.Y;
            position.X += 1;
            position.Y += 1;
            position *= 16;
            this.position = position;
            this.sprite = TTT.PlayerTextures[Player];
            SpriteRectangle = new Rectangle((int)position.X - 8, (int)position.Y - 8, 16, 16);
        }

        public float X { get; set; } = new float();
        public float Y { get; set; } = new float();
        public Player Player { get; set; } = new Player();
        public bool Occupied =>
            Player != Player.None;
        public Rectangle SpriteRectangle { get; set; } = new Rectangle();

        public Task Update(Player player)
        {
            Player = player;
            this.sprite = TTT.PlayerTextures[Player];
            return Task.CompletedTask;
        }
    }
}
