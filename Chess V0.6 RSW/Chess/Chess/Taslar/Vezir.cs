using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public sealed class Vezir : Tas
    {
        public Vezir(bool İsBlack)
        {
            _TasTİpi = TasTipi.Vezir;
            _İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz"; // turnary 
            _BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Vezir.png";
        }





        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            KordinatsCanGo.Clear();
            int x = TasKordinat.X, y = TasKordinat.Y;


            #region Kale Gibi Gidebilmeye Bakan Kodlar ( Eksiksiz Denedim Sorun yok ..)

            for (int i = x + 1; i < 8; i++)
            {
                if (StopTry) break;
                if (CanGo(i, y))
                {
                    KordinatsCanGo.Add(new Kordinat { Y = y, X = i });
                }
            }

            StopTry = false;
            x = TasKordinat.X;
            y = TasKordinat.Y;
            for (int i = x - 1; i > -1; i--)
            {
                if (StopTry) break;
                if (CanGo(i, y))
                {
                    KordinatsCanGo.Add(new Kordinat { Y = y, X = i });
                }
            }
            StopTry = false;
            x = TasKordinat.X;
            y = TasKordinat.Y;
            for (int i = y - 1; i > -1; i--)
            {
                if (StopTry) break;
                if (CanGo(x, i))
                {
                    KordinatsCanGo.Add(new Kordinat { Y = i, X = x });
                }
            }
            StopTry = false;
            x = TasKordinat.X;
            y = TasKordinat.Y;
            for (int i = y + 1; i < 8; i++)
            {
                if (StopTry) break;
                if (CanGo(x, i))
                {
                    KordinatsCanGo.Add(new Kordinat { Y = i, X = x });
                }
            }
            StopTry = false;
            #endregion


            #region Fil Gibi Gitmeyi Sağlayan Kodlar ( Eksiksiz Denedim Sorun Yok )

            for (int i = 0; i < 8; i++)
            {
                if (StopTry) break;
                x += 1;
                y += 1;

                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }



            }

            StopTry = false;
            x = TasKordinat.X;
            y = TasKordinat.Y;
            for (int i = 0; i < 8; i++)
            {
                if (StopTry) break;
                x += -1;
                y += -1;

                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }



            }
            StopTry = false;
            x = TasKordinat.X;
            y = TasKordinat.Y;
            for (int i = 0; i < 8; i++)
            {
                if (StopTry) break;
                x += +1;
                y += -1;

                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }



            }
            StopTry = false;
            x = TasKordinat.X;
            y = TasKordinat.Y;
            for (int i = 0; i < 8; i++)
            {
                if (StopTry) break;
                x += -1;
                y += +1;


                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }



            }

            StopTry = false;

            #endregion



        }



    }
}
