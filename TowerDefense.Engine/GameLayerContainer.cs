using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Engine
{
	/// <summary>
	/// contain state for current game state
	/// </summary>
	public class GameLayerContainer
	{
		public List<GameObject> GameObjects { get; set; }
		public Bitmap LayerBitmap { get; set; }
		public Rectangle Location { get; set; }
	}
}
