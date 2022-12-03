using Metalama.Compiler;

namespace Metalama.Migration.Transformer
{
    [Transformer]
    public class Transformer : ISourceTransformer
    {
        public void Execute( TransformerContext context )
        {
            foreach ( var syntaxTree in context.Compilation.SyntaxTrees )
            {
                var semanticModel = context.Compilation.GetSemanticModel( syntaxTree );
                var rewriter = new Rewriter( semanticModel );
                var newSyntaxRoot = rewriter.Visit( syntaxTree.GetRoot() );
                var newSyntaxTree = syntaxTree.WithRootAndOptions( newSyntaxRoot, syntaxTree.Options );
                context.ReplaceSyntaxTree( syntaxTree, newSyntaxTree );
            }
        }
    }
}