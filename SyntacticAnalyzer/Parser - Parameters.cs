using Triangle.Compiler.SyntaxTrees.Actuals;


namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {

        ///////////////////////////////////////////////////////////////////////////////
        //
        // PARAMETERS
        //
        ///////////////////////////////////////////////////////////////////////////////

       

       

        /**
         * Parses the actual parameter sequence, and constructs an AST to represent
         * its phrase structure.
         * 
         * @return an
         *         {@link triangle.compiler.syntax.trees.actuals.ActualParameterSequence}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        ActualParameterSequence ParseActualParameterSequence()
        {

            var startLocation = _currentToken.Position.Start;
            if (_currentToken.Kind == TokenKind.RightParen)
            {
                var actualsPosition = new SourcePosition(startLocation, _currentToken.Position.Finish);
                return new EmptyActualParameterSequence(actualsPosition);
            }
            return ParseProperActualParameterSequence();
        }

        /**
         * Parses the proper (non-empty) actual parameter sequence, and constructs an
         * AST to represent its phrase structure.
         * 
         * @return an
         *         {@link triangle.compiler.syntax.trees.actuals.ActualParameterSequence}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        ActualParameterSequence ParseProperActualParameterSequence()
        {

            var startLocation = _currentToken.Position.Start;
            var actual = ParseActualParameter();
            if (_currentToken.Kind == TokenKind.Comma)
            {
                AcceptIt();
                var actualSequence = ParseProperActualParameterSequence();
                var actualsPosition = new SourcePosition(startLocation, _currentToken.Position.Finish);
                return new MultipleActualParameterSequence(actual, actualSequence, actualsPosition);
            }
            else
            {
                var actualsPosition = new SourcePosition(startLocation, _currentToken.Position.Finish);
                return new SingleActualParameterSequence(actual, actualsPosition);

            }
           
        }

        /**
         * Parses the actual parameter, and constructs an AST to represent its phrase
         * structure.
         * 
         * @return an {@link triangle.compiler.syntax.trees.actuals.ActualParameter}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        ActualParameter ParseActualParameter()
        {

            var startLocation = _currentToken.Position.Start;
            switch (_currentToken.Kind)
            {
                //ask
                case TokenKind.Identifier:
                case TokenKind.IntLiteral:
                case TokenKind.CharLiteral:
                case TokenKind.Operator:
                case TokenKind.Let:
                case TokenKind.If:
                case TokenKind.LeftParen:
                case TokenKind.LeftBracket:
                case TokenKind.LeftCurly:
                    {
                        //check
                        var pExpression = ParseExpression();
                        var actualPosition = new SourcePosition(startLocation, _currentToken.Position.Finish);
                        return new ConstActualParameter(pExpression, actualPosition);
                    }

                case TokenKind.Var:
                    {
                        AcceptIt();
                        var vName = ParseVname();
                        var actualPosition = new SourcePosition(startLocation, _currentToken.Position.Finish);
                        return new VarActualParameter(vName, actualPosition);
                    }

                default:
                    {
                        RaiseSyntacticError("\"%\" cannot start an actual parameter", _currentToken);
                        return null;
                    }

            }

        }
    }
}