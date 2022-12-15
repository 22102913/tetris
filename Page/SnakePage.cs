using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Tetris.Page
{
    internal class SnakePage : IPage
    {
        Texture2D BlockTexture;
        SpriteFont Font;

        string Page = "snake";

        int X = 20;
        int Y = 20;

        int Count = 0;

        List<int[]> Positions= new List<int[]>();

        string Direction;


        public SnakePage(Texture2D blockTexture, SpriteFont font)
        {
            BlockTexture = blockTexture;
            Font = font;

            Direction = "right";

            Positions.Add(new int[] { X, Y });

        }
        
        private void ShiftPositions(int index, int shift)
        {
            
            foreach(int[] position in Positions)
            {
                position[index] += shift;
            }
        }

        public string Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Direction = "left";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Direction = "right";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Direction = "down";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Direction = "up";
            }



            if (Count == 20)
            {
                switch (Direction)
                {
                    case "left":    ShiftPositions(0,-1); break;
                    case "right":   ShiftPositions(0,1); break;
                    case "up":      ShiftPositions(1,-1); break;
                    case "down":    ShiftPositions(1,1); break;
                }

                Count = 0;

            }
            Count++;

            


            return Page;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(int[] position in Positions)
            {
                spriteBatch.Draw(BlockTexture, new Vector2(position[0] * 16, position[1] * 16), null, Color.Green, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0f);
            }
        }

        
    }
}
