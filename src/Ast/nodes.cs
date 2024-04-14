namespace InterpreterCs.Ast; 

interface INode
{
	string TokenLiteral();		
}

interface IStatement : INode
{
	void StatementNode();
}

interface IExpression: INode
{
	void ExpressionNode();
}


class AstNode : INode
{
	private List<IStatement> Statements { get; set; } = new List<IStatement>();
	
	public string TokenLiteral()
	{
		if (Statements.Count > 0)
			return Statements[0].TokenLiteral();
		return "";
	}
}


