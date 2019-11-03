using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public static bool isblack = false;
        private void button1_Click(object sender, EventArgs e)
        {
            isblack = false;
            MessageBox.Show("Rakip Beklenmeye Başlanacak .. Rakip Bağlandığında Oyun Otomatik Açılır ..");
            Server LocalGame = new Server();
            Hide();
            LocalGame.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            var addr = ipEntry.AddressList[1];

            lbl_pcname.Text = strHostName;
            lbl_ip.Text = addr.ToString();
        }

        private void btn_JoinGame_Click(object sender, EventArgs e)
        {
            isblack = true;
            IPAddress ip = IPAddress.Parse(txt_Remoteip.Text);
            IPEndPoint İpendpt = new IPEndPoint(ip,1453);
            try
            {
                Client RemoteGame = new Client(İpendpt);
                Hide();
                RemoteGame.Show();
            }
            catch (Exception exception)
            {
                // şuan anlamsız ..
                MessageBox.Show(exception.ToString());
            }
        }
    }
}
