using System;
using System.Text;

namespace School
{
    public class PseudoByteCodeGenerator : IExprVisitor<object>
    {
        private StringBuilder builder = new StringBuilder();

        public PseudoByteCodeGenerator() { }

        public string Compile(Expr expr)
        {
            expr.Accept(this);
            return builder.ToString();
        }

        object IExprVisitor<object>.Visit(Number number)
        {
            string ldc = String.Format("ldc {0}\n", number.Value.ToString());
            builder.Append(ldc);
            return null;
        }

        private void CompileBinaryOp(BinaryOperator binOp, string opCode)
        {
            binOp.Left.Accept(this);
            binOp.Right.Accept(this);
            builder.Append(opCode);
            builder.Append("\n");
        }

        object IExprVisitor<object>.Visit(Add add)
        {
            CompileBinaryOp(add, "add");
            return null;
        }

        object IExprVisitor<object>.Visit(Sub sub)
        {
            CompileBinaryOp(sub, "sub");
            return null;
        }

        object IExprVisitor<object>.Visit(Mul mul)
        {
            CompileBinaryOp(mul, "mul");
            return null;
        }

        object IExprVisitor<object>.Visit(Div div)
        {
            CompileBinaryOp(div, "div");
            return null;
        }
    }
}
