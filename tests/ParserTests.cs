using InterpreterCs.Parser;
using InterpreterCs.Lexer;
using InterpreterCs.Ast;
using Xunit.Sdk;

namespace Tests;

public class ParserTests
{
	// private readonly List<string> _expectedIdentifiers;
	private AstRoot _program;
	private Parser _parser;

	private void Initialise(string input)
	{
		var lexer = new Lexer(input);
		_parser = new Parser(lexer);
		_program = _parser.ParseProgram();	
		CheckParserErrors();
	}
	private void CheckParserErrors()
	{
		List<string> errors = _parser.Errors;
		Assert.False(errors.Any(), $"Parser Error: {string.Join("\n", errors)}");
	}
	
	[Theory]
	[InlineData(
		@"
		let x = 5;
		let y = 10;
		let foobar = 838383;",
		new[] { "x", "y", "foobar" }
		)]
	public void TestLetStatements(string input, string[] expectedIdentifiers)
	{
		Initialise(input);
		foreach (var (stmt, idnt) in _program.Statements.Zip(expectedIdentifiers))
		{
			var statement = Assert.IsType<LetStatement>(stmt);
			Assert.Equal(statement.Name.Value, idnt);
			Assert.Equal("let", stmt.TokenLiteral());
		}
	}

	[Theory]
	[InlineData(
		@"
		return 5;
		return 10;
		return 993322;"
		)]
	public void TestReturnStatements(string input)
	{
		Initialise(input);	
		CheckParserErrors();
		Assert.Equal(3, _program.Statements.Count);
		foreach (var stmt in _program.Statements)
		{
			Assert.IsType<ReturnStatement>(stmt);
			Assert.Equal("return", stmt.TokenLiteral());
		}
			
	}
	

}
