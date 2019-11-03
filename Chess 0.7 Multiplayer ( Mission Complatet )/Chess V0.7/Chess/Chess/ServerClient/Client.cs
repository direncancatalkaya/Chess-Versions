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
    public partial class Client : Form
    {
        public Client(IPEndPoint ip)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            CurrentBoard = new Board(false,this);
            CurrentBoard.NewGame();
            Panel panel1 = new Panel();
            Controls.Add(panel1);
            foreach (ChessButton VARIABLE in CurrentBoard.Squares)
            {
                panel1.Controls.Add(VARIABLE);
            }

            ipe = ip;
            panel1.Width = CurrentBoard.Squares[1, 1].Width * 8;
            panel1.Height = CurrentBoard.Squares[1, 1].Height * 8;
            Width = panel1.Width+50;
            Height = panel1.Height+50;
        }
        IPEndPoint ipe;
        public Board CurrentBoard;
        public const bool isPlayerBlack = true;

        public Socket client;
        public NetworkStream stream;
        public BinaryFormatter bf = new BinaryFormatter();
        private void Client_Load(object sender, EventArgs e)
        {

            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ipe);
            stream=new NetworkStream(client);
            Thread dinleyici = new Thread(baglantidinle);
            dinleyici.Start();
            
        }

        public void baglantidinle()
        {
            while (true)
            {
                Command alinan = (Command)bf.Deserialize(stream);
                CurrentBoard.DragDrop(alinan);
            }

        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
