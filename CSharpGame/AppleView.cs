using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGame
{
    public class AppleView
    {
        public List<Apple> Apples;

        public AppleView(List<Apple> apples)
        {
            Apples = apples;
        }

        public void DrawApples(Graphics g)
        {
            foreach (var apple in Apples)
            {
                g.DrawImage(apple.Image, apple.Bounds());
            }
        }
    }
}
