using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int speedX = 0;
        public int speedY = 0;
        public int width = 4;
        public int height = 4;
        public Direction direction = Direction.down;
        public Bitmap image;
        public void Move()
        {
            speedX = 0;
            speedY = 0;

            switch (direction)
            {
                case Direction.up:
                    speedY = -GameSettings.speed*2;
                    break;
                case Direction.right:
                    speedX = GameSettings.speed*2;
                    break;
                case Direction.down:
                    speedY = GameSettings.speed*2;
                    break;
                case Direction.left:
                    speedX = -GameSettings.speed*2;
                    break;
                default:
                    break;
            }

            X += speedX;
            Y += speedY;
        }
        public Bullet(BaseComponent shooter) 
        {
            switch (shooter.direction)
            {
                case Direction.up:
                    X = shooter.X + (shooter.width - width) / 2;
                    Y = shooter.Y;
                    direction = Direction.up;
                    break;
                case Direction.right:
                    X = shooter.X + shooter.width;
                    Y = shooter.Y + (shooter.height - height) / 2;
                    direction = Direction.right;
                    break;
                case Direction.down:
                    X = shooter.X + (shooter.width - width)/ 2;
                    Y = shooter.Y + shooter.height;
                    direction = Direction.down;
                    break;
                case Direction.left:
                    X = shooter.X;
                    Y = shooter.Y + (shooter.height -height) / 2;
                    direction = Direction.left;
                    break;
                default:
                    break;
            }
        }
        public void SelectImage()
        {
            switch (direction)
            {
                case Direction.up:
                    image = new Bitmap(CSharpGame.Properties.Resources.bullet_up);
                    break;
                case Direction.right:
                    image = new Bitmap(CSharpGame.Properties.Resources.bullet_right);
                    break;
                case Direction.down:
                    image = new Bitmap(CSharpGame.Properties.Resources.bullet_down);
                    break;
                case Direction.left:
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
