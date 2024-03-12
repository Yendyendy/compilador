namespace MinskLearn.CodeAnalisys.Syntax
{
    public class LiteralExpressionSyntax : ExpressionSyntax
    { 
        public SyntaxToken LiteralToken { get; }
        public object Value { get; }

        public LiteralExpressionSyntax(SyntaxToken literalToken): this(literalToken, literalToken.Value) { }

        public LiteralExpressionSyntax(SyntaxToken literalToken, Object value)
        {
            LiteralToken = literalToken;
            Value = value; 
        }
        public override SyntaxKind Kind => SyntaxKind.LiteralExpression;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return LiteralToken;
        }
    }
}

