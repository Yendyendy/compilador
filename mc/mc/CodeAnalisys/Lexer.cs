namespace MinskLearn.CodeAnalysis
{
    class Lexer
    {
        private string _text;
        private int _position;
        private List<string> _diagnostics = new List<string>();
        public IEnumerable<string> Diagnostics => _diagnostics;

        #region private class
        private char Current
        {
            get
            {
                if (_position >= _text.Length)
                    return '\0';
                return _text[_position];
            }
        }

        private void Next() { _position++; }
        #endregion
        public Lexer(string text)
        {
            _text = text;
        }

        public SyntaxToken NextToken()
        {
            //numeros
            //+ - * / ()
            //whitespace espacios

            if (_position >= _text.Length)
            {
                return new SyntaxToken(SyntaxKind.EndOfFileToken, _position, "\0", null);
            }

            if (Char.IsDigit(Current))
            {
                var start = _position;
                while (Char.IsDigit(Current)) Next();

                var length = _position - start;
                var text = _text.Substring(start, length);
                int.TryParse(text, out var value);
                return new SyntaxToken(SyntaxKind.NumberToken, start, text, value);
            }

            if (Char.IsWhiteSpace(Current))
            {
                var start = _position;
                while (Char.IsWhiteSpace(Current)) Next();

                var length = _position - start;
                var text = _text.Substring(start, length);
                int.TryParse(text, out var value);
                return new SyntaxToken(SyntaxKind.WhiteSpaceToken, start, text, null);
            }

            if (Current == '+')
            {
                return new SyntaxToken(SyntaxKind.PlusToken, _position++, "+", null);
            }
            else if (Current == '-')
            {
                return new SyntaxToken(SyntaxKind.MinusToken, _position++, "-", null);
            }
            else if (Current == '*')
            {
                return new SyntaxToken(SyntaxKind.StarToken, _position++, "*", null);
            }
            else if (Current == '/')
            {
                return new SyntaxToken(SyntaxKind.SlashToken, _position++, "/", null);
            }
            else if (Current == '(')
            {
                return new SyntaxToken(SyntaxKind.OpenParenthesisToken, _position++, "(", null);
            }
            else if (Current == ')')
            {
                return new SyntaxToken(SyntaxKind.CloseParenthesisToken, _position++, ")", null);
            }

            return new SyntaxToken(SyntaxKind.BadToken, _position++, _text.Substring(_position, 1), null);
        }
    }
}

