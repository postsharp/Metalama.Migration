using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    public interface ILocationLevelAspect : IAspect
    {
        void RuntimeInitialize( LocationInfo locationInfo );
    }
}