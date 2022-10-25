namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Defines the signature of methods implementing the <see cref = "Property{TValue}.Get" />
    ///   semantic of a parameterless property.
    /// </summary>
    /// <typeparam name = "TValue">Property value type.</typeparam>
    /// <returns>The property value.</returns>
    /// <seealso cref = "Property{TValue}" />
    public delegate TValue PropertyGetter<TValue>();
}