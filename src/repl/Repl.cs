using InterpreterCs.Token;

namespace InterpreterCs.Repl; 

public class Repl
{
	public static void ProcessInput(string? input)
	{
		var lexer = new InterpreterCs.Lexer.Lexer(input);
		var tok = lexer.NextToken();
		while (tok.Type != TokenTypes.EOF)
		{
			Console.WriteLine($"Type:{tok.Type} Literal:{tok.Literal}");
			tok = lexer.NextToken();
		}
	}
	
}
