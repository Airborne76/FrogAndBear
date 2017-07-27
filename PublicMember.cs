using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace FrogAndBear
{
    public enum Screens
    {
        MenuScreen,
        PlayScreen
    }
    public static class PublicMember
    {
        public static SpriteBatch SpriteBactch { get; set; }
        public static GraphicsDevice GraphicsDevice { get; set; }
        public static Screen ChangeScreen(Screens screen)
        {
            Screen result = null;
            switch (screen)
            {
                case Screens.MenuScreen:
                    result = new MenuScreen();
                    break;
                case Screens.PlayScreen:
                    result = new PlayScreen();
                    break;
                default:
                    break;
            }
            return result;
        }
        public static Screen CurrentScreen { get; set; }
    }
}
