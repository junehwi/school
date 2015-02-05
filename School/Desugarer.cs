using System;

namespace School
{
    public class Desugarer : Surface.IExprVisitor<Core.Expr>
    {
        public Desugarer() { }

        public Core.Expr Desugar(Surface.Expr expr)
        {
            return expr.Accept(this);
        }

        Core.Expr Surface.IExprVisitor<Core.Expr>.Visit(Surface.Number number)
        {
            return new Core.Number(number.Value);
        }

        Core.Expr Surface.IExprVisitor<Core.Expr>.Visit(Surface.Add add)
        {
            Core.Expr left = add.Left.Accept(this);
            Core.Expr right = add.Right.Accept(this);
            return new Core.FunApp("add", new Core.Expr[] { left, right });
        }

        Core.Expr Surface.IExprVisitor<Core.Expr>.Visit(Surface.Sub sub)
        {
            Core.Expr left = sub.Left.Accept(this);
            Core.Expr right = sub.Right.Accept(this);
            return new Core.FunApp("sub", new Core.Expr[] { left, right });
        }

        Core.Expr Surface.IExprVisitor<Core.Expr>.Visit(Surface.Mul mul)
        {
            Core.Expr left = mul.Left.Accept(this);
            Core.Expr right = mul.Right.Accept(this);
            return new Core.FunApp("mul", new Core.Expr[] { left, right });
        }

        Core.Expr Surface.IExprVisitor<Core.Expr>.Visit(Surface.Div div)
        {
            Core.Expr left = div.Left.Accept(this);
            Core.Expr right = div.Right.Accept(this);
            return new Core.FunApp("div", new Core.Expr[] { left, right });
        }
    }
}

