namespace InterpreterCs.Tests;

public class Lexer_nextToken
{
    [Fact]
    public void IsExpectedType()
    {
		string input = "=+(){},;";
		var lexer = new Lexer(input);
		var expectedType = token.TokenType();
        var result = lexer.nextToken();

            Assert.False(result, "1 should not be prime");
    }
}
