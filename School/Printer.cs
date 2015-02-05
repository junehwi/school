using System;

namespace School
{
    public class Printer : IExprVisitor<object>
    {
        public Printer() { }

        public void Print(Expr expr)
        {
            expr.Accept(this);
        }

        object IExprVisitor<object>.Visit(Number number)
        {
            Console.Write(number.Value);
            return null;
        }

        private void PrintBinaryOperator(BinaryOperator binOp, char opChar)
        {
            Console.Write("(");
            Print(binOp.Left);
            Console.Write(" {0} ", opChar);
            Print(binOp.Right);
            Console.Write(")");
        }

        object IExprVisitor<object>.Visit(Add add)
        {
            PrintBinaryOperator(add, '+');
            return null;
        }

        object IExprVisitor<object>.Visit(Sub sub)
        {
            PrintBinaryOperator(sub, '-');
            return null;
        }

        object IExprVisitor<object>.Visit(Mul mul)
        {
            PrintBinaryOperator(mul, '*');
            return null;
        }

        object IExprVisitor<object>.Visit(Div div)
        {
            PrintBinaryOperator(div, '/');
            return null;
        }
    }
}
