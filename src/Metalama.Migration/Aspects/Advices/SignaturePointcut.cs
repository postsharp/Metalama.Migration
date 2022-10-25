#pragma warning disable CA1710 // Identifiers should have correct suffix

using System;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

#pragma warning disable CS3015 // Type has no accessible constructors which use only CLS-compliant types

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use a <c>foreach</c> loop in the <see cref="Metalama.Framework.Aspects.IAspect{T}.BuildAspect"/> method, iterate the code model exposed on <c>builder</c>.<see cref="IAspectBuilder.Target"/><see cref="INamedType.Methods"/>, and add advice using methods of <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.
    /// </summary>
    public sealed class SignaturePointcut : Pointcut
    {
        public SignaturePointcut( string name, params Type[] parameterTypes )
        {
            Name = name;
            ArgumentTypes = parameterTypes;
        }

        public string Name { get; }

        public Type[] ArgumentTypes { get; }
    }
}