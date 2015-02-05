using System;

namespace School
{
    public class RPNConverter : IExprVisitor<string>
    {
        public RPNConverter() { }

        public string Convert(Expr expr)
        {
            return expr.Accept(this);
        }

        string IExprVisitor<string>.Visit(Number number)
        {
            return number.Value.ToString();
        }

        string IExprVisitor<string>.Visit(Add add)
        {
            return String.Format("{0} {1} +", add.Left.Accept(this), add.Right.Accept(this));
        }

        string IExprVisitor<string>.Visit(Sub sub)
        {
            return String.Format("{0} {1} -", sub.Left.Accept(this), sub.Right.Accept(this));
        }

        string IExprVisitor<string>.Visit(Mul mul)
        {
            return String.Format("{0} {1} *", mul.Left.Accept(this), mul.Right.Accept(this));
        }

        string IExprVisitor<string>.Visit(Div div)
        {
            return String.Format("{0} {1} /", div.Left.Accept(this), div.Right.Accept(this));
        }
    }
}
