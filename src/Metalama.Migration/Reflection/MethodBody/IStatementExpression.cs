namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Represents a statement. A statement is the root of an expression tree.
    /// </summary>
    public interface IStatementExpression : IExpression
    {
        /// <summary>
        /// Gets a previous sibling of the current expression within <see cref="IBlockExpression" />.
        /// </summary>
        IStatementExpression PreviousSibling { get; }

        /// <summary>
        /// Gets a next sibling of the current expression within <see cref="IBlockExpression" />.
        /// </summary>
        IStatementExpression NextSibling { get; }

        /// <summary>
        /// Expression evaluated by the statement.
        /// </summary>
        IExpression Expression { get; }
    }
}