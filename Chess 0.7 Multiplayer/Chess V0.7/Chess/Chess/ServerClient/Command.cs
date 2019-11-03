using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.ServerClient
{
    [Serializable]
    public class Command
    {
        public HamleTipi HamleTipi { get; set; }
        public Kordinat From { get; set; }
        public Kordinat To { get; set; }
    }


    public enum HamleTipi
    {
      Move,
      BlackShortRook,
      BlackLongRook,
      WhiteShortRook,
      WhiteLongRook,
      RightEnpass,
      LeftEnpass,
    }
}
