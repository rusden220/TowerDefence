using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Render.Image
{
	public class AnimationBitmap
	{
		//TODO:rewrite to list 
		private Bitmap _mainBitmap;
		public bool isAnimated { get; set; }

		//TODO: remove implicit convert
		public static implicit operator Bitmap(AnimationBitmap ab)
		{
			return ab._mainBitmap;
		}
		//TODO: remove implicit convert
		public static implicit operator AnimationBitmap(Bitmap bm)
		{
			return new AnimationBitmap() { _mainBitmap = bm };
		}
	}
}
