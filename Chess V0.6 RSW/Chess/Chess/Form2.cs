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
    public partial class Form2 : Form
    {
        public Form2(Piyon piyon)
        {
            InitializeComponent();
            this.isblack = piyon.İsBlack;
            this.X = piyon.TasKordinat.X;
            this.Y = piyon.TasKordinat.Y;
            piyon.ChessBoard.MevcutTaslar.Remove(piyon);
            asd = piyon;
        }

        private Piyon asd;
        public int X { get; set; }
        public int Y{ get; set; }
        public TasTipi TasTipi { get; set; }
        public bool isblack { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (TasTipi)
            {
                case TasTipi.Kale:
                    asd.ChessBoard.MevcutTaslar.Remove(asd);
                    Kale kale = new Kale(isblack) { TasKordinat = new Kordinat { X = this.X, Y = this.Y } };
                    asd.ChessBoard.MevcutTaslar.Add(kale);
                    asd.ChessBoard.Squares[Y, X].Dolumu = true;
                    asd.ChessBoard.Squares[Y, X].Tas = kale;
                    asd.ChessBoard.Squares[Y, X].GetBackgroundİmage();
                    kale.Move(X, Y);
                    break;
                case TasTipi.Fil:
                    asd.ChessBoard.MevcutTaslar.Remove(asd);
                    Fil fil = new Fil(isblack) { TasKordinat = new Kordinat { X = this.X, Y = this.Y } };
                    asd.ChessBoard.MevcutTaslar.Add(fil);
                    asd.ChessBoard.Squares[Y, X].Dolumu = true;
                    asd.ChessBoard.Squares[Y, X].Tas = fil;
                    asd.ChessBoard.Squares[Y,X].GetBackgroundİmage();
                    fil.Move(X, Y);

                    break;
                case TasTipi.At:
                    asd.ChessBoard.MevcutTaslar.Remove(asd);
                    At at = new At(isblack) { TasKordinat = new Kordinat { X = this.X, Y = this.Y } };
                    asd.ChessBoard.Squares[Y, X].Dolumu = true;
                    asd.ChessBoard.Squares[Y, X].Tas = at;
                    asd.ChessBoard.Squares[Y, X].GetBackgroundİmage();
                    at.Move(X, Y);
                    //at.MakeCangoList();
                    break;
                case TasTipi.Vezir:
                    asd.ChessBoard.MevcutTaslar.Remove(asd);
                    Vezir vezir = new Vezir(isblack){TasKordinat = new Kordinat{X =this.X, Y = this.Y}};
                    asd.ChessBoard.MevcutTaslar.Add(vezir);
                    asd.ChessBoard.Squares[Y, X].Dolumu = true;
                    asd.ChessBoard.Squares[Y, X].Tas = vezir;
                    asd.ChessBoard.Squares[Y, X].GetBackgroundİmage();
                    vezir.Move(X,Y);
                    break;
               
            }
            this.Hide();
        }

        private void rdb_vezir_CheckedChanged(object sender, EventArgs e)
        {
            TasTipi = TasTipi.Vezir;
        }

        private void rdb_fil_CheckedChanged(object sender, EventArgs e)
        {
            TasTipi = TasTipi.Fil;
        }

        private void rdb_kale_CheckedChanged(object sender, EventArgs e)
        {
            TasTipi = TasTipi.Kale;
        }

        private void rdb_at_CheckedChanged(object sender, EventArgs e)
        {
            TasTipi = TasTipi.At;
        }
    }
}
