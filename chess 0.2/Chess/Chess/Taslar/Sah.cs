using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Sah : Tas
    {
        public Sah(bool İsBlack)
        {
            this._TasTİpi = TasTipi.Sah;
            this._İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            this._BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Sah.png";

        }





        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            this.KordinatsCanGo.Clear();

            int x = this.TasKordinat.X, y = this.TasKordinat.Y;
            y += 1;
            x += 1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            y += 1;
            x += -1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            y += 1;

            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            y += -1;

            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            y += -1;
            x += -1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;
            y += -1;
            x += +1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;

            x += -1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = this.TasKordinat.X;
            y = this.TasKordinat.Y;

            x += 1;
            if (CanGo(x, y))
            {
                this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

        }

        public override void Move(int x, int y)
        {
            //if (this.İsBlack)
            //{
            //    foreach (Kordinat VARIABLE in Form1.WhiteAttacks)
            //    {
            //        if (VARIABLE.X == x && VARIABLE.Y == y)
            //        {
            //            MessageBox.Show("Bu Bölge Tehdit Altında ..");
            //        }
            //    }
            //}
            //else if (!this.İsBlack)
            //{
            //    foreach (Kordinat VARIABLE in Form1.BlackAttacks)
            //    {
            //        if (VARIABLE.X == x && VARIABLE.Y == y)
            //        {
            //            MessageBox.Show("Bu Bölge Tehdit Altında ..");
            //        }
            //    }
            //}
            //else
            //{
                foreach (Tas item in Form1.MevcutTaslar)
                {
                    item.MakeCangoList();

                    if (item.İsBlack)
                    {
                        foreach (var VARIABLE in item.KordinatsCanGo)
                        {
                            if (VARIABLE.Attack == true) Form1.BlackAttacks.Add(VARIABLE);
                        }
                    }

                    if (!item.İsBlack)
                    {
                        foreach (var VARIABLE in item.KordinatsCanGo)
                        {
                            if (VARIABLE.Attack == true) Form1.WhiteAttacks.Add(VARIABLE);
                        }
                    }
                }




                int OldX = this.TasKordinat.X, OldY = this.TasKordinat.Y;


                foreach (Kordinat VARIABLE in this.KordinatsCanGo)
                {
                    if (VARIABLE.X == x && VARIABLE.Y == y)
                    {
                        if (Form1.Squares[y, x].Tas != null)
                        {
                            Form1.Squares[OldY, OldX].Tas = null;
                            Form1.Squares[OldY, OldX].GetBackgroundİmage();
                            Form1.Squares[OldY, OldX].Dolumu = false;
                            this.TasKordinat.X = x;
                            this.TasKordinat.Y = y;
                            Form1.MevcutTaslar.Remove(Form1.Squares[y, x].Tas);
                            Form1.Squares[y, x].Tas = this;
                            Form1.Squares[y, x].GetBackgroundİmage();
                            Form1.Squares[y, x].Dolumu = true;
                            break;

                        }
                        else
                        {
                            Form1.Squares[OldY, OldX].Tas = null;
                            Form1.Squares[OldY, OldX].GetBackgroundİmage();
                            Form1.Squares[OldY, OldX].Dolumu = false;
                            this.TasKordinat.X = x;
                            this.TasKordinat.Y = y;
                            Form1.Squares[y, x].Tas = this;
                            Form1.Squares[y, x].GetBackgroundİmage();
                            Form1.Squares[y, x].Dolumu = true;
                            break;
                        }

                    }

                }

                this.İsMoved = true;
                this.MakeCangoList();
            //}
        }

    }
}
