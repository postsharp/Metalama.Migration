using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Metalama.Migration.Transformer;

internal class Rewriter : CSharpSyntaxRewriter
{
    private readonly SemanticModel _semanticModel;

    public Rewriter( SemanticModel semanticModel )
    {
        this._semanticModel = semanticModel;
    }

    private T RewriteAttributes<T>(
        T node,
        Func<T, SyntaxNode?> callBase,
        Func<T, SyntaxList<AttributeListSyntax>> getAttributes,
        Func<T, SyntaxList<AttributeListSyntax>, T> changeAttributes,
        Func<T, SyntaxNode>? getSymbolNode = null )
        where T : SyntaxNode
    {
        var transformedNode = (T) callBase( node )!;

        var symbolNode = getSymbolNode?.Invoke( node ) ?? node;

        var symbol = this._semanticModel.GetDeclaredSymbol( symbolNode );

        if ( symbol == null )
        {
            return transformedNode;
        }

        var attributes = getAttributes( transformedNode );

        var obsoleteAttribute = attributes.SelectMany( a => a.Attributes ).SingleOrDefault( a => a.Name.ToString() == "Obsolete" );

        var isError = obsoleteAttribute is { ArgumentList.Arguments.Count: > 1 }
                      && obsoleteAttribute.ArgumentList.Arguments[1].Expression is LiteralExpressionSyntax literal &&
                      literal.Token.IsKind( SyntaxKind.TrueKeyword );

        var xml = symbol.GetDocumentationCommentXml( CultureInfo.InvariantCulture, true );

        var newObsoleteAttribute =
            Attribute(
                QualifiedName( IdentifierName( "System" ), IdentifierName( "Obsolete" ) ),
                AttributeArgumentList(
                    SeparatedList(
                        new[]
                        {
                            AttributeArgument( LiteralExpression( SyntaxKind.StringLiteralExpression, Literal( xml ) ) ),
                            AttributeArgument( LiteralExpression( isError ? SyntaxKind.TrueLiteralExpression : SyntaxKind.FalseLiteralExpression ) )
                        } ) ) );

        SyntaxList<AttributeListSyntax> newAttributes;

        if ( obsoleteAttribute != null )
        {
            var oldAttributeList = attributes.Single( l => l.Attributes.Contains( obsoleteAttribute ) );
            newAttributes = attributes.Replace( oldAttributeList, oldAttributeList.ReplaceNode( obsoleteAttribute, newObsoleteAttribute ) );
        }
        else
        {
            newAttributes = attributes.Add( AttributeList( SingletonSeparatedList( newObsoleteAttribute ) ) );
        }

        return changeAttributes( transformedNode, newAttributes );
    }

    public override SyntaxNode? VisitClassDeclaration( ClassDeclarationSyntax node )
        => this.RewriteAttributes( node, base.VisitClassDeclaration, n => n.AttributeLists, ( n, a ) => n.WithAttributeLists( a ) );

    public override SyntaxNode? VisitPropertyDeclaration( PropertyDeclarationSyntax node )
        => this.RewriteAttributes( node, base.VisitPropertyDeclaration, n => n.AttributeLists, ( n, a ) => n.WithAttributeLists( a ) );

    public override SyntaxNode? VisitIndexerDeclaration( IndexerDeclarationSyntax node )
        => this.RewriteAttributes( node, base.VisitIndexerDeclaration, n => n.AttributeLists, ( n, a ) => n.WithAttributeLists( a ) );

    public override SyntaxNode? VisitStructDeclaration( StructDeclarationSyntax node )
        => this.RewriteAttributes( node, base.VisitStructDeclaration, n => n.AttributeLists, ( n, a ) => n.WithAttributeLists( a ) );

    public override SyntaxNode? VisitDelegateDeclaration( DelegateDeclarationSyntax node )
        => this.RewriteAttributes( node, base.VisitDelegateDeclaration, n => n.AttributeLists, ( n, a ) => n.WithAttributeLists( a ) );

    public override SyntaxNode? VisitFieldDeclaration( FieldDeclarationSyntax node )
        => this.RewriteAttributes(
            node,
            base.VisitFieldDeclaration,
            n => n.AttributeLists,
            ( n, a ) => n.WithAttributeLists( a ),
            f => f.Declaration.Variables[0] );

    public override SyntaxNode? VisitEventFieldDeclaration( EventFieldDeclarationSyntax node )
        => this.RewriteAttributes(
            node,
            base.VisitEventFieldDeclaration,
            n => n.AttributeLists,
            ( n, a ) => n.WithAttributeLists( a ),
            f => f.Declaration.Variables[0] );

    public override SyntaxNode? VisitEnumDeclaration( EnumDeclarationSyntax node )
        => this.RewriteAttributes( node, base.VisitEnumDeclaration, n => n.AttributeLists, ( n, a ) => n.WithAttributeLists( a ) );

    public override SyntaxNode? VisitEnumMemberDeclaration( EnumMemberDeclarationSyntax node )
        => this.RewriteAttributes( node, base.VisitEnumMemberDeclaration, n => n.AttributeLists, ( n, a ) => n.WithAttributeLists( a ) );
}