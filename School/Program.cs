using System;

namespace School
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var input = "1 * (2 + 3) - 4";
            Console.Write("Input:\n {0}\n\n", input);

            var lexer = new SchoolLexer(input);
            var parser = new SchoolParser(lexer);
            Surface.Expr expr = parser.Parse();

            Console.WriteLine("Print:");
            var printer = new Printer();
            printer.Print(expr);
            Console.Write("\n\n");

            var desugarer = new Desugarer();
            Core.Expr coreExpr = desugarer.Desugar(expr);

            var evaluator = new Evaluator();
            Console.Write("Result:\n{0}\n\n", evaluator.Evaluate(coreExpr));
        }
    }
}
