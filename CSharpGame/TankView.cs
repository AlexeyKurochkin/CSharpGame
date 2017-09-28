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
            if (tank.bullet != null)
            {
                tank.bullet.Move();
                tank.bullet.SelectImage();
                g.DrawImage(tank.bullet.image, tank.bullet.Bounds());
                if (!Collisions.BorderCollision(tank.bullet))
                {
                    tank.bullet = null;
                }
                else if (Collisions.ObjectCollision(tank.bullet, kolobok))
                {
                    tank.bullet = null;
                    kolobok.bullet = null;
                    GameSettings.gameOver = true;

                }
                else if (Collisions.ObjectCollision(tank, kolobok))
                {
                    kolobok.bullet = null;
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
