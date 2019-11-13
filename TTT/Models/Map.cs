using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TTT.Models
{
    public class Map : Object
    {
        public Map(Vector2 position) : base(position, 0)
        {
            this.sprite = TTT.BoardTextures[0];
        }

        public List<Tile> Tiles { get; set; } = new List<Tile>();
    }
}
