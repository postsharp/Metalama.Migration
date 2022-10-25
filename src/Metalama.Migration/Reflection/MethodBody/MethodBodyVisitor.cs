using System;
using PostSharp.Collections;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@services"/>
    [Obsolete( "", true )]
    public abstract class MethodBodyVisitor
    {
        public virtual object VisitMethodBody( IMethodBody methodBody )
        {
            if (methodBody.RootBlock != null)
            {
                VisitBlockExpression( methodBody.RootBlock );
            }

            return methodBody;
        }

        public virtual object VisitBlockExpression( IBlockExpression instructionBlock )
        {
            foreach (var instruction in LinkedListExtensions.ToEnumerable( instructionBlock.Items ))
            {
                VisitSyntaxElement( instruction );
            }

            return instructionBlock;
        }

        public virtual object VisitStatementExpression( IStatementExpression statementExpression )
        {
            VisitSyntaxElement( statementExpression.Expression );

            return statementExpression;
        }

        public virtual object VisitSyntaxElement( IMethodBodyElement syntaxElement )
        {
            switch (syntaxElement.MethodBodyElementKind)
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
                    return VisitBinaryExpression( (IBinaryExpression)syntaxElement );

                case MethodBodyElementKind.ValueOf:
                    return VisitValueOfExpression( (IValueOfExpression)syntaxElement );

                case MethodBodyElementKind.AddressOf:
                    return VisitAddressOfExpression( (IAddressOfExpression)syntaxElement );

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
                    return VisitUnaryExpression( (IUnaryExpression)syntaxElement );

                case MethodBodyElementKind.Constant:
                    return VisitConstantExpression( (IConstantExpression)syntaxElement );

                case MethodBodyElementKind.Conditional:
                    return VisitConditionalExpression( (IConditionalExpression)syntaxElement );

                case MethodBodyElementKind.CopyBuffer:
                    return VisitCopyBufferExpression( (ICopyBufferExpression)syntaxElement );

                case MethodBodyElementKind.Field:
                    return VisitFieldExpression( (IFieldExpression)syntaxElement );

                case MethodBodyElementKind.Goto:
                    return VisitGotoExpression( (IGotoExpression)syntaxElement );

                case MethodBodyElementKind.InitBuffer:
                    return VisitInitBufferExpression( (IInitBufferExpression)syntaxElement );

                case MethodBodyElementKind.Variable:
                    return VisitVariableExpression( (ILocalVariableExpression)syntaxElement );

                case MethodBodyElementKind.LoadToken:
                case MethodBodyElementKind.DefaultValue:
                case MethodBodyElementKind.SizeOf:
                    return VisitMetadataExpression( (IMetadataExpression)syntaxElement );

                case MethodBodyElementKind.MethodCall:
                    return VisitMethodCallExpression( (IMethodCallExpression)syntaxElement );

                case MethodBodyElementKind.NewObject:
                    return VisitNewObjectExpression( (INewObjectExpression)syntaxElement );

                case MethodBodyElementKind.MethodPointer:
                    return VisitMethodPointerExpression( (IMethodPointerExpression)syntaxElement );

                case MethodBodyElementKind.NewArray:
                    return VisitNewArrayExpression( (INewArrayExpression)syntaxElement );

                case MethodBodyElementKind.Parameter:
                    return VisitParameterExpression( (IParameterExpression)syntaxElement );

                case MethodBodyElementKind.ArgumentList:
                case MethodBodyElementKind.This:
                case MethodBodyElementKind.Rethrow:
                    return VisitZeroaryExpression( (IZeroaryExpression)syntaxElement );

                case MethodBodyElementKind.Switch:
                    return VisitSwitchExpression( (ISwitchExpression)syntaxElement );

                case MethodBodyElementKind.Block:
                    return VisitBlockExpression( (IBlockExpression)syntaxElement );

                case MethodBodyElementKind.Statement:
                    return VisitStatementExpression( (IStatementExpression)syntaxElement );

                case MethodBodyElementKind.MethodBody:
                    return VisitMethodBody( (IMethodBody)syntaxElement );

                case MethodBodyElementKind.LocalVariableDefinition:
                    return VisitLocalVariable( (ILocalVariable)syntaxElement );

                default:
                    throw new ArgumentOutOfRangeException( nameof(syntaxElement) );
            }
        }

        public virtual object VisitAddressOfExpression( IAddressOfExpression expression )
        {
            VisitUnaryExpression( expression );

            return expression;
        }

        public virtual object VisitValueOfExpression( IValueOfExpression expression )
        {
            VisitUnaryExpression( expression );

            return expression;
        }

        public virtual object VisitLocalVariable( ILocalVariable localVariable )
        {
            return localVariable;
        }

        public virtual object VisitSwitchExpression( ISwitchExpression expression )
        {
            VisitSyntaxElement( expression.Condition );

            foreach (var target in expression.Targets)
            {
                VisitSyntaxElement( target );
            }

            return expression;
        }

        public virtual object VisitZeroaryExpression( IZeroaryExpression expression )
        {
            return expression;
        }

        public virtual object VisitParameterExpression( IParameterExpression expression )
        {
            return expression;
        }

        public virtual object VisitNewArrayExpression( INewArrayExpression expression )
        {
            VisitSyntaxElement( expression.Length );

            return expression;
        }

        public virtual object VisitMethodPointerExpression( IMethodPointerExpression expression )
        {
            return expression;
        }

        public virtual object VisitNewObjectExpression( INewObjectExpression expression )
        {
            foreach (var argument in expression.Arguments)
            {
                VisitSyntaxElement( argument );
            }

            return expression;
        }

        public virtual object VisitMethodCallExpression( IMethodCallExpression expression )
        {
            if (expression.Instance != null)
            {
                VisitSyntaxElement( expression.Instance );
            }

            foreach (var argument in expression.Arguments)
            {
                VisitSyntaxElement( argument );
            }

            return expression;
        }

        public virtual object VisitMetadataExpression( IMetadataExpression expression )
        {
            return expression;
        }

        public virtual object VisitVariableExpression( ILocalVariableExpression expression )
        {
            return expression;
        }

        public virtual object VisitInitBufferExpression( IInitBufferExpression expression )
        {
            VisitSyntaxElement( expression.Buffer );

            return expression;
        }

        public virtual object VisitGotoExpression( IGotoExpression expression )
        {
            return expression;
        }

        public virtual object VisitFieldExpression( IFieldExpression expression )
        {
            if (expression.Instance != null)
            {
                VisitSyntaxElement( expression.Instance );
            }

            return expression;
        }

        public virtual object VisitBinaryExpression( IBinaryExpression expression )
        {
            VisitSyntaxElement( expression.Left );
            VisitSyntaxElement( expression.Right );

            return expression;
        }

        public virtual object VisitUnaryExpression( IUnaryExpression expression )
        {
            if (expression.Value != null)
            {
                VisitSyntaxElement( expression.Value );
            }

            return expression;
        }

        public virtual object VisitConditionalExpression( IConditionalExpression expression )
        {
            VisitSyntaxElement( expression.Condition );

            if (expression.IfTrue != null)
            {
                VisitSyntaxElement( expression.IfTrue );
            }

            if (expression.IfFalse != null)
            {
                VisitSyntaxElement( expression.IfFalse );
            }

            return expression;
        }

        public virtual object VisitConstantExpression( IConstantExpression expression )
        {
            return expression;
        }

        public virtual object VisitCopyBufferExpression( ICopyBufferExpression expression )
        {
            VisitSyntaxElement( expression.Destination );
            VisitSyntaxElement( expression.Source );
            VisitSyntaxElement( expression.Length );

            return expression;
        }
    }
}