using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    public enum ObstacleType
    {
        empty,
        brick,
        concrete,
        river
    }

    class Obstacle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int width = 30;
        public int height = 30;
        public Bitmap image;
        public ObstacleType type;

        public Obstacle(int t)
        {
            
            switch ((ObstacleType)t)
            {
                case ObstacleType.empty:
                    type = ObstacleType.empty;
                    break;
                case ObstacleType.brick:
                    type = ObstacleType.brick;
                    image = new Bitmap(CSharpGame.Properties.Resources.wall_brick);
                    break;
                case ObstacleType.concrete:
                    type = ObstacleType.concrete;
                    image = new Bitmap(CSharpGame.Properties.Resources.wall_concrete);
                    break;
                case ObstacleType.river:
                    type = ObstacleType.river;
                    image = new Bitmap(CSharpGame.Properties.Resources.water_1);
                    break;
            }
        }

        public Rectangle Bounds()
        {
            Rectangle rect = new Rectangle(X, Y, width, height);
            return rect;
        }
    }
}
