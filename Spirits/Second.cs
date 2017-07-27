using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
namespace FrogAndBear.Spirits
{
    public class Second
    {
        public Texture2D Texture;
        public Vector2 Position;
        public int Height()
        {
            return Texture.Height;
        }
        public int Width()
        {
            return Texture.Width;
        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)(Position.X - Width() / 2), (int)(Position.Y - Height() / 2), Width(), Height());
            }

        }
        public void Initialize(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle, Color.White);
        }
    }
}