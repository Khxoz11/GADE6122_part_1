using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_part_1.Models
{
    public abstract class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }

        protected Tile(int x, int y)
        {
            X = x;
            Y = y;
        }

        public enum TileType
        {
            Hero,
            Enemy,
            Gold, 
            Weapon
        }
    }
}
