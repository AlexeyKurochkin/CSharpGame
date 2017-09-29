using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    public class BaseObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int SpeedX = 0;
        public int SpeedY = 0;
        public int Width = 26;
        public int Height = 26;
        public Direction ObjectDirection = Direction.Down;
        public Direction PreviousDirection = Direction.None;
        public Bitmap image;
        public Bullet Bullet;
        public virtual void Move()
        {
            SpeedX = 0;
            SpeedY = 0;
                switch (ObjectDirection)
                {
                case Direction.Up:
                    PreviousDirection = ObjectDirection;
                    SpeedX = 0;
                    SpeedY = -1;
                    break;
                case Direction.Right:
                    PreviousDirection = ObjectDirection;
                    SpeedY = 0;
                    SpeedX = 1;
                    break;
                case Direction.Down:
                    PreviousDirection = ObjectDirection;
                    SpeedX = 0;
                    SpeedY = 1;
                    break;
                case Direction.Left:
                    PreviousDirection = ObjectDirection;
                    SpeedY = 0;
                    SpeedX = -1;
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
            switch (ObjectDirection)
            {
                case Direction.Up:
                    Y += 1;
                    ObjectDirection = Direction.Down;
                    break;
                case Direction.Right:
                    X -= 1;
                    ObjectDirection = Direction.Left;
                    break;
                case Direction.Down:
                    Y -= 1;
                    ObjectDirection = Direction.Up;
                    break;
                case Direction.Left:
                    X += 1;
                    ObjectDirection = Direction.Right;
                    break;
            }
        }

        public void Shoot()
        {
            if (Bullet == null && this != null)
            {
            Bullet = new Bullet(this);
            }
        }
    }
}
