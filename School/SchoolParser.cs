using System;

namespace School
{
    // expr    = term  { ("+" | "-") expr }
    // term    = factor  { ("*"|"/") term }
    // factor  = number | "("  expr  ")"
    public class SchoolParser : Parser
    {
        public SchoolParser(Lexer input) : base(input) { }

        public Surface.Expr Parse()
        {
            return Expr();
        }

        private Surface.Expr Expr()
        {
            Surface.Expr left = Term();

            int type = lookahead.Type;
            switch (type)
            {
                case SchoolLexer.ADD:
                case SchoolLexer.SUB:
                    Consume();
                    break;
                default:
                    return left;
            }

            Surface.Expr right = Expr();

            Surface.Expr expr;
            switch (type)
            {
                case SchoolLexer.ADD:
                    expr = new Surface.Add(left, right);
                    break;
                case SchoolLexer.SUB:
                    expr = new Surface.Sub(left, right);
                    break;
                default:
                    throw new ParserException("unreachable code");
            }
            return expr;
        }

        private Surface.Expr Term()
        {
            Surface.Expr left = Factor();

            int type = lookahead.Type;
            switch (type)
            {
                case SchoolLexer.MUL:
                case SchoolLexer.DIV:
                    Consume();
                    break;
                default:
                    return left;
            }

            Surface.Expr right = Term();

            Surface.Expr expr;
            switch (type)
            {
                case SchoolLexer.MUL:
                    expr = new Surface.Mul(left, right);
                    break;
                case SchoolLexer.DIV:
                    expr = new Surface.Div(left, right);
                    break;
                default:
                    throw new ParserException("unreachable code");
            }
            return expr;
        }

        private Surface.Expr Factor()
        {
            Surface.Expr expr;

            switch (lookahead.Type)
            {
                case SchoolLexer.LPAREN:
                    Match(SchoolLexer.LPAREN);
                    expr = Expr();
                    Match(SchoolLexer.RPAREN);
                    break;
                case SchoolLexer.NUM:
                    string numberText = lookahead.Text;
                    expr = new Surface.Number(Int32.Parse(numberText));
                    Consume();
                    break;
                default:
                    throw new ParserException("expecting number; found " + lookahead);
            }

            return expr;
        }
    }
}

