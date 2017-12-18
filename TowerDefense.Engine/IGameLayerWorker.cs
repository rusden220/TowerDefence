using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Engine
{
	public interface IGameLayerContainerCreator
	{
		GameLayerContainer CreateGameLayerContainer();
	}
	public abstract class GameLayerWorkerBase
	{
		protected GameLayerContainer _gameLayerContainer;
		public GameLayerWorkerBase(IGameLayerContainerCreator creator)
		{
			_gameLayerContainer = creator.CreateGameLayerContainer();
		}
		public GameLayerContainer GetGameLayerContainer { get { return _gameLayerContainer; } }
		
		public abstract void UpdateState();
	}
}
