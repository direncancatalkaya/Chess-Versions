using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        public static ChessButton[,] Squares = new ChessButton[8, 8];
        public static List<Tas> MevcutTaslar = new List<Tas>();  // Tahta Üzeirnde Olan Tüm Taþlarý Bu diziye attým. Foreach için !
        public static List<Kordinat> WhiteAttacks = new List<Kordinat>(); // Beyazlarýn Tehdit Ettiði Kareler.
        public static List<Kordinat> BlackAttacks = new List<Kordinat>(); // Siyahlarýn Tehdit Ettiði Kareler .
        public static Sah BeyazSah = null;
        public static Sah SiyahSah = null;
        //public static Kale SiyahKýsaKale = null;
        //public static Kale SiyahUzunKale
        public const int SquareWidth = 70; // Tahtada Oluþturulan Karelerin Geniþliði Ýçin Sabit.
        public const int SquareHeight = 70; // Tahtada Oluþturulan Karelerin Yüksekliði için sabit.
        public bool tasima = false;
        public static Tas Holded = null;
        public static bool TurnOfBlack = false;
        public Tas data = null;


        public Form1()
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

        #region Tahta Metodlarý
       
        static public void CreateTas(ChessButton button, TasTipi tipi, bool renk) // Tahta Üzerinde Combobox dan seçilen taþý Oluþturur  !!
        {

            TasTipi tip = tipi; //(TasTipi)cmb_tastipi.SelectedItem


            switch (tip)
            {
                case TasTipi.Kale:
                    Kale Kale = new Kale(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) } };
                    button.Tas = Kale;
                    button.Dolumu = true;
                    MevcutTaslar.Add(Kale);
                    
                    break;
                case TasTipi.Sah:
                    Sah sah = new Sah(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) } };
                    button.Tas = sah;
                    MevcutTaslar.Add(sah);
                    button.Dolumu = true;
                    if (renk) SiyahSah = sah;
                    if (!renk) BeyazSah = sah;

                    break;
                case TasTipi.Piyon:
                    Piyon piyon = new Piyon(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) } };
                    button.Tas = piyon;
                    MevcutTaslar.Add(piyon);
                    button.Dolumu = true;
                    break;
                case TasTipi.Fil:
                    Fil fil = new Fil(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) } };
                    button.Tas = fil;
                    MevcutTaslar.Add(fil);
                    button.Dolumu = true;
                    
                    break;
                case TasTipi.At:
                    At at = new At(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) } };
                    button.Tas = at;
                    MevcutTaslar.Add(at);
                    button.Dolumu = true;
                    
                    break;
                case TasTipi.Vezir:
                    Vezir vezir = new Vezir(renk) { TasKordinat = new Kordinat { X = Convert.ToInt32(button.X), Y = Convert.ToInt32(button.Y) } };
                    button.Tas = vezir;
                    MevcutTaslar.Add(vezir);
                    button.Dolumu = true;
                    
                    break;
            }



            button.GetBackgroundÝmage();

        }

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
            Holded = null;
            WhiteAttacks.Clear();
            BlackAttacks.Clear();
            TurnOfBlack = false;
            tasima = false;
            foreach (ChessButton VARIABLE in Squares)
            {
                VARIABLE.Tas = null;
                VARIABLE.Dolumu = false;
                VARIABLE.GetBackgroundÝmage();
            }
            CreateTas(Squares[7, 0], TasTipi.Kale, true);
            CreateTas(Squares[7, 1], TasTipi.At, true);
            CreateTas(Squares[7, 2], TasTipi.Fil, true);
            CreateTas(Squares[7, 3], TasTipi.Vezir, true);
            CreateTas(Squares[7, 4], TasTipi.Sah, true);
            CreateTas(Squares[7, 5], TasTipi.Fil, true);
            CreateTas(Squares[7, 6], TasTipi.At, true);
            CreateTas(Squares[7, 7], TasTipi.Kale, true);
            CreateTas(Squares[6, 0], TasTipi.Piyon, true);
            CreateTas(Squares[6, 1], TasTipi.Piyon, true);
            CreateTas(Squares[6, 2], TasTipi.Piyon, true);
            CreateTas(Squares[6, 3], TasTipi.Piyon, true);
            CreateTas(Squares[6, 4], TasTipi.Piyon, true);
            CreateTas(Squares[6, 5], TasTipi.Piyon, true);
            CreateTas(Squares[6, 6], TasTipi.Piyon, true);
            CreateTas(Squares[6, 7], TasTipi.Piyon, true);

            CreateTas(Squares[0, 0], TasTipi.Kale, false);
            CreateTas(Squares[0, 1], TasTipi.At, false);
            CreateTas(Squares[0, 2], TasTipi.Fil, false);
            CreateTas(Squares[0, 3], TasTipi.Vezir, false);
            CreateTas(Squares[0, 4], TasTipi.Sah, false);
            CreateTas(Squares[0, 5], TasTipi.Fil, false);
            CreateTas(Squares[0, 6], TasTipi.At, false);
            CreateTas(Squares[0, 7], TasTipi.Kale, false);
            CreateTas(Squares[1, 0], TasTipi.Piyon, false);
            CreateTas(Squares[1, 1], TasTipi.Piyon, false);
            CreateTas(Squares[1, 2], TasTipi.Piyon, false);
            CreateTas(Squares[1, 3], TasTipi.Piyon, false);
            CreateTas(Squares[1, 4], TasTipi.Piyon, false);
            CreateTas(Squares[1, 5], TasTipi.Piyon, false);
            CreateTas(Squares[1, 6], TasTipi.Piyon, false);
            CreateTas(Squares[1, 7], TasTipi.Piyon, false);
        }

        public void EndGameCheck()
        {
            bool black = false;
            bool white = false;
            foreach (Tas VARIABLE in MevcutTaslar)
            {
                if (VARIABLE.ÝsBlack && VARIABLE.TasTipi == TasTipi.Sah)
                {
                    black = true;
                }

                if (!VARIABLE.ÝsBlack && VARIABLE.TasTipi == TasTipi.Sah)
                {
                    white = true;
                }
            }

            if (black && !white)
            {
                MessageBox.Show("Siyahlar Kazandý Tebrikler ..");
            }
            if (!black && white)
            {
                MessageBox.Show("Beyazlar Kazandý Tebrikler ..");
            }
        } // þu anki Logic de yok kullanmýyorum .. Oyun her türlü Þah mat la bitmek zorunda ..


        #endregion


        #region Form Eventlarý


        private void Form1_Load(object sender, EventArgs e)
        {
            void CmbDoldur()// comboboxu Taþ Tipleriyle Doldurur. Object içinde TasTipi enumu var Cast Edersen !    
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
        
      
        private int Oldx;
        private int Oldy;

        private void ChessButton_MouseDown(object sender, MouseEventArgs e)  //Tahtadaki Karelerin MouseDown eventi ..
        {
            
          
            PaintBoard();
            ChessButton castedbutton = (ChessButton)sender;
            
           
            this.txt_tahta_x.Text = castedbutton.X.ToString();
            this.txt_tahta_y.Text = castedbutton.Y.ToString();
            

            if (castedbutton.Tas != null && !tasima)
            {
                Oldx = castedbutton.X;
                Oldy = castedbutton.Y;
                castedbutton.Tas.MakeCangoList();
                Holded = castedbutton.Tas;


                foreach (Kordinat VARIABLE in castedbutton.Tas.KordinatsCanGo)
                {
                    if (VARIABLE.KordinatType==KordinatType.Attack && castedbutton.Tas.TasTipi == TasTipi.Piyon)
                    {
                        Piyon asd = (Piyon) castedbutton.Tas;
                        if(Squares[VARIABLE.Y, VARIABLE.X].Tas==null) continue;
                        if (Squares[VARIABLE.Y, VARIABLE.X].Tas.ÝsBlack!=asd.ÝsBlack) Squares[VARIABLE.Y, VARIABLE.X].BackColor = Color.Yellow;
                    }
                    Squares[VARIABLE.Y, VARIABLE.X].BackColor = Color.Yellow;


                }

                //tasima = true;
                ChessButton asdf = (ChessButton)sender;
                asdf.DoDragDrop(asdf, DragDropEffects.Copy); // drag drop baþlangýcý 
                
            }

            //else if (tasima)
            //{
            //    if (castedbutton.X == Oldx && castedbutton.Y == Oldy)
            //    {
            //        tasima = false;
            //    }

            //    else
            //    {
            //        if ((!TurnOfBlack && Holded.ÝsBlack) || (TurnOfBlack && !Holded.ÝsBlack)) // oyun sýrasý siyahta ama oynanan tas beyazsa ve tersi durum için hata fýrlatma kýsmý
            //        {
            //            MessageBox.Show("Oynama Sýrasý Karþý Tarafýn ..");
            //            tasima = false;
            //        }
            //        else
            //        {
            //            Holded.Move(castedbutton.X, castedbutton.Y);
            //            tasima = false;

            //        }

            //    }
                
            //}
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TasTipi tip = (TasTipi)cmb_tastipi.SelectedItem;
            bool renk = cmb_renk.SelectedItem.ToString() == "Siyah" ? true : false; // turnary Kullandým Siyahsa True Beyazsa False Atayacak !
            CreateTas(Squares[Convert.ToInt32(txt_tahta_y.Text), Convert.ToInt32(txt_tahta_x.Text)], tip, renk);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            NewGame();
        }


        
        #endregion

        

        

        private void chessButton_DragDrop(object sender, DragEventArgs e)
        {
            // dragDrop Bitiþi
            ChessButton asd = (ChessButton)e.Data.GetData(typeof(ChessButton));

            asd.Tas.Move((sender as ChessButton).X,(sender as ChessButton).Y);
            PaintBoard();
        }

        private void chessButton_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(typeof(ChessButton)))
            {
               
                e.Effect = DragDropEffects.All;
            }

            else

            {
                e.Effect = DragDropEffects.All;
            } 


        }

    }
    }

