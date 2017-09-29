using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    public class KolobokView
    {
        Kolobok KolobokMain;
        List<Tank> Tanks;

        public KolobokView(Kolobok _kolobok, List<Tank> _tanks)
        {
            KolobokMain = _kolobok;
            Tanks = _tanks;
        }
        public void DrawKolobok(Graphics g)
        {
            g.DrawImage(KolobokMain.image, KolobokMain.Bounds());
            if (KolobokMain.Bullet != null && KolobokMain.Bullet.image != null)
            {
                 g.DrawImage(KolobokMain.Bullet.image, KolobokMain.Bullet.Bounds());
            }      
        }
    }
}
