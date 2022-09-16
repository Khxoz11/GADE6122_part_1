using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_part_1.Models
{
	internal class Hero : Character
	{
		public Hero(int x, int y, int hp, int maxhp) : base(x, y)
		{
			Damage = 2;
			HP = hp;
			MaxHP = maxhp;
			Symbol = "J";
		}

		public override Movement ReturnMove()
		{
			throw new NotImplementedException();
		}

		public override string ToString()
		{
			return $"Player Stats:\nHP: {HP}/{MaxHP}\nDamage: {Damage}\n[{X},{Y}]"; 

		}
	}
}
