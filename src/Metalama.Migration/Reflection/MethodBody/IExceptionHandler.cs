using System;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Represents an exception handler (either <c>catch</c>, <c>finally</c> or <c>filter</c>) attached to a block.
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// Gets the type of handled exception, or <c>null</c> if all exceptions are handled.
        /// </summary>
        Type ExceptionType { get; }

        /// <summary>
        /// Gets the <c>try</c> block.
        /// </summary>
        IBlockExpression TryBlock { get; }

        /// <summary>
        /// Gets the exception filtering block, or <c>null</c> if all exceptions are handled.
        /// </summary>
        IBlockExpression FilterBlock { get; }

        /// <summary>
        /// Gets the exception handling block.
        /// </summary>
        IBlockExpression HandlerBlock { get; }

        /// <summary>
        /// Gets the local variable containing the exception in the <see cref="HandlerBlock"/>.
        /// </summary>
        ILocalVariable HandlerLocalVariable { get; }

        /// <summary>
        /// Gets the local variable containing the exception in the <see cref="FilterBlock"/>.
        /// </summary>
        ILocalVariable FilterLocalVariable { get; }

        /// <summary>
        /// Gets the kind of exception handling clause.
        /// </summary>
        ExceptionHandlerKind ExceptionHandlerKind { get; }
    }
}