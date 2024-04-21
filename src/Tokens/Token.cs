namespace InterpreterCs.Tokens;

public readonly struct Token
{
	public readonly TokenType Type;
	public readonly string Literal;
	
	public Token(TokenType type, string literal)
	{
		Type = type;
		Literal = literal;
	}

	
}

