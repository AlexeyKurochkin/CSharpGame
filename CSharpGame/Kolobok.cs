using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
    class Kolobok : BaseComponent
    {
        public Kolobok(int x, int y)
        {
            this.X = x/3;
            this.Y = y - Height;

            ComponentDirection = Direction.Up;
        }

        public void SelectImage()
        {
            switch (ComponentDirection)
            {
                case Direction.Up:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_up_c0_t1);
                    break;
                case Direction.Right:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_right_c0_t1);
                    break;
                case Direction.Down:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_down_c0_t1);
                    break;
                case Direction.Left:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_left_c0_t1);
                    break;
                default:
                    break;
            }
        }


    }
}

