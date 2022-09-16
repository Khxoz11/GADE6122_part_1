using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADE6122_part_1.Models
{
	internal class GameEngine
	{
		Map map;
		Form MainForm;

		public GameEngine(Form theform) { 
			this.MainForm = theform;
			map = new Map(5, 10, 5, 10, 3);
			DrawMap();

		}

		public void KeyPressed(object? sender, PreviewKeyDownEventArgs e)
		{
			MoveCharacter(sender, e);
		}

		public bool MoveCharacter(object? sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.M)
			{
				map = new Map(5, 10, 5, 10, 3);
				DrawMap();
			}
			if (e.KeyCode == Keys.W)
			{
				if (map.Tiles[map.Hero.X, map.Hero.Y - 1] != null) // tile is not empty
					return false;
				map.Tiles[map.Hero.X, map.Hero.Y - 1] = map.Hero;
				map.Tiles[map.Hero.X, map.Hero.Y] = null;
				map.Hero.Y = map.Hero.Y - 1;
			}
			if (e.KeyCode == Keys.S)
			{
				if (map.Tiles[map.Hero.X, map.Hero.Y + 1] != null) // tile is not empty
					return false;
				map.Tiles[map.Hero.X, map.Hero.Y + 1] = map.Hero;
				map.Tiles[map.Hero.X, map.Hero.Y] = null;
				map.Hero.Y = map.Hero.Y + 1;
			}
			if (e.KeyCode == Keys.A)
			{
				if (map.Tiles[map.Hero.X - 1, map.Hero.Y] != null) // tile is not empty
					return false;
				map.Tiles[map.Hero.X - 1, map.Hero.Y] = map.Hero;
				map.Tiles[map.Hero.X, map.Hero.Y] = null;
				map.Hero.X = map.Hero.X - 1;
			}
			if (e.KeyCode == Keys.D)
			{
				if (map.Tiles[map.Hero.X + 1, map.Hero.Y] != null) // tile is not empty
					return false;
				map.Tiles[map.Hero.X + 1, map.Hero.Y] = map.Hero;
				map.Tiles[map.Hero.X, map.Hero.Y] = null;
				map.Hero.X = map.Hero.X + 1;
			}
			DrawMap();
			return true;
		}
		private void DrawMap()
		{

			MainForm.Controls.Clear();
			var buttons = new Button[100, 100];


			//this.KeyPress += Form1_KeyPress;
			const int blockSize = 150;

			Label label = new Label();
			label.Text=map.Hero.ToString();
			label.Top = 0;
			label.Left = 0;
			label.Height = 150;
			label.Width = 300;
			MainForm.Controls.Add(label);

			for (int i = 0; i < map.Width; i++)
			{
				for (int ii = 0; ii < map.Height; ii++)
				{
					var b = new Button();
					string text = "";
					if (map.Tiles[i, ii] is Hero) text="P";
					if (map.Tiles[i, ii] is Enemy) text="X";
					if (map.Tiles[i, ii] is Obstacle) text = "0";
					b.Text = text;
					b.Left = i * blockSize;
					b.Top = (ii + 1) * blockSize; // +1 to leave space for the status display
					b.Width = blockSize;
					b.Height = blockSize;
					b.PreviewKeyDown += KeyPressed;
					//if (i==0 || ii==0 || i==size-1 || ii==size-1) {
					//	b.Text = "W";
					//	b.BackColor = Color.Gray;
					//}

					b.FlatStyle = FlatStyle.Flat;
					b.FlatAppearance.BorderColor = Color.WhiteSmoke;
					b.FlatAppearance.BorderSize = 1;

					buttons[i, ii] = b;

					MainForm.Controls.Add(b);
				}
			}
			MainForm.Height = blockSize * map.Height +300;
			MainForm.Width = blockSize * map.Width +100;

		}
	}
}
