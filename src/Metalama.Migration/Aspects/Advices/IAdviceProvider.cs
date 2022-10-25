using System.Collections.Generic;

namespace PostSharp.Aspects.Advices
{
    public interface IAdviceProvider : IAspect
    {
        IEnumerable<AdviceInstance> ProvideAdvices( object targetElement );
    }
}