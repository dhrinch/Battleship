using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class CCommon
    {
    }

    public class CPosition
    {
        public int X { set; get; } 
        public int Y { set; get; }
        
        public CPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
