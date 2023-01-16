// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Equivalent to <see cref="IAspect{T}"/> where <c>T</c> is <see cref="IEvent"/>.
    /// </summary>
    public interface IEventLevelAspect : IAspect
    {
        /// <summary>
        /// In Metalama, add an initializer from the <see cref="IAspect{T}.BuildAspect"/>
        /// method using <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.<see cref="IAdviceFactory.AddInitializer(Metalama.Framework.Code.INamedType,string,InitializerKind,object?,object?)"/>.
        /// </summary>
        void RuntimeInitialize( EventInfo eventInfo );
    }
}