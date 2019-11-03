using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Kordinat
    {
       
        private int _x, _y;
        private bool _attack = true;

        public bool Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }

        public int X
        {
            get { return _x; }
            set
            {
                if (value>7 || value <0)
                {
                    throw new Exception("Taş Satranç Tahtasının Dışına Çıkamaz ..");
                }
                //else if (Form1.Squares[_y,value].Dolumu==true)
                //{
                //    throw new Exception("Gidilmeye Çalışılan Kare Dolu");
                    
                //}
                else
                {
                    _x = value;
                }
            }
        }
        public int Y
        {
            get { return _y; }
            set
            {
                if (value > 7 || value<0)
                {
                    throw new Exception("Taş Satranç Tahtasının Dışına Çıkamaz ..");
                }
                else
                {
                    _y = value;
                }
            }
        }

        public override bool Equals(object obj)
        {
            Kordinat kordinat = (Kordinat) obj;
            if (this.X == kordinat.X && this.Y==kordinat.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
