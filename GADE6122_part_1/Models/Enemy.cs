using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_part_1.Models
{
    public abstract class Enemy : Character
    {
        Random RandomNumber { get; set; }

        public Enemy(
            int x,
            int y,
            int hp,
            int maxHP,
            string symbol) : base(x, y)
        {
            HP = hp;
            MaxHP = maxHP;
            Symbol = symbol;
        }
        public override string ToString()
        {
            return $"Enemy at [{X}, {Y}] ({Damage})";
        }
    }
}
