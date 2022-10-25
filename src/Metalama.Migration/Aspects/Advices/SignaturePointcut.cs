#pragma warning disable CA1710 // Identifiers should have correct suffix

using System;

#pragma warning disable CS3015 // Type has no accessible constructors which use only CLS-compliant types

namespace PostSharp.Aspects.Advices
{
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