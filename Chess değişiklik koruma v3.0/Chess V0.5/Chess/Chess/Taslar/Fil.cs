using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Fil : Tas
    {
        public Fil(bool İsBlack)
        {
            _TasTİpi = TasTipi.Fil;
            _İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            _BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Fil.png";
        }


        public override void MakeCangoList()
        {
            KordinatsCanGo.Clear();
            int x = TasKordinat.X, y = TasKordinat.Y;

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
