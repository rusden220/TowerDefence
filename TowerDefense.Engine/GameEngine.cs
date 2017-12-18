using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TowerDefense.Engine.Map;

namespace TowerDefense.Engine
{

	public class GameEngine
	{
		public enum AllGameLayers
		{
			Game = 0,
			Menu = 1,
			User = 2,
			Bullet = 3,
			Achievement = 4,
			//use only to get the size
			Size = 5

		}
		public GameEngine(IGameLayerContainerCreator creator)
		{
			GetGameLayersContainer = new GameLayerWorkerBase[(int)AllGameLayers.Size]
			{
				new MapEngine(creator),
				new MapEngine(creator),
				new MapEngine(creator),
				new MapEngine(creator),
				new MapEngine(creator),
			};
		}
		public GameLayerWorkerBase[] GetGameLayersContainer { get; }
		public void UpdateState(long timeStemp)
		{
			foreach (var layer in GetGameLayersContainer)
			{
				layer.UpdateState();
			}
		}
	}
}
