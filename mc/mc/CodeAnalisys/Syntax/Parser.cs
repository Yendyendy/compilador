namespace MinskLearn.CodeAnalisys.Syntax
{
    class Parser
    {

        public string Text { get; }

        private readonly SyntaxToken[] _tokens;

        private List<string> _diagnostics = new List<string>();

        public IEnumerable<string> Diagnostics => _diagnostics;

        private int _position;

        public Parser(string text)
        {
            var tokens = new List<SyntaxToken>();
            var lexer = new Lexer(text);

            SyntaxToken token;

            do
            {
                token = lexer.NextToken();
                if (token.Kind != SyntaxKind.WhiteSpaceToken &&
                    token.Kind != SyntaxKind.BadToken)
                {
                    tokens.Add(token);
                }

            } while (token.Kind != SyntaxKind.EndOfFileToken);

            _tokens = tokens.ToArray();
            _diagnostics.AddRange(lexer.Diagnostics);
        }

        private SyntaxToken Peek(int offset)
        {
            var index = _position + offset;
            //si idx supera tamaño, devuelve el ultimo
            if (index >= _tokens.Length)
                return _tokens[_tokens.Length - 1];
            return _tokens[index];
        }

        public SyntaxToken Current => Peek(0);

        public SyntaxToken NextToken()
        {
            var current = Current;

            _position++;

            return current;
        }

        public SyntaxToken Match(SyntaxKind kind)
        {
            var current = Current;
            if (current.Kind == kind)
            {
                return NextToken();
            }
            _diagnostics.Add($"ERROR: Unexpected token <{Current.Kind}>, expected <{kind}>");
            return new SyntaxToken(kind, Current.Position, null, null);
        }

        public SyntaxTree Parse()
        {
            var expression = ParseExpression();
            var endOfFileToken = Match(SyntaxKind.EndOfFileToken);


            return new SyntaxTree(_diagnostics, expression, endOfFileToken);
        }
        private ExpressionSyntax ParseExpression(int parentPrecedence = 0)
        {
            ExpressionSyntax left;

            var unaryOperatorPrecedence = Current.Kind.GetUnaryOperatorPrecedence();
            if (unaryOperatorPrecedence != 0 && unaryOperatorPrecedence >= parentPrecedence)
            {
                var operatorToken = NextToken();
                var operand = ParseExpression(unaryOperatorPrecedence);
                left = new UnaryExpressionSyntax(operatorToken, operand);
            }
            else
            {
                left = ParsePrimaryExpression();
            }


            while (true)
            {
                var precedence = Current.Kind.GetBinaryOperatorPrecedence();

                //if we dont have parent-precedence
                //if current precedence is lower tha parent precedence break, we want to parse later
                if (precedence == 0 || precedence <= parentPrecedence)
                {
                    break;
                }

                var operatorToken = NextToken();
                var right = ParseExpression(precedence);
                left = new BinaryExpressionSyntax(left, operatorToken, right);
            }
            return left;
        }

        //parentesis
        public ExpressionSyntax ParsePrimaryExpression()
        {
            if (Current.Kind == SyntaxKind.OpenParenthesisToken)
            {
                var left = NextToken();
                var middle = ParseExpression();
                var right = Match(SyntaxKind.CloseParenthesisToken);
                return new ParenthesizedExpressionSyntax(left, middle, right);
            }
            var numberToken = Match(SyntaxKind.NumberToken);
            return new LiteralExpressionSyntax(numberToken);
        }

        ////suma resta
        //public ExpressionSyntax ParseTerm()
        //{
        //    var left = ParseFactor();

        //    while (Current.Kind == SyntaxKind.PlusToken ||
        //        Current.Kind == SyntaxKind.MinusToken)
        //    {
        //        var middle = NextToken();
        //        var right = ParseFactor();
        //        left = new BinaryExpressionSyntax(left, middle, right);

        //    }

        //    return left;
        //}

        ////mult div
        //public ExpressionSyntax ParseFactor()
        //{
        //    var left = ParsePrimaryExpression();

        //    while (Current.Kind == SyntaxKind.StarToken ||
        //        Current.Kind == SyntaxKind.SlashToken)
        //    {
        //        var middle = NextToken();
        //        var right = ParsePrimaryExpression();
        //        //left
        //        left = new BinaryExpressionSyntax(left, middle, right);
        //    }

        //    return left;

        //}

    }
}

