using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    class Collisions
    {
        static Rectangle gameArea = new Rectangle(0, 0, GameSettings.areaWidth, GameSettings.areaHeight);

        public static bool BorderCollision(Tank tank)
        {
           return gameArea.Contains(tank.Bounds());
            
        }
        public static bool BorderCollision(Kolobok kolobok)
        {
            return gameArea.Contains(kolobok.Bounds());
        }
        public static bool BorderCollision(Bullet bullet)
        {
            return gameArea.Contains(bullet.Bounds());

        }

        public static bool ObjectCollision(Bullet bullet, Tank tank)
        {
            return (Rectangle.Intersect(bullet.Bounds(), tank.Bounds()) != Rectangle.Empty);
        }
        public static bool ObjectCollision(Bullet bullet, Kolobok kolobok)
        {
            return (Rectangle.Intersect(bullet.Bounds(), kolobok.Bounds()) != Rectangle.Empty);
        }

        public static bool ObjectCollision(Tank tank, Kolobok kolobok)
        {
            return (Rectangle.Intersect(tank.Bounds(), kolobok.Bounds()) != Rectangle.Empty);
        }
        public static bool ObjectCollision(Tank tank, Tank tank2)
        {
            return (Rectangle.Intersect(tank.Bounds(), tank2.Bounds()) != Rectangle.Empty);
        }
    }
}
