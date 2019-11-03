using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public interface IRook
    {
        bool isShortRookPossible();
        bool isLongRookPossible();
        void LetsShortRook();
        void LetsLongRook();
    }
}
