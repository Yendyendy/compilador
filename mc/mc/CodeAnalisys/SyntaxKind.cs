namespace MinskLearn.CodeAnalysis
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

        NumberExpression,
        BinaryExpression,
        ParenthesizedExpression,
    }
}

