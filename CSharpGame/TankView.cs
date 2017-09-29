using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    public class TankView
    {
        Kolobok KolobokMain;
        List<Tank> Tanks;

        public TankView(Kolobok _kolobok, List<Tank> _tanks)
        {
            KolobokMain = _kolobok;
            Tanks = _tanks;
        }

        public void DrawTank(Graphics g, Tank tank)
        {
            g.DrawImage(tank.image, tank.Bounds());
            if (tank.Bullet != null)
            {
                g.DrawImage(tank.Bullet.image, tank.Bullet.Bounds());
            }
        }
        
        public void DrawTanks(Graphics g)
        {
            foreach (var tank in Tanks)
            {
                DrawTank(g, tank);
            }
        }
    }
}
