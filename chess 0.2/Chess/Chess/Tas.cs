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
        public bool İsMoved { get; protected set; }
        public bool StopTry { get; set; }

        public bool İsBlack { get { return _İsBlack; } }

        public string Backgroundİmage { get { return _BackGroundİmage; } }

        public virtual void Move(int x, int y)
        {
            Form1.BlackAttacks.Clear();
            Form1.WhiteAttacks.Clear();
            foreach (Tas item in Form1.MevcutTaslar)
            {
                item.MakeCangoList();

                if (item.İsBlack)
                {
                    foreach (var VARIABLE in item.KordinatsCanGo)
                    {
                        if (VARIABLE.Attack==true ) Form1.BlackAttacks.Add(VARIABLE);
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


        }

        public virtual bool CanGo(int x, int y)
        {

            if (x < 0 || x > 7 || y < 0 || y > 7)
            {
                return false;
            }

            if (!Form1.Squares[y, x].Dolumu)
            {
                return true;
            }
            if (Form1.Squares[y, x].Dolumu && (TargetİsBlack(x, y) != this.İsBlack))
            {
                this.StopTry = true;
                return true;

            }


            this.StopTry = true;
            return false;





        }

        public virtual bool TargetİsBlack(int x, int y)
        {
            x = x > 7 ? 7 : x;
            y = y > 7 ? 7 : y;
            x = x < 0 ? 0 : x;
            y = y < 0 ? 0 : y;

            if (Form1.Squares[y, x].Tas.İsBlack)
            {

                return true;
            }
            else
            {
                return false;
            }

        }

        public abstract void MakeCangoList();


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
