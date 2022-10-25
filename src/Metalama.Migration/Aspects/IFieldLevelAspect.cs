using System.Reflection;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using PostSharp.Aspects.Advices;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Equivalent to <see cref="IAspect{T}"/> where <c>T</c> is <see cref="IField"/>.
    /// </summary>
    public interface IFieldLevelAspect : IAspect
    {
        /// <summary>
        /// In Metalama, add an initializer from the <see cref="Metalama.Framework.Aspects.IAspect{T}.BuildAspect"/> method by calling
        /// <c>builder</c>.<see cref="Advice"/>.<see cref="IAdviceFactory.AddInitializer(Metalama.Framework.Code.INamedType,string,Metalama.Framework.Aspects.InitializerKind,object?,object?)"/>.
        /// </summary>
        /// <seealso href="@initializers"/>
        void RuntimeInitialize( FieldInfo field );
    }
}