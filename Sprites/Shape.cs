using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tetris.Sprites
{
    internal class Shape
    {
        List<Block> Blocks = new List<Block>();

        int Level;

        int Height;
        int Width;

        int[][] BlockPos;

        public int Roataion = 0;

        public int X = 0;
        public int Y = 0;

        Texture2D Texture;
        Color ShapeColour;
 
        

        public Shape(Texture2D texture, int[][] blockPos,Microsoft.Xna.Framework.Color shapeColour)
        {

            BlockPos = blockPos;


            int height = 0;
            int width = 0;

            Texture = texture;
            ShapeColour = shapeColour;

            foreach (int[] pos in BlockPos)
            {
                Blocks.Add(new Block(Texture, new Vector2(pos[0] * 16 + 400, pos[1] * 16 + 200), ShapeColour, new Rectangle(pos[0], pos[1], 16, 16)));
                if (pos[1] > Height)
                {
                    Height = pos[1];
                }
                if (pos[0] > Width)
                {
                    Width = pos[0];
                }

            }

        }

        public void StartFalling()
        {
            X = 0;
            Y = 0;

            Blocks.Clear();
            foreach(int[] pos in BlockPos)
            {
                Blocks.Add(new Block(Texture, new Vector2(pos[0] *16+100, pos[1] *16+50), ShapeColour, new Rectangle(pos[0], pos[1], 16,16 )));
                if (pos[1] > Height)
                {
                    Height = pos[1];
                }
                if (pos[0] > Width)
                {
                    Width = pos[0];
                }

            }

            Level = 23 - Width;

        }

        public void MoveToNext()
        {
            Blocks.Clear();
            foreach (int[] pos in BlockPos)
            {
                Blocks.Add(new Block(Texture, new Vector2(pos[0] * 16 + 400, pos[1] * 16 + 100), ShapeColour, new Rectangle(pos[0], pos[1], 16, 16)));
                if (pos[1] > Height)
                {
                    Height = pos[1];
                }
                if (pos[0] > Width)
                {
                    Width = pos[0];
                }
            }
        }


        public void Rotate(List<Block> setBlocks)
        {
            bool collision = false;


            if(Roataion > 3) { Roataion = 0; }

            for(int i = 0; i < 4; i++)
            {
                if(Roataion == 0)
                {
                    Blocks[i].X = (BlockPos[i][0]) * 16 + (X * 16) + 100;
                    Blocks[i].Y = BlockPos[i][1] * 16 + (Y * 16) + 50;
                }
                if (Roataion == 1)
                {
                    Blocks[i].X = (BlockPos[i][2]) * 16 + (X * 16) + 100;
                    Blocks[i].Y = BlockPos[i][3] * 16 + (Y * 16) + 50;
                }
                if (Roataion == 2)
                {
                    Blocks[i].X = (BlockPos[i][4]) * 16 + (X * 16) + 100;
                    Blocks[i].Y = BlockPos[i][5] * 16 + (Y * 16) + 50;
                }


                if (Roataion == 3)
                {
                    Blocks[i].X = (BlockPos[i][6]) * 16 + (X * 16) + 100;
                    Blocks[i].Y = BlockPos[i][7] * 16 + (Y * 16) + 50;
                }

                Blocks[i].Update();

                if (! collision && Blocks[i].CheckCollisions(setBlocks) == true)
                {
                    collision = true;
                    break;
                }


                
                


                //Blocks[i].Y = (BlockPos[i][1]) + Blocks[i].X; ;
                Blocks[i].Update();
            }

            if (collision)
            {
                Roataion -= 1;
                Rotate(setBlocks);
            }
            Roataion++;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Block block in Blocks)
            {
                block.Draw(spriteBatch);
            }
        }

        public List<Block> Update(List<Block> setBlocks)
        {
            Level--;


            if(Level < 0)
            {


                //return Blocks;
                
            }

            foreach(Block block in Blocks)
            {
                block.Update();
            }

            return Move(setBlocks, "down");
        }

        public List<Block> Move(List<Block> setBlocks, string direction)
        {
            bool collision = false;
            string oppositeDirection = "";

            switch (direction)
            {
                case "left":oppositeDirection = "right"; break;
                case "right": oppositeDirection = "left"; break;
                case "up": oppositeDirection = "down"; break;
                case "down": oppositeDirection = "up"; break;
            }


            foreach (Block block in Blocks)
            {

                if (block.Move(setBlocks,direction))
                {
                    collision = true;
                }
            }

            if (collision)
            {
                foreach (Block block in Blocks)
                {
                    block.Move(setBlocks, oppositeDirection);
                }
                return Blocks;
            }

            switch (direction)
            {
                case "left": X -=1; break;
                case "right": X += 1; break;
                case "up": Y -= 1; break;
                case "down": Y += 1; break;
            }


            return null;


        }

    }
}
