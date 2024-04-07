namespace Lexer.Tests;
using System.Collections.Generic; 
using Token;

public class LexerTests
{
    [Fact]
    public void IsExpectedType()
    {
		Dictionary<string, string> tests = new Dictionary<string, string>()
		{
			{ TokenTypes.ASSIGN, "="},
			{ TokenTypes.PLUS, "+"},
			{ TokenTypes.LPAREN, "("},
			{ TokenTypes.RPAREN, ")"},
			{ TokenTypes.LBRACE, "{"},
			{ TokenTypes.RBRACE, "}"},
			{ TokenTypes.COMMA, ","},
			{ TokenTypes.SEMICOLON, ";"},
			{ TokenTypes.EOF, ""},
		};

		string input = "=+(){},;";
		var lexer = new Lexer(input);
		
		foreach(KeyValuePair<string, string> entry in tests)
		{
			var result = lexer.nextToken();
			var typeMessage = $"{result.Type} - TokenType wrong. Expected {entry.Key}";
			Assert.True(entry.Key.Equals(result.Type), typeMessage);
			var literalMessage = $"{result.Literal} - Literal wrong. Expected {entry.Value}";
			Assert.True(entry.Value.Equals(result.Literal), literalMessage);
		} 
    }
}
