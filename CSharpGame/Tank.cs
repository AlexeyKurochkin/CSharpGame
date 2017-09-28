using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    class Tank : BaseComponent
    {


        public Tank(int x, int y)
        {
            this.X = x / 2;
            this.Y = 0;
            direction = Direction.down;
        }

        public Tank(int i)
        {
            SelectPosition(i);
            direction = Direction.down;
        }

        
        public void DefineDirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            direction = (Direction)value;
        }

        public void SelectPosition(int i)
        {
            switch (i % 3)
            {
                case 0:
                    X = 0;
                    Y = 0;
                    break;
                case 1:
                    X = GameSettings.areaWidth / 2 - width / 2;
                    Y = 0;
                    break;
                case 2:
                    X = GameSettings.areaWidth - width;
                    Y = 0;
                    break;
                default:
                    break;
            }
        }
        
        public void SelectImage()
        {
            switch (direction)
            {
                case Direction.up:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_basic_up_c0_t1);
                    break;
                case Direction.right:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_basic_right_c0_t1);
                    break;
                case Direction.down:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_basic_down_c0_t1);
                    break;
                case Direction.left:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_basic_left_c0_t1);
                    break;
                default:
                    break;
            }
        }
        
    }
}
