using MinskLearn.CodeAnalisys.Syntax;
using MinskLearn.CodeAnalysis;
namespace MinskLearn
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, Minsk!");
            while (true)
            {
                Console.Write(">");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                var syntaxTree = SyntaxTree.Parse(line);
                PrettyPrint(syntaxTree.Root);
                if (!syntaxTree.Diagnostics.Any())
                {
                    var e = new Evaluator(syntaxTree.Root);
                    var result = e.Evaluate();
                    Console.WriteLine(result);
                }

            }

        }
        static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
        {
            var marker = isLast ? "└──" : "├──";
            Console.Write(indent);
            Console.Write(marker);
            Console.Write(node.Kind);

            if (node is SyntaxToken t && t.Value != null)
            {
                Console.Write(" ");
                Console.Write(t.Value);
            }

            Console.WriteLine();
            indent += isLast ? "   " : "│  ";
            var lastChild = node.GetChildren().LastOrDefault();
            foreach (var child in node.GetChildren())
                PrettyPrint(child, indent, child == lastChild);

        }
    }
}

