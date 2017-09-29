using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{

    public class Kolobok : BaseObject
    {
        public Kolobok(GameSettings NewGameSettings)
        {
            this.X = NewGameSettings.BlockSize * (NewGameSettings.AreaWidth / 3) + 1;
            this.Y = NewGameSettings.AreaWidthPx - Height;

            ObjectDirection = Direction.Up;
            image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_up_c0_t1);
        }

        public void SelectImage()
        {
            switch (ObjectDirection)
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
                    //image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_up_c0_t1);
                    break;
            }
        }


    }
}

