using System;

namespace School
{
    // expr    = term  { ("+" | "-") expr }
    // term    = factor  { ("*"|"/") term }
    // factor  = number | "("  expr  ")"
    public class SchoolParser : Parser
    {
        public SchoolParser(Lexer input) : base(input) { }

        public Expr Parse()
        {
            return Expr();
        }

        private Expr Expr()
        {
            Expr left = Term();

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

            Expr right = Expr();

            Expr expr;
            switch (type)
            {
                case SchoolLexer.ADD:
                    expr = new Add(left, right);
                    break;
                case SchoolLexer.SUB:
                    expr = new Sub(left, right);
                    break;
                default:
                    throw new ParserException("unreachable code");
            }
            return expr;
        }

        private Expr Term()
        {
            Expr left = Factor();

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

            Expr right = Term();

            Expr expr;
            switch (type)
            {
                case SchoolLexer.MUL:
                    expr = new Mul(left, right);
                    break;
                case SchoolLexer.DIV:
                    expr = new Div(left, right);
                    break;
                default:
                    throw new ParserException("unreachable code");
            }
            return expr;
        }

        private Expr Factor()
        {
            Expr expr;

            switch (lookahead.Type)
            {
                case SchoolLexer.LPAREN:
                    Match(SchoolLexer.LPAREN);
                    expr = Expr();
                    Match(SchoolLexer.RPAREN);
                    break;
                case SchoolLexer.NUM:
                    string numberText = lookahead.Text;
                    expr = new Number(Int32.Parse(numberText));
                    Consume();
                    break;
                default:
                    throw new ParserException("expecting number; found " + lookahead);
            }

            return expr;
        }
    }
}

