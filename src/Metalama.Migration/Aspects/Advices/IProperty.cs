namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// A weakly-typed interface for the <seealso cref="Property{TValue}"/> class.
    /// </summary>
    public interface IProperty
    {
        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <returns>The property value.</returns>
        object GetValue();

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="value">The new property value.</param>
        void SetValue( object value );
    }
}