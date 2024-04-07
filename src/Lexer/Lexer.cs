using InterpreterCs.Token;

namespace InterpreterCs.Lexer;
using InterpreterCs.Token;

public class Lexer
{
	public string Input { get; }
	private int _position; // Current position in input (points to current char)
	private int _readPosition; // Current reading position in input (after current char)
	private char _ch; // Current char under examination

	public Lexer(string input)
	{
		Input = input;
		ReadChar();
	}

	public void ReadChar()
	{
		if (_readPosition >= Input.Length)
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

	private Token NewToken(string tokenType, string? overrideString = null)
	{
		return new Token(new TokenType(tokenType), $"{overrideString ?? _ch.ToString()}");
	}

	public Token NextToken()
	{
		Token tok;
		switch (_ch)
		{
			case '=':
				tok = NewToken(TokenTypes.ASSIGN);
				break;
			case ';':
				tok = NewToken(TokenTypes.SEMICOLON);
				break;
			case '(':
				tok = NewToken(TokenTypes.LPAREN);
				break;
			case ')':
				tok = NewToken(TokenTypes.RPAREN);
				break;
			case ',':
				tok = NewToken(TokenTypes.COMMA);
				break;
			case '+':
				tok = NewToken(TokenTypes.PLUS);
				break;
			case '{':
				tok = NewToken(TokenTypes.LBRACE);
				break;
			case '}':
				tok = NewToken(TokenTypes.RBRACE);
				break;
			case '\0':
				tok = NewToken(TokenTypes.EOF, String.Empty);
				break;
			default:
				tok = NewToken(TokenTypes.ILLEGAL);
				break;
		}
		ReadChar();
		return tok;
	}
}

