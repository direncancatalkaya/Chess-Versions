using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Fil : Tas
    {
        public Fil(bool İsBlack)
        {
            this._TasTİpi = TasTipi.Kale;
            this._İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            this._BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Fil.png";
        }


        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            this.KordinatsCanGo.Clear();
            int x = this.TasKordinat.X, y = this.TasKordinat.Y;

            for (int i = 0; i < 8; i++)
            {
                x += 1;
                y += 1;
                if (!CanGo(x,y))
                {
                    break;
                }
                else if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = 0; i < 8; i++)
            {
                x += -1;
                y += -1;
                if (!CanGo(x, y))
                {
                    break;
                }
                else if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = 0; i < 8; i++)
            {
                x += +1;
                y += -1;
                if (!CanGo(x, y))
                {
                    break;
                }
                else if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = 0; i < 8; i++)
            {
                x += -1;
                y += +1;
                if (!CanGo(x, y))
                {
                    break;
                }
                else if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

            }
        }

      


    }
}
