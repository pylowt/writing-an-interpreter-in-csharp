namespace InterpreterCs.Token;

public readonly struct TokenType
{
	public readonly string Value;

	public TokenType(string value)
	{
		// this.value = value ?? throw new ArgumentNullException(nameof(value));
		Value = value;
	}

	public static implicit operator TokenType(string value)
	{
		return new TokenType(value);
	}
	public static implicit operator string(TokenType tokenType)
	{
		return tokenType.Value;
	}
	public override string ToString() => Value;

}

public struct Token
{
	public readonly TokenType Type;
	public string Literal { get; set; }

	public Token(TokenType type, string literal)
	{
		Type = type;
		Literal = literal;
	}
}

public static class TokenTypes
{
	public const string ILLEGAL	 = "ILLEGAL";
	public const string EOF		 = "EOF";

	// Identifiers + literals
	public const string IDENT	 = "IDENT";
	public const string INT		 = "INT"; 

	// Operators
	public const string ASSIGN = "=";
	public const string PLUS	 = "+";

	// Delimiters
	public const string COMMA		 = ",";
	public const string SEMICOLON	 = ";";
	public const string	LPAREN	= "(";
	public const string	RPAREN	= ")";
	public const string	LBRACE	= "{";
	public const string	RBRACE	= "}";

	// Keywords
	public const string FUNCTION = "FUNCTION";
	public const string LET		 = "LET";
}


