using InterpreterCs.Ast;
using InterpreterCs.Tokens;

namespace InterpreterCs.Parser;

public class Parser
{
	private Lexer.Lexer _lexer;
	private Token? _curToken;
	private readonly Token? _peekToken = null;

	public Parser(Lexer.Lexer l)
	{
		_lexer = l;
		NextToken();
		NextToken();
	}

	private void NextToken()
	{
		_curToken = _peekToken;
	}

	public AstNode? ParseProgram()
	{
		return null;
	}
}
