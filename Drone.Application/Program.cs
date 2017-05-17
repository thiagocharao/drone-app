using System;
using DroneApp.Lib;

namespace DroneApp.Application
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string line;
			Console.WriteLine("Pressione CTRL+Z para sair):");
			Console.WriteLine();
			do { 
				Console.Write("   ");
				line = Console.ReadLine();
				if (line != null) {
					Drone drone = new Drone(new Position(0,0));
					drone.Go(line);
					Console.WriteLine(drone.ToString());
				}
			} while (line != null);  

			Console.ReadLine();
		}
	}
}
