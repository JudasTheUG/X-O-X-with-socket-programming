using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazilimSinamaOdev
{
    public partial class ZamanModu : Form
    {
        int turn = 0, returner = 0;

        public void EnableGame()
        {
            btnKare1.Enabled = true;
            btnKare2.Enabled = true;
            btnKare3.Enabled = true;
            btnKare4.Enabled = true;
            btnKare5.Enabled = true;
            btnKare6.Enabled = true;
            btnKare7.Enabled = true;
            btnKare8.Enabled = true;
            btnKare9.Enabled = true;
        }

        public void DisableButtons()
        {
            btnKare1.Enabled = false;
            btnKare2.Enabled = false;
            btnKare3.Enabled = false;
            btnKare4.Enabled = false;
            btnKare5.Enabled = false;
            btnKare6.Enabled = false;
            btnKare7.Enabled = false;
            btnKare8.Enabled = false;
            btnKare9.Enabled = false;

        }

        public int Oyuncu()
        {


            if (returner % 2 == 0)
            {
                returner = 2;
            }
            else
                returner = returner % 2;

            return returner;
        }

        public void lineControl()
        {
            if ((btnKare1.Text == btnKare2.Text) && (btnKare1.Text == btnKare3.Text) && (btnKare2.Image != null))
            { timer1.Stop(); DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
            else if ((btnKare4.Text == btnKare5.Text) && (btnKare4.Text == btnKare6.Text) && (btnKare5.Image != null))
            { timer1.Stop(); DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
            else if ((btnKare7.Text == btnKare8.Text) && (btnKare7.Text == btnKare9.Text) && (btnKare8.Image != null))
            { timer1.Stop(); DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
        }

        public void columnControl()
        {
            if ((btnKare1.Text == btnKare4.Text) && (btnKare1.Text == btnKare7.Text) && (btnKare4.Image != null))
            { timer1.Stop(); DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
            else if ((btnKare2.Text == btnKare5.Text) && (btnKare2.Text == btnKare8.Text) && (btnKare5.Image != null))
            { timer1.Stop(); DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
            else if ((btnKare3.Text == btnKare6.Text) && (btnKare3.Text == btnKare9.Text) && (btnKare6.Image != null))
            { timer1.Stop(); DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
        }

        public void diagonalControl()
        {
            if ((btnKare1.Text == btnKare5.Text) && (btnKare1.Text == btnKare9.Text) && (btnKare5.Image != null))
            { timer1.Stop(); DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
            else if ((btnKare3.Text == btnKare5.Text) && (btnKare3.Text == btnKare7.Text) && (btnKare5.Image != null))
            { timer1.Stop(); DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
        }

        public void Control()
        {
            lineControl();
            columnControl();
            diagonalControl();
        }


        public ZamanModu()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(timer1_Tick);
            pbTime.ForeColor = Color.Red;
            pbTime.BackColor = Color.Blue;
        }

        private void ZamanModu_Load(object sender, EventArgs e)
        {
            pbTime.Value = 5;
            DisableButtons();
            pbTime.Maximum = 12;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (btnP1.Enabled==false)
            {
                if (pbTime.Value <= 0)
                {
                    timer1.Stop();
                    DisableButtons();
                    MessageBox.Show("2.Oyuncu Kazandı!");
                }
                else
                { pbTime.Value--; }
                
            }
            else if (btnP1.Enabled != false)
            {
                if (pbTime.Value>=10)
                {
                    timer1.Stop();
                    DisableButtons();
                    MessageBox.Show("1.Oyuncu Kazandı!");
                }
                pbTime.Value++;
            }
            
        }

        private void btnP1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000; 

            btnP1.Enabled = false;
            btnP2.Enabled = true;
            turn = 1;
        }

        private void btnP2_Click(object sender, EventArgs e)
        {
            btnP2.Enabled = false;
            btnP1.Enabled = true;
            turn = 2;
        }

        private void btnOyun_Click(object sender, EventArgs e)
        {
            EnableGame();
            btnP1.PerformClick();
            btnOyun.Enabled = false;
        }

        private void anyButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            returner++;

            if (turn == 1)
            {
                button.Text = "X";
                button.ForeColor = Color.Red;
                button.Image = System.Drawing.Image.FromFile(@"x.jpg");
                Control();
                btnP2.PerformClick();

            }
            else if (turn == 2)
            {
                button.Text = "O";
                button.ForeColor = Color.LimeGreen;
                button.Image = System.Drawing.Image.FromFile(@"o.jpg");
                Control();
                btnP1.PerformClick();
            }
            if (returner == 9)
            {
                timer1.Stop();
                DisableButtons();

                if (pbTime.Value>5)
                {
                    MessageBox.Show("Tebrikler 1. Oyuncu Kazandı !!!");
                }
                else if (pbTime.Value<5)
                {
                    MessageBox.Show("Tebrikler 2. Oyuncu Kazandı !!!");
                }
                else
                { MessageBox.Show("Berabere kaldınız.Kendinizi bir daha denemek için yeni oyun başlatın! "); }
                
                
            }

        }

        private void ZamanModu_FormClosed(object sender, FormClosedEventArgs e)
        {
            GirisEkrani giris = new GirisEkrani();
            giris.Show();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            ZamanModu game = new ZamanModu();
            game.Show();
            this.Hide();

        }

    }
}
