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

        #region eski Override Move // Fake Move İle bu Logice Gerek Kalmadı . Çok daha Kullanışlı Yöntem 



        //public override void Move(int x, int y)
        //{
        //    int OldX = this.TasKordinat.X, OldY = this.TasKordinat.Y;
        //    Kordinat krd = new Kordinat { X = x, Y = y };
        //    FillAllCanGoList();
        //    FillAttackList();
        //    if (!FakeMove(x, y))
        //    {
        //        MessageBox.Show("Şah Tehdit Altında Kalıyor Bu hamle yapılamaz..");
        //        return;
        //    }
        //    FillAllCanGoList();
        //    FillAttackList();
        //    base.Move(x,y);

        //    #region Eski Logicle Sahın move kodları

        //    //foreach (Kordinat VARIABLE in Form1.WhiteAttacks)
        //    //{

        //    //    if (Form1.SiyahSah.KordinatsCanGo.Contains(VARIABLE))
        //    //    {
        //    //        Form1.SiyahSah.KordinatsCanGo.Remove(VARIABLE);
        //    //    }


        //    //}
        //    //foreach (Kordinat VARIABLE in Form1.BlackAttacks)
        //    //{
        //    //    if (Form1.BeyazSah.KordinatsCanGo.Contains(VARIABLE))
        //    //    {
        //    //        Form1.BeyazSah.KordinatsCanGo.Remove(VARIABLE);
        //    //    }
        //    //}

        //    //if (this.İsBlack)
        //    //{
        //    //    foreach (Kordinat item in Form1.WhiteAttacks)
        //    //    {
        //    //        if (krd == item)
        //    //        {
        //    //            MessageBox.Show("Bu Kare Tehdit Altında..");
        //    //            break;
        //    //        }
        //    //        if (krd != item)
        //    //        {
        //    //            foreach (Kordinat VARIABLE in this.KordinatsCanGo)
        //    //            {
        //    //                if (krd == VARIABLE)
        //    //                {
        //    //                    if (Form1.Squares[y, x].Tas != null)
        //    //                    {
        //    //                        Form1.Squares[OldY, OldX].Tas = null;
        //    //                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
        //    //                        Form1.Squares[OldY, OldX].Dolumu = false;
        //    //                        this.TasKordinat.X = x;
        //    //                        this.TasKordinat.Y = y;
        //    //                        Form1.MevcutTaslar.Remove(Form1.Squares[y, x].Tas);
        //    //                        Form1.Squares[y, x].Tas = this;
        //    //                        Form1.Squares[y, x].GetBackgroundİmage();
        //    //                        Form1.Squares[y, x].Dolumu = true;
        //    //                        this.İsMoved = true;
        //    //                        this.MakeCangoList();
        //    //                        Form1.TurnOfBlack = !Form1.TurnOfBlack;
        //    //                        break;


        //    //                    }
        //    //                    if (Form1.Squares[y, x].Tas == null)
        //    //                    {
        //    //                        Form1.Squares[OldY, OldX].Tas = null;
        //    //                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
        //    //                        Form1.Squares[OldY, OldX].Dolumu = false;
        //    //                        this.TasKordinat.X = x;
        //    //                        this.TasKordinat.Y = y;
        //    //                        Form1.Squares[y, x].Tas = this;
        //    //                        Form1.Squares[y, x].GetBackgroundİmage();
        //    //                        Form1.Squares[y, x].Dolumu = true;
        //    //                        this.İsMoved = true;
        //    //                        this.MakeCangoList();
        //    //                        Form1.TurnOfBlack = !Form1.TurnOfBlack;
        //    //                        break;

        //    //                    }

        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}


        //    //if (!this.İsBlack)
        //    //{
        //    //    foreach (Kordinat item in Form1.BlackAttacks)
        //    //    {
        //    //        if (krd == item)
        //    //        {
        //    //            MessageBox.Show("Bu Kare Tehdit Altında..");
        //    //            break;
        //    //        }
        //    //        if (krd != item)
        //    //        {
        //    //            foreach (Kordinat VARIABLE in this.KordinatsCanGo)
        //    //            {
        //    //                if (krd == VARIABLE)
        //    //                {
        //    //                    if (Form1.Squares[y, x].Tas != null)
        //    //                    {
        //    //                        Form1.Squares[OldY, OldX].Tas = null;
        //    //                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
        //    //                        Form1.Squares[OldY, OldX].Dolumu = false;
        //    //                        this.TasKordinat.X = x;
        //    //                        this.TasKordinat.Y = y;
        //    //                        Form1.MevcutTaslar.Remove(Form1.Squares[y, x].Tas);
        //    //                        Form1.Squares[y, x].Tas = this;
        //    //                        Form1.Squares[y, x].GetBackgroundİmage();
        //    //                        Form1.Squares[y, x].Dolumu = true;
        //    //                        this.İsMoved = true;
        //    //                        this.MakeCangoList();
        //    //                        Form1.TurnOfBlack = !Form1.TurnOfBlack;
        //    //                        break;


        //    //                    }
        //    //                    if (Form1.Squares[y, x].Tas == null)
        //    //                    {
        //    //                        Form1.Squares[OldY, OldX].Tas = null;
        //    //                        Form1.Squares[OldY, OldX].GetBackgroundİmage();
        //    //                        Form1.Squares[OldY, OldX].Dolumu = false;
        //    //                        this.TasKordinat.X = x;
        //    //                        this.TasKordinat.Y = y;
        //    //                        Form1.Squares[y, x].Tas = this;
        //    //                        Form1.Squares[y, x].GetBackgroundİmage();
        //    //                        Form1.Squares[y, x].Dolumu = true;
        //    //                        this.İsMoved = true;
        //    //                        this.MakeCangoList();
        //    //                        Form1.TurnOfBlack = !Form1.TurnOfBlack;
        //    //                        break;

        //    //                    }

        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}

        //    #endregion


        //    FillAllCanGoList();
        //    FillAttackList();
        //    if (Form1.İsKingDanger(!this.İsBlack)) MessageBox.Show("Şah ..");

        // 
        #endregion

    }
}
