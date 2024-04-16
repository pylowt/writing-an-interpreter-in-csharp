using InterpreterCs.Tokens;


namespace InterpreterCs.Ast; 
class LetStatement : IStatement
{
	private Token _Token { get; set; } 
	private Identifier _name { get; set; } 
	private IExpression _value { get; set; } 
	
	public void StatementNode()
	{
	}
	public string TokenLiteral()
	{
		return _Token.Literal;
	}
}

class Identifier : IExpression
{
	private Token _token { get; set; }

	private string _value { get; set; }
	
	public void ExpressionNode()
	{
	}
	public string TokenLiteral()
	{
		return _token.Literal;
	}
}
