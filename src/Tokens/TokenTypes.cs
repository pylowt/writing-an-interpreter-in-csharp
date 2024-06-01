namespace InterpreterCs.Tokens;


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
	public const string MINUS	 = "-";
	public const string BANG	 = "!";
	public const string ASTERISK	 = "*";
	public const string SLASH	 = "/";

	public const string EQ	 = "==";
	public const string NOT_EQ	 = "!=";


	public const string LT	 = "<";
	public const string GT	 = ">";

	// Delimiters
	public const string COMMA		 = ",";
	public const string COLON	 = ":";
	public const string NEWLINE = "\n";
	public const string	LPAREN	= "(";
	public const string	RPAREN	= ")";
	public const string	LBRACE	= "{";
	public const string	RBRACE	= "}";
	public const string INDENT = "INDENT";
	public const string DEDENT = "DEDENT";

	// Keywords
	public const string FUNCTION = "FUNCTION";
	public const string VAR		 = "VAR";
	public const string TRUE	= "TRUE";
	public const string FALSE	= "FALSE";
	public const string IF  	= "IF";
	public const string ELSE  	= "ELSE";
	public const string RETURN  	= "RETURN";
	
	private static readonly Dictionary<string, TokenType> Keywords = new()
	{
		{ "fn", FUNCTION},
		{ "var", VAR},
		{ "true", TRUE},
		{ "false", FALSE},
		{ "if", IF},
		{ "else", ELSE},
		{ "return", RETURN},
	};
	
	public static TokenType LookupIdent(string ident)
	{
		if (Keywords.ContainsKey(ident))
			return Keywords[ident];
		return IDENT;
	}
}

