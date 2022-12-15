using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Tetris.Data
{

    public class ShapeTypes
    {
        private readonly static int[][][] TypePos = new int[][][]
        {
            //square tetromino
            new int[][]{
                new int[] {0,0, 0,0, 0,0, 0,0},
                new int[] {0,1, 0,1, 0,1, 0,1},
                new int[] {1,0, 1,0, 1,0, 1,0},
                new int[] {1,1, 1,1, 1,1, 1,1},
            },
            //skew tetromino 1
            new int[][]{
                new int[] {0,0, 2,-1, 0,0, 2,-1,},
                new int[] {1,0, 2,0, 1,0, 2,0},
                new int[] {1,1, 1,0, 1,1, 1,0},
                new int[] {2,1, 1,1, 2,1, 1,1},
            },
            //skew tetromino 2
            new int[][]{
                new int[] {0,1, 1,-1, 0,1, 1,-1},
                new int[] {1,0, 1,0, 1,0, 1,0},
                new int[] {1,1, 2,0, 1,1, 2,0},
                new int[] {2,0, 2,1, 2,0, 2,1},
            },
            //L-tetromino 1
            new int[][]{
                new int[] {0,2, 0,1, 0,0, 0,0},
                new int[] {1,0, 0,2, 0,1, 1,0},
                new int[] {1,1, 1,2, 0,2, 2,0},
                new int[] {1,2, 2,2, 1,0, 2,1},
            },
            //L-tetromino 2
            new int[][]{
                new int[] {0,0, 0,0, 1,0, 0,2},
                new int[] {0,1, 0,1, 2,0, 1,2},
                new int[] {0,2, 1,0, 2,1, 2,1},
                new int[] {1,2, 2,0, 2,2, 2,2},
            },
            //T-tetromino
            new int[][]{
                new int[] {0,0, 1,0, 0,1, 0,1},
                new int[] {1,0, 1,1, 1,1, 1,0},
                new int[] {1,1, 1,2, 1,0, 1,1},
                new int[] {2,0, 2,1, 2,1, 1,2},
            },
            //Straight-tetromino
            new int[][]{
                new int[] {0,0, 1,-2, 0,0,  2,-2,},
                new int[] {1,0, 1,-1, 1,0,  2,-1,},
                new int[] {2,0, 1,0,  2,0,  2,0, },
                new int[] {3,0, 1,1,  3,0,  2,1, } ,
            } 
        };
        private readonly static Color[] Colours = new Color[] {
            Color.LightCoral,
            Color.SteelBlue,
            Color.IndianRed,
            Color.CadetBlue,
            Color.LightSeaGreen,
            Color.DarkSeaGreen,
            Color.MonoGameOrange,
            };

        public static (int[][],Color) Get()
        {
            Random random = new Random();

            var num = random.Next(0, TypePos.Length);
            
            

            return (TypePos[num], Color.BlueViolet);
        }


    }
}
