using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Threading;

namespace YazilimSinamaOdev
{
    public partial class PvP : Form
    {
        int turn = 0 , returner = 0;

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
            { DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
            else if ((btnKare4.Text == btnKare5.Text) && (btnKare4.Text == btnKare6.Text) && (btnKare5.Image != null))
            { DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
            else if ((btnKare7.Text == btnKare8.Text) && (btnKare7.Text == btnKare9.Text) && (btnKare8.Image != null))
            { DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
        }

        public void columnControl()
        {
            if ((btnKare1.Text == btnKare4.Text) && (btnKare1.Text == btnKare7.Text) && (btnKare4.Image != null))
            { DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
            else if ((btnKare2.Text == btnKare5.Text) && (btnKare2.Text == btnKare8.Text) && (btnKare5.Image != null))
            { DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
            else if ((btnKare3.Text == btnKare6.Text) && (btnKare3.Text == btnKare9.Text) && (btnKare6.Image != null))
            { DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
        }

        public void diagonalControl()
        {
            if ((btnKare1.Text == btnKare5.Text) && (btnKare1.Text == btnKare9.Text) && (btnKare5.Image != null))
            { DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
            else if ((btnKare3.Text == btnKare5.Text) && (btnKare3.Text == btnKare7.Text) && (btnKare5.Image != null))
            { DisableButtons(); MessageBox.Show("Tebrikler " + Oyuncu() + ". Oyuncu Kazandı !!!"); }
        }

        public void Control()
        {
            lineControl();
            columnControl();
            diagonalControl();
        }

        public PvP()
        {
            InitializeComponent();
        }

        private void PvP_Load(object sender, EventArgs e)
        {
            DisableButtons(); 
        }

        private void btnP1_Click(object sender, EventArgs e)
        {
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
            
            if (turn==1)
            {
                button.Text = "X";
                button.ForeColor = Color.Red;
                button.Image = System.Drawing.Image.FromFile(@"x.jpg");
                Control();
                btnP2.PerformClick();

            }
            else if (turn==2)
            {
                button.Text = "O";
                button.ForeColor =Color.LimeGreen;
                button.Image = System.Drawing.Image.FromFile(@"o.jpg");
                Control();
                btnP1.PerformClick();
            }
            if (returner == 9)
            {
                DisableButtons();
                MessageBox.Show("Berabere kaldınız.Kendinizi bir daha denemek için yeni oyun başlatın! ");
            }
            
        }

        private void PvP_FormClosed(object sender, FormClosedEventArgs e)
        {
            GirisEkrani giris = new GirisEkrani();
            giris.Show();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
                PvP game = new PvP();
                game.Show();
                this.Hide();

        }

    }
}
