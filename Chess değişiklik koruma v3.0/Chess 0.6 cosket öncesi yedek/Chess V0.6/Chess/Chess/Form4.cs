using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form4 : Form
    {
        public static ChessButton[,] Squares = new ChessButton[8, 8]; // Tahtadaki Kareleri Listesi
        public static List<Tas> MevcutTaslar = new List<Tas>();  // Tahta Üzeirnde Olan Tüm Taşları Bu diziye attım. Foreach için !
        public static List<Kordinat> WhiteAttacks = new List<Kordinat>(); // Beyazların Tehdit Ettiği Kareler.
        public static List<Kordinat> BlackAttacks = new List<Kordinat>(); // Siyahların Tehdit Ettiği Kareler .
        public static Sah BeyazSah = null;
        public static Sah SiyahSah = null;
        public static bool TurnOfBlack = false; // Oyuncu Sırası .. True ise Sıra Siyahtadır .. Oyun başlangıcında Beyaz Başlar !
        public const int SquareWidth = 70; // Tahtada Oluşturulan Karelerin Genişliği İçin Sabit.
        public const int SquareHeight = 70; // Tahtada Oluşturulan Karelerin Yüksekliği için sabit.
        


        public Form4()
        {
            InitializeComponent();
            int Top = SquareWidth * 7;
            int Left = 0;
            int index = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Squares[i, j] = new ChessButton();
                    Squares[i, j].Dolumu = false;
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
                    Controls.Add(Squares[i, j]);
                    Left += SquareWidth;
                    index++;
                }
                Top -= SquareWidth;
                Left = 0;
                index++;
            }
        }

        #region Tahta Metodları

        public void CreateTas(ChessButton button, TasTipi tipi, bool renk, Tasİd tasid) // Tahta Üzerinde Combobox dan seçilen taşı Oluşturur  !!
        {

            TasTipi tip = tipi; //(TasTipi)cmb_tastipi.SelectedItem


            switch (tip)
            {
                case TasTipi.Kale:
                    Kale Kale = new Kale(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid };
                    button.Tas = Kale;
                    button.Dolumu = true;
                    MevcutTaslar.Add(Kale);

                    break;
                case TasTipi.Sah:
                    Sah sah = new Sah(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid };
                    button.Tas = sah;
                    MevcutTaslar.Add(sah);
                    button.Dolumu = true;
                    if (renk) SiyahSah = sah;
                    if (!renk) BeyazSah = sah;

                    break;
                case TasTipi.Piyon:
                    Piyon piyon = new Piyon(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid };
                    button.Tas = piyon;
                    MevcutTaslar.Add(piyon);
                    button.Dolumu = true;
                    break;
                case TasTipi.Fil:
                    Fil fil = new Fil(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid };
                    button.Tas = fil;
                    MevcutTaslar.Add(fil);
                    button.Dolumu = true;

                    break;
                case TasTipi.At:
                    At at = new At(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid };
                    button.Tas = at;
                    MevcutTaslar.Add(at);
                    button.Dolumu = true;

                    break;
                case TasTipi.Vezir:
                    Vezir vezir = new Vezir(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) }, Tasid = tasid };
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

        #endregion


        #region Form Eventları


        private void Form1_Load(object sender, EventArgs e)
        {
            void CmbDoldur()// comboboxu Taş Tipleriyle Doldurur. Object içinde TasTipi enumu var Cast Edersen !    
            {

                cmb_tastipi.Items.Add(TasTipi.At);
                cmb_tastipi.Items.Add(TasTipi.Fil);
                cmb_tastipi.Items.Add(TasTipi.Kale);
                cmb_tastipi.Items.Add(TasTipi.Piyon);
                cmb_tastipi.Items.Add(TasTipi.Sah);
                cmb_tastipi.Items.Add(TasTipi.Vezir);
                cmb_tastipi.SelectedItem = cmb_tastipi.Items[0];
            }

            CmbDoldur();
            cmb_renk.SelectedItem = cmb_renk.Items[0];
        }

        private void ChessButton_MouseDown(object sender, MouseEventArgs e)  //Tahtadaki Karelerin MouseDown eventi ..
        {


            ChessButton castedbutton = (ChessButton)sender;
            this.txt_tahta_x.Text = castedbutton.X.ToString();
            this.txt_tahta_y.Text = castedbutton.Y.ToString();



            if (castedbutton.Tas != null)
            {

                castedbutton.Tas.MakeCangoList();

                foreach (Kordinat VARIABLE in castedbutton.Tas.KordinatsCanGo)
                {
                    if (VARIABLE.KordinatType==KordinatType.Attack && castedbutton.Tas.TasTipi == TasTipi.Piyon)
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
                return;
            }
            else if (TB.Dolumu  && DB.Tas.Tasid == Tasİd.SiyahSah && TB.Tas.Tasid == Tasİd.SiyahUzunKale && (DB.Tas as Sah).isLongRookPossible())
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

        private void chessButton_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(ChessButton)) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TasTipi tip = (TasTipi)cmb_tastipi.SelectedItem;
            bool renk = cmb_renk.SelectedItem.ToString() == "Siyah" ? true : false; // turnary Kullandım Siyahsa True Beyazsa False Atayacak !
            CreateTas(Squares[Convert.ToInt32(txt_tahta_y.Text), Convert.ToInt32(txt_tahta_x.Text)], tip, renk, Tasİd.Diger);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewGame();
        }



        #endregion


    }
}
