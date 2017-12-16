using System.Diagnostics;


namespace TowerDefense.Engine.Map
{
	[DebuggerDisplay("isEmpty={isEmpty}, weight={Weight}")]
	class GameMapFieldContainer
	{
		public bool IsEmpty { get; set; } = true;
		public int Weight { get; set; }

		public override string ToString()
		{
			return Weight.ToString();
		}
	}
}
