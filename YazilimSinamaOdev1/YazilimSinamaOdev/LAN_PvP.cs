using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazilimSinamaOdev
{
    public partial class LAN_PvP : Form
    {
        public Socket socket;
        public EndPoint epLocal, epRemote;
        public List<Button> buttons = new List<Button>();
        public string P1Ip, P2Ip;
        int turn = 0, returner = 0;

        public void buttonRemover(Button b)
        {
            for (int i = 0; i < buttons.Count(); i++)
            {
                if (b.Name==buttons[i].Name)
                {
                    buttons.Remove(buttons[i]);

                }
            }
            
        }

        public void lanEnabler()
        {
            for (int i = 0; i < buttons.Count(); i++)
            {
                buttons[i].Enabled = true;
            }
        }

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

        private string GetIP()  //Aynı bilgisyardan 2 farklı ekranla dene yaparken kullanılan IP alma fonksiyonu
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }

            }
            return "127.0.0.1";
        }

        public LAN_PvP()
        {
            
            InitializeComponent();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        }

        private void LAN_PvP_Load(object sender, EventArgs e)
        {
         MessageBox.Show("LAN bağlantısı ile oynamak için gerekenler : "+Environment.NewLine+"1-)Kendi IP adresinizi 1.Oyuncunun IP adresi kısmına yazınız" +
                        Environment.NewLine+"2-)Karşınızdaki oyuncunun IP adresini 2.Oyuncunun IP adresi kısmına yazınız" + Environment.NewLine+
                        "3-)1.Oyuncunun Portu yazan kısma 'X' olacak oyuncu düşük değerli port adresini,2.Oyuncunun Portu yazan kısma yüksek değerli port adresini yazar " +
                        Environment.NewLine+ "'O' olacak oyuncu ise 1.Oyuncunun Portu yazan kısma yüksek değerli IP adresini,2.Oyuncunun Portu yazan kısma düşük değerli port adresini yazar"+
                        Environment.NewLine+ "=>Örnek olarak 'X'olacak kişi 1.Oyuncunun Portu yazan kısma '88've 2.Oyuncunun Portu yazan kısma'89' yazarken"+
                        Environment.NewLine + "'O'olacak kişi 1.Oyuncunun Portu yazan kısma '89've 2.Oyuncunun Portu yazan kısma'88' yazar<="+
                        Environment.NewLine +"=>IP adresinizi öğrenmek için'windows+R' tuşlarına basıp açılan pencereye 'cmd' yazarak komut satırını açabilir" +
                        " ve 'ipconfig' komutuyla IP adresinizi öğrenebilirisiniz.");
            buttons.Add(btnKare1); buttons.Add(btnKare2); buttons.Add(btnKare3);
            buttons.Add(btnKare4); buttons.Add(btnKare5); buttons.Add(btnKare6);
            buttons.Add(btnKare7); buttons.Add(btnKare8); buttons.Add(btnKare9);
            DisableButtons();
            
        }

        private void btnOyun_Click(object sender, EventArgs e)
        {
            
            if (Convert.ToInt32(txtport1.Text) < Convert.ToInt32(txtport2.Text))
            { turn = 1; EnableGame(); }
            else if (Convert.ToInt32(txtport1.Text) > Convert.ToInt32(txtport2.Text))
                turn = 2;
            btnOyun.Enabled = false;
            Start();
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
                turn = 2;
                Send((Button)sender, button.Text);

            }

            else if (turn == 2)
            {
                button.Text = "O";
                button.ForeColor = Color.LimeGreen;
                button.Image = System.Drawing.Image.FromFile(@"o.jpg");
                Control();
                turn = 1;
                Send((Button)sender, button.Text);
            }
            if (returner == 9)
            {
                DisableButtons();
                MessageBox.Show("Berabere kaldınız.Kendinizi bir daha denemek için yeni oyun başlatın! ");
            }

            buttonRemover(button);
            queueChecker();

        }

        private void LAN_PvP_FormClosed(object sender, FormClosedEventArgs e)
        {
            GirisEkrani giris = new GirisEkrani();
            giris.Show();
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            LAN_PvP game = new LAN_PvP();
            game.Show();
            this.Hide();

        }

        private void MessageCallBack(IAsyncResult aResult)
        {

                int size = socket.EndReceiveFrom(aResult, ref epRemote);
                if (size > 0)
                {
                    byte[] receivedData = new byte[1464];
                    receivedData = (byte[])aResult.AsyncState;
                    ASCIIEncoding eEncoding = new ASCIIEncoding();
                    string receivedMessage = eEncoding.GetString(receivedData);
                    string gelenButton = receivedMessage[0].ToString() + receivedMessage[1].ToString() + receivedMessage[2].ToString() + receivedMessage[3].ToString() + 
                               receivedMessage[4].ToString()+ receivedMessage[5].ToString()+ receivedMessage[6].ToString()+ receivedMessage[7];
                    string gelenResim = receivedMessage[8].ToString();
                string gelenSıra = receivedMessage[9].ToString();

                netOynamaAktarma(gelenButton, gelenResim, gelenSıra);

                }

                byte[] buffer = new byte[1500];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

            

        }

        public void Start()
        {
            P1Ip = txtIP1.Text; //GetIP();
            P2Ip = txtIP2.Text; //GetIP();

            epLocal = new IPEndPoint(IPAddress.Parse(P1Ip), Convert.ToInt32(txtport1.Text));
                socket.Bind(epLocal);

                epRemote = new IPEndPoint(IPAddress.Parse(P2Ip), Convert.ToInt32(txtport2.Text));
                socket.Connect(epRemote);

                byte[] buffer = new byte[1500];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(MessageCallBack), buffer);

     
        }

        private void btnBilgi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("LAN bağlantısı ile oynamak için gerekenler : " + Environment.NewLine + "1-)Kendi IP adresinizi 1.Oyuncunun IP adresi kısmına yazınız" +
                        Environment.NewLine + "2-)Karşınızdaki oyuncunun IP adresini 2.Oyuncunun IP adresi kısmına yazınız" + Environment.NewLine +
                        "3-)1.Oyuncunun Portu yazan kısma 'X' olacak oyuncu düşük değerli port adresini,2.Oyuncunun Portu yazan kısma yüksek değerli port adresini yazar " +
                        Environment.NewLine + "'O' olacak oyuncu ise 1.Oyuncunun Portu yazan kısma yüksek değerli IP adresini,2.Oyuncunun Portu yazan kısma düşük değerli port adresini yazar" +
                        Environment.NewLine + "=>Örnek olarak 'X'olacak kişi 1.Oyuncunun Portu yazan kısma '88've 2.Oyuncunun Portu yazan kısma'89' yazarken" +
                        Environment.NewLine + "'O'olacak kişi 1.Oyuncunun Portu yazan kısma '89've 2.Oyuncunun Portu yazan kısma'88' yazar<=" +
                        Environment.NewLine + "=>IP adresinizi öğrenmek için'windows+R' tuşlarına basıp açılan pencereye 'cmd' yazarak komut satırını açabilir" +
                        " ve 'ipconfig' komutuyla IP adresinizi öğrenebilirisiniz.");
        }

        public void Send(Button b, string xORo)
        {
            try
            {

                string s = b.Name;
                s += xORo;
                s += returner.ToString();
                System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                byte[] msg = new byte[1500];
                msg = enc.GetBytes(s);//xyada y değeri girilecek
                socket.Send(msg);


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void netOynamaAktarma(string button,string resim,string gelenSıra)
        {

            for (int i = 0; i < buttons.Count(); i++)
            {
                if (button==buttons[i].Name)
                {
                    buttons[i].Text = resim;
                    if (resim == "X")
                    {
                        returner = Convert.ToInt32(gelenSıra);
                        turn = 2;
                        buttons[i].ForeColor = Color.Red;
                        buttons[i].Image = System.Drawing.Image.FromFile(@"x.jpg");
                        buttons[i].Enabled = false;
                        buttonRemover(buttons[i]);
                    }
                    else if (resim == "O")
                    {
                        returner = Convert.ToInt32(gelenSıra);
                        turn = 1;
                        buttons[i].ForeColor = Color.LimeGreen;
                        buttons[i].Image = System.Drawing.Image.FromFile(@"o.jpg");
                        buttons[i].Enabled = false;
                        buttonRemover(buttons[i]);
                    }
                    
                    Control();
                }
            }
            queueChecker();
        }

        public void queueChecker()
        {
            if (Convert.ToInt32(txtport1.Text)< Convert.ToInt32(txtport2.Text))
            {
                if (turn == 1)
                    lanEnabler();
                else if (turn == 2)
                    DisableButtons();
            }
            else if (Convert.ToInt32(txtport1.Text) > Convert.ToInt32(txtport2.Text))
            {
                if (turn == 1)
                    DisableButtons();
                else if (turn == 2)
                    lanEnabler();
            }
        }
    }

}
