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

        int[] SnakePos = {0,13};

        int Count = 0;

        List<int[]> Positions = new List<int[]>();

        int[] ApplePos = new int[2];

        string Direction;
        string CurrentDirection;

        uint Length;

        Texture2D BoardTexture;

        bool Died = false;



        

        Random R;

        public string infomation { get; set; }

        public SnakePage(Texture2D blockTexture, Texture2D boardTexture, SpriteFont font)
        {
            BlockTexture = blockTexture;
            BoardTexture = boardTexture;
            Font = font;
            
            R = new Random();

            Direction = "right";

            Positions.Add(SnakePos);

            Length = 1;

            ApplePos[0] = R.Next(25);
            ApplePos[1] = R.Next(25);

        }

        private void ShiftPositions(int index, int shift)
        {
            SnakePos[index] += shift;
            Positions.Add(new int[] { SnakePos[0], SnakePos[1] });
            

            while(Positions.Count > Length)
            {
                Positions.RemoveAt(0);
            }
        }

        private void MoveApple()
        {
            ApplePos[0] = R.Next(25);
            ApplePos[1] = R.Next(25);

            foreach (int[] pos in Positions)
            {
                if(pos[0] == ApplePos[0] && pos[1] == ApplePos[1])
                {
                    MoveApple();
                }
            }
        }

        public string Update()
        {
            if (Died)
            {
                Page = "end";
                infomation = "SNAKE \nScore: " + Convert.ToString(Length - 1);
                
            }



            if (Keyboard.GetState().IsKeyDown(Keys.Left) && CurrentDirection != "right")
            {
                Direction = "left";
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && CurrentDirection != "left")
            {
                Direction = "right";
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && CurrentDirection != "up")
            {
                Direction = "down";
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && CurrentDirection != "down")
            {
                Direction = "up";
                
            }

            foreach (var pos1 in Positions)
            {
                int SamePositions = 0;
                foreach(var pos2 in Positions)
                {
                    if (pos1[0] == pos2[0] && pos1[1] == pos2[1])
                    {
                        SamePositions++;
                    }
                    if(SamePositions > 1)
                    {
                        Died = true;
                    }
                    
                }
                
            }

            if (SnakePos[0] < 0 || SnakePos[0] >= 25 || SnakePos[1] < 0 || SnakePos[1] >= 25)
            {
                Died = true;
                CurrentDirection = Direction;

                switch (Direction)
                {
                    
                }

                Count = 0;
            }



            if (ApplePos[0] == SnakePos[0] && ApplePos[1] == SnakePos[1])
            {
                MoveApple();
                Length++;
                
            }



            if (Count == 5)
            {
                CurrentDirection = Direction;

                switch (Direction)
                {
                    case "left":    ShiftPositions(0, -1);break;
                    case "right":   ShiftPositions(0, 1); break;
                    case "up":      ShiftPositions(1, -1);break;
                    case "down":    ShiftPositions(1, 1); break;
                }

                Count = 0;

            }

            

            Count++;




            return Page;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            string positions = "\n";

            spriteBatch.Draw(BoardTexture, new Vector2(98,48), Color.White);

            

            spriteBatch.DrawString(Font, "Score: " + Convert.ToString(Length-1), new Vector2(10, 10), Color.White);

            spriteBatch.Draw(BlockTexture, new Vector2(ApplePos[0] * 16 + 100, ApplePos[1] * 16 + 50), null, Color.Gold, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0f);
            
            for (int i = 0; i < Positions.Count; i++)
            {
                spriteBatch.Draw(BlockTexture, new Vector2(Positions[i][0] * 16 + 100, Positions[i][1] * 16 + 50), null, Color.Purple, 0f, new Vector2(0, 0), 2f, SpriteEffects.None, 0f);

            }

        }


    }
}
