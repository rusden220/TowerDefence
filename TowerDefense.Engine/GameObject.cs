using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TowerDefense.Render.Image;

namespace TowerDefense.Engine
{
	public abstract class GameObject
	{
		public Rectangle Location { get; set; }
		public AnimationBitmap Image { get; set; }
	}
}
