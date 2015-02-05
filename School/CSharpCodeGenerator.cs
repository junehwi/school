using System;
using System.Text;

namespace School
{
    public class CSharpCodeGenerator : IExprVisitor<object>
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

        public string Compile(Expr expr)
        {

            expr.Accept(this);
            string code = builder.ToString();
            return prolog + code + epilog;
        }

        object IExprVisitor<object>.Visit(Number number)
        {
            builder.Append(number.Value.ToString());
            return null;
        }

        private void CompileBinaryOp(BinaryOperator binOp, string opCode)
        {
            builder.Append("(");
            binOp.Left.Accept(this);
            builder.Append(opCode);
            binOp.Right.Accept(this);
            builder.Append(")");
        }

        object IExprVisitor<object>.Visit(Add add)
        {
            CompileBinaryOp(add, "+");
            return null;
        }

        object IExprVisitor<object>.Visit(Sub sub)
        {
            CompileBinaryOp(sub, "-");
            return null;
        }

        object IExprVisitor<object>.Visit(Mul mul)
        {
            CompileBinaryOp(mul, "*");
            return null;
        }

        object IExprVisitor<object>.Visit(Div div)
        {
            CompileBinaryOp(div, "/");
            return null;
        }
    }
}
