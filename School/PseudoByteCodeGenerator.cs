using System;
using System.Text;

namespace School
{
    public class PseudoByteCodeGenerator : Surface.IExprVisitor<object>
    {
        private StringBuilder builder = new StringBuilder();

        public PseudoByteCodeGenerator() { }

        public string Compile(Surface.Expr expr)
        {
            expr.Accept(this);
            return builder.ToString();
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Number number)
        {
            string ldc = String.Format("ldc {0}\n", number.Value.ToString());
            builder.Append(ldc);
            return null;
        }

        private void CompileBinaryOp(Surface.BinaryOperator binOp, string opCode)
        {
            binOp.Left.Accept(this);
            binOp.Right.Accept(this);
            builder.Append(opCode);
            builder.Append("\n");
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Add add)
        {
            CompileBinaryOp(add, "add");
            return null;
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Sub sub)
        {
            CompileBinaryOp(sub, "sub");
            return null;
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Mul mul)
        {
            CompileBinaryOp(mul, "mul");
            return null;
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Div div)
        {
            CompileBinaryOp(div, "div");
            return null;
        }
    }
}
