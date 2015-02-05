using System;
using System.Text;

namespace School
{
    public class CSharpCodeGenerator : Core.IExprVisitor<object>
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

        public string Compile(Core.Expr expr)
        {

            expr.Accept(this);
            string code = builder.ToString();
            return prolog + code + epilog;
        }

        object Core.IExprVisitor<object>.Visit(Core.Number number)
        {
            builder.Append(number.Value.ToString());
            return null;
        }

        private void CompileBinaryOp(Core.BinaryOperator binOp, string opCode)
        {
            builder.Append("(");
            binOp.Left.Accept(this);
            builder.Append(opCode);
            binOp.Right.Accept(this);
            builder.Append(")");
        }

        object Core.IExprVisitor<object>.Visit(Core.Add add)
        {
            CompileBinaryOp(add, "+");
            return null;
        }

        object Core.IExprVisitor<object>.Visit(Core.Sub sub)
        {
            CompileBinaryOp(sub, "-");
            return null;
        }

        object Core.IExprVisitor<object>.Visit(Core.Mul mul)
        {
            CompileBinaryOp(mul, "*");
            return null;
        }

        object Core.IExprVisitor<object>.Visit(Core.Div div)
        {
            CompileBinaryOp(div, "/");
            return null;
        }
    }
}
