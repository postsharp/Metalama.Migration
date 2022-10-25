namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression representing a build-time constant.
    /// </summary>
    public interface IConstantExpression : IExpression
    {
        /// <summary>
        /// Gets the constant value.
        /// </summary>
        object Value { get; }
    }
}