using PostSharp.Collections;

namespace PostSharp.Reflection.MethodBody
{
    public interface ISequenceExpression : IBlockExpression
    {
        ReadOnlySinglyLinkedList<ISequenceExpression> Predecessors { get; }

        ReadOnlySinglyLinkedList<ISequenceExpression> Successors { get; }

        ReadOnlySinglyLinkedList<LocalVariableAssignment> LocalVariableAssignments { get; }
    }
}