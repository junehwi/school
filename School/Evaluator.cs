using System;
using System.Collections.Generic;

namespace School
{
    public class Evaluator : Core.IExprVisitor<int>
    {
        private static readonly Dictionary<string, Func<int, int, int>> builtinFunctions = new Dictionary<string, Func<int, int, int>>
        {
            { "add", (a, b) => a + b },
            { "sub", (a, b) => a - b },
            { "mul", (a, b) => a * b },
            { "div", (a, b) => a / b }
        };

        public Evaluator() { }

        public int Evaluate(Core.Expr expr)
        {
            return expr.Accept(this);
        }

        int Core.IExprVisitor<int>.Visit(Core.Number number)
        {
            return number.Value;
        }

        int Core.IExprVisitor<int>.Visit(Core.FunApp app)
        {
            // FIXME: Currently, we assume that all functions are binary.
            int arg0 = app.Args[0].Accept(this);
            int arg1 = app.Args[1].Accept(this);

            Func<int, int, int> func = builtinFunctions[app.Name];
            return func(arg0, arg1);
        }
    }
}
