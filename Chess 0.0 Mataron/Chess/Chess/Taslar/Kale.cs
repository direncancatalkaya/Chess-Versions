using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Chess
{
    class Kale : Tas
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
            
            for (int i = 0; i < 8; i++)
            {
                if (i==this.TasKordinat.X)
                {
                    continue;
                }
                if (CanGo(y, i) == false)
                {
                    break;
                }
                else if (CanGo(y,i)  && y<8)
                {
                    KordinatsCanGo.Add(new Kordinat{Y = y, X = i});
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
                else if (CanGo(i, x) == false)
                {
                    break;
                }
                else if (CanGo(i, x) && x < 8)
                {
                    KordinatsCanGo.Add(new Kordinat { Y = i, X = x });
                }
               
                
            }
        }

        
    }
}
