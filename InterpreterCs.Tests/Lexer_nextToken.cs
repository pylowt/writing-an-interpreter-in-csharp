namespace InterpreterCs.Tests;
using System.Collections.Generic; 
using token;

public class Lexer_nextToken
{
    [Fact]
    public void IsExpectedType()
    {
		Dictionary<token.TokenType, string> tests = new Dictionary<token.TokenType, string>()
		{
			{ token.TokenType.ASSIGN, "="},
			{ token.TokenTypes.PLUS, "+"},
			{ token.TokenTypes.LPAREN, "("},
			{ token.TokenTypes.RPAREN, ")"},
			{ token.TokenTypes.LBRACE, "{"},
			{ token.TokenTypes.RBRACE, "}"},
			{ token.TokenTypes.COMMA, ","},
			{ token.TokenTypes.SEMICOLON, ";"},
			{ token.TokenTypes.EOF, ""},
		};

		string input = "=+(){},;";
		var lexer = new Lexer(input);
		
		foreach(KeyValuePair<token.TokenType, string> entry in tests)
		{
			var result = lexer.nextToken();
			var typeMessage = $"{result.Type} - TokenType wrong. Expected {entry.key}";
			Assert.True(entry.Key.Equals(result.Type), typeMessage);
			var literalMessage = $"{result.Literal} - Literal wrong. Expected {entry.Value}";
			Assert.True(entry.Value.Equals(result.Literal), literalMessage);
		}
    }
}
