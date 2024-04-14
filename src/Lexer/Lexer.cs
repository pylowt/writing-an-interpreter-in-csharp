using InterpreterCs.Token;

namespace InterpreterCs.Lexer;
using InterpreterCs.Token;

public class Lexer
{
	private string Input { get; }
	// Current position in input (points to current char)
	private int _position; 
	// Current reading position in input (after current char)
	private int _readPosition; 
	// Current char under examination
	private char _ch; 

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
		EatWhitespace();
		switch (_ch)
		{
			case '=':
				if (PeekAhead() == '=')
				{
					tok = NewToken(TokenTypes.EQ, "==");
					ReadChar();
					break;
				}
				tok = NewToken(TokenTypes.ASSIGN);
				break;
			case '+':
				tok = NewToken(TokenTypes.PLUS);
				break;
			case '-':
				tok = NewToken(TokenTypes.MINUS);
				break;
			case '!':
				if (PeekAhead() == '=')
				{
					tok = NewToken(TokenTypes.NOT_EQ, "!=");
					ReadChar();
					break;
				}
				tok = NewToken(TokenTypes.BANG);
				break;
			case '*':
				tok = NewToken(TokenTypes.ASTERISK);
				break;
			case '/':
				tok = NewToken(TokenTypes.SLASH);
				break;
			case '<':
				tok = NewToken(TokenTypes.LT);
				break;
			case '>':
				tok = NewToken(TokenTypes.GT);
				break;
			case ',':
				tok = NewToken(TokenTypes.COMMA);
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
				if (IsALetter())
				{
					var literal = ReadIdentifier();
					tok = NewToken(TokenTypes.LookupIdent(literal), literal);
					return tok;
				}
				if (IsADigit())
				{
					var literal = ReadNumber();
					tok = NewToken(TokenTypes.INT, literal);
					return tok;
				}
				tok = NewToken(TokenTypes.ILLEGAL);

				break;
		}
		ReadChar();
		return tok;
	}
	private bool IsALetter()
	{
		return char.IsLetter(_ch) || _ch is '_' or '!' or '?'; 
	}
	private bool IsADigit()
	{
		return char.IsDigit(_ch); 
	}
	private string ReadIdentifier()
	{
		var sb = new System.Text.StringBuilder();
		while (IsALetter())
		{
			sb.Append(_ch);
			ReadChar();
		}
		return sb.ToString();
	}	
	private string ReadNumber()
	{
		var sb = new System.Text.StringBuilder();
		while (IsADigit())
		{
			sb.Append(_ch);
			ReadChar();
		}
		return sb.ToString();
	}

	private void EatWhitespace()
	{
		while (_ch is ' ' or '\t' or '\n' or '\r')
		{
			ReadChar();
		}
	}

	private char PeekAhead()
	{
		if (_readPosition >= Input.Length)
		{
			return '\0';
		}

		return Input[_readPosition];
	}
}


