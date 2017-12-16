using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TowerDefense.Core
{
	public class GameCoreException:Exception
	{
		public GameCoreException(string message): base(message){
			Trace.TraceError($"[{DateTime.UtcNow}]: {message}");
		}
		public GameCoreException(string message, Exception innerException) : base(message, innerException)
		{
			Trace.TraceError($"[{DateTime.UtcNow}]: {message} inner exception: {innerException.Message}");
		}
	}
}
