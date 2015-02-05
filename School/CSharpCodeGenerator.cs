using System;
using System.Text;

namespace School
{
    public class CSharpCodeGenerator : Surface.IExprVisitor<object>
    {
        private StringBuilder builder = new StringBuilder();

        private const string prolog = @"
namespace School
{
    public static class School
    {
        public static int EvaluateExpression()
        {
            return ";

        private const string epilog = @";
        }
    }
}";

        public CSharpCodeGenerator() { }

        public string Compile(Surface.Expr expr)
        {

            expr.Accept(this);
            string code = builder.ToString();
            return prolog + code + epilog;
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Number number)
        {
            builder.Append(number.Value.ToString());
            return null;
        }

        private void CompileBinaryOp(Surface.BinaryOperator binOp, string opCode)
        {
            builder.Append("(");
            binOp.Left.Accept(this);
            builder.Append(opCode);
            binOp.Right.Accept(this);
            builder.Append(")");
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Add add)
        {
            CompileBinaryOp(add, "+");
            return null;
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Sub sub)
        {
            CompileBinaryOp(sub, "-");
            return null;
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Mul mul)
        {
            CompileBinaryOp(mul, "*");
            return null;
        }

        object Surface.IExprVisitor<object>.Visit(Surface.Div div)
        {
            CompileBinaryOp(div, "/");
            return null;
        }
    }
}
