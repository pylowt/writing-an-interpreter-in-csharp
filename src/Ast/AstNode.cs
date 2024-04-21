namespace InterpreterCs.Ast; 

public class AstNode : INode
{
	private List<IStatement> Statements { get; set; } = new List<IStatement>();
	
	public string TokenLiteral()
	{
		if (Statements.Count > 0)
			return Statements[0].TokenLiteral();
		return "";
	}
}
