using System;

namespace School
{
    public class Printer : Surface.IExprVisitor<object>
    {
        public Printer() { }

        public void Print(Surface.Expr expr)
        {
            expr.Accept(this);
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Number number)
        {
            Console.Write(number.Value);
            return null;
        }

        private void PrintBinaryOperator(Surface.BinaryOperator binOp, char opChar)
        {
            Console.Write("(");
            Print(binOp.Left);
            Console.Write(" {0} ", opChar);
            Print(binOp.Right);
            Console.Write(")");
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Add add)
        {
            PrintBinaryOperator(add, '+');
            return null;
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Sub sub)
        {
            PrintBinaryOperator(sub, '-');
            return null;
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Mul mul)
        {
            PrintBinaryOperator(mul, '*');
            return null;
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Div div)
        {
            PrintBinaryOperator(div, '/');
            return null;
        }
    }
}
