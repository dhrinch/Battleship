using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class CGame
    {
        //0 - empty
        //1 - filled

        //int[,] map; 

        List<Ship> ships;
        public CGame()
        {
            ships = new List<Ship>();
            //map = new int[10,10];
        }

        public bool addShip(Ship ship)
        {
            if (ship.direction == Ship.Direction.vert && ship.x > 10 - ship.size) return false;
            if (ship.direction == Ship.Direction.horiz && ship.y > 10 - ship.size) return false;

            bool Ok = test(ship);
            if (!Ok) return false;
            
            ships.Add(ship);
            return true;
        }

        private bool test(Ship _ship)
        {
            CPosition[] _positions = _ship.GetPositions();
            foreach (var ship in ships)
            {
                CPosition[] positions = ship.GetPositions();
                for (int i = 0; i < _positions.Length; i++)
                {
                    for (int j = 0; j < positions.Length; j++)
                    {
                        int dX = Math.Abs(_positions[i].X - positions[j].X);
                        int dY = Math.Abs(_positions[i].Y - positions[j].Y);
                        if (dX < 2 && dY < 2) return false;
                    }
                }
            }
            return true;
        }

        public void delete(Ship ship)
        {
            ships.Remove(ship);
        }

        public int[,] fillMap()
        {
            int[,] map = new int[10, 10];
            foreach (var ship in ships)
            {
                var positions = ship.GetPositions();
                foreach(var position in positions)
                {
                    map[position.X, position.Y] = 1;
                }
            }
            return map;
        }

        public Ship getShipByPosition(int i, int j)
        {
            foreach(Ship ship in ships)
            {
                var positions = ship.GetPositions();
                foreach (var position in positions)
                {
                    if (position.X == i && position.Y == j) return ship;
                }
            }
            return null;
        }
    }
}
