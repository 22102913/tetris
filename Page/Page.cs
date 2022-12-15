using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Page
{
    interface IPage
    {
        string infomation { get; set; } 

        public string Update();

        public void Draw(SpriteBatch spriteBatch);

    }
}
