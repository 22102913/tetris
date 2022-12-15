using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Tetris.Data;
using Tetris.Page;
using Tetris.Sprites;

namespace Tetris
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        IPage page;
        string CurrentPage = "home";


        Texture2D BlockTexture;

        Texture2D[] ButtonTextures = new Texture2D[3];

        Texture2D TetrisBoard;
        Texture2D SnakeBoard;

        SpriteFont Font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferMultiSampling = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            BlockTexture = Content.Load<Texture2D>("block");

            ButtonTextures[0] = Content.Load<Texture2D>("Button");
            ButtonTextures[1] = Content.Load<Texture2D>("ButtonHover");
            ButtonTextures[2] = Content.Load<Texture2D>("ButtonDown");

            TetrisBoard = Content.Load<Texture2D>("TetrisBoardv1");
            SnakeBoard = Content.Load<Texture2D>("SnakeBoard");

            Font = Content.Load<SpriteFont>(@"Fonts/Font");

            page = new HomePage(ButtonTextures,Font);


        }

        protected override void Update(GameTime gameTime)
        {
            string information = "";

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var newPage = page.Update();
            if(newPage == "end")
            {
                information = page.infomation;
            }

            if (newPage != CurrentPage)
            {
                switch (newPage)
                {
                    case "tetris": page = new TetrisPage(BlockTexture,TetrisBoard,Font,ButtonTextures); CurrentPage = "tetris"; break;

                    case "snake": page = new SnakePage(BlockTexture,SnakeBoard, Font); CurrentPage = "snake";  break;

                    case "home": page = new HomePage(ButtonTextures,Font); CurrentPage = "home"; break;

                    case "end": page = new EndPage(Font, information); CurrentPage = "end"; break;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            _spriteBatch.Begin(SpriteSortMode.Deferred,null,SamplerState.PointClamp);

            page.Draw(_spriteBatch);
            
            _spriteBatch.End();
        }
    }
}