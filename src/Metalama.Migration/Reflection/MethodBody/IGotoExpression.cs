namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Unconditional branching instruction.
    /// </summary>
    public interface IGotoExpression : IExpression
    {
        /// <summary>
        /// Instruction block that must receive control.
        /// </summary>
        IBlockExpression Target { get; }
    }
}