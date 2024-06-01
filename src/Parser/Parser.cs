// using InterpreterCs.Ast;
// using InterpreterCs.Tokens;
//
// namespace InterpreterCs.Parser;
//
// /*
// Ideas for improvement:
// Enhance error handling in the parser:
// Right now, if an expected token is not found, null is returned, which is simple but does not provide enough information 
// for debugging syntax errors. Implement a system to collect and report parsing errors, which might include detailed 
// messages about what went wrong and where.
// */
//
// public class Parser
// {
// 	private readonly Lexer.Lexer _lexer;
// 	private Token _curToken;
// 	private Token _peekToken;
// 	public List<string> Errors { get; }
//
// 	public Parser(Lexer.Lexer l)
// 	{
// 		_lexer = l;
// 		Errors = new List<string>();
// 		NextToken();
// 		NextToken();
// 	}
//
// 	private void NextToken()
// 	{
// 		_curToken = _peekToken;
// 		_peekToken = _lexer.NextToken();
// 	}
//
// 	public AstRoot ParseProgram()
// 	{
// 		var program = new AstRoot();
//
// 		while (_curToken.Type != TokenTypes.EOF)
// 		{
// 			var stmt = ParseStatement();
// 			if (stmt is not null)
// 				program.Statements.Add(stmt);
//
// 			NextToken();
// 		}
// 		return program;
// 	}
//
// 	private Statement? ParseStatement()
// 	{
// 		switch (_curToken.Type)
// 		{
// 			case TokenTypes.VAR:
// 				return ParseLetStatement();
// 			case TokenTypes.RETURN:
// 				return ParseReturnStatement();
// 			default:
// 				return null; 
// 		}
// 	}
//
// 	private LetStatement? ParseLetStatement()
// 	{
// 		var stmt = new LetStatement{Token = _curToken}; 
//
// 		if (!ExpectPeek(TokenTypes.IDENT))
// 				return null;
//
// 		stmt.Name = new Identifier(_curToken, _curToken.Literal);
//
// 		if (!ExpectPeek(TokenTypes.ASSIGN))
// 			return null;
//
// 		// TODO: Skipping the expressions until encounter a semicolon
// 		// while (!CurTokenIs(TokenTypes.SEMICOLON))
// 		// {
// 			// NextToken();
// 		// }
// 		// return stmt;
// 	}
//
// 	private ReturnStatement ParseReturnStatement()
// 	{
// 		var stmt = new ReturnStatement(){Token = _curToken};
// 		// TODO: Skipping the expressions until encounter a semicolon
// 		// while (!CurTokenIs(TokenTypes.SEMICOLON))
// 		// {
// 			// NextToken();
// 		// }
// 		return stmt;
// 	}
//
// 	private bool CurTokenIs(TokenType t)
// 	{
// 		return _curToken.Type == t;
// 	}
// 	
// 	private bool PeekTokenIs(TokenType t)
// 	{
// 		return _peekToken.Type == t; 
// 	}
//
// 	private bool ExpectPeek(TokenType t)
// 	{
// 		if (PeekTokenIs(t))
// 		{
// 			NextToken();
// 			return true;
// 		}
// 		PeekError(t);
// 		return false;
// 	}
//
// 	private void PeekError(TokenType t)
// 	{
// 		string message = $"Expected next token to be {t}, got {_peekToken.Type} instead";
// 		Errors.Add(message);
// 	}
// }
