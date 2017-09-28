using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    class BaseComponent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int speedX = 0;
        public int speedY = 0;
        public int width = 28;
        public int height = 28;
        public Direction direction = Direction.down;
        public Bitmap image;
        public Bullet bullet;
        public virtual void Move()
        {
            speedX = 0;
            speedY = 0;

            switch (direction)
            {
                case Direction.up:
                    speedY = -GameSettings.speed;
                    break;
                case Direction.right:
                    speedX = GameSettings.speed;
                    break;
                case Direction.down:
                    speedY = GameSettings.speed;
                    break;
                case Direction.left:
                    speedX = -GameSettings.speed;
                    break;
                default:
                    break;
            }

            X += speedX;
            Y += speedY;
        }
        public Rectangle Bounds()
        {
            Rectangle rect = new Rectangle(X, Y, width, height);
            return rect;
        }
        public void Reverse()
        {
            switch (direction)
            {
                case Direction.up:
                    direction = Direction.down;
                    break;
                case Direction.right:
                    direction = Direction.left;
                    break;
                case Direction.down:
                    direction = Direction.up;
                    break;
                case Direction.left:
                    direction = Direction.right;
                    break;
            }
        }

        public void Shoot()
        {
            if (bullet == null)
            {
            bullet = new Bullet(this);
            }
        }
    }
}
