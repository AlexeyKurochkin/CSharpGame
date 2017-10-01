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
        public Label speedLabel = new Label();
        public ComboBox Speed = new ComboBox();
        public Label TankAmountLabel = new Label();
        public NumericUpDown TankAmount = new NumericUpDown();
        public Label AppleAmountLabel = new Label();
        public NumericUpDown AppleAmount = new NumericUpDown();
        public Label ColumnAmountLabel = new Label();
        public NumericUpDown ColumnAmount = new NumericUpDown();
        public Label RowAmountLabel = new Label();
        public NumericUpDown RowAmount = new NumericUpDown();

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
        public MainScreen Mainscreen;
        public int Scores;
        public DataView Dataview;


        public PackmanController(MainScreen msc)
        {
            Tanks = new List<Tank>();
            Apples = new List<Apple>();
            Mainscreen = msc;
            StartGame();

           
        }

        public void AddRequiredElements()
        {
            GameArea.Size = new Size(NewGameSettings.AreaWidthPx, NewGameSettings.AreaHeightPx);
            GameArea.SizeMode = PictureBoxSizeMode.AutoSize;
            Mainscreen.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Mainscreen.AutoSize = true;
            Speed.Hide();
            TankAmount.Hide();
            AppleAmount.Hide();
            ColumnAmount.Hide();
            RowAmount.Hide();



            DrawTimer.Interval = NewGameSettings.Speed;

            Mainscreen.Controls.Add(Speed);
            Mainscreen.Controls.Add(TankAmount);
            Mainscreen.Controls.Add(GameArea);
            Mainscreen.Controls.Add(AppleAmount);
            Mainscreen.Controls.Add(ColumnAmount);
            Mainscreen.Controls.Add(RowAmount);
            GameArea.BackColor = Color.Brown;
        }

        public void DrawNewFrame(Graphics g)
        {
            if (Mapview != null)
            {
                Mapview.DrawMap(g);
            }
            if (KolobokMain != null)
            {
                Kolobokview.DrawKolobok(g);
            }
            if (Tankview != null)
            {
                Tankview.DrawTanks(g);
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
            Scores = 0;
        }
        public void StartGame(Button button)
        {
            Dataview = new DataView(this);
            Dataview.Show();
            Mainscreen.Focus();
            SetSettings();
            CollisionsCheck = new Collisions(NewGameSettings);
            Level = NewGameSettings.GenerateMap();
            Mapview = new MapView(Level);

            Scores = 0;
            Apples.Clear();

            button.Hide();
            DrawTimer.Start();
            GameArea.Show();
            var settingsButton = Mainscreen.Controls.Find("SettingsButton", true);
            HideSettings((Button)settingsButton[0]);
            settingsButton[0].Hide();

            KolobokMain = null;
            Tanks.Clear();
        }

        public void EndGame()
        {
            DrawTimer.Stop();
            var arr = Mainscreen.Controls.Find("newGameButton", true);
            var arr2 = Mainscreen.Controls.Find("SettingsButton", true);
            arr[0].Show();
            arr2[0].Show();
            Dataview.Close();
        }

        public void UpdateValues()
        {

            Dataview.AddRequiredElements();
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
            CollisionsCheck.HandleApplesCollision(Apples, KolobokMain, this);

            Dataview.InitDisplayValues();

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
            if (Apples == null || !Apples.Any());
            {
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
            }
            else if (obj is Tank)
            {
                if (CollisionsCheck.ObjectCollision((Tank)obj, KolobokMain))
                {
                    obj.Bullet = null;
                    KolobokMain.Bullet = null;
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
                    EndGame();
                } else
                CollisionsCheck.HandleObstacleCollision(ref bullet, Level);
            }
        }

        public void CheckScore(Label score)
        {
            if (score.Text != Scores.ToString())
            {
                score.Text = Scores.ToString();
            }
        }

        public void ShowSettings(object sender)
        {
            Button settingsButton = sender as Button;
            if (settingsButton.Text == "Settings")
            {
                settingsButton.Text = "Settings\n(Click to hide)";

                speedLabel.Top = settingsButton.Bottom + 10;
                speedLabel.Text = "Game speed:";
                speedLabel.Width = 70;
                speedLabel.Show();
                Mainscreen.Controls.Add(speedLabel);
                Speed.Top = speedLabel.Bottom;
                Speed.Items.Add("Fast");
                Speed.Items.Add("Slow");
                Speed.SelectedIndex = 0;
                Speed.Width = speedLabel.Width;
                Speed.Show();

                
                TankAmountLabel.Top = settingsButton.Bottom + 10;
                TankAmountLabel.Left = speedLabel.Right + 10;
                TankAmountLabel.Text = "Tank amount:";
                TankAmountLabel.Width = 75;
                TankAmountLabel.Show();
                Mainscreen.Controls.Add(TankAmountLabel);
                TankAmount.Value = 5;
                TankAmount.Top = TankAmountLabel.Bottom;
                TankAmount.Left = Speed.Right + 10;
                TankAmount.Width = TankAmountLabel.Width;
                TankAmount.Show();

                
                AppleAmountLabel.Top = settingsButton.Bottom + 10;
                AppleAmountLabel.Left = TankAmountLabel.Right + 10;
                AppleAmountLabel.Text = "Apple amount:";
                AppleAmountLabel.Width = 75;
                AppleAmountLabel.Show();
                Mainscreen.Controls.Add(AppleAmountLabel);
                AppleAmount.Value = 5;
                AppleAmount.Top = AppleAmountLabel.Bottom;
                AppleAmount.Left = TankAmount.Right + 10;
                AppleAmount.Width = AppleAmountLabel.Width;
                AppleAmount.Show();

                
                ColumnAmountLabel.Top = settingsButton.Bottom + 10;
                ColumnAmountLabel.Left = AppleAmountLabel.Right + 10;
                ColumnAmountLabel.Text = "Width:";
                ColumnAmountLabel.Width = 40;
                ColumnAmountLabel.Show();
                Mainscreen.Controls.Add(ColumnAmountLabel);
                ColumnAmount.Value = 26;
                ColumnAmount.Top = ColumnAmountLabel.Bottom;
                ColumnAmount.Left = AppleAmount.Right + 10;
                ColumnAmount.Width = ColumnAmountLabel.Width;
                ColumnAmount.Show();

                
                RowAmountLabel.Top = settingsButton.Bottom + 10;
                RowAmountLabel.Left = ColumnAmountLabel.Right + 10;
                RowAmountLabel.Text = "Height:";
                RowAmountLabel.Width = 45;
                RowAmountLabel.Show();
                Mainscreen.Controls.Add(RowAmountLabel);
                RowAmount.Value = 26;
                RowAmount.Top = RowAmountLabel.Bottom;
                RowAmount.Left = ColumnAmount.Right + 10;
                RowAmount.Width = RowAmountLabel.Width;
                RowAmount.Show();
            }
            else
            {
                HideSettings(settingsButton);
            }
            Mainscreen.Refresh();
        }

        public void HideSettings(Button settingsButton)
        {
            settingsButton.Text = "Settings";
            speedLabel.Hide();
            Speed.Hide();
            TankAmountLabel.Hide();
            TankAmount.Hide();
            AppleAmountLabel.Hide();
            AppleAmount.Hide();
            ColumnAmountLabel.Hide();
            ColumnAmount.Hide();
            RowAmountLabel.Hide();
            RowAmount.Hide();
        }

        public void SetSettings()
        {
            //SaveSettingsButton.Text = "Saved successfully!";
            //NewGameSettings.Speed = int.TryParse(Speed.Text, out NewGameSettings.Speed) ? NewGameSettings.Speed : 20;
            //NewGameSettings.TanksAmount = int.TryParse(TankAmount.Text, out NewGameSettings.TanksAmount) ? NewGameSettings.TanksAmount : 5;
            NewGameSettings.TanksAmount = TankAmount.Visible ? (int)TankAmount.Value : 5;

            //NewGameSettings.AppleAmount = int.TryParse(AppleAmount.Text, out NewGameSettings.AppleAmount) ? NewGameSettings.AppleAmount : 5;
            NewGameSettings.AppleAmount = AppleAmount.Visible ? (int)AppleAmount.Value : 5;

            //NewGameSettings.AreaWidth = int.TryParse(ColumnAmount.Text, out NewGameSettings.AreaWidth) ? NewGameSettings.AreaWidth : 26;
            NewGameSettings.AreaWidth = ColumnAmount.Visible ? (int)ColumnAmount.Value : 26;
            NewGameSettings.AreaWidthPx = NewGameSettings.AreaWidth * NewGameSettings.BlockSize;

            //NewGameSettings.AreaHeight= int.TryParse(RowAmount.Text, out NewGameSettings.AreaHeight) ? NewGameSettings.AreaHeight : 26;
            NewGameSettings.AreaHeight = RowAmount.Visible ? (int)RowAmount.Value : 26;
            NewGameSettings.AreaHeightPx = NewGameSettings.AreaHeight * NewGameSettings.BlockSize;

            GameArea.Size = new Size(NewGameSettings.AreaWidthPx, NewGameSettings.AreaHeightPx);

            try
            {
                switch (Speed.SelectedItem.ToString())
                {
                    case "Fast":
                        NewGameSettings.Speed = 20;
                        break;
                    case "Slow":
                        NewGameSettings.Speed = 100;
                        break;
                    default:
                        NewGameSettings.Speed = 20;
                        break;
                }
            }
            catch (NullReferenceException)
            {
                NewGameSettings.Speed = 20;
            }
            finally
            {
                DrawTimer.Interval = NewGameSettings.Speed;
            }
            Dataview.UpdateValues(this);
        }
    }
}
