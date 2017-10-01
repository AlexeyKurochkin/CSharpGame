using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGame
{
    public partial class MainScreen : Form
    {
        public PackmanController packmancontroller;
        //Kolobok kolobok;
        //Tank tank;
        //List<Tank> tanks = new List<Tank>();
        //int enemySpawnLeft = GameSettings.tanksAmount;
        //int timerCounter = 0;
        //List<Obstacle> mapObstacles;
        
        

        public MainScreen()
        {
            InitializeComponent();
            packmancontroller = new PackmanController(this);
            packmancontroller.AddRequiredElements();
            packmancontroller.GameArea.Paint += GameArea_Paint;
            packmancontroller.DrawTimer.Tick += UpdateScreen;
            //CreateBitmapAtRuntime();
            //kolobok = new Kolobok(GameSettings.areaWidth, GameSettings.areaHeight);
            //kolobok = KolobokView.SpawnKolobok();
            //for (int i = 0; i < GameSettings.tanksAmount; i++)
            //{

            //    tanks.Add(new Tank(i));
            //    enemySpawnLeft--;
            //}

            // TankView.SpawnTank(tanks, timerCounter, enemySpawnLeft);
            //mapObstacles = GameSettings.GenerateObstacles(GameSettings.map);

            

        }
        
        //public void StartGame()
        //{
        //    newGameButton.Hide();
        //    timer1.Start();
        //    pictureBox1.Show();
        //    GameSettings.gameOver = false;
        //    //kolobok.X = GameSettings.areaWidth/3;
        //    //kolobok.Y = GameSettings.areaHeight-kolobok.height;
        //    enemySpawnLeft = GameSettings.tanksAmount;
        //    //foreach (var tank in tanks)
        //    //{
        //    //    tank.bullet = null;
        //    //    tank.SelectPosition(tanks.IndexOf(tank));
        //    //}
        //}
        //public void GameOver()
        //{
        //    timer1.Stop();
        //    newGameButton.Show();
        //    tanks.Clear();
        //    kolobok = null;
        //    timerCounter = 0;
        //}


        private void UpdateScreen(object sender, EventArgs e)
        {
            packmancontroller.UpdateValues();
            packmancontroller.CheckScore(Score);
        }

        private void GameArea_Paint(object sender, PaintEventArgs e)
        {
            //GameSettings.DrawObstacles(e.Graphics, mapObstacles);
            packmancontroller.DrawNewFrame(e.Graphics);
            //KolobokView.drawKolobok(e.Graphics, kolobok, tanks);
            //TankView.drawTanks(e.Graphics, tanks, kolobok);
            //if (GameSettings.gameOver == true)
            //{
            //    GameOver();
            //}
            //kolobok.draw(e.Graphics);
            
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Right)
                {
                packmancontroller.KolobokMain.PreviousDirection = packmancontroller.KolobokMain.ObjectDirection;
                packmancontroller.KolobokMain.ObjectDirection = Direction.Right;
                }
                if (e.KeyCode == Keys.Left)
                {
                packmancontroller.KolobokMain.PreviousDirection = packmancontroller.KolobokMain.ObjectDirection;
                packmancontroller.KolobokMain.ObjectDirection = Direction.Left;
                }
                if (e.KeyCode == Keys.Up)
                {
                packmancontroller.KolobokMain.PreviousDirection = packmancontroller.KolobokMain.ObjectDirection;
                packmancontroller.KolobokMain.ObjectDirection = Direction.Up;
                }
                if (e.KeyCode == Keys.Down)
                {
                packmancontroller.KolobokMain.PreviousDirection = packmancontroller.KolobokMain.ObjectDirection;
                packmancontroller.KolobokMain.ObjectDirection = Direction.Down;
                }
            if (e.KeyCode == Keys.Space)
            {
                packmancontroller.KolobokMain.Shoot();
            }
        }

        private void newGameButton_MouseClick(object sender, MouseEventArgs e)
        {
            packmancontroller.StartGame(newGameButton);
            Refresh();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            packmancontroller.ShowSettings(sender);
            
        }
    }
}
