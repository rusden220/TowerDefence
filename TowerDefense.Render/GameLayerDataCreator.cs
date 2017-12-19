using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using TowerDefense.Engine;

namespace TowerDefense.Render
{
	public class GameLayerDataCreator : IGameLayerContainerCreator
	{
        public GameLayerData CreateGameLayerContainer()
		{
			//TODO rewrite with
			// add new class(Loader ) to the core ?
			return new GameLayerData() { LayerBitmap = new System.Drawing.Bitmap(100, 100), Location = new System.Drawing.Rectangle(0, 0, 100, 100), GameObjects = new List<GameObject>() { } };
		}
	}
}
