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
            this.Y = NewGameSettings.AreaHeightPx - Height;

            ObjectDirection = Direction.Up;
            image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_up_c0_t1);
        }

        public void SelectImage()
        {
            switch (ObjectDirection)
            {
                case Direction.Up:
                    image = new Bitmap(CSharpGame.Properties.Resources.kolobok1_up);
                    break;
                case Direction.Right:
                    image = new Bitmap(CSharpGame.Properties.Resources.kolobok1_right);
                    break;
                case Direction.Down:
                    image = new Bitmap(CSharpGame.Properties.Resources.kolobok1_down);
                    break;
                case Direction.Left:
                    image = new Bitmap(CSharpGame.Properties.Resources.kolobok1_left);
                    break;
                default:
                    //image = new Bitmap(CSharpGame.Properties.Resources.tank_player1_up_c0_t1);
                    break;
            }
        }


    }
}

