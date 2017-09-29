using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    public class MapView
    {
        List<Obstacle> Level;

        public MapView(List<Obstacle> lvl)
        {
            Level = lvl;
        }

        public void DrawMap(Graphics g)
        {
            foreach (var obstacle in Level)
            {
                if (obstacle.Type != ObstacleType.empty)
                {
                    g.DrawImage(obstacle.Image, obstacle.Bounds());
                }
            }
        }

    }
}
