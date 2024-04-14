using System.Linq.Expressions;

namespace InterpreterCs.Ast; 

class LetStatement : IStatement
{
	private Token.Token _token { get; set; } 
	private Identifier _name { get; set; } 
	private Expression value { get; set; } 
	
	public void StatementNode()
	{
	}
	public string TokenLiteral()
	{
		return _token.Literal;
	}
}

class Identifier : IExpression
{
	private Token.Token _token;

	private string _value { get; set; }
	
	public void ExpressionNode()
	{
	}
	public string TokenLiteral()
	{
		return _token.Literal;
	}
}
