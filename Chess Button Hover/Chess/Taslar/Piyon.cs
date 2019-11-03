using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Piyon : Tas
    {
        public Piyon(bool İsBlack)
        {
            this._TasTİpi = TasTipi.Piyon;
            this._İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            this._BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Piyon.png";
        }

        public bool CanEat(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }


            if (Form1.Squares[y, x].Tas != null && (TargetİsBlack(x, y) != this.İsBlack))
            {
                return true;
            }

            return false;
        }

        public override void MakeCangoList() // taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        {
            this.KordinatsCanGo.Clear();
            int x = this.TasKordinat.X, y = this.TasKordinat.Y;



            if (!this.İsBlack)
            {



                y += 1;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y, Attack = false });
                }

                y = this.TasKordinat.Y;


                if (!İsMoved)
                {
                    y = this.TasKordinat.Y;
                    y += 2;
                    if (CanGo(x, y))
                    {
                        this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y, Attack = false });
                    }

                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                x += 1;
                y += 1;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y, Attack = true });
                }


                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                x += -1;
                y += 1;

                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y, Attack = true });
                }

            }
            else
            {

                y += -1;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y, Attack = false });
                }

                if (!İsMoved)
                {

                    y = this.TasKordinat.Y;
                    y += -2;
                    if (CanGo(x, y))
                    {
                        this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y, Attack = false });
                    }
                }

                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                x += 1;
                y += -1;
                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y, Attack = true });
                }


                x = this.TasKordinat.X;
                y = this.TasKordinat.Y;
                x += -1;
                y += -1;

                if (CanGo(x, y))
                {
                    this.KordinatsCanGo.Add(new Kordinat { X = x, Y = y, Attack = true });
                }

            }

            
        }

        public override bool CanGo(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }

            if (!Form1.Squares[y, x].Dolumu || Form1.Squares[y, x].Tas.İsBlack!=this.İsBlack)
            {
                return true;
            }



            return false;

        }

        public override void Move(int x, int y)
        {
            //FillAllCanGoList();
            //FillAttackList();
            if (!FakeMove(x, y))
            {
                MessageBox.Show("Şah Tehdit Altında Kalıyor Bu hamle yapılamaz..");
                return;
                FillAllCanGoList();
                FillAttackList();
            }
            FillAllCanGoList();
            FillAttackList();



            int OldX = this.TasKordinat.X, OldY = this.TasKordinat.Y;



            foreach (Kordinat VARIABLE in this.KordinatsCanGo)
            {
                if (VARIABLE.X == x && VARIABLE.Y == y && VARIABLE.Attack && CanEat(x, y))
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
                    this.İsMoved = true;
                    this.MakeCangoList();
                    Form1.TurnOfBlack = !Form1.TurnOfBlack;
                    break;

                }

                if (VARIABLE.X == x && VARIABLE.Y == y && !VARIABLE.Attack && Form1.Squares[y, x].Tas == null)
                {
                    Form1.Squares[OldY, OldX].Tas = null;
                    Form1.Squares[OldY, OldX].GetBackgroundİmage();
                    Form1.Squares[OldY, OldX].Dolumu = false;
                    this.TasKordinat.X = x;
                    this.TasKordinat.Y = y;
                    Form1.Squares[y, x].Tas = this;
                    Form1.Squares[y, x].GetBackgroundİmage();
                    Form1.Squares[y, x].Dolumu = true;
                    this.İsMoved = true;
                    this.MakeCangoList();
                    Form1.TurnOfBlack = !Form1.TurnOfBlack;
                    break;
                }

               


            }
            FillAllCanGoList();
            FillAttackList();


            if (İsEnemyKingDanger())
            {
                int a = this.İsCheckMate();

                if (a < 3)
                {
                    MessageBox.Show("Şah Mat .. Oyun Bitti Tebrikler ..");
                }
                else if (a > 0)
                {
                    MessageBox.Show("Şah..");
                }
            }


            if (TasKordinat.Y == 0 || TasKordinat.Y == 7)
            {
                Form2 frm2 = new Form2(this);
                frm2.ShowDialog();
            }
        }


    }
}

