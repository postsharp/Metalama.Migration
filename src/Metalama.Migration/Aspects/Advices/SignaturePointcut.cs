// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
#pragma warning disable CA1710 // Identifiers should have correct suffix

using System;

#pragma warning disable CS3015 // Type has no accessible constructors which use only CLS-compliant types

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// A <see cref="Pointcut"/> that matches target methods by name and signature.
    /// This works only with non-generic methods.
    /// </summary>
    public sealed class SignaturePointcut : Pointcut
    {
        /// <summary>
        /// Initializes a new <see cref="SignaturePointcut"/>.
        /// </summary>
        /// <param name="name">The name of the target method.</param>
        /// <param name="parameterTypes">The exact type of parameters of this method.</param>
        public SignaturePointcut(string name, params Type[] parameterTypes)
        {
            this.Name = name;
            this.ArgumentTypes = parameterTypes;
        }

        /// <summary>
        /// Gets the name of the target method.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the exact types of parameters of the target method.
        /// </summary>
        public Type[] ArgumentTypes { get; private set; }
    }
}
