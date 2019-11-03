using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Chess.ServerClient;

namespace Chess
{

    public class Board
    {
        public Board()
        {
            int Top = SquareWidth * 7;
            int Left = 0;
            int index = 0;
            for (int i = 0; i < 8; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    Squares[i, j] = new ChessButton();
                    Squares[i, j].Dolumu = false;
                    Squares[i, j].ChessBoard = this;
                    Squares[i, j].X = j;
                    Squares[i, j].Y = i;
                    Squares[i, j].AllowDrop = true;
                    Squares[i, j].MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChessButton_MouseDown);
                    Squares[i, j].DragDrop += new System.Windows.Forms.DragEventHandler(this.chessButton_DragDrop);
                    Squares[i, j].DragEnter += new System.Windows.Forms.DragEventHandler(this.chessButton_DragEnter);
                    Squares[i, j].Width = SquareWidth;
                    Squares[i, j].Height = SquareHeight;
                    Squares[i, j].Left = Left;
                    Squares[i, j].Top = Top;
                    Squares[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                    Squares[i, j].BackColor = index % 2 == 0 ? Color.Gray : Color.White;
                    Left += SquareWidth;
                    index++;
                }
                Top -= SquareWidth;
                Left = 0;
                index++;
            }
        }
        public Board(bool server, Form asd)
        {
           
           
                if (server)
                {
                    Server = (Server)asd;

                    int Top = SquareWidth * 7;
                    int Left = 0;
                    int index = 0;
                    for (int i = 0; i < 8; i++)
                    {

                        for (int j = 0; j < 8; j++)
                        {
                            Squares[i, j] = new ChessButton();
                            Squares[i, j].Dolumu = false;
                            Squares[i, j].ChessBoard = this;
                            Squares[i, j].X = j;
                            Squares[i, j].Y = i;
                            Squares[i, j].AllowDrop = true;
                            Squares[i, j].MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChessButton_MouseDown);
                            Squares[i, j].DragDrop += new System.Windows.Forms.DragEventHandler(this.chessButton_DragDrop);
                            Squares[i, j].DragEnter += new System.Windows.Forms.DragEventHandler(this.chessButton_DragEnter);
                            Squares[i, j].Width = SquareWidth;
                            Squares[i, j].Height = SquareHeight;
                            Squares[i, j].Left = Left;
                            Squares[i, j].Top = Top;
                            Squares[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                            Squares[i, j].BackColor = index % 2 == 0 ? Color.Gray : Color.White;
                            Left += SquareWidth;
                            index++;
                        }
                        Top -= SquareWidth;
                        Left = 0;
                        index++;
                    }
            }

                if (!server)
                {
                    Client = (Client)asd;

                    int Top = SquareWidth * 7;
                    int Left = 0;
                    int index = 0;
                    for (int i = 8 - 1; i >= 0; i--)
                    {

                        for (int j = 0; j < 8; j++)
                        {
                            Squares[i, j] = new ChessButton();
                            Squares[i, j].Dolumu = false;
                            Squares[i, j].ChessBoard = this;
                            Squares[i, j].X = j;
                            Squares[i, j].Y = i;
                            Squares[i, j].AllowDrop = true;
                            Squares[i, j].MouseDown += new System.Windows.Forms.MouseEventHandler(this.ChessButton_MouseDown);
                            Squares[i, j].DragDrop += new System.Windows.Forms.DragEventHandler(this.chessButton_DragDrop);
                            Squares[i, j].DragEnter += new System.Windows.Forms.DragEventHandler(this.chessButton_DragEnter);
                            Squares[i, j].Width = SquareWidth;
                            Squares[i, j].Height = SquareHeight;
                            Squares[i, j].Left = Left;
                            Squares[i, j].Top = Top;
                            Squares[i, j].BackgroundImageLayout = ImageLayout.Zoom;
                            Squares[i, j].BackColor = index % 2 == 0 ? Color.Gray : Color.White;
                            Left += SquareWidth;
                            index++;
                        }
                        Top -= SquareWidth;
                        Left = 0;
                        index++;
                    }
            }
                
            
        }

