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
            StepSize = BlockSize * 2;
            AreaWidth = 26;
            AreaHeight = 26;
            AreaWidthPx = AreaWidth * BlockSize;
            AreaHeightPx = AreaHeight * BlockSize;
            Speed = 1;
            TanksAmount = 5;
            AppleAmount = 1;
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
        { 0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,1,1,0,0,1,1,0,0,0,1,1,1,1,0,0,0,1,1,0,0,1,1,0,0 },
        { 0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 },
        { 0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0 }};
        }

        //public static List<Obstacle> GenerateObstacles(int[,] map)
        //{
        //    List<Obstacle> mapObstacles = new List<Obstacle>();
        //    for (int i = 0; i < map.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < map.GetLength(1); j++)
        //        {
        //            int element = map[i, j];
        //            mapObstacles.Add(new Obstacle(element));
        //        }
        //    }
        //    return mapObstacles;
        //}

        //public static void DrawObstacles(Graphics g, List<Obstacle> map)
        //{
        //    foreach (var element in map)
        //    {
        //        if (element.type != ObstacleType.empty)
        //        {
        //            DrawObstacle(g, element);
        //        }

        //        //foreach (var item in tanks)
        //        //{
        //        //    if (Collisions.ObjectCollision(tank, item))
        //        //    {
        //        //        tank.Reverse();
        //        //        item.Reverse();
        //        //    }
        //        //}
        //    }
        //}
        //public static void DrawObstacle(Graphics g, Obstacle obstacle)
        //{
        //    g.DrawImage(obstacle.image, obstacle.Bounds());
        //}

        public List<Obstacle> GenerateMap()
        {
            List<Obstacle> mapObstacles = new List<Obstacle>();
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    int element = Map[i, j];
                    mapObstacles.Add(new Obstacle(element, i, j, this));
                }
            }
            return mapObstacles;
        }
    }

}
