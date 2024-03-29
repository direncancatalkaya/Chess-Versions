﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Chess
{
    public class Kale : Tas
    {
        public Kale(bool İsBlack)
        {
            this._TasTİpi = TasTipi.Kale;
            this._İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            this._BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Kale.png";


        }


        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            this.KordinatsCanGo.Clear();
            int x = this.TasKordinat.X, y = this.TasKordinat.Y;

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
            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = x - 1; i > -1; i--)
            {
                if (StopTry) break;
                if (CanGo(i, y))
                {
                    KordinatsCanGo.Add(new Kordinat { Y = y, X = i });
                }
            }
            StopTry = false;
            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            for (int i = y - 1; i > -1; i--)
            {
                if (StopTry) break;
                if (CanGo(x, i))
                {
                    KordinatsCanGo.Add(new Kordinat { Y = i, X = x });
                }
            }
            StopTry = false;
            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
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

        }
    }


}

