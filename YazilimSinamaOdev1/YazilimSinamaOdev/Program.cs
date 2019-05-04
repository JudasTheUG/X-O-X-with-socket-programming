using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //StreamReader ve StreamWriter sınıfları için gerek
using System.Net.Sockets; // Socket, TcpListener ve NetworkStream siniflari için
using System.Threading;
using System.Net;

namespace YazilimSinamaOdev
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GirisEkrani());


        }


    }
}



