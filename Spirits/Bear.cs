using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FrogAndBear.Spirits
{
    public class Bear
    {
        public Texture2D Texture;
        public Vector2 Position;
        public SpriteEffects Direction;
        public Vector2 Center;
        public int Height
        {
            get
            {
                return Texture.Height/2;
            }
            
        }
        public int Width
        {
            get
            {
                return Texture.Width/2;
            }            
        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)(Position.X - Width/ 2), (int)(Position.Y - Height/ 2), Width, Height);
            }

        }
        public void Initialize(Texture2D texture, Vector2 position,Vector2 center)
        {
            Direction = SpriteEffects.None;
            Texture = texture;
            Position = position;
            Center = center;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Texture, Rectangle, Color.White);
            spriteBatch.Draw(Texture, Rectangle, null, Color.White, 0, Center, Direction, 1);
        }
    }
}
