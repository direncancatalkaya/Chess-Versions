using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    class Vezir : Tas
    {
        public Vezir(bool İsBlack)
        {
            this._TasTİpi = TasTipi.Kale;
            this._İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz"; // turnary 
            this._BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Vezir.png";
        }





        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            this.KordinatsCanGo.Clear();
            int x = this.TasKordinat.X, y = this.TasKordinat.Y;

            for (int i = 0; i < 8; i++)
            {
                if (i == this.TasKordinat.X)
                {
                    continue;
                }
                if (CanGo(y, i) && y < 8)
                {
                    KordinatsCanGo.Add(new Kordinat { Y = y, X = i });
                }

                if (CanGo(y, i) == false)
                {
                    break;
                }

            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = 0; i < 8; i++)
            {
                if (i == this.TasKordinat.Y)
                {
                    continue;
                }
                if (CanGo(i, x) && x < 8)
                {
                    KordinatsCanGo.Add(new Kordinat { Y = i, X = x });
                }
                else if (CanGo(i, x) == false)
                {
                    break;
                }

            }


            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;

            for (int i = 0; i < 8; i++)
            {
                x += 1;
                y += 1;
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
