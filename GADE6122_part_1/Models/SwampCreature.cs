using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_part_1.Models
{
    public class SwampCreature : Enemy
    {

        public SwampCreature(
            int x, 
            int y, 
            int hp,
            int maxHP, 
            int damage, 
            string symbol
            ) : base(x, y, hp, maxHP,damage, symbol)
        {
            MaxHP = 10;
            Damage = 1;
        }

		public override Movement ReturnMove()
		{
			Movement[] values = (Movement[])Enum.GetValues(typeof(Movement));
			Movement movement = values[new Random().Next(0, values.Length)];

			//while (var tile in Vision)
			//{
			//	if (tile == TileType.Hero || tile == TileType.Wall)
			//	{
			//		movement = values[new Random().Next(0, values.Length)];
			//	}
			//}

			return movement;
		}
		//public override Movement ReturnMove()
		//{
		//	Movement[] values = (Movement[])Enum.GetValues(typeof(Movement));
		//	Movement movement = new Movement();

		//	foreach (var tile in Vision)
		//	{
		//		if (tile == TileType.Hero || tile == TileType.Wall)
		//		{
		//			movement = values[new Random().Next(0, values.Length)];
		//		}
		//	}

		//	return movement;
		//}
	}
}
