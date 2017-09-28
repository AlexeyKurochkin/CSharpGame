using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    enum Direction
    {
        up,
        right,
        down,
        left
    }
    class Kolobok : BaseComponent
    {
        public Kolobok(int x, int y)
        {
            this.X = x/3;
            this.Y = y - height;

            direction = Direction.up;
        }

        public void SelectImage()
        {
            switch (direction)
            {
                case Direction.up:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_up_c0_t1);
                    break;
                case Direction.right:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_right_c0_t1);
                    break;
                case Direction.down:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_down_c0_t1);
                    break;
                case Direction.left:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_left_c0_t1);
                    break;
                default:
                    break;
            }
        }


    }
}

