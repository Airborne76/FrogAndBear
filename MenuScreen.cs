using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FrogAndBear.Spirits;
using System.Diagnostics;

namespace FrogAndBear
{
    public class MenuScreen:Screen
    {
        private Texture2D ButtonStartTexture;
        private Texture2D ButtonExitTexture;
        private Button ButtonStart;
        private Button ButtonExit;
        public MenuScreen()
        {
            ButtonStartTexture = Game1.ButtonStart;
            ButtonExitTexture = Game1.ButtonExit;
            ButtonStart = new Button() { Texture = ButtonStartTexture, Position = new Vector2() { X=200, Y=300 } };
            ButtonExit = new Button() { Texture = ButtonExitTexture, Position = new Vector2() { X = 600, Y = 300 } };
        }
        public override void Initialize()
        {

            base.Initialize();
        }        
        public override void Update(GameTime gametime)
        {
            if (ButtonStart.IsClicked())
            {
              PublicMember.CurrentScreen= PublicMember.ChangeScreen(Screens.PlayScreen);                
            }
            if (ButtonExit.IsClicked())
            {
                Process.GetCurrentProcess().Kill();
            }
            base.Update(gametime);
        }
        public override void Draw(GameTime gametime)
        {
            PublicMember.GraphicsDevice.Clear(Color.Aqua);
            PublicMember.SpriteBactch.Begin();
            ButtonStart.Draw(PublicMember.SpriteBactch);
            ButtonExit.Draw(PublicMember.SpriteBactch);
            PublicMember.SpriteBactch.End();
            base.Draw(gametime);
        }
    }
}
