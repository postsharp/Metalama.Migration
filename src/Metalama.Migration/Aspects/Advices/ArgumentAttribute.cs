using Metalama.Framework.Aspects;
using Metalama.Framework.Code.Advised;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, run-time advice parameters are matched by name, not by index. If you need to get a parameter by index,
    /// use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Parameters"/><c>[index]</c>.<see cref="IAdvisedParameter.Value"/>.
    /// from the template.
    /// </summary>
    /// <seealso href="@template-parameters"/>
    public sealed class ArgumentAttribute : AdviceParameterAttribute
    {
        public int Index { get; }

        public ArgumentAttribute( int index )
        {
            Index = index;
        }
    }
}