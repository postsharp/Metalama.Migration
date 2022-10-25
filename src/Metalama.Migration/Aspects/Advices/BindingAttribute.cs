using Metalama.Framework.Code;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Bindings do not exist in Metalama. Instead, use invokers (e.g. <see cref="IMethod"/>.<see cref="IMethod.Invokers"/>) to generate run-time
    /// code that invokes the desired method or accesses the property or event.
    /// </summary>
    public sealed class BindingAttribute : AdviceParameterAttribute { }
}