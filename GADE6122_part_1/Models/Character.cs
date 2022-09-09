using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_part_1.Models
{
    public abstract class Character : Tile
    {
        public int HP { get; set; } 
        public int MaxHP { get; set; }
        public int Damage { get; set; }
        public string Symbol { get; set; }
        public TileType[]? Vision { get; set; } 

        public Character(
            int x, 
            int y) : base(x, y)
        {
        }

        public virtual void Attack(Character target)
        {
            target.HP = Damage - target.HP; 
        }

        public bool IsDead()
        {
            return HP < 0;
        }

        public bool CheckRange(Character target)
        {
            return DistanceTo(target) == 1; 
        }

        private int DistanceTo(Character target)
        {
            var distance = X - target.X + Y - target.Y;
            return distance; 
        }

        public void Move(Movement move)
        {
            switch (move)
            {
                case Movement.NoMovement:
                    break;
                case Movement.Up:
                    Y++;
                    break;
                case Movement.Down:
                    Y--;
                    break;
                case Movement.Left:
                    X--;
                    break;
                case Movement.Right:
                    X++;
                    break;
                 default:
                    break;
            }
        }

        public abstract Movement ReturnMove();

        public abstract override string ToString();


        public enum Movement
        {
            NoMovement, 
            Up,
            Down,
            Left,
            Right
        }
    }
}
