using InterpreterCs.Tokens;

namespace InterpreterCs.Ast;

public class LetStatement : IStatement
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
