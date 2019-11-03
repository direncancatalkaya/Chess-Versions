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
            this._TasTİpi = TasTipi.Vezir;
            this._İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz"; // turnary 
            this._BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Vezir.png";
        }





        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            this.KordinatsCanGo.Clear();
            int x = this.TasKordinat.X, y = this.TasKordinat.Y;


            #region Kale Gibi Gidebilmeye Bakan Kodlar ( Eksiksiz Denedim Sorun yok ..)

            for (int i = x + 1; i < 8; i++)
            {
                if (CanGo(i, y) == false)
                {
                    break;
                }
                else if (CanGo(i, y))
                {
                    KordinatsCanGo.Add(new Kordinat { Y = y, X = i });
                }
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = x - 1; i > -1; i--)
            {
                if (CanGo(i, y) == false)
                {
                    break;
                }
                else if (CanGo(i, y))
                {
                    KordinatsCanGo.Add(new Kordinat { Y = y, X = i });
                }
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = y - 1; i > -1; i--)
            {

                if (CanGo(x, i) == false)
                {
                    break;
                }
                else if (CanGo(x, i))
                {
                    KordinatsCanGo.Add(new Kordinat { Y = i, X = x });
                }
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = y + 1; i < 8; i++)
            {
                if (CanGo(x, i) == false)
                {
                    break;
                }
                else if (CanGo(x, i))
                {
                    KordinatsCanGo.Add(new Kordinat { Y = i, X = x });
                }
            }

            #endregion


            #region Fil Gibi Çapraz Gitmeyi Kontrol Eden Kodlar ( Eksiksiz Denedim Sorun yok )

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
            #endregion



        }



    }
}
