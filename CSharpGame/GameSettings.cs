using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGame
{
    class GameSettings
    {
        public static int areaWidth;
        public static int areaHeight;
        public static int speed;
        public static int tanksAmount;
        public static int appleAmount;
        public static bool gameOver = true;


        public GameSettings()
        {
            areaWidth = 255;
            areaHeight = 255;
            speed = 1;
            tanksAmount = 5;
            appleAmount = 1;
        }

    }

}
