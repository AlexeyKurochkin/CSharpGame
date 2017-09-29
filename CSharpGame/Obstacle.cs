using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{


    public class Obstacle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width;
        public int Height;
        public int XIndex;
        public int YIndex;
        public Bitmap Image;
        public ObstacleType Type;

        public Obstacle(int _type, int row, int column, GameSettings NewGameSettings)
        {
            XIndex = column;
            YIndex = row;
            X = column * NewGameSettings.BlockSize;
            Y = row * NewGameSettings.BlockSize;

            Width = NewGameSettings.BlockSize;
            Height = NewGameSettings.BlockSize;

            switch ((ObstacleType)_type)
            {
                case ObstacleType.empty:
                    Type = ObstacleType.empty;
                    break;
                case ObstacleType.brick:
                    Type = ObstacleType.brick;
                    Image = new Bitmap(CSharpGame.Properties.Resources.wall_brick);
                    break;
                case ObstacleType.concrete:
                    Type = ObstacleType.concrete;
                    Image = new Bitmap(CSharpGame.Properties.Resources.wall_concrete);
                    break;
                case ObstacleType.river:
                    Type = ObstacleType.river;
                    Image = new Bitmap(CSharpGame.Properties.Resources.water_1);
                    break;
            }
        }

        public Rectangle Bounds()
        {
            Rectangle rect = new Rectangle(X, Y, Width, Height);
            return rect;
        }
    }
}
