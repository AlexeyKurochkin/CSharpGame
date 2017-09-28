using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    class TankView
    {
        public static void drawTank(Graphics g, Tank tank, Kolobok kolobok)
        {
            //tank.defineDirection();

            tank.Shoot();
            if (tank.Bullet != null)
            {
                tank.Bullet.Move();
                tank.Bullet.SelectImage();
                g.DrawImage(tank.Bullet.image, tank.Bullet.Bounds());
                if (!Collisions.BorderCollision(tank.Bullet))
                {
                    tank.Bullet = null;
                }
                else if (Collisions.ObjectCollision(tank.Bullet, kolobok))
                {
                    tank.Bullet = null;
                    kolobok.Bullet = null;
                    GameSettings.gameOver = true;

                }
                else if (Collisions.ObjectCollision(tank, kolobok))
                {
                    kolobok.Bullet = null;
                    GameSettings.gameOver = true;
                }
            }

            tank.Move();
            if (!Collisions.BorderCollision(tank))
            {
                tank.Reverse();
            }



            tank.SelectImage();
            g.DrawImage(tank.image, tank.Bounds());
        }
        public static void drawTanks(Graphics g, List<Tank> tanks, Kolobok kolobok)
        {
            foreach (var tank in tanks)
            {
                drawTank(g, tank, kolobok);
                foreach (var item in tanks)
                {
                    if (Collisions.ObjectCollision(tank, item))
                    {
                        tank.Reverse();
                        item.Reverse();
                    }
                    
                }
            }
        }

        public static void SpawnTank(List<Tank> tanks, int timerCount, ref int index)
        {
            if (timerCount % 100 == 0 || index == GameSettings.tanksAmount)
            {
                var j = index;
                for (int i = 0; (i < j) && (i < 3); i++)
                {
                    tanks.Add(new Tank(i));
                    index--;
                }
            }
        }

    }
}
