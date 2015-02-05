using System;

namespace School
{
    public class Evaluator : IExprVisitor<int>
    {
        public Evaluator() { }

        public int Evaluate(Expr expr)
        {
            return expr.Accept(this);
        }

        int IExprVisitor<int>.Visit(Number number)
        {
            return number.Value;
        }

        int IExprVisitor<int>.Visit(Add add)
        {
            return add.Left.Accept(this) + add.Right.Accept(this);
        }

        int IExprVisitor<int>.Visit(Sub sub)
        {
            return sub.Left.Accept(this) - sub.Right.Accept(this);
        }

        int IExprVisitor<int>.Visit(Mul mul)
        {
            return mul.Left.Accept(this) * mul.Right.Accept(this);
        }

        int IExprVisitor<int>.Visit(Div div)
        {
            return div.Left.Accept(this) / div.Right.Accept(this);
        }
    }
}
