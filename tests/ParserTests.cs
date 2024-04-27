using InterpreterCs.Parser;
using InterpreterCs.Lexer;
using InterpreterCs.Ast; 

namespace Tests;

public class ParserTests
{
	private string _input;
	private List<string> _expectedIdentifiers;
	private Lexer _lexer;
	private Parser _parserinput;
	private AstNode? _program;

	public ParserTests()
	{
	    _input = @"
			let x = 5;
			let y = 10;
			let foobar = 838383;";
		_lexer = new Lexer(_input);
		_parserinput = new Parser(_lexer);
		_program = _parserinput.ParseProgram();
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
		foreach (IStatement stmt in _program.Statements)
		{
			Assert.Equal(stmt.TokenLiteral(), "let");
		}
	}
}
