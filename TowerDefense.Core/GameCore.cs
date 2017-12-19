using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

using TowerDefense.Engine;
using TowerDefense.Render;


namespace TowerDefense.Core
{
	/// <summary>
	/// Main tower defense 
	/// </summary>
	public class GameCore
	{
		public delegate void RedrawEvent(object sender, Bitmap bitmap);
		public event RedrawEvent RedrawEventHendler;

		private GameRender _gameRender;
		private GameEngine _gameEngine;
		private GameTimer _gameTimer;


		public GameCore(Size mainGameImageSize)
		{			
			_gameEngine = new GameEngine(new GameLayerDataCreator());
			var layers = _gameEngine.GetGameLayersContainer;
			_gameRender = new GameRender(mainGameImageSize, layers);
			_gameTimer = new GameTimer(MainGameLoopHandler);
		}
		public void StartGame()
		{
			if (RedrawEventHendler == null)
				throw new GameCoreException($"{nameof(RedrawEventHendler)} must be set");
			_gameTimer.Start();
		} 
		/// <summary>
		/// mouse click handler 
		/// </summary>
		/// <param name="mousePositon"></param>
		public void AddMouseDown(Point mousePositon, object mouseState)
		{
			Trace.WriteLine($"{nameof(AddMouseDown)}");
		}
		public void AddMouseUp(Point mousePosition, object mouseState)
		{
			Trace.WriteLine($"{nameof(AddMouseUp)}");
		}
		public void AddMouseMove(Point mousePosition, object mouseState)
		{
			Trace.WriteLine($"{nameof(AddMouseMove)}");
		}
		
		internal void MainGameLoopHandler(long elapsedMiliseconds)
		{
			Trace.WriteLine(elapsedMiliseconds);

			_gameEngine.UpdateState(elapsedMiliseconds);
			_gameRender.UpdateState(elapsedMiliseconds);

			//yes i don't check null (the best way is ?. but slowly)
			RedrawEventHendler.Invoke(this, _gameRender.GetCurrentBitmapSate);
		}
		




	}
}
