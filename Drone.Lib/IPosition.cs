using System;

namespace DroneApp.Lib
{
	public interface IPosition
	{
		int X { get; set; }
		int Y { get; set; }
		string ToString();
	}
}

