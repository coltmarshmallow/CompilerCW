using Triangle.Compiler.SyntaxTrees.Terminals;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.SyntacticAnalyzer
{
    public partial class Parser
    {

        // /////////////////////////////////////////////////////////////////////////////
        //
        // VALUE-OR-VARIABLE NAMES
        //
        // /////////////////////////////////////////////////////////////////////////////

        /**
         * Parses the v-name, and constructs an AST to represent its phrase structure.
         * 
         * @return a {@link triangle.compiler.syntax.trees.vnames.Vname}
         * 
         * @throws SyntaxError
         *           a syntactic error
         * 
         */
        Vname ParseVname()
        {
            var identifier = ParseIdentifier();
            //return SimpleVname(vName);
            return ParseRestOfVname(identifier);

            /*
            var startLocation = _currentToken.Start;
            var identifier = ParseIdentifier();
            var vnamePosition = new SourcePosition(startLocation, _currentToken.Finish);
            return new SimpleVname(identifier, vnamePosition);*/

        }


        Vname ParseRestOfVname(Identifier firstIdentifier)
        {
            var startLocation = firstIdentifier.Start;
            Vname vname = new SimpleVname(firstIdentifier, firstIdentifier.Position);
            return vname;

        }
    }
}