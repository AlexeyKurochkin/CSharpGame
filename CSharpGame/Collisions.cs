using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CSharpGame
{
    public class Collisions
    {
        Rectangle gameArea;

        public Collisions(GameSettings NewGameSettings)
        {
            gameArea = new Rectangle(0, 0, NewGameSettings.AreaWidthPx, NewGameSettings.AreaHeightPx);
        }

        public bool NoBorderCollision(Tank tank)
        {
           return gameArea.Contains(tank.Bounds());
        }
        public bool NoBorderCollision(Kolobok kolobok)
        {
            return gameArea.Contains(kolobok.Bounds());
        }
        public bool NoBorderCollision(Bullet bullet)
        {
            return gameArea.Contains(bullet.Bounds());
        }
        public bool NoBorderCollision(BaseObject obj)
        {
            return gameArea.Contains(obj.Bounds());
        }


        public bool ObjectCollision(Bullet bullet, Tank tank)
        {
            return (Rectangle.Intersect(bullet.Bounds(), tank.Bounds()) != Rectangle.Empty);
        }
        public bool ObjectCollision(Bullet bullet, Kolobok kolobok)
        {
            return (Rectangle.Intersect(bullet.Bounds(), kolobok.Bounds()) != Rectangle.Empty);
        }
        public bool ObjectCollision(Bullet bullet, Obstacle obstacle)
        {
            return (Rectangle.Intersect(bullet.Bounds(), obstacle.Bounds()) != Rectangle.Empty);
        }

        public bool ObjectCollision(Tank tank, Kolobok kolobok)
        {
            return (Rectangle.Intersect(tank.Bounds(), kolobok.Bounds()) != Rectangle.Empty);
        }
        public bool ObjectCollision(Tank tank, Tank tank2)
        {
            return (Rectangle.Intersect(tank.Bounds(), tank2.Bounds()) != Rectangle.Empty);
        }
        //public bool ObjectCollision(Kolobok kolobok, Obstacle obstacle)
        //{
        //    return (Rectangle.Intersect(kolobok.Bounds(), obstacle.Bounds()) != Rectangle.Empty);
        //}
        //public bool ObjectCollision(Tank tank, Obstacle obstacle)
        //{
        //    return (Rectangle.Intersect(tank.Bounds(), obstacle.Bounds()) != Rectangle.Empty);
        //}
        public bool ObjectCollision(BaseObject obj, Obstacle obstacle)
        {
            return (Rectangle.Intersect(obj.Bounds(), obstacle.Bounds()) != Rectangle.Empty);
            //return obj.Bounds().IntersectsWith(obstacle.Bounds());
        }

        public void HandleObstacleCollision(ref Bullet bullet, List<Obstacle> lvl)
        {
            foreach (var obstacle in lvl)
            {
                if (bullet != null && this.ObjectCollision(bullet, obstacle))
                {
                    if (obstacle.Type == ObstacleType.brick)
                    {
                        bullet = null;
                        obstacle.Type = ObstacleType.empty;
                        break;
                    }
                    else if (obstacle.Type == ObstacleType.concrete)
                    {
                        bullet = null;
                        break;
                    }
                }
            }
        }

        public void HandleObstacleCollision(BaseObject obj, List<Obstacle> lvl)
        {
            foreach (var obstacle in lvl)
            {
                if (this.ObjectCollision(obj, obstacle))
                {
                    if (obstacle.Type != ObstacleType.empty)
                    {
                        if (obj is Kolobok)
                        {
                            switch (obj.ObjectDirection)
                            {
                                case Direction.Up:
                                    obj.Y += 1;
                                    break;
                                case Direction.Right:
                                    obj.X -= 1;
                                    break;
                                case Direction.Down:
                                    obj.Y -= 1;
                                    break;
                                case Direction.Left:
                                    obj.X += 1;
                                    break;
                            }
                            obj.PreviousDirection = obj.ObjectDirection;
                            obj.ObjectDirection = Direction.None;

                        }
                        else obj.Reverse();
                    }
                }
            }
        }
    }
}
