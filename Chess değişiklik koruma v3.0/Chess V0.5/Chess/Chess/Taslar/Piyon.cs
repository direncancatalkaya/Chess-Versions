﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Piyon : Tas, IEnpassant
    {
        public Piyon(bool İsBlack)
        {
            _TasTİpi = TasTipi.Piyon;
            _İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            _BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Piyon.png";
            isEnpassEnable = false;
        }

        public bool isEnpassEnable { get; set; }

        public bool CanEat(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }


            if (Form1.Squares[y, x].Tas != null && (TargetİsBlack(x, y) != İsBlack))
            {
                return true;
            }

            return false;
        }

        public override void MakeCangoList()
        {
            KordinatsCanGo.Clear();
            int x = TasKordinat.X, y = TasKordinat.Y;



            if (!İsBlack)
            {



                y += 1;
                if (CanGo(x, y) && !Form1.Squares[y, x].Dolumu)
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y, KordinatType = KordinatType.Normal });
                }



                y = TasKordinat.Y;
                y += 2;
                if (CanGo(x, y) && !Form1.Squares[y - 1, x].Dolumu && İsMoved == 0 && !Form1.Squares[y, x].Dolumu)
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y, KordinatType = KordinatType.Normal });
                }


                x = TasKordinat.X;
                y = TasKordinat.Y;
                x += 1;
                y += 1;
                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y, KordinatType = KordinatType.Attack });
                }


                x = TasKordinat.X;
                y = TasKordinat.Y;
                x += -1;
                y += 1;

                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y, KordinatType = KordinatType.Attack });
                }

            }
            else
            {

                y += -1;
                if (CanGo(x, y) && !Form1.Squares[y, x].Dolumu)
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y, KordinatType = KordinatType.Normal });
                }

                y = TasKordinat.Y;
                y += -2;
                if (CanGo(x, y) && !Form1.Squares[y + 1, x].Dolumu && İsMoved == 0 && !Form1.Squares[y, x].Dolumu)
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y, KordinatType = KordinatType.Normal });
                }


                x = TasKordinat.X;
                y = TasKordinat.Y;
                x += 1;
                y += -1;
                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y, KordinatType = KordinatType.Attack });
                }


                x = TasKordinat.X;
                y = TasKordinat.Y;
                x += -1;
                y += -1;

                if (CanGo(x, y))
                {
                    KordinatsCanGo.Add(new Kordinat { X = x, Y = y, KordinatType = KordinatType.Attack });
                }

            }


        }

        public override bool CanGo(int x, int y)
        {
            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }

            if (!Form1.Squares[y, x].Dolumu || Form1.Squares[y, x].Tas.İsBlack != İsBlack)
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



            int OldX = TasKordinat.X, OldY = TasKordinat.Y;



            foreach (Kordinat VARIABLE in KordinatsCanGo)
            {
                if (VARIABLE.X == x && VARIABLE.Y == y && VARIABLE.KordinatType == KordinatType.Attack && CanEat(x, y))
                {

                    Form1.Squares[OldY, OldX].Tas = null;
                    Form1.Squares[OldY, OldX].GetBackgroundİmage();
                    Form1.Squares[OldY, OldX].Dolumu = false;
                    TasKordinat.X = x;
                    TasKordinat.Y = y;
                    Form1.MevcutTaslar.Remove(Form1.Squares[y, x].Tas);
                    Form1.Squares[y, x].Tas = this;
                    Form1.Squares[y, x].GetBackgroundİmage();
                    Form1.Squares[y, x].Dolumu = true;
                    İsMoved += 1;
                    MakeCangoList();
                    Form1.TurnOfBlack = !Form1.TurnOfBlack;
                    break;

                }

                if (VARIABLE.X == x && VARIABLE.Y == y && VARIABLE.KordinatType == KordinatType.Normal && Form1.Squares[y, x].Tas == null)
                {
                    Form1.Squares[OldY, OldX].Tas = null;
                    Form1.Squares[OldY, OldX].GetBackgroundİmage();
                    Form1.Squares[OldY, OldX].Dolumu = false;
                    TasKordinat.X = x;
                    TasKordinat.Y = y;
                    Form1.Squares[y, x].Tas = this;
                    Form1.Squares[y, x].GetBackgroundİmage();
                    Form1.Squares[y, x].Dolumu = true;
                    İsMoved += 1;
                    MakeCangoList();
                    Form1.TurnOfBlack = !Form1.TurnOfBlack;
                    break;
                }




            }
            FillAllCanGoList();
            FillAttackList();


            if (İsEnemyKingDanger())
            {
                int a = İsCheckMate();

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

            Piyon.AllPiyonisMoveUp();


        }


        public bool isLeftEnpastPossible()
        {
            if (TasKordinat.X + 1 > 7 || TasKordinat.X - 1 < 0 || TasKordinat.Y + 1 > 7 || TasKordinat.Y - 1 < 0 || (!İsBlack && TasKordinat.Y != 4) || (İsBlack && TasKordinat.Y != 3))
            {
                return false;
            }

            if (!İsBlack && Form1.Squares[TasKordinat.Y, TasKordinat.X - 1].Dolumu)
            {
                if (Form1.Squares[TasKordinat.Y, TasKordinat.X - 1].Tas.İsBlack == !İsBlack && Form1.Squares[TasKordinat.Y, TasKordinat.X - 1].Tas.İsMoved == 1 && !Form1.Squares[TasKordinat.Y + 1, TasKordinat.X - 1].Dolumu && Form1.Squares[TasKordinat.Y, TasKordinat.X - 1].Tas.TasTipi == TasTipi.Piyon && (Form1.Squares[TasKordinat.Y, TasKordinat.X - 1].Tas as Piyon).isEnpassEnable)
                {
                    return true;
                }
            }
            else
            {
                if (İsBlack && Form1.Squares[TasKordinat.Y, TasKordinat.X + 1].Dolumu)
                {
                    if (Form1.Squares[TasKordinat.Y, TasKordinat.X + 1].Tas.İsBlack == !İsBlack && Form1.Squares[TasKordinat.Y, TasKordinat.X + 1].Tas.İsMoved == 1 && !Form1.Squares[TasKordinat.Y - 1, TasKordinat.X + 1].Dolumu && İsBlack && Form1.Squares[TasKordinat.Y, TasKordinat.X + 1].Tas.TasTipi == Chess.TasTipi.Piyon && (Form1.Squares[TasKordinat.Y, TasKordinat.X + 1].Tas as Piyon).isEnpassEnable)
                    {
                        return true;
                    }
                }

            }

            return false;

        }

        public bool isRightEnpassPossible()
        {
            if (TasKordinat.X + 1 > 7 || TasKordinat.X - 1 < 0 || TasKordinat.Y + 1 > 7 || TasKordinat.Y - 1 < 0 || (!İsBlack && TasKordinat.Y != 4) || (İsBlack && TasKordinat.Y != 3))
            {
                return false;
            }

            if (!İsBlack && Form1.Squares[TasKordinat.Y, TasKordinat.X + 1].Dolumu)
            {
                if (Form1.Squares[TasKordinat.Y, TasKordinat.X + 1].Tas.İsBlack == !İsBlack && Form1.Squares[TasKordinat.Y, TasKordinat.X + 1].Tas.İsMoved == 1 && !Form1.Squares[TasKordinat.Y + 1, TasKordinat.X + 1].Dolumu && Form1.Squares[TasKordinat.Y, TasKordinat.X + 1].Tas.TasTipi == TasTipi.Piyon && (Form1.Squares[TasKordinat.Y, TasKordinat.X + 1].Tas as Piyon).isEnpassEnable)
                {
                    return true;
                }
            }
            else
            {
                if (İsBlack && Form1.Squares[TasKordinat.Y, TasKordinat.X - 1].Dolumu)
                {
                    if (Form1.Squares[TasKordinat.Y, TasKordinat.X - 1].Tas.İsBlack == !İsBlack && Form1.Squares[TasKordinat.Y, TasKordinat.X - 1].Tas.İsMoved == 1 && !Form1.Squares[TasKordinat.Y - 1, TasKordinat.X + 1].Dolumu && Form1.Squares[TasKordinat.Y, TasKordinat.X - 1].Tas.TasTipi == TasTipi.Piyon && (Form1.Squares[TasKordinat.Y, TasKordinat.X - 1].Tas as Piyon).isEnpassEnable)
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        public void LetsRightEnpass()
        {
            if (!İsBlack)
            {
                MoveNonCheck(TasKordinat.X + 1, TasKordinat.Y);
                MoveNonCheck(TasKordinat.X, TasKordinat.Y + 1);
                Form1.TurnOfBlack = !Form1.TurnOfBlack;
            }
            else
            {
                MoveNonCheck(TasKordinat.X - 1, TasKordinat.Y);
                MoveNonCheck(TasKordinat.X, TasKordinat.Y - 1);
                Form1.TurnOfBlack = !Form1.TurnOfBlack;
            }

            Piyon.AllPiyonisMoveUp();
        }

        public void LetsLeftEnpass()
        {
            if (!İsBlack)
            {
                MoveNonCheck(TasKordinat.X - 1, TasKordinat.Y);
                MoveNonCheck(TasKordinat.X, TasKordinat.Y + 1);
                Form1.TurnOfBlack = !Form1.TurnOfBlack;
            }
            else
            {
                MoveNonCheck(TasKordinat.X + 1, TasKordinat.Y);
                MoveNonCheck(TasKordinat.X, TasKordinat.Y - 1);
                Form1.TurnOfBlack = !Form1.TurnOfBlack;
            }

            Piyon.AllPiyonisMoveUp();
        }

        public static void AllPiyonisMoveUp()
        {
            foreach (Tas VARIABLE in Form1.MevcutTaslar)
            {
                if (VARIABLE.TasTipi == TasTipi.Piyon)
                {
                    (VARIABLE as Piyon).isEnpassEnable = false;
                }
            }
        }
    }
}

