using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    class KolobokView
    {
        
        public static void drawKolobok(Graphics g, Kolobok kolobok, List<Tank> tanks)
        {
            if (kolobok != null)
            {

                if (kolobok.Bullet != null)
                {
                    kolobok.Bullet.Move();
                    kolobok.Bullet.SelectImage();
                    g.DrawImage(kolobok.Bullet.image, kolobok.Bullet.Bounds());
                    if (!Collisions.BorderCollision(kolobok.Bullet))
                    {
                        kolobok.Bullet = null;
                    }
                    else
                    {
                        foreach (var tank in tanks)
                        {
                            if (Collisions.ObjectCollision(kolobok.Bullet, tank))
                            {
                                kolobok.Bullet = null;
                                tank.SelectPosition(tanks.IndexOf(tank));
                                break;
                            }
                        }
                    }
                    
                }

                kolobok.Move();
                if (!Collisions.BorderCollision(kolobok))
                {
                    kolobok.Reverse();
                }

                kolobok.SelectImage();
                g.DrawImage(kolobok.image, kolobok.Bounds());           
            }
        }

        public static Kolobok SpawnKolobok()
        {
            return new Kolobok(GameSettings.areaWidth, GameSettings.areaHeight);
        }



    }
}
