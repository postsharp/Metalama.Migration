using System.Collections.Generic;
using PostSharp.Collections;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@services"/>
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