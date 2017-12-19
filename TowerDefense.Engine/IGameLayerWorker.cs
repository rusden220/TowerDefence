using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Engine
{
	public interface IGameLayerContainerCreator
	{
		GameLayerData CreateGameLayerContainer();
	}
	public abstract class GameLayerWorkerBase
	{
		protected GameLayerData _gameLayerContainer;
		public GameLayerWorkerBase(IGameLayerContainerCreator creator)
		{
			_gameLayerContainer = creator.CreateGameLayerContainer();
		}
		public GameLayerData GetGameLayerContainer { get { return _gameLayerContainer; } }
		
		public abstract void UpdateState();
	}
}
