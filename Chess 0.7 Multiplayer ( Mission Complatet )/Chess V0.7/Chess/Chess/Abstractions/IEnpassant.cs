using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public interface IEnpassant
    {
        bool isEnpassEnable { get; set; }
        bool isLeftEnpastPossible();
        bool isRightEnpassPossible();
        void LetsRightEnpass();
        void LetsLeftEnpass();
    }
}
