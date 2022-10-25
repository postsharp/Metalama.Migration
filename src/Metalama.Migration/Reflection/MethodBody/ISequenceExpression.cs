using PostSharp.Collections;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Sequence of instructions.
    /// </summary>
    public interface ISequenceExpression : IBlockExpression
    {
        /// <summary>
        /// Gets the list of sequences that can branch to the current sequence.
        /// </summary>
        ReadOnlySinglyLinkedList<ISequenceExpression> Predecessors { get; }

        /// <summary>
        /// Gets the list of sequences to which the current sequence branch.
        /// </summary>
        ReadOnlySinglyLinkedList<ISequenceExpression> Successors { get; }

        /// <summary>
        /// Gets the list of local variables that the current sequence assigns, and the value to which the local variable is assigned when the current sequence
        /// is fully executed.
        /// </summary>
        ReadOnlySinglyLinkedList<LocalVariableAssignment> LocalVariableAssignments { get; }
    }
}