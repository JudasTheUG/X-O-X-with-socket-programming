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
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPvC_Click(object sender, EventArgs e)
        {
            this.Hide();
            PvC form = new PvC();
            form.Show();
        }

        private void btnPvP_Click(object sender, EventArgs e)
        {
            this.Hide();
            PvP form = new PvP();
            form.Show();
        }

        private void btnPZ_Click(object sender, EventArgs e)
        {
            this.Hide();
            ZamanModu form = new ZamanModu();
            form.Show();
        }

        private void btnLP_Click(object sender, EventArgs e)
        {
            this.Hide();
            LAN_PvP form = new LAN_PvP();
            form.Show();
        }

        private void btnLPZ_Click(object sender, EventArgs e)
        {
            this.Hide();
            ZamanModuLAN form = new ZamanModuLAN();
            form.Show();
        }

        private void GirisEkrani_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
