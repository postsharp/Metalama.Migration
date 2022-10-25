namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Defines the signature of methods implementing the <see cref = "Property{TValue}.Set" />
    ///   semantic of a parameterless property.
    /// </summary>
    /// <typeparam name = "TValue">Property value type.</typeparam>
    /// <param name = "value">The property value.</param>
    /// <seealso cref = "Property{TValue}" />
    public delegate void PropertySetter<TValue>( TValue value );
}