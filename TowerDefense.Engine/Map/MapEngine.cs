using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Engine.Map
{
	internal class MapEngine: GameLayerWorkerBase
	{
		
		private GameMapContainer _gameMapContainer;

		public MapEngine(IGameLayerContainerCreator creator): base(creator)
		{

		}
		public GameMapContainer GetMap()
		{
			return _gameMapContainer;
		}

		public override void UpdateState()
		{
			//TODO: Update State
		}
	}
}
