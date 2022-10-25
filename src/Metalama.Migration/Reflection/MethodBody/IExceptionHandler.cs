using System;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@services"/>
    public interface IExceptionHandler
    {
        Type ExceptionType { get; }

        IBlockExpression TryBlock { get; }

        IBlockExpression FilterBlock { get; }

        IBlockExpression HandlerBlock { get; }

        ILocalVariable HandlerLocalVariable { get; }

        ILocalVariable FilterLocalVariable { get; }

        ExceptionHandlerKind ExceptionHandlerKind { get; }
    }
}