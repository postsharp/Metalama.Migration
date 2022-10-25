using PostSharp.Constraints;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that has two operands, <see cref="Left"/> and <see cref="Right"/>.
    /// </summary>
    [Experimental]
    public interface IBinaryExpression : IExpression
    {
        /// <summary>
        /// Gets the left operand.
        /// </summary>
        IExpression Left { get; }

        /// <summary>
        /// Gets the right operand.
        /// </summary>
        IExpression Right { get; }
    }
}