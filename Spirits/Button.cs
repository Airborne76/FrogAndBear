using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace FrogAndBear.Spirits
{
    public class Button
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public int Height()
        {
            return Texture.Height;
        }
        public int Width()
        {
            return Texture.Width;
        }
        public Rectangle Rectangle()
        {
            return new Rectangle((int)(Position.X - Width() / 2), (int)(Position.Y - Height() / 2), Width(), Height());
        }
        public void Initialize(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Rectangle(), Color.White);
        }
        public bool IsClicked()
        {
            if (Mouse.GetState().LeftButton==ButtonState.Pressed)
            {
                if (Mouse.GetState().X>=Rectangle().X&& Mouse.GetState().X<=Rectangle().X+Rectangle().Width&& Mouse.GetState().Y >= Rectangle().Y && Mouse.GetState().Y <= Rectangle().Y + Rectangle().Height)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
