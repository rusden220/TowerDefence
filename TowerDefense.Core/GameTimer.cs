using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TowerDefense.Core
{
	internal class GameTimer
	{
		private Thread _mainGameLoopThread;
		private bool _isRaiseTimeEvent;
		private Action<long> _timeEventHendler;

		public GameTimer(Action<long> timeEventHendler)
		{			
			_mainGameLoopThread = new Thread(ThreadHendler);
			if (timeEventHendler == null)
				throw new GameCoreException($"{nameof(timeEventHendler)} must be set");
			this._timeEventHendler = timeEventHendler;
		}
		public void Start()
		{
			_isRaiseTimeEvent = true;
			_mainGameLoopThread.Start();
		}
		public void Stop()
		{
			_isRaiseTimeEvent = false;
		}
		private void ThreadHendler()
		{			
			try
			{
				Stopwatch sw = new Stopwatch();
				sw.Start();
				long beforeElapsedTicks = 0;
				long currentElapsedTicks = 0;
				while (_isRaiseTimeEvent)
				{
					currentElapsedTicks = sw.ElapsedTicks;
					_timeEventHendler(currentElapsedTicks - beforeElapsedTicks);
					beforeElapsedTicks = currentElapsedTicks;
				}
			}
			catch (Exception ex)
			{
				_isRaiseTimeEvent = false;
				throw new GameCoreException($"{nameof(_mainGameLoopThread)} exception(timer do not running)", ex);
			}
		}
	}
}
