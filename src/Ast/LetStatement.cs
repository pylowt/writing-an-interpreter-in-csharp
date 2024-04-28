using InterpreterCs.Tokens;

namespace InterpreterCs.Ast;

public class LetStatement : Statement
{
	public Identifier Name { get; set; } 
	private INode _value { get; set; } 
}
