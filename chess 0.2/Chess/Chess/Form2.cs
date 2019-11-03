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
            Form1.MevcutTaslar.Remove(piyon);
        }

        public int X { get; set; }
        public int Y{ get; set; }
        public TasTipi TasTipi { get; set; }
        public bool isblack { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (TasTipi)
            {
                case TasTipi.Kale:
                    Form1.Squares[Y, X].Dolumu = false;
                    Form1.Squares[Y, X].Tas = null;
                    Form1.CreateTas(Form1.Squares[Y, X], TasTipi.Kale, isblack);
                    Form1.Squares[Y, X].GetBackgroundİmage();
                    break;
                case TasTipi.Fil:
                    Form1.Squares[Y, X].Dolumu = false;
                    Form1.Squares[Y, X].Tas = null;
                    Form1.CreateTas(Form1.Squares[Y, X], TasTipi.Fil, isblack);
                    Form1.Squares[Y, X].GetBackgroundİmage();

                    break;
                case TasTipi.At:
                    Form1.Squares[Y, X].Dolumu = false;
                    Form1.Squares[Y, X].Tas = null;
                    Form1.CreateTas(Form1.Squares[Y, X], TasTipi.At, isblack);
                    Form1.Squares[Y, X].GetBackgroundİmage();
                    break;
                case TasTipi.Vezir:
                    Form1.Squares[Y, X].Dolumu = false;
                    Form1.Squares[Y, X].Tas = null;
                    Form1.CreateTas(Form1.Squares[Y, X], TasTipi.Vezir, isblack);
                    Form1.Squares[Y, X].GetBackgroundİmage();
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
