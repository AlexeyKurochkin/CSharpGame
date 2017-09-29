using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
   public class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int speedX = 0;
        public int speedY = 0;
        public int width = 4;
        public int height = 4;
        public Direction direction = Direction.Down;
        public Bitmap image;
        public void Move()
        {
            speedX = 0;
            speedY = 0;

            switch (direction)
            {
                case Direction.Up:
                    speedY = -2;
                    break;
                case Direction.Right:
                    speedX = 2;
                    break;
                case Direction.Down:
                    speedY = 2;
                    break;
                case Direction.Left:
                    speedX = -2;
                    break;
                default:
                    break;
            }

            X += speedX;
            Y += speedY;
        }
        public Bullet(BaseObject shooter) 
        {
            switch (shooter.PreviousDirection)
            {
                case Direction.Up:
                    X = shooter.X + (shooter.Width - width) / 2;
                    Y = shooter.Y;
                    direction = Direction.Up;
                    break;
                case Direction.Right:
                    X = shooter.X + shooter.Width;
                    Y = shooter.Y + (shooter.Height - height) / 2;
                    direction = Direction.Right;
                    break;
                case Direction.Down:
                    X = shooter.X + (shooter.Width - width)/ 2;
                    Y = shooter.Y + shooter.Height;
                    direction = Direction.Down;
                    break;
                case Direction.Left:
                    X = shooter.X;
                    Y = shooter.Y + (shooter.Height -height) / 2;
                    direction = Direction.Left;
                    break;
                default:
                    break;
            }
        }
        public void SelectImage()
        {
            switch (direction)
            {
                case Direction.Up:
                    image = new Bitmap(CSharpGame.Properties.Resources.bullet_up);
                    break;
                case Direction.Right:
                    image = new Bitmap(CSharpGame.Properties.Resources.bullet_right);
                    break;
                case Direction.Down:
                    image = new Bitmap(CSharpGame.Properties.Resources.bullet_down);
                    break;
                case Direction.Left:
                    image = new Bitmap(CSharpGame.Properties.Resources.bullet_left);
                    break;
                default:
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
