using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public sealed class Sah : Tas, IRook
    {
        public Sah(bool İsBlack)
        {
            _TasTİpi = TasTipi.Sah;
            _İsBlack = İsBlack;
            string Renk = İsBlack == true ? "Siyah" : "Beyaz";
            _BackGroundİmage = $"{ Application.StartupPath}//Taslar//{Renk}Sah.png";
            _Tasid = İsBlack ? Tasİd.SiyahSah : Tasİd.BeyazSah;

        }
        /// <summary>
        ///  taşın Gidebileceği Yerleri Hesaplayıp Yolu üzerinde Başka taş Varmı Hesaplar ve listeyi doldurur ..
        /// </summary>
        public override void MakeCangoList()
        {
            KordinatsCanGo.Clear();

            int x = TasKordinat.X, y = TasKordinat.Y;
            y += 1;
            x += 1;
            if (CanGo(x, y))
            {
                KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = TasKordinat.X;
            y = TasKordinat.Y;
            y += 1;
            x += -1;
            if (CanGo(x, y))
            {
                KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = TasKordinat.X;
            y = TasKordinat.Y;
            y += 1;

            if (CanGo(x, y))
            {
                KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = TasKordinat.X;
            y = TasKordinat.Y;
            y += -1;

            if (CanGo(x, y))
            {
                KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = TasKordinat.X;
            y = TasKordinat.Y;
            y += -1;
            x += -1;
            if (CanGo(x, y))
            {
                KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = TasKordinat.X;
            y = TasKordinat.Y;
            y += -1;
            x += +1;
            if (CanGo(x, y))
            {
                KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = TasKordinat.X;
            y = TasKordinat.Y;

            x += -1;
            if (CanGo(x, y))
            {
                KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }

            x = TasKordinat.X;
            y = TasKordinat.Y;

            x += 1;
            if (CanGo(x, y))
            {
                KordinatsCanGo.Add(new Kordinat { X = x, Y = y });
            }



        }

        public bool isShortRookPossible()
        {
            if (İsBlack)
            {
                if (!İsSquareİnDanger(5, 7) && !İsSquareİnDanger(6, 7) && ChessBoard.Squares[7, 7].Tas.İsMoved == 0 && İsMoved == 0)
                {
                    return true;
                }

            }
            else
            {
                if (!İsSquareİnDanger(5, 0) && !İsSquareİnDanger(6, 0) && ChessBoard.Squares[0, 7].Tas.İsMoved == 0 && İsMoved == 0)
                {
                    return true;
                }

            }

            return false;
        }

        public bool isLongRookPossible()
        {
            if (İsBlack)
            {
                if (!İsSquareİnDanger(2, 7) && !İsSquareİnDanger(3, 7) && ChessBoard.Squares[7, 0].Tas.İsMoved == 0 && İsMoved == 0 && !ChessBoard.Squares[7, 1].Dolumu)
                {
                    return true;
                }

            }
            else
            {
                if (!İsSquareİnDanger(2, 0) && !İsSquareİnDanger(3, 0) && ChessBoard.Squares[0, 0].Tas.İsMoved == 0 && İsMoved == 0 && !ChessBoard.Squares[0, 1].Dolumu)
                {
                    return true;
                }

            }

            return false;
        }

        public void LetsShortRook()
        {
            if (İsBlack)
            {
                MoveNonCheck(6, 7);
                ChessBoard.Squares[7, 7].Tas.MoveNonCheck(5, 7);
                ChessBoard.TurnOfBlack = !ChessBoard.TurnOfBlack;
            }
            else
            {
                MoveNonCheck(6, 0);
                ChessBoard.Squares[0, 7].Tas.MoveNonCheck(5, 0);
                ChessBoard.TurnOfBlack = !ChessBoard.TurnOfBlack;
            }

            ChessBoard.AllPiyonisMoveUp();
        }

        public void LetsLongRook()
        {
            if (İsBlack)
            {
                MoveNonCheck(2, 7);
                ChessBoard.Squares[7, 0].Tas.MoveNonCheck(3, 7);
                ChessBoard.TurnOfBlack = !ChessBoard.TurnOfBlack;
            }
            else
            {
                MoveNonCheck(2, 0);
                ChessBoard.Squares[0, 0].Tas.MoveNonCheck(3, 0);
                ChessBoard.TurnOfBlack = !ChessBoard.TurnOfBlack;
            }

            ChessBoard.AllPiyonisMoveUp();
        }
    }
}
