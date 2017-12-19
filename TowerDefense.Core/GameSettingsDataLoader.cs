using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TowerDefense.Engine;
using TowerDefense.Render;

namespace TowerDefense.Core
{
    public class GameSettingsDataLoader
    {
		/// <summary>
		/// Load Game all Setting sFrom File
		/// </summary>
		/// <param name="path">if null load default settings</param>
		public void LoadGameSettingsFromFile(string path)
        {
			//TODO write settings loader
			this.EngineSettingsData = new GameEngineSettingsData();
			this.RenderSettingsData = new GameRenderSettingsData();
        }
		
		public GameEngineSettingsData EngineSettingsData { get; set; }
		public GameRenderSettingsData RenderSettingsData { get; set; }

	}
}
