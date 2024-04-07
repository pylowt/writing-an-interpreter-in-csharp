using InterpreterCs.Token;

namespace Lexer.Tests;
using System.Collections.Generic;

public class LexerTests
{
    [Fact]
    public void TestNextToken()
    {
	    string input = @"let five = 5;
		let ten = 10;

		let add = fn(x, y) {
			x + y;
		};
		let result = add(five, ten);
		";
	    List<KeyValuePair<string, string>> tests = new List<KeyValuePair<string, string>>
	    {
		    new(TokenTypes.LET, "let"),
			new(TokenTypes.IDENT, "five"),
			new(TokenTypes.ASSIGN, "="),
			new(TokenTypes.INT, "5"),
			new(TokenTypes.SEMICOLON, ";"),
			new(TokenTypes.LET, "let"),
			new(TokenTypes.IDENT, "ten"),
			new(TokenTypes.ASSIGN, "="),
			new(TokenTypes.INT, "10"),
			new(TokenTypes.SEMICOLON, ";"),
			new(TokenTypes.LET, "let"),
			new(TokenTypes.IDENT, "add"),
			new(TokenTypes.ASSIGN, "="),
			new(TokenTypes.FUNCTION, "fn"),
			new(TokenTypes.LPAREN, "("),
			new(TokenTypes.IDENT, "x"),
			new(TokenTypes.COMMA, ","),
			new(TokenTypes.IDENT, "y"),
			new(TokenTypes.RPAREN, ")"),
			new(TokenTypes.LBRACE, "{"),
			new(TokenTypes.IDENT, "x"),
			new(TokenTypes.PLUS, "+"),
			new(TokenTypes.IDENT, "y"),
			new(TokenTypes.SEMICOLON, ";"),
			new(TokenTypes.RBRACE, "}"),
			new(TokenTypes.SEMICOLON, ";"),
			new(TokenTypes.LET, "let"),
			new(TokenTypes.IDENT, "result"),
			new(TokenTypes.ASSIGN, "="),
			new(TokenTypes.IDENT, "add"),
			new(TokenTypes.LPAREN, "("),
			new(TokenTypes.IDENT, "five"),
			new(TokenTypes.COMMA, ","),
			new(TokenTypes.IDENT, "ten"),
			new(TokenTypes.RPAREN, ")"),
			new(TokenTypes.SEMICOLON, ";"),
			new(TokenTypes.EOF, ""),
		};

		var lexer = new InterpreterCs.Lexer.Lexer(input);
		
		foreach(KeyValuePair<string, string> entry in tests)
		{
			var result = lexer.NextToken();
			var typeMessage = $"{result.Type} - TokenType wrong. Expected {entry.Key}";
			Assert.True(entry.Key.Equals(result.Type), typeMessage);
			var literalMessage = $"{result.Literal} - Literal wrong. Expected {entry.Value}";
			Assert.True(entry.Value.Equals(result.Literal), literalMessage);
		} 
    }
}
