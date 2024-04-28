using InterpreterCs.Tokens;

namespace InterpreterCs.Ast;

public abstract class Statement : INode
{
	public Token Token { get; set; }

	public virtual string TokenLiteral()
	{
		return Token.Literal;
	}
}