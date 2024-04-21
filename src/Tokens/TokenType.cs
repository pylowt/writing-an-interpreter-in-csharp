namespace InterpreterCs.Tokens;

public readonly struct TokenType
{
	public readonly string Value;

	public TokenType(string value)
	{
		this.Value = value ?? throw new ArgumentNullException(nameof(value));
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
