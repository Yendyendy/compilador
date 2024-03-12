namespace MinskLearn.CodeAnalisys.Syntax
{
    public enum SyntaxKind
    {
        BadToken,
        EndOfFileToken,
        WhiteSpaceToken,
        NumberToken,

        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        BangToken,
        AmpersandAmpersandToken,
        PipePipeToken,
        EqualsEqualsToken,
        BangEqualsToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        IdentifierToken,

        TrueKeyword,
        FalseKeyword,

        LiteralExpression,
        UnaryExpression,
        BinaryExpression,
        ParenthesizedExpression,
    }
}

