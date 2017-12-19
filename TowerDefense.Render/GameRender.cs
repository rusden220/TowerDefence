using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using TowerDefense.Engine;

namespace TowerDefense.Render
{
    public class GameRender
    {
		private GameLayerWorkerBase[] _arrayGameLayer;
		private Bitmap _currentBitmapState;
		public GameRender(Size size, GameLayerWorkerBase[] arrayGameLayerWorker)
		{
			this.MainGameBitmapSize = size;
			this._arrayGameLayer = arrayGameLayerWorker;
		}

		public Size MainGameBitmapSize { get; }

		public Bitmap GetCurrentBitmapSate { get { return _currentBitmapState; } }

		public void UpdateState(long timeStemp)
		{
			_currentBitmapState = new Bitmap(MainGameBitmapSize.Width, MainGameBitmapSize.Height);
			var graphics = Graphics.FromImage(_currentBitmapState);
			foreach (var layer in _arrayGameLayer)
			{
				layer.GetGameLayerContainer.LayerBitmap = CreateLayerBitmap(layer.GetGameLayerContainer, timeStemp);
				graphics.DrawImage(layer.GetGameLayerContainer.LayerBitmap, layer.GetGameLayerContainer.Location);
			}
		}
		public Bitmap CreateLayerBitmap(GameLayerData gameLayer, long timeStemp)
		{
			var resultBitmap = new Bitmap(gameLayer.Location.Width, gameLayer.Location.Height);
			var graphics = Graphics.FromImage(resultBitmap);

			foreach (var gameObject in gameLayer.GameObjects)
				graphics.DrawImage(gameObject.Image.GetNextBitmap(timeStemp), gameObject.Location);

			return resultBitmap;
		}
	}
}
