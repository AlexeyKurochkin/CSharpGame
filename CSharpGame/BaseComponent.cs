using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    public class BaseComponent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int SpeedX = 0;
        public int SpeedY = 0;
        public int Width = 28;
        public int Height = 28;
        public Direction ComponentDirection = Direction.Down;
        public Bitmap image;
        public Bullet Bullet;
        public virtual void Move()
        {
            SpeedX = 0;
            SpeedY = 0;

            switch (ComponentDirection)
            {
                case Direction.Up:
                    SpeedY = -GameSettings.speed;
                    break;
                case Direction.Right:
                    SpeedX = GameSettings.speed;
                    break;
                case Direction.Down:
                    SpeedY = GameSettings.speed;
                    break;
                case Direction.Left:
                    SpeedX = -GameSettings.speed;
                    break;
                default:
                    break;
            }

            X += SpeedX;
            Y += SpeedY;
        }
        public Rectangle Bounds()
        {
            Rectangle rect = new Rectangle(X, Y, Width, Height);
            return rect;
        }
        public void Reverse()
        {
            switch (ComponentDirection)
            {
                case Direction.Up:
                    ComponentDirection = Direction.Down;
                    break;
                case Direction.Right:
                    ComponentDirection = Direction.Left;
                    break;
                case Direction.Down:
                    ComponentDirection = Direction.Up;
                    break;
                case Direction.Left:
                    ComponentDirection = Direction.Right;
                    break;
            }
        }

        public void Shoot()
        {
            if (Bullet == null)
            {
            Bullet = new Bullet(this);
            }
        }
    }
}
