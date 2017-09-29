using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGame
{
    public class Apple
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width;
        public int Height;
        public Bitmap Image = new Bitmap(CSharpGame.Properties.Resources.Apple32);
        public Apple(int x, int y, GameSettings NewGameSettings)
        {
            X = x;
            Y = y;

            Width = NewGameSettings.BlockSize*2;
            Height = NewGameSettings.BlockSize*2;
        }

        public Rectangle Bounds()
        {
            Rectangle rect = new Rectangle(X, Y, Width, Height);
            return rect;
        }
    }
}
