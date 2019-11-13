using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TTT.Models
{
    public class Camera
    {
        public Camera(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
        }

        SpriteBatch SpriteBatch { get; set; }
        Vector2 Position { get; set; } = new Vector2();
        public float Rotation { get; set; } = new float();

        float zoom = 1f;
        public float Zoom
        {
            get => zoom;
            set { zoom = value; if (zoom < 1f) zoom = 1f; }
        }

        public void DrawNode(SceneNode sceneNode)
        {
            var drawPosition = ApplyTransformations(sceneNode.Position);
            sceneNode.Draw(SpriteBatch, drawPosition);
        }

        Vector2 ApplyTransformations(Vector2 nodePosition)
        {
            var pos = nodePosition - Position;
            Vector2 finalPosition = pos;
            return finalPosition;
        }

        public Matrix Transform(GraphicsDevice graphicsDevice, (int width, int height) windowDimensions)
        {
            var transform = Matrix.CreateTranslation(new Vector3(Position.X, Position.Y, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                Matrix.CreateTranslation(new Vector3(windowDimensions.width * 0.5f, windowDimensions.height * 0.5f, 0));
            return transform;
        }

        public void Translate(Vector2 moveVector)
        {
            Position += moveVector;
        }
    }
}