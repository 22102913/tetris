using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Sprites
{
    abstract class Sprites
    {
        public Texture2D _Texture;
        public Vector2 _Position;
        public Color _Colour;
        public Rectangle _HitBox;

        public Sprites(Texture2D texture, Vector2 position, Color colour, Rectangle hitBox)
        {
            _Texture = texture;
            _Position = position;
            _Colour = colour;
            _HitBox = hitBox;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_Texture, _Position,null, _Colour,0f,new Vector2(0,0),2f,SpriteEffects.None,0f);
        }



    }
}