        public ChessButton[,] Squares = new ChessButton[8, 8]; // Tahtadaki Kareleri Listesi
        public List<Tas> MevcutTaslar = new List<Tas>();  // Tahta Üzerinde Olan Tüm Taşları Bu diziye attım. Foreach için !
        public List<Kordinat> WhiteAttacks = new List<Kordinat>(); // Beyazların Tehdit Ettiği Kareler.
        public List<Kordinat> BlackAttacks = new List<Kordinat>(); // Siyahların Tehdit Ettiği Kareler .
        public List<Player> Spectators = new List<Player>(); // tahtayı İzleyen oyuncuların listesi.
        public Sah BeyazSah = null;
        public Sah SiyahSah = null;
        public bool TurnOfBlack = false; // Oyuncu Sırası .. True ise Sıra Siyahtadır .. Oyun başlangıcında Beyaz Başlar !
        public const int SquareWidth = 70; // Tahtada Oluşturulan Karelerin Genişliği İçin Sabit.
        public const int SquareHeight = 70; // Tahtada Oluşturulan Karelerin Yüksekliği için sabit.
        public string GameName { get; set; }
        public string CreatingTime { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Server Server;
        public Client Client;

        #region Tahta Metodları

        public override string ToString()
        {
            return GameName + " ( Created at : " + CreatingTime + ")";
        }

        public void CreateTas(ChessButton button, TasTipi tipi, bool renk, Tasİd tasid) // Tahta Üzerinde Combobox dan seçilen taşı Oluşturur  !!
        {

            TasTipi tip = tipi; //(TasTipi)cmb_tastipi.SelectedItem


            switch (tip)
            {
                case TasTipi.Kale:
                    Kale Kale = new Kale(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid, ChessBoard = this };
                    button.Tas = Kale;
                    button.Dolumu = true;
                    MevcutTaslar.Add(Kale);

                    break;
                case TasTipi.Sah:
                    Sah sah = new Sah(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid, ChessBoard = this };
                    button.Tas = sah;
                    MevcutTaslar.Add(sah);
                    button.Dolumu = true;
                    if (renk) SiyahSah = sah;
                    if (!renk) BeyazSah = sah;

                    break;
                case TasTipi.Piyon:
                    Piyon piyon = new Piyon(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid, ChessBoard = this };
                    button.Tas = piyon;
                    MevcutTaslar.Add(piyon);
                    button.Dolumu = true;
                    break;
                case TasTipi.Fil:
                    Fil fil = new Fil(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid, ChessBoard = this };
                    button.Tas = fil;
                    MevcutTaslar.Add(fil);
                    button.Dolumu = true;

                    break;
                case TasTipi.At:
                    At at = new At(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid, ChessBoard = this };
                    button.Tas = at;
                    MevcutTaslar.Add(at);
                    button.Dolumu = true;

                    break;
                case TasTipi.Vezir:
                    Vezir vezir = new Vezir(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid, ChessBoard = this };
                    button.Tas = vezir;
                    MevcutTaslar.Add(vezir);
                    button.Dolumu = true;

                    break;
            }



            button.GetBackgroundİmage();

        }
        /// <summary>
        /// tahtayı İlk Baştaki Haline Boyar
        /// </summary>
        public void PaintBoard()
        {
            int index = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Squares[i, j].BackColor = index % 2 == 0 ? Color.Gray : Color.White;
                    index++;
                }

                index++;
            }
        }

        public void NewGame()
        {
            MevcutTaslar.Clear();
            WhiteAttacks.Clear();
            BlackAttacks.Clear();
            TurnOfBlack = false;
            foreach (ChessButton VARIABLE in Squares)
            {
                VARIABLE.Tas = null;
                VARIABLE.Dolumu = false;
                VARIABLE.GetBackgroundİmage();
            }
            CreateTas(Squares[7, 0], TasTipi.Kale, true, Tasİd.SiyahUzunKale);
            CreateTas(Squares[7, 1], TasTipi.At, true, Tasİd.Diger);
            CreateTas(Squares[7, 2], TasTipi.Fil, true, Tasİd.Diger);
            CreateTas(Squares[7, 3], TasTipi.Vezir, true, Tasİd.Diger);
            CreateTas(Squares[7, 4], TasTipi.Sah, true, Tasİd.SiyahSah);
            CreateTas(Squares[7, 5], TasTipi.Fil, true, Tasİd.Diger);
            CreateTas(Squares[7, 6], TasTipi.At, true, Tasİd.Diger);
            CreateTas(Squares[7, 7], TasTipi.Kale, true, Tasİd.SiyahKisaKale);
            CreateTas(Squares[6, 0], TasTipi.Piyon, true, Tasİd.Diger);
            CreateTas(Squares[6, 1], TasTipi.Piyon, true, Tasİd.Diger);
            CreateTas(Squares[6, 2], TasTipi.Piyon, true, Tasİd.Diger);
            CreateTas(Squares[6, 3], TasTipi.Piyon, true, Tasİd.Diger);
            CreateTas(Squares[6, 4], TasTipi.Piyon, true, Tasİd.Diger);
            CreateTas(Squares[6, 5], TasTipi.Piyon, true, Tasİd.Diger);
            CreateTas(Squares[6, 6], TasTipi.Piyon, true, Tasİd.Diger);
            CreateTas(Squares[6, 7], TasTipi.Piyon, true, Tasİd.Diger);

            CreateTas(Squares[0, 0], TasTipi.Kale, false, Tasİd.BeyazUzunKale);
            CreateTas(Squares[0, 1], TasTipi.At, false, Tasİd.Diger);
            CreateTas(Squares[0, 2], TasTipi.Fil, false, Tasİd.Diger);
            CreateTas(Squares[0, 3], TasTipi.Vezir, false, Tasİd.Diger);
            CreateTas(Squares[0, 4], TasTipi.Sah, false, Tasİd.BeyazSah);
            CreateTas(Squares[0, 5], TasTipi.Fil, false, Tasİd.Diger);
            CreateTas(Squares[0, 6], TasTipi.At, false, Tasİd.Diger);
            CreateTas(Squares[0, 7], TasTipi.Kale, false, Tasİd.BeyazKisaKale);
            CreateTas(Squares[1, 0], TasTipi.Piyon, false, Tasİd.Diger);
            CreateTas(Squares[1, 1], TasTipi.Piyon, false, Tasİd.Diger);
            CreateTas(Squares[1, 2], TasTipi.Piyon, false, Tasİd.Diger);
            CreateTas(Squares[1, 3], TasTipi.Piyon, false, Tasİd.Diger);
            CreateTas(Squares[1, 4], TasTipi.Piyon, false, Tasİd.Diger);
            CreateTas(Squares[1, 5], TasTipi.Piyon, false, Tasİd.Diger);
            CreateTas(Squares[1, 6], TasTipi.Piyon, false, Tasİd.Diger);
            CreateTas(Squares[1, 7], TasTipi.Piyon, false, Tasİd.Diger);
        }

        public void AllPiyonisMoveUp()
        {
            foreach (Tas VARIABLE in MevcutTaslar)
            {
                if (VARIABLE.TasTipi == TasTipi.Piyon)
                {
                    (VARIABLE as Piyon).isEnpassEnable = false;
                }
            }
        }

        public void SendCommand(int Fromx, int Fromy, int Tox, int Toy, HamleTipi hamletipi, bool isblack)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (!isblack)
            {
                Command cmd = new Command { From = new Kordinat { X = Fromx, Y = Fromy }, To = new Kordinat { X = Tox, Y = Toy }, HamleTipi = hamletipi };
                bf.Serialize(Server.Stream, cmd);
                Server.Stream.Flush();
                
            }
            else
            {
                Command cmd = new Command { From = new Kordinat { X = Fromx, Y = Fromy }, To = new Kordinat { X = Tox, Y = Toy }, HamleTipi = hamletipi };
                bf.Serialize(Client.stream, cmd);
                Client.stream.Flush();
            }


        }

        #endregion

        #region DragDrop Eventları
        /// <summary>
        /// Tcp Listenerla karşıdan gelen hamleyi karşılayan fonksiyon .
        /// </summary>
        /// <param name="GelenHamle"></param>
        public void DragDrop(Command GelenHamle)
        {

            ChessButton TB = Squares[GelenHamle.To.Y,GelenHamle.To.X]; // TB = Target Button
            ChessButton DB = Squares[GelenHamle.From.Y, GelenHamle.From.X]; // DB = Dragged Button

            #region Rook'ları Kontrol Eden İf blokları

            if (TB.Dolumu && DB.Tas.Tasid == Tasİd.SiyahSah && TB.Tas.Tasid == Tasİd.SiyahKisaKale && (DB.Tas as Sah).isShortRookPossible())
            {
                (DB.Tas as Sah).LetsShortRook();
                PaintBoard();
               

                return;
            }
            else if (TB.Dolumu && DB.Tas.Tasid == Tasİd.SiyahSah && TB.Tas.Tasid == Tasİd.SiyahUzunKale && (DB.Tas as Sah).isLongRookPossible())
            {
                (DB.Tas as Sah).LetsLongRook();
                PaintBoard();
                
                return;
            }
            else if (TB.Dolumu && DB.Tas.Tasid == Tasİd.BeyazSah && TB.Tas.Tasid == Tasİd.BeyazKisaKale && (DB.Tas as Sah).isShortRookPossible())
            {
                (DB.Tas as Sah).LetsShortRook();
                PaintBoard();
              
                return;
            }
            else if (TB.Dolumu && DB.Tas.Tasid == Tasİd.BeyazSah && TB.Tas.Tasid == Tasİd.BeyazUzunKale && (DB.Tas as Sah).isLongRookPossible())
            {
                (DB.Tas as Sah).LetsLongRook();
                PaintBoard();
               
                return;
            }

            #endregion

            #region Enpas'Ları Kontrol Eden İf Blokları

            else if (DB.Tas.TasTipi == TasTipi.Piyon && (DB.Tas as Piyon).isRightEnpassPossible() && ((TB.X == DB.X + 1 && TB.Y == DB.Y + 1) || (TB.X == DB.X - 1 && TB.Y == DB.Y - 1)))
            {
                (DB.Tas as Piyon).LetsRightEnpass();
                PaintBoard();
               
                return;
            }
            else if (DB.Tas.TasTipi == TasTipi.Piyon && (DB.Tas as Piyon).isLeftEnpastPossible() && ((TB.X == DB.X - 1 && TB.Y == DB.Y + 1) || (TB.X == DB.X + 1 && TB.Y == DB.Y - 1)))
            {
                (DB.Tas as Piyon).LetsLeftEnpass();
                PaintBoard();
                
                return;
            }

            bool WillEnpassEnable = false;

            if (DB.Tas.TasTipi == TasTipi.Piyon && ((TB.X == DB.X && TB.Y == DB.Y + 2) || (TB.X == DB.X && TB.Y == DB.Y - 2)))
            {
                WillEnpassEnable = true;
            }
            Piyon asd = DB.Tas as Piyon;

            #endregion

            DB.Tas.Move(TB.X, TB.Y);
            PaintBoard();
            

            if (WillEnpassEnable) asd.isEnpassEnable = true;

        }

        private void ChessButton_MouseDown(object sender, MouseEventArgs e)  //Tahtadaki Karelerin MouseDown eventi ..
        {
            if (Form1.isblack != TurnOfBlack)
            {
                MessageBox.Show("Karşı Hamle Bekleniyor !!");
                return;
            }

            ChessButton castedbutton = (ChessButton)sender;

            if (castedbutton.Tas != null)
            {
                castedbutton.Tas.MakeCangoList();

                foreach (Kordinat VARIABLE in castedbutton.Tas.KordinatsCanGo)
                {
                    if (VARIABLE.KordinatType == KordinatType.Attack && castedbutton.Tas.TasTipi == TasTipi.Piyon)
                    {
                        Piyon asd = (Piyon)castedbutton.Tas;
                        if (Squares[VARIABLE.Y, VARIABLE.X].Tas == null) continue;
                        if (Squares[VARIABLE.Y, VARIABLE.X].Tas.İsBlack != asd.İsBlack) Squares[VARIABLE.Y, VARIABLE.X].BackColor = Color.Yellow;
                    }
                    Squares[VARIABLE.Y, VARIABLE.X].BackColor = Color.Yellow;
                }

                ChessButton Sender = (ChessButton)sender; // drag drop baslangıcı
                if (Sender.Tas.İsBlack == TurnOfBlack) Sender.DoDragDrop(Sender, DragDropEffects.Copy);
                else
                {
                    PaintBoard();
                    MessageBox.Show("Sıra Karşı Tarafın ..");
                }
            }


        }

        private void chessButton_DragDrop(object sender, DragEventArgs e)
        {
            
            ChessButton TB = (sender as ChessButton); // TB = Target Button
            ChessButton DB = (ChessButton)e.Data.GetData(typeof(ChessButton)); // DB = Dragged Button

            #region Rook'ları Kontrol Eden İf blokları

            if (TB.Dolumu && DB.Tas.Tasid == Tasİd.SiyahSah && TB.Tas.Tasid == Tasİd.SiyahKisaKale && (DB.Tas as Sah).isShortRookPossible())
            {
                (DB.Tas as Sah).LetsShortRook();
                PaintBoard();
                SendCommand(DB.X, DB.Y, TB.X, TB.Y, HamleTipi.BlackShortRook, Form1.isblack);

                return;
            }
            else if (TB.Dolumu && DB.Tas.Tasid == Tasİd.SiyahSah && TB.Tas.Tasid == Tasİd.SiyahUzunKale && (DB.Tas as Sah).isLongRookPossible())
            {
                (DB.Tas as Sah).LetsLongRook();
                PaintBoard();
                SendCommand(DB.X, DB.Y, TB.X, TB.Y, HamleTipi.BlackLongRook, Form1.isblack);
                return;
            }
            else if (TB.Dolumu && DB.Tas.Tasid == Tasİd.BeyazSah && TB.Tas.Tasid == Tasİd.BeyazKisaKale && (DB.Tas as Sah).isShortRookPossible())
            {
                (DB.Tas as Sah).LetsShortRook();
                PaintBoard();
                SendCommand(DB.X, DB.Y, TB.X, TB.Y, HamleTipi.WhiteShortRook, Form1.isblack);
                return;
            }
            else if (TB.Dolumu && DB.Tas.Tasid == Tasİd.BeyazSah && TB.Tas.Tasid == Tasİd.BeyazUzunKale && (DB.Tas as Sah).isLongRookPossible())
            {
                (DB.Tas as Sah).LetsLongRook();
                PaintBoard();
                SendCommand(DB.X, DB.Y, TB.X, TB.Y, HamleTipi.WhiteLongRook, Form1.isblack);
                return;
            }

            #endregion

            #region Enpas'Ları Kontrol Eden İf Blokları

            else if (DB.Tas.TasTipi == TasTipi.Piyon && (DB.Tas as Piyon).isRightEnpassPossible() && ((TB.X == DB.X + 1 && TB.Y == DB.Y + 1) || (TB.X == DB.X - 1 && TB.Y == DB.Y - 1)))
            {
                (DB.Tas as Piyon).LetsRightEnpass();
                PaintBoard();
                SendCommand(DB.X, DB.Y, TB.X, TB.Y, HamleTipi.RightEnpass, Form1.isblack);
                return;
            }
            else if (DB.Tas.TasTipi == TasTipi.Piyon && (DB.Tas as Piyon).isLeftEnpastPossible() && ((TB.X == DB.X - 1 && TB.Y == DB.Y + 1) || (TB.X == DB.X + 1 && TB.Y == DB.Y - 1)))
            {
                (DB.Tas as Piyon).LetsLeftEnpass();
                PaintBoard();
                SendCommand(DB.X, DB.Y, TB.X, TB.Y, HamleTipi.LeftEnpass, Form1.isblack);
                return;
            }

            bool WillEnpassEnable = false;

            if (DB.Tas.TasTipi == TasTipi.Piyon && ((TB.X == DB.X && TB.Y == DB.Y + 2) || (TB.X == DB.X && TB.Y == DB.Y - 2)))
            {
                WillEnpassEnable = true;
            }
            Piyon asd = DB.Tas as Piyon;

            #endregion

            DB.Tas.Move(TB.X, TB.Y);
            PaintBoard();
            SendCommand(DB.X, DB.Y, TB.X, TB.Y, HamleTipi.Move, Form1.isblack);

            if (WillEnpassEnable) asd.isEnpassEnable = true;

        }

        private void chessButton_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(ChessButton)) ? DragDropEffects.All : DragDropEffects.None;
        }

        #endregion
    }
}
