using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Not supported in Metalama because aspects no longer have a run-time existence. Instead, they only exist at compile time,
    /// and generate run-time code.
    /// </summary>
    public interface IInstanceScopedAspect : IAspect
    {
        /// <summary>
        /// No equivelent in Metalama.
        /// </summary>
        object CreateInstance( AdviceArgs adviceArgs );

        /// <summary>
        /// Typically, add an initializer using <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.<see cref="IAdviceFactory.AddInitializer(Metalama.Framework.Code.INamedType,string,Metalama.Framework.Aspects.InitializerKind,object?,object?)"/>.
        /// </summary>
        void RuntimeInitializeInstance();
    }
}