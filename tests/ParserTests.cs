using InterpreterCs.Parser;
using InterpreterCs.Lexer;
using InterpreterCs.Ast; 

namespace Tests;

public class ParserTests
{
	private readonly List<string> _expectedIdentifiers;
	private readonly AstRoot _program;

	public ParserTests()
	{
		var input = @"
			let x = 5;
			let y = 10;
			let foobar = 838383;";
		var lexer = new Lexer(input);
		var parserinput = new Parser(lexer);
		_program = parserinput.ParseProgram();
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
			Assert.Equal(stmt.TokenLiteral(), "let");
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
}
