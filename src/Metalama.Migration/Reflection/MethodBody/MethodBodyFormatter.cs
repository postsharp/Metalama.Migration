// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.IO;
using PostSharp.Collections;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Formats an <see cref="IMethodBodyElement"/> to a textual representation, for debugging purposes.
    /// </summary>
    public class MethodBodyFormatter : MethodBodyVisitor
    {
        private readonly IndentedTextWriter writer;

        /// <summary>
        /// Initializes a new <see cref="MethodBodyFormatter"/>.
        /// </summary>
        /// <param name="writer">A  <see cref="TextWriter"/> where the textual representation will be written.</param>
        public MethodBodyFormatter(TextWriter writer)
        {
            this.writer = writer as IndentedTextWriter ?? new IndentedTextWriter( writer );
        }

        /// <inheritdoc />
        public override object VisitBlockExpression( IBlockExpression instructionBlock )
        {
            int brackets = 0;

            if ( instructionBlock.ExceptionHandlers.First != null )
            {
                brackets ++;
                this.writer.WriteLine("try");
                this.writer.WriteLine("{");
                this.writer.Indent++;
            }

            switch ( instructionBlock.ExceptionHandlerKind )
            {
             
                case ExceptionHandlerKind.Catch:
                case ExceptionHandlerKind.Filter:
                    this.writer.WriteLine("filter");
                    if (instructionBlock.ParentExceptionHandler.ExceptionType != null)
                    {
                        this.writer.Write("( ");
                        this.writer.Write(instructionBlock.ParentExceptionHandler.ExceptionType);
                        this.writer.WriteLine(" )");
                    }
                    this.writer.WriteLine("{");
                    this.writer.Indent++;
                    break;

                case ExceptionHandlerKind.Finally:
                    brackets++;
                    this.writer.WriteLine("finally");
                    this.writer.WriteLine("{");
                    this.writer.Indent++;
                    break;
            }

          

            if ( instructionBlock.Label != null )
            {
                this.writer.Indent--;
                this.writer.Write( instructionBlock.Label );
                this.writer.WriteLine( ":" );
                this.writer.Indent++;
            }

            for ( ILinkedListNode<IExpression> expression = instructionBlock.Items.First; expression != null; expression = expression.Next )
            {
                this.VisitSyntaxElement( expression.Value );
                this.writer.WriteLine();
            }

            for ( int i = 0; i < brackets; i++ )
            {
                this.writer.Indent--;
                this.writer.WriteLine( "}" );
            }

     

            return null;
        }

        /// <inheritdoc />
        public override object VisitSwitchExpression( ISwitchExpression expression )
        {
            this.writer.Write( "switch ( " );
            this.VisitSyntaxElement( expression.Condition );
            this.writer.WriteLine( " )" );
            this.writer.WriteLine( "{" );
            this.writer.Indent++;

            for ( int i = 0; i < expression.Targets.Count; i++ )
            {
                IExpression target = expression.Targets[i];

                this.writer.Write("case ");
                this.writer.Write(i);
                this.writer.WriteLine(": ");
                this.writer.Indent++;
                this.VisitSyntaxElement(target);
                this.writer.Indent--;
                
            }
            this.writer.Indent--;
            this.writer.WriteLine( "}" );

            return null;
        }

        /// <inheritdoc />
        public override object VisitZeroaryExpression( IZeroaryExpression expression )
        {
            switch ( expression.MethodBodyElementKind )
            {
                case MethodBodyElementKind.This:
                    this.writer.Write( "this" );
                    break;

                case MethodBodyElementKind.ArgumentList:
                    this.writer.Write( "__arglist" );
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(expression));
            }

            return null;
        }

        /// <inheritdoc />
        public override object VisitParameterExpression( IParameterExpression expression )
        {
            this.writer.Write( expression.Parameter.Name );
            return null;
        }

        /// <inheritdoc />
        public override object VisitNewArrayExpression( INewArrayExpression expression )
        {
            this.writer.Write( "new " );
            this.writer.Write( expression.ElementType );
            this.writer.Write( "[" );
            this.VisitSyntaxElement( expression.Length );
            this.writer.Write( "]" );
            return null;
        }


        /// <inheritdoc />
        public override object VisitMethodCallExpression( IMethodCallExpression expression )
        {
            if ( expression.MethodBodyElementKind == MethodBodyElementKind.NewObject )
            {
                this.writer.Write( "new " );
            }

            if ( expression.Instance != null )
            {
                this.VisitSyntaxElement( expression.Instance );
            }
            else
            {
                this.writer.Write( expression.Method.DeclaringType );
            }

            if ( expression.MethodBodyElementKind != MethodBodyElementKind.NewObject )
            {
                this.writer.Write( "." );
                this.writer.Write( expression.Method.Name.Replace( '.', '#' ) );
            }
            this.writer.Write( "( " );

            bool needComma = false;

            foreach ( IExpression argument in expression.Arguments )
            {
                if ( needComma )
                {
                    this.writer.Write( ", " );
                }
                else
                {
                    needComma = true;
                }

                this.VisitSyntaxElement( argument );
            }

            if ( needComma )
                this.writer.Write( " )" );
            else
                this.writer.Write( ")" );

            return null;
        }

        /// <inheritdoc />
        public override object VisitMetadataExpression( IMetadataExpression expression )
        {
            switch ( expression.MethodBodyElementKind )
            {
                case MethodBodyElementKind.LoadToken:
                    this.writer.Write( "tokenof(" );
                    break;

                case MethodBodyElementKind.DefaultValue:
                    this.writer.Write( "default(" );
                    break;

                case MethodBodyElementKind.SizeOf:
                    this.writer.Write( "sizeof(" );
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(expression));
            }

            this.writer.Write( expression.Declaration );
            this.writer.Write( ")" );
            return null;
        }

        /// <inheritdoc />
        public override object VisitVariableExpression( ILocalVariableExpression expression )
        {
            this.writer.Write( expression.LocalVariable.Name ?? "__variable(" + expression.LocalVariable.Slot + ")" );
            return null;
        }

        /// <inheritdoc />
        public override object VisitInitBufferExpression( IInitBufferExpression expression )
        {
            this.writer.Write( "__init( " );
            this.VisitSyntaxElement( expression.Buffer );
            this.writer.Write( ", " );
            this.VisitSyntaxElement( expression.Length );
            this.writer.Write( ")" );

            return null;
        }

        /// <inheritdoc />
        public override object VisitGotoExpression( IGotoExpression expression )
        {
            this.writer.Write( "goto " );
            this.writer.Write( expression.Target.Label );
            this.writer.WriteLine();

            return null;
        }

        /// <inheritdoc />
        public override object VisitFieldExpression( IFieldExpression expression )
        {
            if ( expression.Instance != null )
            {
                this.VisitSyntaxElement( expression.Instance );
                this.writer.Write( "." );
            }
            else
            {
                this.writer.Write( expression.Field.DeclaringType );
                this.writer.Write( "::" );
            }


            this.writer.Write( expression.Field.Name );

            return null;
        }

        /// <inheritdoc />
        public override object VisitBinaryExpression( IBinaryExpression expression )
        {
            switch ( expression.MethodBodyElementKind )
            {
                case MethodBodyElementKind.Add:
                case MethodBodyElementKind.AddChecked:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " + " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.And:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " & " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.ArrayIndex:
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( "[" );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( "]" );
                    break;

                case MethodBodyElementKind.Assign:
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " = " );
                    this.VisitSyntaxElement( expression.Right );
                    break;

                case MethodBodyElementKind.Divide:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " / " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.LessThan:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " < " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.LessThanOrEqual:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " <= " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.Modulo:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " % " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.Multiply:
                case MethodBodyElementKind.MultiplyChecked:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " * " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;


                case MethodBodyElementKind.GreaterThan:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " > " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.GreaterThanOrEqual:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " >= " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.SubstractChecked:
                case MethodBodyElementKind.Substract:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " - " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.Equal:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " == " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.Different:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " - " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.Or:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " | " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.Xor:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " ^ " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.ShiftLeft:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " << " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.ShiftRight:
                    this.writer.Write( "( " );
                    this.VisitSyntaxElement( expression.Left );
                    this.writer.Write( " >> " );
                    this.VisitSyntaxElement( expression.Right );
                    this.writer.Write( " )" );
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(expression));
            }

            return null;
        }

        /// <inheritdoc />
        public override object VisitUnaryExpression( IUnaryExpression expression )
        {
            switch ( expression.MethodBodyElementKind )
            {
                case MethodBodyElementKind.ArrayLength:
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( ".Length" );
                    break;

                case MethodBodyElementKind.Cast:
                    this.writer.Write( "((" );
                    this.writer.Write( expression.ReturnType );
                    this.writer.Write( ") " );
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( ")" );
                    break;

                case MethodBodyElementKind.AddressOf:
                    this.writer.Write( "&" );
                    this.VisitSyntaxElement( expression.Value );
                    break;

                case MethodBodyElementKind.Not:
                    this.writer.Write( "!" );
                    this.VisitSyntaxElement( expression.Value );
                    break;

                case MethodBodyElementKind.ValueOf:
                    this.writer.Write( "*" );
                    this.VisitSyntaxElement( expression.Value );
                    break;

                case MethodBodyElementKind.Negate:
                    this.writer.Write( "-" );
                    this.VisitSyntaxElement( expression.Value );
                    break;

                case MethodBodyElementKind.SafeCast:
                    this.writer.Write( "(" );
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( " as " );
                    this.writer.Write( expression.ReturnType );
                    this.writer.Write( ")" );

                    break;

                case MethodBodyElementKind.Unbox:
                    this.writer.Write( "__unbox( " );
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.Throw:
                    this.writer.Write( "throw" );
                    if ( expression.Value != null )
                    {
                        this.writer.Write( " " );
                        this.VisitSyntaxElement( expression.Value );
                    }
                    break;

                case MethodBodyElementKind.Box:
                    this.writer.Write( "__box( " );
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( " )" );
                    break;

                case MethodBodyElementKind.TypedReferenceValue:
                    this.writer.Write( "__refvalue(" );
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( ")" );
                    break;

                case MethodBodyElementKind.CheckFinite:
                    this.writer.Write( "__checkfinite(" );
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( ")" );
                    break;

                case MethodBodyElementKind.MakeTypedReference:
                    this.writer.Write( "__refvalue(" );
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( ")" );
                    break;

                case MethodBodyElementKind.LocalAlloc:
                    this.writer.Write( "stackalloc byte[" );
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( "]" );
                    break;

                case MethodBodyElementKind.TypedReferenceType:
                    this.writer.Write( "__reftype(" );
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( ")" );
                    break;

                case MethodBodyElementKind.Return:
                    this.writer.Write( "return" );
                    if ( expression.Value != null )
                    {
                        this.writer.Write( " " );
                        this.VisitSyntaxElement( expression.Value );
                    }
                    break;

                case MethodBodyElementKind.Convert:
                    this.writer.Write( "((" );
                    this.writer.Write( expression.ReturnType );
                    this.writer.Write( ")" );
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( ")" );
                    break;

                case MethodBodyElementKind.ConvertChecked:
                    this.writer.Write( "__convert_checked(" );
                    this.writer.Write( expression.ReturnType );
                    this.writer.Write( ", " );
                    this.VisitSyntaxElement( expression.Value );
                    this.writer.Write( ")" );
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(expression));
            }

            return null;
        }

        /// <inheritdoc />
        public override object VisitConditionalExpression( IConditionalExpression expression )
        {
            this.writer.Write( "if ( " );
            this.VisitSyntaxElement( expression.Condition );
            this.writer.WriteLine( " )" );
            this.writer.WriteLine( "{" );
            if ( expression.IfTrue != null )
            {
                this.writer.Indent++;
                this.VisitSyntaxElement( expression.IfTrue );
                this.writer.Indent--;
            }
            this.writer.WriteLine( "}" );
            if ( expression.IfFalse != null )
            {
                this.writer.WriteLine( "else" );
                this.writer.WriteLine( "{" );
                this.writer.Indent++;
                this.VisitSyntaxElement( expression.IfFalse );
                this.writer.Indent--;

                this.writer.WriteLine( "}" );
            }

            return null;
        }

        /// <inheritdoc />
        public override object VisitConstantExpression( IConstantExpression expression )
        {
            if ( expression.Value == null )
            {
                this.writer.Write( "null" );
            }
            else
            {
                string str = expression.Value as string;
                if ( str != null )
                {
                    this.writer.Write( "\"" );
                    this.writer.Write( str );
                    this.writer.Write( "\"" );
                }
                else
                {
                    this.writer.Write( expression.Value );
                }
            }

            return null;
        }

        /// <inheritdoc />
        public override object VisitCopyBufferExpression( ICopyBufferExpression expression )
        {
            this.writer.Write( "__copy( " );
            this.VisitSyntaxElement( expression.Source );
            this.writer.Write( ", " );
            this.VisitSyntaxElement( expression.Destination );
            this.writer.Write( ", " );
            this.VisitSyntaxElement( expression.Length );
            this.writer.Write( " )" );

            return null;
        }
    }
}

