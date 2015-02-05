using System;
using System.Text;

namespace School
{
    public class PseudoByteCodeGenerator : Core.IExprVisitor<object>
    {
        private StringBuilder builder = new StringBuilder();

        public PseudoByteCodeGenerator() { }

        public string Compile(Core.Expr expr)
        {
            expr.Accept(this);
            return builder.ToString();
        }

        object Core.IExprVisitor<object>.Visit(Core.Number number)
        {
            string ldc = String.Format("ldc {0}\n", number.Value.ToString());
            builder.Append(ldc);
            return null;
        }

        private void CompileBinaryOp(Core.BinaryOperator binOp, string opCode)
        {
            binOp.Left.Accept(this);
            binOp.Right.Accept(this);
            builder.Append(opCode);
            builder.Append("\n");
        }

        object Core.IExprVisitor<object>.Visit(Core.Add add)
        {
            CompileBinaryOp(add, "add");
            return null;
        }

        object Core.IExprVisitor<object>.Visit(Core.Sub sub)
        {
            CompileBinaryOp(sub, "sub");
            return null;
        }

        object Core.IExprVisitor<object>.Visit(Core.Mul mul)
        {
            CompileBinaryOp(mul, "mul");
            return null;
        }

        object Core.IExprVisitor<object>.Visit(Core.Div div)
        {
            CompileBinaryOp(div, "div");
            return null;
        }
    }
}
