using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public sealed class At : Tas
    {

        public At(bool İsBlack)
        {
           _TasTİpi = TasTipi.At;
           _İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
           _BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}At.png";
        }

        

        public override void MakeCangoList()
        {
            KordinatsCanGo.Clear();
            try
            {
                int x = TasKordinat.X, y = TasKordinat.Y;
                y += 2;
                x += 1;
                if (CanGo(x,y))
                {
                    KordinatsCanGo.Add(new Kordinat {X = x, Y = y});
                }
            
                x = TasKordinat.X;
                y = TasKordinat.Y;
                y += 2;
                x += -1;
                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = TasKordinat.X;
                y = TasKordinat.Y;
                y += -2;
                x += -1;
                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = TasKordinat.X;
                y = TasKordinat.Y;
                y += -2;
                x += 1;
                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = TasKordinat.X;
                y = TasKordinat.Y;
                y += 1;
                x += 2;
                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = TasKordinat.X;
                y = TasKordinat.Y;
                y += 1;
                x += -2;

                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = TasKordinat.X;
                y = TasKordinat.Y;
                y += -1;
                x += 2;
                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }

                x = TasKordinat.X;
                y = TasKordinat.Y;
                y += -1;
                x += -2;
                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
                }
            }
            catch (Exception e)
            {
                
            }

        }

       



    }
}
