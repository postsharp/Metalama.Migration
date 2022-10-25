// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Collections;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Abstract implementation of a visitor of method bodies (<see cref="IMethodBody"/> and <see cref="IExpression"/>).
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class provides an abstract implementation, which only ensures that the proper visiting method
    ///         gets called for every node of the tree, without any other effect. Concrete implementations typically
    ///         override specific visiting methods, and call the base implementation to ensure that children nodes
    ///         are being processed too.
    ///     </para>
    /// </remarks>
    public abstract class MethodBodyVisitor
    {
        /// <summary>
        /// Visits a method body and, recursively, all syntax nodes.
        /// </summary>
        /// <param name="methodBody">The method body to be visited.</param>
        /// <returns><paramref name="methodBody"/>, unless the override returns something else.</returns>
        public virtual object VisitMethodBody( IMethodBody methodBody )
        {
            if ( methodBody.RootBlock != null )
            {
                this.VisitBlockExpression( methodBody.RootBlock );
            }
            return methodBody;
        }


        /// <summary>
        /// Visits an instruction block and, recursively, all syntax nodes.
        /// </summary>
        /// <param name="instructionBlock">The method body to be visited.</param>
        /// <returns><paramref name="instructionBlock"/>, unless the override returns something else.</returns>
        public virtual object VisitBlockExpression(IBlockExpression instructionBlock)
        {
            foreach ( IExpression instruction in LinkedListExtensions.ToEnumerable( instructionBlock.Items ) )
            {
                this.VisitSyntaxElement( instruction );
            }

            return instructionBlock;
        }



        /// <summary>
        /// Visits an instruction block and, recursively, all syntax nodes.
        /// </summary>
        /// <param name="statementExpression">The statement to be visited.</param>
        /// <returns><paramref name="statementExpression"/>, unless the override returns something else.</returns>
        public virtual object VisitStatementExpression( IStatementExpression statementExpression )
        {
            this.VisitSyntaxElement( statementExpression.Expression );

            return statementExpression;
        }



        /// <summary>
        /// Visits a syntax element and, recursively, all children elements.
        /// </summary>
        /// <param name="syntaxElement">The element to be visited.</param>
        /// <returns><paramref name="syntaxElement"/>, unless the override returns something else.</returns>
        public virtual object VisitSyntaxElement(IMethodBodyElement syntaxElement)
        {
            switch ( syntaxElement.MethodBodyElementKind )
            {
                case MethodBodyElementKind.Add:
                case MethodBodyElementKind.AddChecked:
                case MethodBodyElementKind.And:
                case MethodBodyElementKind.ArrayIndex:
                case MethodBodyElementKind.Assign:
                case MethodBodyElementKind.Divide:
                case MethodBodyElementKind.LessThan:
                case MethodBodyElementKind.LessThanOrEqual:
                case MethodBodyElementKind.Modulo:
                case MethodBodyElementKind.Multiply:
                case MethodBodyElementKind.MultiplyChecked:
                case MethodBodyElementKind.GreaterThan:
                case MethodBodyElementKind.GreaterThanOrEqual:
                case MethodBodyElementKind.SubstractChecked:
                case MethodBodyElementKind.Substract:
                case MethodBodyElementKind.Equal:
                case MethodBodyElementKind.Different:
                case MethodBodyElementKind.Or:
                case MethodBodyElementKind.Xor:
                case MethodBodyElementKind.ShiftLeft:
                case MethodBodyElementKind.ShiftRight:
                    return this.VisitBinaryExpression( (IBinaryExpression) syntaxElement );

                case MethodBodyElementKind.ValueOf:
                    return this.VisitValueOfExpression( (IValueOfExpression) syntaxElement );

                case MethodBodyElementKind.AddressOf:
                    return this.VisitAddressOfExpression( (IAddressOfExpression) syntaxElement );

                case MethodBodyElementKind.ArrayLength:
                case MethodBodyElementKind.Cast:

                case MethodBodyElementKind.Not:
                case MethodBodyElementKind.Negate:
                case MethodBodyElementKind.SafeCast:
                case MethodBodyElementKind.Unbox:
                case MethodBodyElementKind.Throw:
                case MethodBodyElementKind.Box:
                case MethodBodyElementKind.TypedReferenceValue:
                case MethodBodyElementKind.CheckFinite:
                case MethodBodyElementKind.MakeTypedReference:
                case MethodBodyElementKind.LocalAlloc:
                case MethodBodyElementKind.TypedReferenceType:
                case MethodBodyElementKind.Return:
                case MethodBodyElementKind.Convert:
                case MethodBodyElementKind.ConvertChecked:
                    return this.VisitUnaryExpression( (IUnaryExpression) syntaxElement );

                case MethodBodyElementKind.Constant:
                    return this.VisitConstantExpression( (IConstantExpression) syntaxElement );

                case MethodBodyElementKind.Conditional:
                    return this.VisitConditionalExpression( (IConditionalExpression) syntaxElement );

                case MethodBodyElementKind.CopyBuffer:
                    return this.VisitCopyBufferExpression( (ICopyBufferExpression) syntaxElement );

                case MethodBodyElementKind.Field:
                    return this.VisitFieldExpression( (IFieldExpression) syntaxElement );

                case MethodBodyElementKind.Goto:
                    return this.VisitGotoExpression( (IGotoExpression) syntaxElement );

                case MethodBodyElementKind.InitBuffer:
                    return this.VisitInitBufferExpression( (IInitBufferExpression) syntaxElement );

                case MethodBodyElementKind.Variable:
                    return this.VisitVariableExpression( (ILocalVariableExpression) syntaxElement );


                case MethodBodyElementKind.LoadToken:
                case MethodBodyElementKind.DefaultValue:
                case MethodBodyElementKind.SizeOf:
                    return this.VisitMetadataExpression( (IMetadataExpression) syntaxElement );

                case MethodBodyElementKind.MethodCall:
                    return this.VisitMethodCallExpression( (IMethodCallExpression) syntaxElement );

                case MethodBodyElementKind.NewObject:
                    return this.VisitNewObjectExpression( (INewObjectExpression) syntaxElement );

                case MethodBodyElementKind.MethodPointer:
                    return this.VisitMethodPointerExpression( (IMethodPointerExpression) syntaxElement );

                case MethodBodyElementKind.NewArray:
                    return this.VisitNewArrayExpression( (INewArrayExpression) syntaxElement );

                case MethodBodyElementKind.Parameter:
                    return this.VisitParameterExpression( (IParameterExpression) syntaxElement );

                case MethodBodyElementKind.ArgumentList:
                case MethodBodyElementKind.This:
                case MethodBodyElementKind.Rethrow:
                    return this.VisitZeroaryExpression( (IZeroaryExpression) syntaxElement );

                case MethodBodyElementKind.Switch:
                    return this.VisitSwitchExpression( (ISwitchExpression) syntaxElement );


                case MethodBodyElementKind.Block:
                    return this.VisitBlockExpression( (IBlockExpression) syntaxElement );

                case MethodBodyElementKind.Statement:
                    return this.VisitStatementExpression((IStatementExpression)syntaxElement);

                case MethodBodyElementKind.MethodBody:
                    return this.VisitMethodBody( (IMethodBody) syntaxElement );

                case MethodBodyElementKind.LocalVariableDefinition:
                    return this.VisitLocalVariable( (ILocalVariable) syntaxElement );


                default:
                    throw new ArgumentOutOfRangeException(nameof(syntaxElement));
            }
        }

        /// <summary>
        /// Visits an expression of type <see cref="IAddressOfExpression"/>  and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitAddressOfExpression( IAddressOfExpression expression )
        {
            this.VisitUnaryExpression( expression );
            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="IValueOfExpression"/>  and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitValueOfExpression(IValueOfExpression expression)
        {
            this.VisitUnaryExpression( expression );
            return expression;
        }

        /// <summary>
        /// Visits a local variable definition.
        /// </summary>
        /// <param name="localVariable">The local variable to be visited.</param>
        /// <returns><paramref name="localVariable"/>, unless the override returns something else.</returns>
        public virtual object VisitLocalVariable( ILocalVariable localVariable )
        {
            return localVariable;
        }


        /// <summary>
        /// Visits an expression of type <see cref="ISwitchExpression"/>  and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitSwitchExpression( ISwitchExpression expression )
        {
            this.VisitSyntaxElement( expression.Condition );
            foreach ( IExpression target in expression.Targets )
            {
                this.VisitSyntaxElement( target );
            }

            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="IZeroaryExpression"/>.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitZeroaryExpression( IZeroaryExpression expression )
        {
            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="IParameterExpression"/>.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitParameterExpression( IParameterExpression expression )
        {
            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="INewArrayExpression"/>  and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitNewArrayExpression( INewArrayExpression expression )
        {
            this.VisitSyntaxElement( expression.Length );
            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="IMethodPointerExpression"/>  and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitMethodPointerExpression( IMethodPointerExpression expression )
        {
            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="INewObjectExpression"/>  and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitNewObjectExpression( INewObjectExpression expression )
        {
            foreach ( IExpression argument in expression.Arguments )
            {
                this.VisitSyntaxElement( argument );
            }

            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="IMethodCallExpression"/>  and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitMethodCallExpression( IMethodCallExpression expression )
        {
            if ( expression.Instance != null )
                this.VisitSyntaxElement( expression.Instance );

            foreach ( IExpression argument in expression.Arguments )
            {
                this.VisitSyntaxElement( argument );
            }

            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="IMetadataExpression"/>.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitMetadataExpression( IMetadataExpression expression )
        {
            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="ILocalVariableExpression"/>.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitVariableExpression( ILocalVariableExpression expression )
        {
            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="IInitBufferExpression"/> and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitInitBufferExpression( IInitBufferExpression expression )
        {
            this.VisitSyntaxElement( expression.Buffer );
            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="IGotoExpression"/>.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        /// <returns><paramref name="expression"/>, unless the override returns something else.</returns>
        public virtual object VisitGotoExpression( IGotoExpression expression )
        {
            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="IFieldExpression"/>.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        public virtual object VisitFieldExpression( IFieldExpression expression )
        {
            if (expression.Instance != null)
                this.VisitSyntaxElement( expression.Instance );

            return expression;
        }

        
         /// <summary>
        /// Visits an expression of type <see cref="IBinaryExpression"/> and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        public virtual object VisitBinaryExpression( IBinaryExpression expression )
        {
            this.VisitSyntaxElement( expression.Left );
            this.VisitSyntaxElement( expression.Right );

            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="IUnaryExpression"/> and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        public virtual object VisitUnaryExpression( IUnaryExpression expression )
        {
            if (expression.Value != null)
            {
                this.VisitSyntaxElement(expression.Value);
            }

            return expression;
        }


        /// <summary>
        /// Visits an expression of type <see cref="IUnaryExpression"/> and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        public virtual object VisitConditionalExpression( IConditionalExpression expression )
        {
            this.VisitSyntaxElement( expression.Condition );

            if ( expression.IfTrue != null )
                this.VisitSyntaxElement( expression.IfTrue );

            if ( expression.IfFalse != null )
                this.VisitSyntaxElement( expression.IfFalse );

            return expression;
        }

        /// <summary>
        /// Visits an expression of type <see cref="IGotoExpression"/>.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        public virtual object VisitConstantExpression( IConstantExpression expression )
        {
            return expression;
        }


        /// <summary>
        /// Visits an expression of type <see cref="ICopyBufferExpression"/> and, recursively, all children elements.
        /// </summary>
        /// <param name="expression">The element to be visited.</param>
        public virtual object VisitCopyBufferExpression(ICopyBufferExpression expression)
        {
            this.VisitSyntaxElement( expression.Destination );
            this.VisitSyntaxElement( expression.Source );
            this.VisitSyntaxElement( expression.Length );

            return expression;
        }
    }
}
