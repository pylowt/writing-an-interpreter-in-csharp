namespace InterpreterCs.Ast; 

public class AstRoot : INode
{
	public List<Statement> Statements { get; } = new();
	
	public string TokenLiteral()
	{
		if (Statements.Count > 0)
			return Statements[0].TokenLiteral();
		return "";
	}
}
