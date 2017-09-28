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

        PictureBox pictureBox1 = new PictureBox();
        Timer timer1 = new Timer();
        Kolobok kolobok;
        Tank tank;
        List<Tank> tanks = new List<Tank>();
        int enemySpawnLeft = GameSettings.tanksAmount;
        int timerCounter = 0;
        List<Obstacle> mapObstacles;
        
        

        public MainScreen()
        {
            InitializeComponent();
            new GameSettings();
            AddRequiredElements();
            //CreateBitmapAtRuntime();
            //kolobok = new Kolobok(GameSettings.areaWidth, GameSettings.areaHeight);
            //kolobok = KolobokView.SpawnKolobok();
            //for (int i = 0; i < GameSettings.tanksAmount; i++)
            //{

            //    tanks.Add(new Tank(i));
            //    enemySpawnLeft--;
            //}

            // TankView.SpawnTank(tanks, timerCounter, enemySpawnLeft);
            mapObstacles = GameSettings.GenerateObstacles(GameSettings.map);

            

        }
        
        public void AddRequiredElements()
        {
            pictureBox1.Size = new Size(GameSettings.areaWidth, GameSettings.areaHeight);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Paint += pictureBox1_paint;
            // pictureBox1.Hide();

            timer1.Interval = 20;
            timer1.Tick += UpdateScreen;
            
            this.Controls.Add(pictureBox1);

            //this.components.Add(timer1);
            timer1.Start();

            pictureBox1.BackColor = Color.Brown;
        }
        public void StartGame()
        {
            newGameButton.Hide();
            timer1.Start();
            pictureBox1.Show();
            GameSettings.gameOver = false;
            //kolobok.X = GameSettings.areaWidth/3;
            //kolobok.Y = GameSettings.areaHeight-kolobok.height;
            enemySpawnLeft = GameSettings.tanksAmount;
            //foreach (var tank in tanks)
            //{
            //    tank.bullet = null;
            //    tank.SelectPosition(tanks.IndexOf(tank));
            //}
        }
        public void GameOver()
        {
            timer1.Stop();
            newGameButton.Show();
            tanks.Clear();
            kolobok = null;
            timerCounter = 0;
        }


        private void UpdateScreen(object sender, EventArgs e)
        {
            timerCounter += 1;
            if (kolobok == null)
            {
                kolobok = KolobokView.SpawnKolobok();
            }
            TankView.SpawnTank(tanks, timerCounter, ref enemySpawnLeft);
            label1.Text = "tttt";
            pictureBox1.Invalidate();
        }

        private void pictureBox1_paint(object sender, PaintEventArgs e)
        {
            //GameSettings.DrawObstacles(e.Graphics, mapObstacles);
            KolobokView.drawKolobok(e.Graphics, kolobok, tanks);
            TankView.drawTanks(e.Graphics, tanks, kolobok);
            if (GameSettings.gameOver == true)
            {
                GameOver();
            }
            //kolobok.draw(e.Graphics);
            
        }

        private void MainScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                kolobok.ComponentDirection = Direction.Right;
            }
            if (e.KeyCode == Keys.Left)
            {
                kolobok.ComponentDirection = Direction.Left;
            }
            if (e.KeyCode == Keys.Up)
            {
                kolobok.ComponentDirection = Direction.Up;
            }
            if (e.KeyCode == Keys.Down)
            {
                kolobok.ComponentDirection = Direction.Down;
            }
            if (e.KeyCode == Keys.Space)
            {
                kolobok.Shoot();
            }
        }

        private void newGameButton_MouseClick(object sender, MouseEventArgs e)
        {
            StartGame();

        }
    }
}
