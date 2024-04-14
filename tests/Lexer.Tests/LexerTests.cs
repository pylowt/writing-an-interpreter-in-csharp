using InterpreterCs.Token;
using Xunit.Abstractions;

namespace Lexer.Tests;
using System.Collections.Generic;

public class LexerTests
{
	[Fact]
    public void TestNextToken()
    {
	    string input = @"let five = 5;
		let ten = 10;

		let add_? = fn(x, y) {
			x + y;
		};
		let result! = add(five, ten);
		!-/*5;
		5 < 10 > 5;
		
		if (5 < 10) {
			return true;
		} else {
			return false;
		}

		10 == 10;
		10 != 9;

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
			new(TokenTypes.IDENT, "add_?"),
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
			new(TokenTypes.IDENT, "result!"),
			new(TokenTypes.ASSIGN, "="),
			new(TokenTypes.IDENT, "add"),
			new(TokenTypes.LPAREN, "("),
			new(TokenTypes.IDENT, "five"),
			new(TokenTypes.COMMA, ","),
			new(TokenTypes.IDENT, "ten"),
			new(TokenTypes.RPAREN, ")"),
			new(TokenTypes.SEMICOLON, ";"),
			new(TokenTypes.BANG, "!"),
			new(TokenTypes.MINUS, "-"),
			new(TokenTypes.SLASH, "/"),
			new(TokenTypes.ASTERISK, "*"),
			new(TokenTypes.INT, "5"),
			new(TokenTypes.SEMICOLON, ";"),
			new(TokenTypes.INT, "5"),
			new(TokenTypes.LT, "<"),
			new(TokenTypes.INT, "10"),
			new(TokenTypes.GT, ">"),
			new(TokenTypes.INT, "5"),
			new(TokenTypes.SEMICOLON, ";"),
			new(TokenTypes.IF, "if"),
			new(TokenTypes.LPAREN, "("),
			new(TokenTypes.INT, "5"),
			new(TokenTypes.LT, "<"),
			new(TokenTypes.INT, "10"),
			new(TokenTypes.RPAREN, ")"),
			new(TokenTypes.LBRACE, "{"),
			new(TokenTypes.RETURN, "return"),
			new(TokenTypes.TRUE, "true"),
			new(TokenTypes.SEMICOLON, ";"),
			new(TokenTypes.RBRACE, "}"),
			new(TokenTypes.ELSE, "else"),
			new(TokenTypes.LBRACE, "{"),
			new(TokenTypes.RETURN, "return"),
			new(TokenTypes.FALSE, "false"),
			new(TokenTypes.SEMICOLON, ";"),
			new(TokenTypes.RBRACE, "}"),
			new(TokenTypes.INT, "10"),
			new(TokenTypes.EQ, "=="),
			new(TokenTypes.INT, "10"),
			new(TokenTypes.SEMICOLON, ";"),
			new(TokenTypes.INT, "10"),
			new(TokenTypes.NOT_EQ, "!="),
			new(TokenTypes.INT, "9"),
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
