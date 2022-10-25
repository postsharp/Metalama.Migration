namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that returns the value stored at an address. Equivalent to the C# keyword <c>*</c>.
    /// </summary>
    public interface IValueOfExpression : IUnaryExpression
    {
        /// <summary>
        /// Determines whether if the location at the address is volatile, i.e. if it can be changed
        /// by a different thread than the current one.
        /// </summary>
        bool IsVolatile { get; }

        /// <summary>
        /// Gets the alignment of the value at the address.
        /// </summary>
        AddressAlignment Alignment { get; }
    }
}