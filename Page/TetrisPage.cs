using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Sprites;
using System.Reflection.Metadata;
using Tetris.Data;
using Microsoft.Xna.Framework.Input;
using System.Net.Security;

namespace Tetris.Page
{
    public class TetrisPage : IPage
    {
        Texture2D BlockTexture;
        Shape shape;

        List<Block> Blocks = new List<Block>();

        string KeyPressed;

        Shape[] NextShapes = new Shape[2];

        int counter;
        string Page = "tetris";

        Texture2D Board;

        int Score;
        SpriteFont Font;

        bool Rotate = false;
        bool Rotated = false;

        int Level = 0;

        int Speed = 52;

        bool Died = false;
        bool Exit = false;

        bool Paused;

        Button PausePlayBtn;
        Button ExitBtn;

        public string infomation { get; set; }

        public TetrisPage (Texture2D blocktexture,Texture2D board,SpriteFont font,Texture2D[] buttonTexture)
        {
            

            // TODO: use this.Content to load your game content here
            
            BlockTexture = blocktexture;

            Board = board;
            Font = font;

            

            (int[][] shapeType, Color shapeColour) = ShapeTypes.Get();

            shape = new Shape(BlockTexture, shapeType, shapeColour);
            shape.StartFalling();

            (shapeType, shapeColour) = ShapeTypes.Get();
            NextShapes[0] = new Shape(BlockTexture, shapeType, shapeColour);
            NextShapes[0].MoveToNext();

            (shapeType, shapeColour) = ShapeTypes.Get();
            NextShapes[1] = new Shape(BlockTexture, shapeType, shapeColour);

            PausePlayBtn = new Button(buttonTexture, new Vector2(600, 10), Color.White, new Rectangle(600, 10, 128, 64), PausePlay, "Pause", font);
            ExitBtn = new Button(buttonTexture, new Vector2(600, 110), Color.White, new Rectangle(600, 110, 128, 64), ExitPage, "Exit", font);


        }

        public void ExitPage()
        {
            Exit = true;
        }

        public void PausePlay()
        {

            if (Paused)
            {
                Paused = false;
                PausePlayBtn.Text = "Pause";
            }
            else
            {
                Paused = true;
                PausePlayBtn.Text = "Play";
            }
        }

        public string Update()
        {
            ExitBtn.Update();
            PausePlayBtn.Update();


            if (Exit)
            {
                return "home";
            }

            if (Paused)
            {
                return Page;
            }

            if (Died)
            {
                infomation = "TETRIS \nScore: " + Convert.ToString(Score);
                return "exit";
            }

            int linesRemoved = 0;

            if(KeyPressed != null)
            {
                KeyPressed = null;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                KeyPressed = "left";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                KeyPressed = "right";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                KeyPressed = "down";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if(!Rotated)
                {
                    Rotate = true;
                    Rotated  =false;
                }
                    
                    
             }
            


            if (counter % 5 == 0)
            {
                shape.Move(Blocks, KeyPressed);
                KeyPressed = null;
                
                Rotated = false;
                if (Rotate)
                {
                    shape.Rotate(Blocks);
                    Rotated = true;
                    Rotate = false;

                }
                
            }

            if (counter == Speed)
            {
                var newBlocks = shape.Update(Blocks);

                IDictionary<int,int> setBlocks = new Dictionary<int,int>();
                List<Block> MoveDown = new List<Block>();

                


                if (newBlocks != null)
                {
                    foreach (Block block in newBlocks)
                    {
                        Blocks.Add(block);
                        if(block.Y <= (3 * 16)+50)
                        {
                            Died = true;
                            
                        }
                    }



                    (int[][] shapeType, Color shapeColour) = ShapeTypes.Get();




                    shape = NextShapes[0];
                    shape.StartFalling();

                    NextShapes[0] = NextShapes[1];
                    NextShapes[0].MoveToNext();

                    NextShapes[1] = new Shape(BlockTexture, shapeType, shapeColour);

                    


                }

                foreach(var block in Blocks)
                {
                    if (setBlocks.ContainsKey(block.Y))
                    {
                        setBlocks[block.Y] ++;
                    }
                    else
                    {
                        setBlocks.Add(block.Y, 0);
                    }
                }

                for(int i = 0; i < Blocks.Count; i++)
                {  
                    if(i == Blocks.Count)
                    {
                        break;
                    }
                    if ((setBlocks[(Blocks[i].Y)]) == 9)
                    {
                        Blocks.Remove(Blocks[i]);
                        i--;
                    }
                }

                foreach(var kvp in setBlocks.Reverse())
                {
                    if(kvp.Value == 9)
                    {
                        linesRemoved++;
                        foreach(Block block in Blocks)
                        {
                            
                            if(block.Y < kvp.Key)
                            {
                                MoveDown.Add(block);
                            }
                        }
                    }
                }

                
                
                foreach(Block block in MoveDown)
                {
                    block.Move(Blocks,"down");
                }
                
                counter = 0;
            }

            switch (linesRemoved)
            {

                case 1: Score += (Level+1) * 40; break;
                case 2: Score += (Level+1) * 100; break;
                case 3: Score += (Level+1) * 300; break;
                case 4: Score += (Level+1) * 1200; break;
            }

            if (Score > 120) { Level = 1; }
            if (Score > 300) { Level = 2; }
            if (Score > 500) { Level = 3; }
            if (Score > 900) { Level = 4; }
            if (Score > 1000) { Level = 5; }
            if (Score > 1500) { Level = 6; }
            if (Score > 3000) { Level = 7; }
            if (Score > 4200) { Level = 8; }
            if (Score > 8000) { Level = 9; }
            if (Score > 12000) { Level = 10; }
            if (Score > 16000) { Level = 11; }
            if (Score > 20000) { Level = 12; }

            Level = Score / 1000;

            Speed = (16 - Level) * 2;


            counter++;
            
            return Page;


            

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            

            spriteBatch.Draw(Board, new Vector2(98, 48), Color.White);
            foreach(var block in Blocks)
            {
                block.Draw(spriteBatch);
            }
            spriteBatch.DrawString(Font, ("Score: " + Convert.ToString(Score)), new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(Font, ("Level: " + Convert.ToString(Level)), new Vector2(250, 10), Color.White);
            //spriteBatch.DrawString(Font, ("Speed: " + Convert.ToString(Speed)), new Vector2(400, 10), Color.White);
            //spriteBatch.DrawString(Font, ("Died: " + Convert.ToString(Died)), new Vector2(600, 10), Color.White);
            shape.Draw(spriteBatch);

            NextShapes[0].Draw(spriteBatch);
            NextShapes[1].Draw(spriteBatch);

            ExitBtn.Draw(spriteBatch);
            PausePlayBtn.Draw(spriteBatch);
        }
    }
}
