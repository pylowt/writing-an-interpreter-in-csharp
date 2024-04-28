using InterpreterCs.Ast;
using InterpreterCs.Tokens;

namespace InterpreterCs.Parser;

public class Parser
{
	private readonly Lexer.Lexer _lexer;
	private Token _curToken;
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

	public AstRoot ParseProgram()
	{
		var program = new AstRoot();

		while (_curToken.Type != TokenTypes.EOF)
		{
			var stmt = ParseStatement();
			if (stmt is not null)
				program.Statements.Add(stmt);

			NextToken();
		}
		return program;
	}

	private LetStatement? ParseStatement()
	{
		switch (_curToken.Type)
		{
			case TokenTypes.LET:
				return ParseLetStatement();
			default:
				return null; 
		}
	}

	private LetStatement? ParseLetStatement()
	{
		var stmt = new LetStatement{Token = _curToken}; 

		if (!ExpectPeek(TokenTypes.IDENT))
				return null;

		stmt.Name = new Identifier(_curToken, _curToken.Literal);

		if (!ExpectPeek(TokenTypes.ASSIGN))
			return null;

		// TODO: Skipping the expressions until encounter a semicolon
		while (!CurTokenIs(TokenTypes.SEMICOLON))
		{
			NextToken();
		}
		return stmt;
	}

	private bool CurTokenIs(TokenType t)
	{
		return _curToken.Type == t;
	}
	
	private bool PeekTokenIs(TokenType t)
	{
		return _peekToken.Type == t; 
	}

	private bool ExpectPeek(TokenType t)
	{
		if (PeekTokenIs(t))
		{
			NextToken();
			return true;
		}
		return false;
	}
}
