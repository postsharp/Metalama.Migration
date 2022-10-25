using System.Reflection;

namespace PostSharp.Aspects
{
    public interface IEventLevelAspect : IAspect
    {
        void RuntimeInitialize( EventInfo eventInfo );
    }
}