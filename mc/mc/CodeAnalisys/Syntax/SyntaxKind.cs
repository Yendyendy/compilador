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
        OpenParenthesisToken,
        CloseParenthesisToken,

        LiteralExpression,
        BinaryExpression,
        ParenthesizedExpression,
        UnaryExpression,
    }
}

