// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Collections;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@services"/>
    public interface ISequenceExpression : IBlockExpression
    {
        ReadOnlySinglyLinkedList<ISequenceExpression> Predecessors { get; }

        ReadOnlySinglyLinkedList<ISequenceExpression> Successors { get; }

        ReadOnlySinglyLinkedList<LocalVariableAssignment> LocalVariableAssignments { get; }
    }
}