using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Tetris.Sprites
{
    internal class Button : Sprites
    {
        MouseState PrevMouse;
        MouseState CurrentMouse;

        

        Rectangle HitBox;
        Action Command;
        Texture2D BaseTexture;
        Texture2D HoverTexture;
        Texture2D DownTexture;

        public string Text;
        SpriteFont Font;

        


        public Button(Texture2D[] texture, Vector2 position, Color colour, Rectangle hitBox, Action command, string text, SpriteFont font) : base(texture[0], position, colour, hitBox)
        {
            HitBox = hitBox;
            Command = command;

            BaseTexture = texture[0];
            HoverTexture = texture[1];
            DownTexture = texture[2];

            Text = text;
            Font = font;



        }

        public void Update()
        {
            PrevMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();


            var MouseRect = new Rectangle(CurrentMouse.X, CurrentMouse.Y, 1, 1);

            if (MouseRect.Intersects(HitBox))
            {
                if(CurrentMouse.LeftButton == ButtonState.Pressed)
                {
                    _Texture = DownTexture;
                }
                else
                {
                    _Texture = HoverTexture;
                }

                if(CurrentMouse.LeftButton == ButtonState.Released && PrevMouse.LeftButton == ButtonState.Pressed)
                {
                    Command();
                    
                }

            }
            else
            {
                _Texture = BaseTexture;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(Font, Text, new Vector2(_Position.X + (HitBox.Width/2) - (Font.MeasureString(Text).X / 2), _Position.Y + (HitBox.Height / 2) - (Font.MeasureString(Text).Y / 2)), Color.White);
        }
    }
}
