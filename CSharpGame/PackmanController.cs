using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CSharpGame
{

    public class PackmanController
    {
        public PictureBox GameArea = new PictureBox();
        public Timer DrawTimer = new Timer();
        public Kolobok KolobokMain;
        public List<Tank> Tanks;
        private int timerCount = 0;
        public GameSettings NewGameSettings;
        public Collisions CollisionsCheck;
        public TankView Tankview;
        public KolobokView Kolobokview;
        public List<Obstacle> Level;
        public List<Obstacle> EmptyPlaces;
        public List<Apple> Apples;
        public AppleView Appleview;
        public MapView Mapview;
        private MainScreen mainscreen;


        public PackmanController(MainScreen msc)
        {
            Tanks = new List<Tank>();
            StartGame();
            mainscreen = msc;
           
        }

        public void AddRequiredElements(MainScreen mainscreen)
        {
            GameArea.Size = new Size(NewGameSettings.AreaWidthPx, NewGameSettings.AreaHeightPx);
            GameArea.SizeMode = PictureBoxSizeMode.AutoSize;
            //GameArea.Paint += GameArea_Paint;

            DrawTimer.Interval = 20;
            //drawTimer.Tick += UpdateScreen;

            mainscreen.Controls.Add(GameArea);

            //DrawTimer.Start();
            
            GameArea.BackColor = Color.Brown;
        }

        public void DrawNewFrame(Graphics g)
        {
            if (KolobokMain != null)
            {
                Kolobokview.DrawKolobok(g);
            }
            if (Tankview != null)
            {
                Tankview.DrawTanks(g);
            }
            if (Mapview != null)
            {
                Mapview.DrawMap(g);
            }
            if (Appleview != null)
            {
                Appleview.DrawApples(g);
            }

        }

        public void StartGame()
        {
            NewGameSettings = new GameSettings();
            CollisionsCheck = new Collisions(NewGameSettings);
            Level = NewGameSettings.GenerateMap();
            Mapview = new MapView(Level);
            
        }
        public void StartGame(Button button)
        {
            NewGameSettings = new GameSettings();
            CollisionsCheck = new Collisions(NewGameSettings);
            Level = NewGameSettings.GenerateMap();
            Mapview = new MapView(Level);

            button.Hide();
            DrawTimer.Start();
            GameArea.Show();

            KolobokMain = null;
            Tanks.Clear();


        }

        public void EndGame()
        {

            DrawTimer.Stop();
            var arr = mainscreen.Controls.Find("newGameButton", true);
            arr[0].Show();
            
            

        }

        public void UpdateValues()
        {
            timerCount += 1;
            SpawnTanks();
            SpawnKolobok();
            SpawnApples();

            KolobokMain.SelectImage();
            CheckCollisions(KolobokMain);
            KolobokMain.Move();
            if (KolobokMain.Bullet != null)
            {
                KolobokMain.Bullet.SelectImage();
                KolobokMain.Bullet.Move();
                CheckCollisions(ref KolobokMain.Bullet, "kolobok");

            }

            foreach (var tank in Tanks)
            {
                //tank.DefineDirection(NewGameSettings.BlockSize, Level);
                if (tank != null)
                {

                tank.Shoot();
                }
                tank.SelectImage();
                tank.Move(NewGameSettings.BlockSize, Level);
                CheckCollisions(tank);
                if (tank.Bullet != null)
                {
                    tank.Bullet.SelectImage();
                    tank.Bullet.Move();
                    CheckCollisions(ref tank.Bullet, "tank");
                }
            }



            GameArea.Invalidate();
        }

        public void SpawnTanks()
        {
            if (timerCount % 80 == 0 || timerCount == 1 /*|| index == GameSettings.tanksAmount*/)
            {
                var _currentTanksAmount = NewGameSettings.TanksAmount;
                for (int i = 0; (i < _currentTanksAmount) && (i < 3); i++)
                {
                    Tanks.Add(new Tank(i, NewGameSettings));
                    NewGameSettings.TanksAmount--;
                }

            }
        }

        public void SpawnKolobok()
        {
            if (KolobokMain == null)
            {
                KolobokMain = new Kolobok(NewGameSettings);
                Kolobokview = new KolobokView(KolobokMain, Tanks);
                Tankview = new TankView(KolobokMain, Tanks);
            }
        }

        public void SpawnApples()
        {
            if (Apples == null)
            {
                Apples = new List<Apple>();
                Appleview = new AppleView(Apples);
                EmptyPlaces = Level.FindAll(e => e.Type == ObstacleType.empty);
                Random r = new Random();
                int _amount = NewGameSettings.AppleAmount;
                while (NewGameSettings.AppleAmount > 0)
                {
                var place = EmptyPlaces.ElementAt(r.Next(EmptyPlaces.Count));
                    if (CheckApplePlace(place))
                    {
                        Apples.Add(new Apple(place.X, place.Y, NewGameSettings));
                        NewGameSettings.AppleAmount--;
                    }

                }
            }
        }

        public bool CheckApplePlace(Obstacle obstacle)
        {
            int _x = (int)(obstacle.X / NewGameSettings.BlockSize);
            int _y = (int)(obstacle.Y / NewGameSettings.BlockSize);

            Obstacle obst = Level.Find(o => (o.XIndex == _x + 1) && (o.YIndex == _y));
            Obstacle obst2 = Level.Find(o => (o.XIndex == _x + 1) && (o.YIndex == _y + 1));
            Obstacle obst3 = Level.Find(o => (o.XIndex == _x) && (o.YIndex == _y + 1));
            if ((obst != null && obst2 != null))
            {
                return (obst.Type == ObstacleType.empty && obst2.Type == ObstacleType.empty && obst3.Type == ObstacleType.empty);
            }
            return false;
        }

        public void CheckCollisions(BaseObject obj)
        {
            //CollisionsCheck.HandleObstacleCollision(obj, Level);
            if (!CollisionsCheck.NoBorderCollision(obj))
            {
                switch (obj.ObjectDirection)
                {
                    case Direction.Up:
                        obj.Y += 2;
                        break;
                    case Direction.Right:
                        obj.X -= 2;
                        break;
                    case Direction.Down:
                        obj.Y -= 2;
                        break;
                    case Direction.Left:
                        obj.X += 2;
                        break;
                    default:
                        break;
                }
                obj.PreviousDirection = obj.ObjectDirection;
                obj.ObjectDirection = Direction.None;
                //obj.Reverse();
            }
            else if (obj is Tank)
            {
                if (CollisionsCheck.ObjectCollision((Tank)obj, KolobokMain))
                {
                    obj.Bullet = null;
                    KolobokMain.Bullet = null;
                    //GameSettings.gameOver = true;
                    EndGame();
                }
                else 
                {
                    foreach (var item in Tanks)
                    {
                        if (CollisionsCheck.ObjectCollision((Tank)obj, item))
                        {
                            obj.Reverse();
                            item.Reverse();
                        }
                    }
                }
            }
            else if (obj is Kolobok)
            {
                CollisionsCheck.HandleObstacleCollision(obj, Level);
            }
        }

        public void CheckCollisions(ref Bullet bullet, string type)
        {
            if (!CollisionsCheck.NoBorderCollision(bullet))
            {
                bullet = null;
            }
            
            else if (type == "kolobok")
            {
                foreach (var tank in Tanks)
                {
                    if (CollisionsCheck.ObjectCollision(bullet, tank))
                    {
                        bullet = null;
                        tank.SelectPosition(Tanks.IndexOf(tank), NewGameSettings);
                        break;
                    }
                }
                CollisionsCheck.HandleObstacleCollision(ref bullet, Level);
            }
            else if (type == "tank")
            {
                if (CollisionsCheck.ObjectCollision(bullet, KolobokMain))
                {
                    bullet = null;
                    KolobokMain.Bullet = null;
                    //GameSettings.gameOver = true;
                    EndGame();
                } else
                CollisionsCheck.HandleObstacleCollision(ref bullet, Level);
            }
        }
    }
}
