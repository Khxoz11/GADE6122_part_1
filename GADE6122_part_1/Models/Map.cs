using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GADE6122_part_1.Models
{
	internal class Map
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public Enemy[] EnemyList { get; set; }
		public Hero Hero { get; set; }

		public Tile[,] Tiles { get; set; }

		Random Rand=new Random();

		public Map(int minWidth,int maxWidth,int minHeight,int maxHeight, int numEnemies)
		{
			Width=Rand.Next(minWidth,maxWidth);
			Height=Rand.Next(minHeight, maxHeight);
			Tiles=new Tile[Width, Height];
			EnemyList = new Enemy[numEnemies];

			for (int i = 0; i < Width; i++)
			{
				Tiles[i, 0] = new Obstacle(i,0);
			}
			for (int i = 1; i < Height - 1; i++)
			{
				Tiles[0, i] = new Obstacle(0, i);
			}
			for (int i = 1; i < Height - 1; i++)
			{
				Tiles[Width-1, i] = new Obstacle(Width - 1, i);
			}
			for (int i = 0; i < Width; i++)
			{
				Tiles[i, Height - 1] = new Obstacle(i, Height - 1);
			}

			Hero = Create(Tile.TileType.Hero) as Hero;

			for (int i = 0; i < numEnemies; i++)
			{
				EnemyList[i] = Create(Tile.TileType.Enemy) as SwampCreature;
			}
			  
			var totBlocksRequired = numEnemies + 1;// 1 for the hero
			var availBlocks = (Width - 2) * (Height - 2);
			if (totBlocksRequired > availBlocks)
			{
				throw new Exception();
			}

		}

		private Tile Create(Tile.TileType tileType)
		{
			int starty = 0;
			if (tileType == Tile.TileType.Hero) { starty = 1; }

			int x=Rand.Next(0,Width);
			int y=Rand.Next(starty,Height);

			while (Tiles[x,y] != null)
			{
				x = Rand.Next(0, Width);
				y = Rand.Next(0, Height);
			}

			if (tileType == Tile.TileType.Hero)
			{
				//Hero = new Hero(x, y, 10, 10);
				Tiles[x, y] = new Hero(x, y, 10, 10);
			}

			if (tileType == Tile.TileType.Enemy) {
				//var sw = new SwampCreature(x, y, 10, 10, 1, "");
				Tiles[x, y] = new SwampCreature(x, y, 10, 10, 1, "N");
			}
			return Tiles[x, y];

		}

	}


}
