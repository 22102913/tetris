using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Sprites
{
    static class Text
    {

        

        public static void Write(string text, Texture2D[] font,SpriteBatch spriteBatch, Color colour) 
        {

            string FontArrangement = "0123456789:.ABCDEFGHIJKLNMOPQRSTUVWXYZ";
            int x = 0;
            int y = 0;

            foreach (char letter in text)
            {

                if (letter == '\n')
                {
                    y += 30;
                    continue;
                }

                try
                {
                    int index = FontArrangement.IndexOf(letter);
                    spriteBatch.Draw(font[index], new Vector2(x, y), colour);
                }
                catch 
                {

                    throw new NotSupportedException("text can not be written due to limited fonts");
                }

                x += 30;
            }
        }

    }
}
