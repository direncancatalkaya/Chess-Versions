using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class At : Tas
    {

        public At(bool İsBlack)
        {
            this._TasTİpi = TasTipi.At;
            this._İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            this._BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}At.png";
        }

        

        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            this.KordinatsCanGo.Clear();
            try
            {
                int x = this.TasKordinat.X, y = this.TasKordinat.Y;
                y += 2;
                x += 1;
                if (CanGo(x,y))
                {
                    this.KordinatsCanGo.Add(new Kordinat {X = x, Y = y});
                }
            
                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                y += 2;
                x += -1;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                y += -2;
                x += -1;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                y += -2;
                x += 1;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                y += 1;
                x += 2;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                y += 1;
                x += -2;

                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                y += -1;
                x += 2;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                y += -1;
                x += -2;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }
            }
            catch (Exception e)
            {
                
            }

        }

       



    }
}
