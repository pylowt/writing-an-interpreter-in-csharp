public class Lexer 
{
	public string Input { get; }
	private int _position;
	private int _readPosition;
	private char _ch;

	public Lexer(string input)
	{
		Input = input;
	}
}
