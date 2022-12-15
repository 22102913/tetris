using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Tetris.Sprites;

namespace Tetris.Page
{
    class HomePage : IPage
    {

        Button TetrisBtn;
        Button SnakeBtn;

        static string page;

        string Text = "Play";
        SpriteFont Font;

        public string infomation { get; set; }

        public HomePage(Texture2D[] ButtonTexture,SpriteFont font)
        {
            page = "home";
            Font = font;

            SnakeBtn = new Button(ButtonTexture, new Vector2(100, 200), Color.White, new Rectangle(100, 200, 128, 64), PlaySnake,"Snake", font);
            TetrisBtn = new Button(ButtonTexture, new Vector2(100, 100), Color.White, new Rectangle(100, 100, 128, 64), PlayTetris, "Tetris", font);
        }

        static public void PlayTetris() {page = "tetris";}
        static public void PlaySnake() { page = "snake"; }


        public string Update()
        {
            SnakeBtn.Update();
            TetrisBtn.Update();


            return page;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            SnakeBtn.Draw(spriteBatch);
            TetrisBtn.Draw(spriteBatch);
            spriteBatch.DrawString(Font, "Tetris", new Vector2(10,10), Color.White);



        }
    }
}
