using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Sah : Tas
    {
        public Sah(bool İsBlack)
        {
            this._TasTİpi = TasTipi.Kale;
            this._İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            this._BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Sah.png";
        }


       
        

        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            this.KordinatsCanGo.Clear();
            
            int x = this.TasKordinat.X, y = this.TasKordinat.Y;
            y += 1;
            x += 1;
            if (CanGo(x,y))
            {
                this.KordinatsCanGo.Add(new Kordinat {X = x, Y = y});
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            y += 1;
            x += -1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            y += 1;
            
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            y += -1;
            
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            y += -1;
            x += -1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            y += -1;
            x += +1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
           
            x += -1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
           
            x += 1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

        }

       
    }
}
