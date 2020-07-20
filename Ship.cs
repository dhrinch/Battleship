using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public class Ship
    {
        public enum Direction { vert, horiz }
        public int x { set; get; }
        public int y { set; get; }
        public Direction direction;
        public int size;
        public Ship(int X, int Y, Direction dir, int Size)
        {
            x = X;
            y = Y;
            direction = dir;
            size = Size;
        }

        public CPosition[] GetPositions()
        {
            CPosition[] positions = new CPosition[size];
            if(direction == Direction.vert)
            {
                for (int j = 0; j < size; j++) positions[j] = new CPosition(x + j, y);
            }
            if (direction == Direction.horiz)
            {
                for (int i = 0; i < size; i++) positions[i] = new CPosition(x, y+i);
            }
            return positions;
        }
    }
}
