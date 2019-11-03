using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public abstract class Tas
    {
        public Tas()
        {
            this.İsMoved = false;
        }
        public List<Kordinat> KordinatsCanGo = new List<Kordinat>();
        protected TasTipi _TasTİpi;
        protected bool _İsBlack;
        protected string _BackGroundİmage;
        public int İd { get; set; }
        public Kordinat TasKordinat { get; set; }
        public TasTipi TasTipi { get { return _TasTİpi; } }
        public bool İsMoved { get;protected set; }

        public bool İsBlack { get { return _İsBlack; } }

        public string Backgroundİmage { get { return _BackGroundİmage; } }

        public virtual void Move(int x, int y)
        {
            int OldX = this.TasKordinat.X, OldY = this.TasKordinat.Y;


            foreach (Kordinat VARIABLE in this.KordinatsCanGo)
            {
                if (VARIABLE.X == x && VARIABLE.Y == y)
                {
                    Form1.Squares[OldY, OldX].Tas = null;
                    Form1.Squares[OldY, OldX].GetBackgroundİmage();
                    Form1.Squares[OldY, OldX].Dolumu = false;
                    this.TasKordinat.X = x;
                    this.TasKordinat.Y = y;
                    Form1.Squares[y, x].Tas = this;
                    Form1.Squares[y, x].GetBackgroundİmage();
                    break;
                }

            }

            this.İsMoved = true;
        }

        public virtual bool CanGo(int x, int y)
        {
            if (y < 8 && y > -1 && x < 8 && x > -1 && !Form1.Squares[y, x].Dolumu)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract void MakeCangoList();

        public virtual void RandomGit()
        {
            MakeCangoList();
            Random rnd = new Random();
            int random = rnd.Next(0, this.KordinatsCanGo.Count);
            Move(KordinatsCanGo[random].X, KordinatsCanGo[random].Y);
        }
    }



    public enum TasTipi
    {
        Kale,
        Sah,
        Piyon,
        Fil,
        At,
        Vezir,

    }

}
