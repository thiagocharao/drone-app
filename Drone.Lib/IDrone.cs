using System;

namespace DroneApp.Lib
{
	public interface IDrone
	{
		IPosition Position { get; set; }
		void Go(string commands);
		string ToString();
	}
}

