using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TTT.Models
{
    public class Object
    {
        public Vector2 position;
        public float rotation;
        public float scale = 1;
        protected (Texture2D texture, Vector2 position) sprite;
        public readonly Vector2 spritePosition = new Vector2();

        public Object(Vector2 position, float rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }

        public void Draw(SpriteBatch spriteBatch) =>
            spriteBatch.Draw(
                this.sprite.texture,
                this.position,
                new Rectangle((16 * this.sprite.position).ToPoint(),
                (Vector2.One * 16).ToPoint()),
                Color.White,
                this.rotation,
                Vector2.One * this.scale * 8,
                Vector2.One * this.scale,
                SpriteEffects.None,
                0
            );
    }
}
