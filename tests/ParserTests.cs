using InterpreterCs.Parser;
using InterpreterCs.Lexer;
using InterpreterCs.Ast;
using Xunit.Sdk;

namespace Tests;

public class ParserTests
{
	private readonly List<string> _expectedIdentifiers;
	private readonly AstRoot _program;
	private readonly Parser _parser;

	public ParserTests()
	{
		const string input = @"
			let x = 5;
			let y = 10;
			let foobar = 838383;";
		var lexer = new Lexer(input);
		_parser = new Parser(lexer);
		_program = _parser.ParseProgram();
		_expectedIdentifiers = new List<string> {"x", "y", "foobar"};
	}

	[Fact]
    public void TestProgramNotNull() 
	{
		Assert.NotNull(_program);
	}

	[Fact]
	public void TestTokenLiteralsAreAllLet()
	{
		foreach (var stmt in _program.Statements)
			Assert.Equal("let", stmt.TokenLiteral());
	}
	
	[Fact]
	public void TestValueAreAllCorrect()
	{
		foreach (var (stmt, idnt) in _program.Statements.Zip(_expectedIdentifiers))
		{
			if (stmt is LetStatement letStatement)
				Assert.Equal(letStatement.Name.Value, idnt);
			else 
				Assert.True(false, $"Incorrect type of statement, got {stmt.GetType()} expected LetStatement");
		}
			
	}

	[Fact]
	public void TestTokenLiteralAreAllCorrect()
	{
		foreach (var (stmt, idnt) in _program.Statements.Zip(_expectedIdentifiers))
		{
			if (stmt is LetStatement letStatement)
				Assert.Equal(letStatement.Name.TokenLiteral(), idnt);
			else
				Assert.True(false, $"Incorrect type of statement, got {stmt.GetType()} expected LetStatement");
		}
	}

	private void CheckParserErrors()
	{
		List<string> errors = _parser.Errors;
		var hasErrors = errors.Any();
		Assert.False(hasErrors, $"Parser Error: {string.Join("\n", errors)}");
	}
}
