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
            Form4.MevcutTaslar.Remove(piyon);
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
                    Form4.MevcutTaslar.Remove(asd);
                    Kale kale = new Kale(isblack) { TasKordinat = new Kordinat { X = this.X, Y = this.Y } };
                    Form4.MevcutTaslar.Add(kale);
                    Form4.Squares[Y, X].Dolumu = true;
                    Form4.Squares[Y, X].Tas = kale;
                    Form4.Squares[Y, X].GetBackgroundİmage();
                    kale.Move(X, Y);
                    break;
                case TasTipi.Fil:
                    Form4.MevcutTaslar.Remove(asd);
                    Fil fil = new Fil(isblack) { TasKordinat = new Kordinat { X = this.X, Y = this.Y } };
                    Form4.MevcutTaslar.Add(fil);
                    Form4.Squares[Y, X].Dolumu = true;
                    Form4.Squares[Y, X].Tas = fil;
                    Form4.Squares[Y,X].GetBackgroundİmage();
                    fil.Move(X, Y);

                    break;
                case TasTipi.At:
                    Form4.MevcutTaslar.Remove(asd);
                    At at = new At(isblack) { TasKordinat = new Kordinat { X = this.X, Y = this.Y } };
                    Form4.Squares[Y, X].Dolumu = true;
                    Form4.Squares[Y, X].Tas = at;
                    Form4.Squares[Y, X].GetBackgroundİmage();
                    at.Move(X, Y);
                    //at.MakeCangoList();
                    break;
                case TasTipi.Vezir:
                    Form4.MevcutTaslar.Remove(asd);
                    Vezir vezir = new Vezir(isblack){TasKordinat = new Kordinat{X =this.X, Y = this.Y}};
                    Form4.MevcutTaslar.Add(vezir);
                    Form4.Squares[Y, X].Dolumu = true;
                    Form4.Squares[Y, X].Tas = vezir;
                    Form4.Squares[Y, X].GetBackgroundİmage();
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
