using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Core.IO
{
	[Flags]
	public enum MouseState
	{
		Down,
		Up,
		Move
	}
	public struct MouseStateContainer
	{
		public Point MousePosition { get; set; }
		public MouseState MouseState { get; set; }
	}
	public class MouseStateProvider
	{
		private MouseStateContainer _mouseState;
		public MouseStateContainer MouseState
		{
			get {
				return _mouseState;
			}
		}
	}
}
