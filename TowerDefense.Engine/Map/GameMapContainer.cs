using System;
using System.Diagnostics;
using System.Drawing;

namespace TowerDefense.Engine.Map
{
	internal class GameMapContainer	
	{
		private GameMapFieldContainer[,] _mapFieldsArray;

		public GameMapContainer(int mapWeight, int mapHieght)
		{
			_mapFieldsArray = new GameMapFieldContainer[mapHieght, mapWeight];
			
		}
		public GameMapFieldContainer this[int index1, int index2]
		{
			get { return _mapFieldsArray[index1, index2]; }
			set { _mapFieldsArray[index1, index2] = value; }
		}
#if DEBUG
		public void PrintArrayInDebugStream()
		{
			for (int i = 0; i < _mapFieldsArray.GetLength(0); i++)
			{
				for (int j = 0; j < _mapFieldsArray.GetLength(1); j++)
				{
					Debug.Write(_mapFieldsArray[i, j].ToString() + "|");
				}
				Debug.WriteLine("");
			}
		}
#endif

		public Size GameMapSize { get; private set; }
		public Size GameFiledSize { get; private set; }
	}
}
