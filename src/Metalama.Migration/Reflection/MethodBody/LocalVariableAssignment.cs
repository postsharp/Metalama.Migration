namespace PostSharp.Reflection.MethodBody
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// Represents the assignment of a local variable to an expression.
    /// </summary>
    public struct LocalVariableAssignment
    {
        /// <summary>
        /// Gets the local variable being assigned.
        /// </summary>
        public ILocalVariable LocalVariable { get; }

        /// <summary>
        /// Gets the expression to which the local variable is being assigned.
        /// </summary>
        public IExpression Expression { get; }
    }
}