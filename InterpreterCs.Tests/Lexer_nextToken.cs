namespace InterpreterCs.Tests;
using token;

public class Lexer_nextToken
{
    [Fact]
    public void IsExpectedType()
    {
		Dictionary<token.TokenType, string> tests = new Dictionary<string, string>();

		string input = "=+(){},;";
		//var lexer = new Lexer(input);
		var expectedType = token.TokenType();
        //var result = lexer.nextToken();

    }
}
