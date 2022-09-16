using GADE6122_part_1.Models;
using System.Diagnostics;

namespace GADE6122_part_1
{
    public partial class Form1 : Form
    {
        public Form1()
		{
			InitializeComponent();

			GameEngine gameEngine = new GameEngine(this);

			this.KeyPreview = true;
			this.PreviewKeyDown += gameEngine.KeyPressed;

			this.Focus();

		}




	}
}