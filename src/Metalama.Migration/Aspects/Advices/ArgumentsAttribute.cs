using Metalama.Framework.Aspects;
using Metalama.Framework.Code.Advised;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, do not use a parameter but use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Parameters"/>.<see cref="IAdvisedParameterList.Values"/>.<see cref="IAdviseParameterValueList.ToArray"/>
    /// from the template implementation.
    /// </summary>
    /// <seealso href="@template-parameters"/>
    public sealed class ArgumentsAttribute : AdviceParameterAttribute { }
}