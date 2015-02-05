using System;

namespace School
{
    public class RPNConverter : Core.IExprVisitor<string>
    {
        public RPNConverter() { }

        public string Convert(Core.Expr expr)
        {
            return expr.Accept(this);
        }

        string Core.IExprVisitor<string>.Visit(Core.Number number)
        {
            return number.Value.ToString();
        }

        string Core.IExprVisitor<string>.Visit(Core.Add add)
        {
            return String.Format("{0} {1} +", add.Left.Accept(this), add.Right.Accept(this));
        }

        string Core.IExprVisitor<string>.Visit(Core.Sub sub)
        {
            return String.Format("{0} {1} -", sub.Left.Accept(this), sub.Right.Accept(this));
        }

        string Core.IExprVisitor<string>.Visit(Core.Mul mul)
        {
            return String.Format("{0} {1} *", mul.Left.Accept(this), mul.Right.Accept(this));
        }

        string Core.IExprVisitor<string>.Visit(Core.Div div)
        {
            return String.Format("{0} {1} /", div.Left.Accept(this), div.Right.Accept(this));
        }
    }
}
