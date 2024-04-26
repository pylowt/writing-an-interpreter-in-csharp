using InterpreterCs.Parser;
using InterpreterCs.Lexer;

namespace Tests;

public class ParserTests
{
	[Fact]
    public void TestLetStatements()
	{
	    string input = @"
			let x = 5;
			let y = 10;
			let foobar = 838383;";
		var lexer = new Lexer(input);
		var parser = new Parser(lexer);
		var	program = parser.ParseProgram();
		// Assert.NotNull(program);
		Assert.Equal(program.Statements.Count, 3);

	}

}
