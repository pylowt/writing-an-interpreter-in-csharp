namespace Interpreter;

public class Lexer 
{
	public string Input { get; }
	private int _position; // Current position in input (points to current char)
	private int _readPosition; // Current reading position in input (after current char)
	private char _ch; // Current char under examination

	public Lexer(string input)
	{
		Input = input;
	}
	
	public void ReadChar()
	{
		if(_readPosition >= Input.Length) 
		{
			_ch = '\0';
		}
		else 
		{
			_ch = Input[_readPosition];
		}
		_position = _readPosition;
		_readPosition++;
	}
}
