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
        public int StepCounter;

        public Tank(GameSettings NewGameSettings)
        {
            this.X = NewGameSettings.BlockSize *  (NewGameSettings.AreaWidth / 3);
            this.Y = 0;
            PreviousDirection = Direction.Down;
            ObjectDirection = Direction.Down;
        }

        public Tank(int i, GameSettings NewGameSettings)
        {
            SelectPosition(i, NewGameSettings);
            ObjectDirection = Direction.Down;
            PreviousDirection = Direction.Down;
        }


        //public void DefineDirection(int stepSize)
        //{
        //    if ((X % stepSize * 2 == 0 && X != 0) || (Y % stepSize * 2 == 0 && Y != 0))
        //    {
        //    Random r = new Random();
        //    int value = r.Next(4);
        //    ObjectDirection = (Direction)value;

        //    }
        //}
        public void DefineDirection()
        {
            Random r = new Random();
            int value = r.Next(2);
            if (value == 0)
            {
                ObjectDirection++;
                if ((int)ObjectDirection > 3)
                {
                    ObjectDirection = (Direction)0;
                }
            }
            else
            {
                ObjectDirection--;
                if ((int)ObjectDirection < 0)
                {
                    ObjectDirection = (Direction)3;
                }
            }

            //TestStep(stepSize, map);
        }

        public bool TestStep(int stepSize, List<Obstacle> map)
        {
            int _x =(int)(X / stepSize);
            int _y = (int)(Y / stepSize);

            switch (ObjectDirection)
            {
                case Direction.Up:
                    Obstacle obst = map.Find(o => (o.XIndex == _x) && (o.YIndex == _y));
                    Obstacle obst2 = map.Find(o => (o.XIndex == _x+1) && (o.YIndex == _y));
                    if (obst != null && obst2 != null)
                    {
                        return (obst.Type == ObstacleType.empty && obst2.Type == ObstacleType.empty);
                    }
                    //if (Y > 0)
                    //{
                    //    return true;
                    //}
                    break;
                case Direction.Right:
                    obst = map.Find(o => (o.XIndex == _x+2) && (o.YIndex == _y));
                    obst2 = map.Find(o => (o.XIndex == _x + 2) && (o.YIndex == _y+1));
                    if (obst != null && obst2 != null)
                    {
                        return (obst.Type == ObstacleType.empty && obst2.Type == ObstacleType.empty);
                    }
                    break;
                case Direction.Down:
                    obst = map.Find(o => (o.XIndex == _x) && (o.YIndex == _y+2));
                    obst2 = map.Find(o => (o.XIndex == _x + 1) && (o.YIndex == _y + 2));
                    if (obst != null && obst2 != null)
                    {
                        return (obst.Type == ObstacleType.empty && obst2.Type == ObstacleType.empty);
                    }
                    break;
                case Direction.Left:
                    obst = map.Find(o => (o.XIndex == _x) && (o.YIndex == _y));
                    obst2 = map.Find(o => (o.XIndex == _x) && (o.YIndex == _y + 1));
                    if (obst != null && obst2 != null)
                    {
                        return (obst.Type == ObstacleType.empty && obst2.Type == ObstacleType.empty);
                    }
                    if (X > 0)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }

        public void Move(int stepSize, List<Obstacle> map)
        {
            switch (ObjectDirection)
            {
                case Direction.Up:
                    if (StepCounter >= 6)
                    {
                        DefineDirection();
                        StepCounter = 0;
                    }
                    if (TestStep(stepSize, map) && Y != 0)
                    {
                        Y -= 1;
                        if (Y % stepSize == 0)
                        {
                            StepCounter++;
                        }
                    }
                    else
                    {
                        DefineDirection();
                        StepCounter = 0;
                    }
                    break;
                case Direction.Right:
                    if (StepCounter >= 6)
                    {
                        DefineDirection();
                        StepCounter = 0;
                    }
                    if (TestStep(stepSize, map) )
                    {
                        X += 1;
                        if (X % stepSize == 0)
                        {
                            StepCounter++;
                        }
                    }
                    else
                    {
                        DefineDirection();
                        StepCounter = 0;
                    }
                    break;
                case Direction.Down:
                    if (StepCounter >=6 )
                    {
                        DefineDirection();
                        StepCounter = 0;
                    }
                    else if (TestStep(stepSize, map))
                    {
                        Y += 1;
                        if (Y % stepSize == 0)
                        {
                            StepCounter++;
                        }
                    }
                    else
                    {
                        DefineDirection();
                        StepCounter = 0;
                    }
                    break;
                case Direction.Left:
                    if (StepCounter >= 6)
                    {
                        DefineDirection();
                        StepCounter = 0;
                    }
                    if (TestStep(stepSize, map) && X != 0)
                    {
                        X -= 1;
                        if (X % stepSize == 0)
                        {
                            StepCounter++;
                        }
                    }
                    else
                    {
                        DefineDirection();
                        StepCounter = 0;
                    }
                    break;
            }
        }

        public void SelectPosition(int i, GameSettings NewGameSettings)
        {
            ObjectDirection = Direction.Down;
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
