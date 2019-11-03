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
            this._TasTİpi = TasTipi.Fil;
            this._İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            this._BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Fil.png";
            this.Cursor = new Cursor($"{ Application.StartupPath}//Taslar//{Renk}Fil.cur");
        }


        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            this.KordinatsCanGo.Clear();
            int x = this.TasKordinat.X, y = this.TasKordinat.Y;

            #region Fil Gibi Gitmeyi Sağlayan Kodlar ( Eksiksiz Denedim Sorun Yok )

            for (int i = 0; i < 8; i++)
            {
                if (StopTry) break;
                x += 1;
                y += 1;
              
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

               

            }

            StopTry = false;
            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = 0; i < 8; i++)
            {
                if (StopTry) break;
                x += -1;
                y += -1;
               
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

           

            }
            StopTry = false;
            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = 0; i < 8; i++)
            {
                if (StopTry) break;
                x += +1;
                y += -1;
               
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

              

            }
            StopTry = false;
            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = 0; i < 8; i++)
            {
                if (StopTry) break;
                x += -1;
                y += +1;
              

                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

             

            }

            StopTry = false;

            #endregion

        }




    }
}
