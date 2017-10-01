using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    public class GameSettings
    {
        public int AreaWidth;
        public int AreaHeight;
        public int AreaWidthPx;
        public int AreaHeightPx;
        public int Speed;
        public int TanksAmount;
        public int AppleAmount;
        public int BlockSize;
        public int StepSize;

        public  int[,] Map;

        public GameSettings()
        {
            BlockSize = 15;
            //StepSize = BlockSize * 2;
            AreaWidth = 26;
            AreaHeight = 26;
            AreaWidthPx = AreaWidth * BlockSize;
            AreaHeightPx = AreaHeight * BlockSize;
            Speed = 20;
            TanksAmount = 5;
            AppleAmount = 5;
            Map = new int[,] {
        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,2,2,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,2,2,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0 },
        { 0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0 },
        { 1,1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,1 },
        { 2,2,0,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,2,2 },
        { 0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0 },
        { 0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,1,1,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,3,3,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,3,3,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,3,3,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,0,1,1,1,1,0,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,0,0,0,0,0,0,0,0,0,1,3,3,1,0,0,0,0,0,0,0,0,0,0,0 },
        { 0,0,0,0,0,0,0,0,0,0,0,1,3,3,1,0,0,0,0,0,0,0,0,0,0,0 }};
        }

        public List<Obstacle> GenerateMap()
        {
            List<Obstacle> mapObstacles = new List<Obstacle>();
            for (int i = 0; i < AreaHeight; i++)
            {
                for (int j = 0; j < AreaWidth; j++)

                {
                    try
                    {
                        int element = Map[i, j];
                        if (i == AreaHeight-1 || i == AreaHeight - 2)
                        {
                            element = 0;
                        }
                        mapObstacles.Add(new Obstacle(element, i, j, this));
                    }
                    catch (Exception)
                    {
                        mapObstacles.Add(new Obstacle(0, i, j, this));
                    }
                }
            }
            return mapObstacles;
        }
    }

}
