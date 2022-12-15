using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Page
{
    public class EndPage : IPage
    {
        string Page;

        SpriteFont Font;
        public string infomation { get; set; }

        public EndPage(SpriteFont font, string _infomation)
        {
            Font = font;
            infomation = _infomation;

        }

        public string Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                Page = "home";
                return "home";
            }

            return "end";

            
        }
        
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Font, (infomation), new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(Font, "Return to exit to menu", new Vector2(100, 300), Color.White);
        }
    }
}
