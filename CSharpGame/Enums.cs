using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGame
{
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left,
        None
    }

    public enum ObstacleType
    {
        empty,
        brick,
        concrete,
        river
    }
}
