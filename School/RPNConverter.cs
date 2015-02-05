using System;

namespace School
{
    public class RPNConverter : Surface.IExprVisitor<string>
    {
        public RPNConverter() { }

        public string Convert(Surface.Expr expr)
        {
            return expr.Accept(this);
        }

        string Surface.IExprVisitor<string>.Visit(Surface.Number number)
        {
            return number.Value.ToString();
        }

        string Surface.IExprVisitor<string>.Visit(Surface.Add add)
        {
            return String.Format("{0} {1} +", add.Left.Accept(this), add.Right.Accept(this));
        }

        string Surface.IExprVisitor<string>.Visit(Surface.Sub sub)
        {
            return String.Format("{0} {1} -", sub.Left.Accept(this), sub.Right.Accept(this));
        }

        string Surface.IExprVisitor<string>.Visit(Surface.Mul mul)
        {
            return String.Format("{0} {1} *", mul.Left.Accept(this), mul.Right.Accept(this));
        }

        string Surface.IExprVisitor<string>.Visit(Surface.Div div)
        {
            return String.Format("{0} {1} /", div.Left.Accept(this), div.Right.Accept(this));
        }
    }
}
