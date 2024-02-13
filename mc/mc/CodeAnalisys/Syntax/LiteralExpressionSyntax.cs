namespace MinskLearn.CodeAnalisys.Syntax
{
    public class LiteralExpressionSyntax : ExpressionSyntax
    {
        public SyntaxToken NumberToken { get; }

        public LiteralExpressionSyntax(SyntaxToken numberToken)
        {
            NumberToken = numberToken;
        }
        public override SyntaxKind Kind => SyntaxKind.LiteralExpression;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return NumberToken;
        }
    }
}

