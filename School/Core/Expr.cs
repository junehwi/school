using System;

namespace School.Core
{
    public interface IExprVisitor<R>
    {
        R Visit(Number number);
        R Visit(FunApp app);
    }

    public abstract class Expr
    {
        public abstract R Accept<R>(IExprVisitor<R> visitor);
    }

    public class Number : Expr
    {
        private readonly int value;

        public int Value
        {
            get { return value; }
        }

        public Number(int value)
        {
            this.value = value;
        }

        public override R Accept<R>(IExprVisitor<R> visitor)
        {
            return visitor.Visit(this);
        }
    }

    public class FunApp : Expr
    {
        private readonly string name;

        private readonly Expr[] args;

        public string Name
        {
            get { return name; }
        }

        public Expr[] Args
        {
            get { return args; }
        }
            
        public FunApp(string name, Expr[] args)
        {
            this.name = name;
            this.args = args;
        }

        public override R Accept<R>(IExprVisitor<R> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
