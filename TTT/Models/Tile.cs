using Microsoft.Xna.Framework;
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
            this.sprite = TTT.PlayerTextures[Player];
        }

        public float X { get; set; } = new float();
        public float Y { get; set; } = new float();
        public Player Player { get; set; } = new Player();
        public bool Occupied =>
            Player != Player.None;

        public void Update(Vector2 position, Player player)
        {
            X = position.X;
            Y = position.Y;
            Player = player;
            this.sprite = TTT.PlayerTextures[Player];
        }
    }
}
