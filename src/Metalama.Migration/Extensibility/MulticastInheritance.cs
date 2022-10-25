// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use the <see cref="InheritedAttribute"/> custom attribute, but multicast inheritance must be implemented manually.
    /// </summary>
    public enum MulticastInheritance
    {
        /// <summary>
        /// This is still the default option.
        /// </summary>
        None,

        /// <summary>
        /// In Metalama, use the <see cref="InheritedAttribute"/> custom attribute.
        /// </summary>
        Strict,

        /// <summary>
        /// Multicast inheritance is not supported in Metalama, but it can be emulated by having the aspect implement
        /// <see cref="IAspect{T}"/> for <see cref="INamedType"/> and add the aspect to members.
        /// </summary>
        Multicast
    }
}