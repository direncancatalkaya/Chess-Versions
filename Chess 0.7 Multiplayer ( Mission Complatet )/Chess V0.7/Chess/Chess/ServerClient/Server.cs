using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.ServerClient;

namespace Chess
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            CurrentBoard = new Board(true, this);
            CurrentBoard.NewGame();
            Panel panel1 = new Panel();
            Controls.Add(panel1);
            foreach (ChessButton VARIABLE in CurrentBoard.Squares)
            {
                panel1.Controls.Add(VARIABLE);
            }

            panel1.Width = CurrentBoard.Squares[1, 1].Width * 8;
            panel1.Height = CurrentBoard.Squares[1, 1].Height * 8;
            Width = panel1.Width + 50;
            Height = panel1.Height + 50;
        }

        public Board CurrentBoard;
        public const bool isPlayerBlack = false;
        public Socket socket;
        public NetworkStream Stream;
        public TcpListener Listener;

        private void Server_Load(object sender, EventArgs e)
        {
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            IPAddress addr = ipEntry.AddressList[1];

            
            Listener = new TcpListener(IPAddress.Any, 1453);
            Listener.Start();
            socket = Listener.AcceptSocket();
            Stream = new NetworkStream(socket);
            Thread dinle = new Thread(SoketDinle);
            dinle.Start();

           
        }

        BinaryFormatter bf = new BinaryFormatter();



        public void SoketDinle()
        {

            while (socket.Connected)
            {
                Command alinan = (Command)bf.Deserialize(Stream);
                CurrentBoard.DragDrop(alinan);
            }

        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }


}
