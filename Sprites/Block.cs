using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Xna.Framework.Color;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using System;
using System.IO;


namespace Tetris.Sprites
{
    internal class Block : Sprites
    {
        public int X;
        public int Y;


        public Block(Texture2D texture, Vector2 position, Color colour,Rectangle hitbox):base(texture,position,colour,hitbox)
        {
            X = (int)position.X;
            Y = (int)position.Y;
        }

        public void Update()
        {
            _HitBox.X = X;
            _Position.X = X;

            _HitBox.Y = Y;
            _Position.Y = Y;
        }

        public bool CheckCollisions(List<Block> setBlocks)
        { 
            
            if(X < 0 + 100 || 9*16 + 100 < X || Y < 50 ||Y > 23 * 16 + 50)
            {
                return true;
            }

            foreach (Block setblock in setBlocks)
            {
                //string log = Convert.ToString(setblock.X/16) +" | "+ Convert.ToString(setblock.Y/16) + " | " + Convert.ToString(X/16) + " | " + Convert.ToString(Y / 16) + "\n";

                //File.AppendAllText(@"C:\Users\super\OneDrive - wqeic.ac.uk\ComputerScience\Tetris\Data\Positions.txt", log);

                if (_HitBox.Intersects(setblock._HitBox))
                {
                    return true;
                }
            }

            return false;

        }


        

        public bool Move(List<Block> setBlocks, string direction)
        {
            int distance = 0;
            
            if(direction == "left" || direction == "up")
            {
                distance = -16;
            }
            else if (direction == "right" || direction == "down")
            {
                distance = +16;
            }

            if(direction == "left" || direction == "right")
            {
                X += distance;
                _Position.X += distance;
                _HitBox.X += distance;
            }
            else if (direction == "up" || direction == "down")
            {
                Y += distance;
                _Position.Y += distance;
                _HitBox.Y += distance;
            }

            //File.AppendAllText(@"C:\Users\super\OneDrive - wqeic.ac.uk\ComputerScience\Tetris\Data\Positions.txt", "-------------------------------------------- \n");

            return CheckCollisions(setBlocks);

        }
    }
}
