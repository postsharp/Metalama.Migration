// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Collections.Generic;
using PostSharp.Collections;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Block containing other blocks or instructions.
    /// </summary>
    /// <remarks>
    /// <para>A block typically contains other blocks or instructions. Blocks that contain instructions also implement the <see cref="ISequenceExpression"/> interface. </para>
    /// </remarks>
    public interface IBlockExpression : IExpression
    {
        /// <summary>
        /// Gets a string that uniquely identifies the block (inside the current method body) as a possible branching target.
        /// </summary>
        string Label { get; }

        /// <summary>
        /// Gets the kind of exception handler of the current block (<see cref="ExceptionHandlerKind.Catch"/>, <see cref="ExceptionHandlerKind.None"/>
        /// or <see cref="ExceptionHandlerKind.Finally"/>), or <see cref="ExceptionHandlerKind.None"/> if the current block is not an exception handler.
        /// </summary>
        ExceptionHandlerKind ExceptionHandlerKind { get; }

        /// <summary>
        /// Gets the parent exception handler in the current block is in the <see cref="ExceptionHandlerKind.Catch"/>, <see cref="ExceptionHandlerKind.Filter"/> or <see cref="ExceptionHandlerKind.Finally"/> role.
        /// </summary>
        IExceptionHandler ParentExceptionHandler { get; }

        /// <summary>
        /// Gets the collection of items in the block.
        /// </summary>
        IReadOnlyLinkedList<IExpression> Items { get; }

        /// <summary>
        /// Gets the collection of exception handlers that protect the block, in which the current block is in the <c>try</c> role.
        /// </summary>
        IReadOnlyLinkedList<IExceptionHandler> ExceptionHandlers { get; }
        
        /// <summary>
        /// Gets the collection of local variables defined for the current block.
        /// </summary>
        IList<ILocalVariable> LocalVariables { get; }
    }

    /// <summary>
    /// Kinds of <see cref="IExceptionHandler"/>.
    /// </summary>
    public enum ExceptionHandlerKind
    {
        /// <summary>
        /// Not an exception handler.
        /// </summary>
        None,

        /// <summary>
        /// Catch without filter.
        /// </summary>
        Catch,

        /// <summary>
        /// Filter with catch block.
        /// </summary>
        Filter,

        /// <summary>
        /// Finally.
        /// </summary>
        Finally
    }
}
