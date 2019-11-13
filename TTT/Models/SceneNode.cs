using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TTT.Models
{
    public class SceneNode
    {
        Texture2D texture;
        Vector2 worldPosition;

        public Vector2 Position
        {
            get { return worldPosition; }
            set { worldPosition = value; }
        }

        public SceneNode(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.worldPosition = position;
        }

        public void Draw(SpriteBatch renderer, Vector2 drawPosition)
        {
            renderer.Draw(texture, drawPosition, Color.White);
        }
    }
}
