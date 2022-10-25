using System;
using System.Collections.Generic;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> and use the methods of the
    /// <see cref="IAdviceFactory"/> interface exposed on <see cref="IAspectBuilder{TAspectTarget}"/>.<see cref="IAspectBuilder.Advice"/>.
    /// </summary>
    /// <seealso href="@advising-concepts"/>
    [Obsolete( "Override IAspect.BuildAspect and add advice using the builder.Advice object." )]
    public interface IAdviceProvider : IAspect
    {
        IEnumerable<AdviceInstance> ProvideAdvices( object targetElement );
    }
}