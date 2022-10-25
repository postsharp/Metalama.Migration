namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Represents an expression with a single operand.
    /// </summary>
    public interface IUnaryExpression : IExpression
    {
        /// <summary>
        /// Operand of the unary expression.
        /// </summary>
        IExpression Value { get; }
    }
}