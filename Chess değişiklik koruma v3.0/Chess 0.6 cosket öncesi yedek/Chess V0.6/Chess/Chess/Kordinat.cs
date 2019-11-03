using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Kordinat : ICloneable
    {

        private int _x, _y;
        private KordinatType _KordinatType=KordinatType.Attack;

        public KordinatType KordinatType
        {
            get { return _KordinatType; }
            set { _KordinatType = value; }
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override bool Equals(object o)
        {
            Kordinat asd = (Kordinat)o;
            return (X == asd.X && Y == asd.Y);

        }

        public static bool operator ==(Kordinat kordinat, Kordinat kordinat1)
        {
            return kordinat1.Equals(kordinat);
        }

        public static bool operator !=(Kordinat kordinat, Kordinat kordinat1)
        {
            return !kordinat1.Equals(kordinat);
        }
    }

    public enum KordinatType
    {
        Attack,
        Normal
    }
}
