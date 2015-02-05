using System;

namespace School
{
    public class LexerException : Exception
    {
        public LexerException(string message) : base(message) { }
    }

    public abstract class Lexer
    {
        public const char EOF = '\x1a';      // represent end of file char
        public const int EOF_TYPE = 1;       // represent EOF token type

        private readonly char[] input;   // input string
        private int p = 0;      // index into input of current character
        protected char c;       // current character

        public Lexer(string input)
        {
            this.input = input.ToCharArray();
            c = this.input[p]; // prime lookahead
        }

        public void Consume() {
            p++;
            if (p >= input.Length)
                c = EOF;
            else
                c = input[p];
        }

        public void Match(char x)
        {
            if (c == x)
                Consume();
            else
                throw new LexerException("expecting " + x + "; found " + c);
        }

        public abstract Token NextToken();
        public abstract String GetTokenName(int tokenType);
    }
}
