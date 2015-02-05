using System;

namespace School
{
    public class Evaluator : Surface.IExprVisitor<int>
    {
        public Evaluator() { }

        public int Evaluate(Surface.Expr expr)
        {
            return expr.Accept(this);
        }

        int Surface.IExprVisitor<int>.Visit(Surface.Number number)
        {
            return number.Value;
        }

        int Surface.IExprVisitor<int>.Visit(Surface.Add add)
        {
            return add.Left.Accept(this) + add.Right.Accept(this);
        }

        int Surface.IExprVisitor<int>.Visit(Surface.Sub sub)
        {
            return sub.Left.Accept(this) - sub.Right.Accept(this);
        }

        int Surface.IExprVisitor<int>.Visit(Surface.Mul mul)
        {
            return mul.Left.Accept(this) * mul.Right.Accept(this);
        }

        int Surface.IExprVisitor<int>.Visit(Surface.Div div)
        {
            return div.Left.Accept(this) / div.Right.Accept(this);
        }
    }
}
