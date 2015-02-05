using System;

namespace School
{
    public class ParserException : Exception
    {
        public ParserException(string message) : base(message) { }
    }

    public abstract class Parser
    {
        private Lexer input;        // from where do we get tokens?
        protected Token lookahead;    // the current lookahead token

        public Parser(Lexer input)
        {
            this.input = input;
            Consume();
        }

        public void Match(int x)
        {
            if (lookahead.Type == x)
                Consume();
            else
                throw new ParserException("expecting " + input.GetTokenName(x) + 
                    "; found " + lookahead);
        }

        public void Consume()
        {
            lookahead = input.NextToken();
        }
    }
}
