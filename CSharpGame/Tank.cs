﻿using System;
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
            ComponentDirection = Direction.Down;
        }

        public Tank(int i)
        {
            SelectPosition(i);
            ComponentDirection = Direction.Down;
        }

        
        public void DefineDirection()
        {
            Random r = new Random();
            int value = r.Next(4);
            ComponentDirection = (Direction)value;
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
                    X = GameSettings.areaWidth / 2 - Width / 2;
                    Y = 0;
                    break;
                case 2:
                    X = GameSettings.areaWidth - Width;
                    Y = 0;
                    break;
                default:
                    break;
            }
        }
        
        public void SelectImage()
        {
            switch (ComponentDirection)
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
