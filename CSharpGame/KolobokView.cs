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

                if (kolobok.bullet != null)
                {
                    kolobok.bullet.Move();
                    kolobok.bullet.SelectImage();
                    g.DrawImage(kolobok.bullet.image, kolobok.bullet.Bounds());
                    if (!Collisions.BorderCollision(kolobok.bullet))
                    {
                        kolobok.bullet = null;
                    }
                    else
                    {
                        foreach (var tank in tanks)
                        {
                            if (Collisions.ObjectCollision(kolobok.bullet, tank))
                            {
                                kolobok.bullet = null;
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
