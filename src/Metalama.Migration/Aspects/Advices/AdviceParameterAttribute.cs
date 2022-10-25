using System;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, there is no declarative way to bind advice parameters. Instead, Metalama uses a programmatic approach, where the advice can get the desired
    /// value using the code model. In Metalama, template parameters can be marked as compile-time using <see cref="CompileTimeAttribute"/>, otherwise they are run-time.
    /// Run-time parameters must match the target parameter by name. Compile-time parameters must be supplied by the advice factory method (see <see cref="IAdviceFactory"/>).
    /// </summary>
    /// <seealso href="@template-parameters"/>
    [AttributeUsage( AttributeTargets.Parameter )]
    public abstract class AdviceParameterAttribute : Attribute { }
}