using System;
using InterpreterCs.Repl;

class Program
{
	static void Main(string[] args)
	{
		var user = Environment.UserName;
		Console.WriteLine($"Hello {user}! This is the Hamster programming language!");
		while (true)
		{
			Console.Write(">> ");
			string? userInput = Console.ReadLine();
			if (userInput == "exit")
				break;
			Repl.ProcessInput(userInput);
		} 
	}
}

