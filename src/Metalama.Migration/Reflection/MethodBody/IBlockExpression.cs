using System.Collections.Generic;
using PostSharp.Collections;

namespace PostSharp.Reflection.MethodBody
{
    public interface IBlockExpression : IExpression
    {
        string Label { get; }

        ExceptionHandlerKind ExceptionHandlerKind { get; }

        IExceptionHandler ParentExceptionHandler { get; }

        IReadOnlyLinkedList<IExpression> Items { get; }

        IReadOnlyLinkedList<IExceptionHandler> ExceptionHandlers { get; }

        IList<ILocalVariable> LocalVariables { get; }
    }

    public enum ExceptionHandlerKind
    {
        None,

        Catch,

        Filter,

        Finally
    }
}