using System;

namespace Calculating
{
    class Program
    {
        static void Main(string[] args)
        {
            var newParseTree = new Structures.ParseTree();
            newParseTree.SetExpression("(/ 100 (+ (* 2 3) 4))");
            Console.WriteLine(newParseTree.PrintExpression());
            Console.WriteLine(newParseTree.Count());
        }
    }
}
