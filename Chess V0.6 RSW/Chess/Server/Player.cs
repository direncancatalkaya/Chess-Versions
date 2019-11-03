using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Chess
{
    public class Player
    {
        
        public int İd { get; set; }
        public string ip { get; set; }
        public string NickName { get; set; }
        public PlayerType PlayerType { get; set; }

    }

    public enum PlayerType
    {
        White,
        Black,
        Spectator,
        Admin
    }
}
