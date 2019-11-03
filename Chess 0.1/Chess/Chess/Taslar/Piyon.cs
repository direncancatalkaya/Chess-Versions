using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Piyon : Tas
    {
        public Piyon(bool İsBlack)
        {
            this._TasTİpi = TasTipi.Piyon;
            this._İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            this._BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Piyon.png";
        }

        

        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            this.KordinatsCanGo.Clear();
            int x = this.TasKordinat.X, y = this.TasKordinat.Y;

            y+=1;
            if (CanGo(x,y))
            {
                this.KordinatsCanGo.Add(new Kordinat{X=x, Y = y});
            }

            y = this.TasKordinat.Y;
            y += -1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            if (!İsMoved)
            {
                y = this.TasKordinat.Y;
                y += 2;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }
                y = this.TasKordinat.Y;
                y += -2;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }
            }


        }



    }
}
