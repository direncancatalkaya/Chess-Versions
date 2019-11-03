using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Piyon : Tas
    {
        public Piyon(bool İsBlack)
        {
            this._TasTİpi = TasTipi.Piyon;
            this._İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            this._BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Piyon.png";
        }

        bool CanEat(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }

            if (Form1.Squares[y, x].Tas != null && (TargetİsBlack(x, y) != this.İsBlack))
            {
                return true;
            }

            return false;
        }

        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            this.KordinatsCanGo.Clear();
            int x = this.TasKordinat.X, y = this.TasKordinat.Y;

            if (this.İsBlack == false)
            {
                y += 1;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y, Attack = false});
                }

                y = this.TasKordinat.Y;


                if (!İsMoved)
                {
                    y = this.TasKordinat.Y;
                    y += 2;
                    if (CanGo(x, y))
                    {
                        this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y, Attack =false});
                    }

                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                x += 1;
                y += 1;
                if (CanEat(x,y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                x += -1;
                y += 1;

                if (CanEat(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }
            }
            else
            {

                y += -1;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y,Attack = false});
                }

                if (!İsMoved)
                {

                    y = this.TasKordinat.Y;
                    y += -2;
                    if (CanGo(x, y))
                    {
                        this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y,Attack = false});
                    }
                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                x += 1;
                y += -1;
                if (CanEat(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                x += -1;
                y += -1;

                if (CanEat(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }
            }

            if (TasKordinat.Y==0 || TasKordinat.Y==7)
            {
                Form2 frm2 = new Form2(this);
                frm2.ShowDialog();
            }
        }

        public override bool CanGo(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }

            if (!Form1.Squares[y, x].Dolumu)
            {
                return true;
            }
           
            
            
            return false;

        }
    }
}
