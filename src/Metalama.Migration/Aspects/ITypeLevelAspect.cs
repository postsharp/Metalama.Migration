using System;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Equivalent to <see cref="IAspect{T}"/> where <c>T</c> is <see cref="INamedType"/>.
    /// </summary>
    public interface ITypeLevelAspect : IAspect
    {
        /// <summary>
        /// In Metalama, add an initializer from the <see cref="TypeAspect.BuildAspect"/> method by calling
        /// <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.<see cref="IAdviceFactory.AddInitializer(Metalama.Framework.Code.INamedType,string,Metalama.Framework.Aspects.InitializerKind,object?,object?)"/>.
        /// </summary>
        /// <seealso href="@initializers"/>
        void RuntimeInitialize( Type type );
    }
}