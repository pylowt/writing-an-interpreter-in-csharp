namespace InterpreterCs.Ast;

using Tokens;

public class Identifier : INode
{
	private readonly Token _token; 

	public string Value { get; }
	
	public Identifier(Token token, string value)
	{
		_token = token;
		Value = value;
	}

	public string TokenLiteral()
	{
		return _token.Literal;
	}
}
