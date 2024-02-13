using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinskLearn.CodeAnalisys.Syntax
{
    internal class UnaryExpressionSyntax : ExpressionSyntax
    {
        public override SyntaxKind Kind => SyntaxKind.UnaryExpression;

        public SyntaxToken OperatorToken { get; }
        public ExpressionSyntax Operand { get; }

        public UnaryExpressionSyntax(SyntaxToken operatorToken, ExpressionSyntax operand)
        {
            OperatorToken = operatorToken;
            Operand = operand;
        }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return OperatorToken;
            yield return Operand;
        }
    }
}
