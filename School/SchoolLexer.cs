using System;
using System.Text;

namespace School
{
    public class SchoolLexer : Lexer
    {
        public const int ADD = 2;
        public const int SUB = 3;
        public const int MUL = 4;
        public const int DIV = 5;
        public const int LPAREN = 6;
        public const int RPAREN = 7;
        public const int NUM = 8;
        public static readonly string[] tokenNames =
            { "n/a", "<EOF>", "ADD", "SUB", "MUL", "DIV", "LPAREN", "RPAREN", "NUM" };
        public override String GetTokenName(int x) { return tokenNames[x]; }

        public SchoolLexer(string input) : base(input) { }

        public override Token NextToken()
        {
            while (c != EOF)
            {
                switch (c)
                {
                    case ' ':
                    case '\t':
                    case '\n':
                    case '\r':
                        WS();
                        continue;
                    case '+':
                        Consume();
                        return new Token(ADD, "+");
                    case '-':
                        Consume();
                        return new Token(SUB, "-");
                    case '*':
                        Consume();
                        return new Token(MUL, "*");
                    case '/':
                        Consume();
                        return new Token(DIV, "/");
                    case '(':
                        Consume();
                        return new Token(LPAREN, "(");
                    case ')':
                        Consume();
                        return new Token(RPAREN, ")");
                    default:
                        if (IsDigit())
                            return NUMBER();
                        throw new LexerException("invalid character: " + c);
                }
            }

            return new Token(EOF_TYPE, "<EOF>");
        }
            
        private bool IsDigit()
        {
            return c >= '0' && c <= '9';
        }

        /** DIGIT   : '0'..'9'; // define what a digit is */
        private void DIGIT()
        {
            if (IsDigit())
                Consume();
            else
                throw new LexerException("expecting DIGIT; found " + c);
        }

        /** NUMBER : DIGIT+ ; // NUMBER is sequence of >=1 digit */
        private Token NUMBER()
        {
            var buf = new StringBuilder();
            do
            {
                buf.Append(c);
                DIGIT();
            } while (IsDigit());
            return new Token(NUM, buf.ToString());
        }

        /** WS : (' '|'\t'|'\n'|'\r')* ; // ignore any whitespace */
        private void WS()
        {
            while (c == ' ' || c == '\t' || c == '\n' || c == '\r')
                Consume();
        }
    }
}
