using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FrogAndBear.Spirits;

namespace FrogAndBear
{
    public class PlayScreen:Screen
    {
        private Texture2D FrogTexture;
        private Frog Frog;
        private Bear Bear;
        private Texture2D SecondTexture;
        private List<Second> Seconds;
        private Texture2D BearTexture;
        private double TimeForSecond;
        public PlayScreen()
        {
            TimeForSecond = 0;
            FrogTexture = Game1.Frog;
            SecondTexture = Game1.Second;
            BearTexture = Game1.Bear;
            Seconds = new List<Second>();
            Frog = new Frog() { Texture=FrogTexture, Position= new Vector2() { X = 80, Y = 500 }, Center = new Vector2() { X = 0, Y = 0} ,Direction=SpriteEffects.None};
            Bear = new Bear();
            Bear.Initialize(BearTexture, new Vector2() { X = 80, Y = 90 },new Vector2() { X=0,Y=0});
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gametime)
        {
            Frog.Position.X = MathHelper.Clamp(Frog.Position.X, Frog.Width() / 2, Game1.ScreenWidth - Frog.Width() / 2);
            Frog.Position.Y = MathHelper.Clamp(Frog.Position.Y, Frog.Height() / 2, Game1.ScreenHeight - Frog.Height() / 2);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                PublicMember.CurrentScreen = PublicMember.ChangeScreen(Screens.MenuScreen);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Frog.Direction = SpriteEffects.None;
                Frog.Position.X -= 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Frog.Direction = SpriteEffects.FlipHorizontally;
                Frog.Position.X += 6;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Bear.Direction = SpriteEffects.FlipHorizontally;
            }
            if (gametime.TotalGameTime.TotalMilliseconds>=TimeForSecond+1000)
            {
                TimeForSecond = gametime.TotalGameTime.TotalMilliseconds;
                Second second = new Second();
                second.Initialize(SecondTexture, new Vector2()
                {
                    X=Game1.ran.Next(0,Game1.ScreenWidth-10),
                    Y=0
                });
                Seconds.Add(second);
            }
            if (Seconds.Count>0)
            {
                for (int i = Seconds.Count - 1; i >= 0; i--)
                {
                    Seconds[i].Position.Y += 3;
                    if (Seconds[i].Position.Y >= Game1.ScreenHeight - Seconds[i].Height() / 2|| Seconds[i].Rectangle.Intersects(Frog.Rectangle))
                    {
                        Seconds.Remove(Seconds[i]);

                    }
                }
            }
            base.Update(gametime);
        }
        public override void Draw(GameTime gametime)
        {
            PublicMember.GraphicsDevice.Clear(Color.Azure);
            PublicMember.SpriteBactch.Begin();
            if (Seconds.Count>0)
            {
                foreach (var second in Seconds)
                {
                    second.Draw(PublicMember.SpriteBactch);
                }

            }

            Frog.Draw(PublicMember.SpriteBactch);
            Bear.Draw(PublicMember.SpriteBactch);
            PublicMember.SpriteBactch.End();
            base.Draw(gametime);
        }
    }
}
