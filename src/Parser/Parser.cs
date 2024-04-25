using InterpreterCs.Ast;
using InterpreterCs.Tokens;

namespace InterpreterCs.Parser;
public class Parser
{
	private Lexer.Lexer _lexer;
	private Token? _curToken;
	private Token _peekToken;

	public Parser(Lexer.Lexer l)
	{
		_lexer = l;
		NextToken();
		NextToken();
	}

	private void NextToken()
	{
		_curToken = _peekToken;
		_peekToken = _lexer.NextToken();
	}

	public AstNode? ParseProgram()
	{
		throw new NotImplementedException();
	}
}
