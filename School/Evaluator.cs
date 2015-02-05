using System;

namespace School
{
    public class Evaluator : Core.IExprVisitor<int>
    {
        public Evaluator() { }

        public int Evaluate(Core.Expr expr)
        {
            return expr.Accept(this);
        }

        int Core.IExprVisitor<int>.Visit(Core.Number number)
        {
            return number.Value;
        }

        int Core.IExprVisitor<int>.Visit(Core.Add add)
        {
            return add.Left.Accept(this) + add.Right.Accept(this);
        }

        int Core.IExprVisitor<int>.Visit(Core.Sub sub)
        {
            return sub.Left.Accept(this) - sub.Right.Accept(this);
        }

        int Core.IExprVisitor<int>.Visit(Core.Mul mul)
        {
            return mul.Left.Accept(this) * mul.Right.Accept(this);
        }

        int Core.IExprVisitor<int>.Visit(Core.Div div)
        {
            return div.Left.Accept(this) / div.Right.Accept(this);
        }
    }
}
