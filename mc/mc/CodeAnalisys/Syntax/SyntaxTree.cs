﻿namespace MinskLearn.CodeAnalisys.Syntax
{
    public sealed class SyntaxTree
    {
        public SyntaxTree(IEnumerable<string> diagnostics, ExpressionSyntax root, SyntaxToken endOfFileToken)
        {
            Diagnostics = diagnostics;
            Root = root;
            EndOfFileToken = endOfFileToken;
        }

        public IEnumerable<string> Diagnostics { get; }
        public ExpressionSyntax Root { get; }
        public SyntaxToken EndOfFileToken { get; }


        public static SyntaxTree Parse(string text)
        {
            var parser = new Parser(text);
            var aux = parser.Parse();
            return aux;
        }
    }
}

