using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DroneApp.Lib
{
	public enum Command
	{
		Norte = 'N',
		Leste = 'L',
		Sul = 'S',
		Oeste = 'O',
		CancelarAnterior = 'X'
	}



	public class Drone : IDrone
	{
		private char[] VALID_CHARS = {'N', 'S', 'L', 'O', 'X'}; 

		public IPosition Position { get; set; }

		public Drone(IPosition Position)
		{
			this.Position = Position;
		}

		public void Go(string commands)
		{
			List<KeyValuePair<int, Command>> commandsAndTimes = TranslateCommands(commands);

			foreach (var commandAndTimes in commandsAndTimes)
			{
				if (commandAndTimes.Value == Command.Norte)
					Position.Y += commandAndTimes.Key;
				else if(commandAndTimes.Value == Command.Leste)
					Position.X += commandAndTimes.Key;
				else if(commandAndTimes.Value == Command.Sul)
					Position.Y -= commandAndTimes.Key;
				else if(commandAndTimes.Value == Command.Oeste)
					Position.X -= commandAndTimes.Key;
			}
		}
			
		private List<KeyValuePair<int, Command>> TranslateCommands(string stringCommands)
		{
			List<KeyValuePair<int, Command>> listCommands = new List<KeyValuePair<int, Command>> ();

			var directionsAndNumbers = Regex.Matches(stringCommands, @"[A-Z]+|\d+")
				.Cast<Match>()
				.Select(m => m.Value)
				.ToArray();

			foreach (var directionsOrNumber in directionsAndNumbers) {
				if (directionsOrNumber.All (char.IsDigit)) 
				{
					Command lastCommand = listCommands.Last ().Value;
					listCommands.Remove (listCommands.Last());
					listCommands.Add(new KeyValuePair<int, Command>(Convert.ToInt32(directionsOrNumber), lastCommand));
					continue;
				}

				char[] charCommands = directionsOrNumber.ToCharArray ();

				foreach (var charCommand in charCommands) {
					if (VALID_CHARS.Contains (charCommand)) 
					{
						
						if ((Command)charCommand == Command.CancelarAnterior) 
						{
							listCommands.RemoveAt (listCommands.Count - 1);
							continue;
						}

						listCommands.Add(new KeyValuePair<int, Command>(1,(Command)charCommand));
					}
				}

			}

			return listCommands;
		}


		public override string ToString()
		{
			return Position.ToString();
		}

	}
}









		