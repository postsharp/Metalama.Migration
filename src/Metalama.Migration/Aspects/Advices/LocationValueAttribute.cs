namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In a template applied to a field or property, the field or property value can be represented as a parameter named <c>value</c>. The type of this parameter must be <c>dynamic</c>
    /// or be compatible with the field or property type.
    /// </summary>
    public sealed class LocationValueAttribute : AdviceParameterAttribute { }
}