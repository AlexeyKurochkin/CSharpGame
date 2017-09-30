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
    public partial class DataView : Form
    {
        PackmanController Pc;
        public List<Label> Labels;
        public List<Label> CoordinatesX;
        public List<Label> CoordinatesY;
        private int tanksAmount;

        public DataView(PackmanController pc)
        {
            InitializeComponent();
            Pc = pc;
            tanksAmount = pc.NewGameSettings.TanksAmount;
            //KolobokLabel.Hide();
            //CenterToScreen();
            //Location = new Point(pc.mainscreen.Location.X , pc.mainscreen.Location.Y);
            //Location = new Point(pc.mainscreen.Location.X + pc.mainscreen.Width, 0);
            
        }

        public void InitDisplayValues()
        {
            InitKolobok();
            InitTanks();
            InitApples();
            //KolobokX.Text = Pc.KolobokMain.X.ToString();
            //KolobokY.Text = Pc.KolobokMain.Y.ToString();
        }

        public void AddRequiredElements()
        {
            if (Labels == null)
            {
                AddNames();
            }
            if (CoordinatesX == null)
            {
                AddCoordinatesX();
            }
            if (CoordinatesY == null)
            {
                AddCoordinatesY();
            }
        }

        private void AddNames()
        {
            Labels = new List<Label>();

            Label Kolobok = new Label();
            Kolobok.Text = "Kolobok ";
            Kolobok.Top = 10;
            Kolobok.Width = 50;
            Labels.Add(Kolobok);
            this.Controls.Add(Kolobok);

            int _tanksAmount = Pc.NewGameSettings.TanksAmount;
            for (int i = 0; i < _tanksAmount; i++)
            {
                Label lab = new Label();
                try
                {
                    lab.Top = Labels.Last().Bottom;
                }
                catch (Exception)
                {
                    lab.Top = 10;
                }
                lab.Width = 50;
                lab.Text = "Tank " + (i + 1);
                Labels.Add(lab);
                this.Controls.Add(lab);
            }

            for (int i = 0; i < Pc.NewGameSettings.AppleAmount; i++)
            {
                Label lab = new Label();
                try
                {
                    lab.Top = Labels.Last().Bottom;
                }
                catch (Exception)
                {
                    lab.Top = 10;
                }
                lab.Width = 50;
                lab.Text = "Apple " + (i + 1);
                Labels.Add(lab);
                this.Controls.Add(lab);
            }
        }

        private void AddCoordinatesX()
        {
            CoordinatesX = new List<Label>();

            Label KolobokX = new Label();
            KolobokX.Text = "KolobokX ";
            KolobokX.Top = 10;
            KolobokX.Left = 60;
            KolobokX.Width = 40;
            CoordinatesX.Add(KolobokX);
            this.Controls.Add(KolobokX);

            int _tanksAmount = Pc.NewGameSettings.TanksAmount;
            for (int i = 0; i < _tanksAmount; i++)
            {
                Label lab = new Label();
                try
                {
                    lab.Top = CoordinatesX.Last().Bottom;
                }
                catch (Exception)
                {
                    lab.Top = 10;
                }
                lab.Left = 60;
                lab.Width = 40;
                lab.Text = "None " + (i + 1);
                CoordinatesX.Add(lab);
                this.Controls.Add(lab);
            }

            for (int i = 0; i < Pc.NewGameSettings.AppleAmount; i++)
            {
                Label lab = new Label();
                try
                {
                    lab.Top = CoordinatesX.Last().Bottom;
                }
                catch (Exception)
                {
                    lab.Top = 10;
                }
                lab.Left = 60;
                lab.Width = 40;
                lab.Text = "Apple " + (i + 1);
                CoordinatesX.Add(lab);
                this.Controls.Add(lab);
            }
        }

        private void AddCoordinatesY()
        {
            CoordinatesY = new List<Label>();

            Label KolobokY = new Label();
            KolobokY.Text = "KolobokY ";
            KolobokY.Top = 10;
            KolobokY.Left = 100;
            KolobokY.Width = 40;
            CoordinatesY.Add(KolobokY);
            this.Controls.Add(KolobokY);

            int _tanksAmount = Pc.NewGameSettings.TanksAmount;
            for (int i = 0; i < _tanksAmount; i++)
            {
                Label lab = new Label();
                try
                {
                    lab.Top = CoordinatesY.Last().Bottom;
                }
                catch (Exception)
                {
                    lab.Top = 10;
                }
                lab.Left = 100;
                lab.Width = 40;
                lab.Text = "None " + (i + 1);
                CoordinatesY.Add(lab);
                this.Controls.Add(lab);
            }

            for (int i = 0; i < Pc.NewGameSettings.AppleAmount; i++)
            {
                Label lab = new Label();
                try
                {
                    lab.Top = CoordinatesY.Last().Bottom;
                }
                catch (Exception)
                {
                    lab.Top = 10;
                }
                lab.Left = 100;
                lab.Width = 40;
                lab.Text = "Apple " + (i + 1);
                CoordinatesY.Add(lab);
                this.Controls.Add(lab);
            }
        }

        private void InitKolobok()
        {
            CoordinatesX.First().Text = Pc.KolobokMain.X.ToString();
            CoordinatesY.First().Text = Pc.KolobokMain.Y.ToString();
        }

        private void InitTanks()
        {
            for (int i = 0; i < Pc.Tanks.Count; i++)
            {
                CoordinatesX[i + 1].Text = Pc.Tanks[i].X.ToString();
                CoordinatesY[i + 1].Text = Pc.Tanks[i].Y.ToString();
            }
        }

        private void InitApples()
        {
            for (int i = 0; i < Pc.Apples.Count; i++)
            {
                CoordinatesX[i + 1 + tanksAmount].Text = Pc.Apples[i].X.ToString();
                CoordinatesY[i + 1 + tanksAmount].Text = Pc.Apples[i].Y.ToString();
            }
        }
    }
}
