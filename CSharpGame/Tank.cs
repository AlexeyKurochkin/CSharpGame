using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    public class Tank : BaseObject
    {


        public Tank(GameSettings NewGameSettings)
        {
            this.X = NewGameSettings.BlockSize *  (NewGameSettings.AreaWidth / 3);
            this.Y = 0;
            ObjectDirection = Direction.Down;
        }

        public Tank(int i, GameSettings NewGameSettings)
        {
            SelectPosition(i, NewGameSettings);
            ObjectDirection = Direction.Down;
        }

        
        public void DefineDirection(int blockSize)
        {
            if ((X % blockSize*2 == 0 && X != 0) || (Y % blockSize*2 == 0 && Y != 0))
            {
            Random r = new Random();
            int value = r.Next(4);
            ObjectDirection = (Direction)value;

            }
        }

        public void SelectPosition(int i, GameSettings NewGameSettings)
        {
            switch (i % 3)
            {
                case 0:
                    X = 0;
                    Y = 0;
                    break;
                case 1:
                    X = NewGameSettings.BlockSize * (NewGameSettings.AreaWidth / 2) - Width/2;
                    Y = 0;
                    break;
                case 2:
                    X = NewGameSettings.AreaWidthPx - Width;
                    Y = 0;
                    break;
                default:
                    break;
            }
        }
        
        public void SelectImage()
        {
            switch (ObjectDirection)
            {
                case Direction.Up:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_basic_up_c0_t1);
                    break;
                case Direction.Right:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_basic_right_c0_t1);
                    break;
                case Direction.Down:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_basic_down_c0_t1);
                    break;
                case Direction.Left:
                    image = new Bitmap(CSharpGame.Properties.Resources.tank_basic_left_c0_t1);
                    break;
                default:
                    break;
            }
        }
        
    }
}
