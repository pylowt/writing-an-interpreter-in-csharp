namespace InterpreterCs.Ast;

using Tokens;

class Identifier : IExpression
{
	private Token Token { get; set; }

	private string _value { get; set; }
	
	public void ExpressionNode()
	{
	}
	public string TokenLiteral()
	{
		return Token.Literal;
	}
}
