using InterpreterCs.Tokens;

namespace InterpreterCs.Lexer;

public class Lexer
{
	private string Input { get; }
	// Current position in input (points to current char)
	private int _position; 
	// Current reading position in input (after current char)
	private int _readPosition; 
	// Current char under examination
	private char _ch;

	private bool _atBegLine = true;
	
	private Stack<int> _indents = new Stack<int>();	

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
		var bar = _atBegLine; 
		int whitespaceCount = CountWhitespace();
		if (_atBegLine)
		{
			if (_indents.Count == 0)
			{
				_indents.Push(whitespaceCount);
			}
			else if (whitespaceCount > _indents.Peek())
			{
				_indents.Push(whitespaceCount);
				tok = NewToken(TokenTypes.INDENT);
			}
			else while (whitespaceCount < _indents.Peek())
			{
				_indents.Pop();
				tok = NewToken(TokenTypes.DEDENT);
			}

			_atBegLine = false;
		}
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
			case ':':
				tok = NewToken(TokenTypes.COLON);
				break;
			case '\n':
				tok = NewToken(TokenTypes.NEWLINE);
				_atBegLine = true;
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
		while (_ch is ' ' or '\t')
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

	private int CountWhitespace()
	{
		int count = 0;
		while (_ch is ' ' or '\t')
		{
			count++;
			ReadChar();
		}
		return count;
	}

	private void _handleWhitespace()
	{
		
	}
}


