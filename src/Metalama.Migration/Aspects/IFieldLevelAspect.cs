using System.Reflection;

namespace PostSharp.Aspects
{
    public interface IFieldLevelAspect : IAspect
    {
        void RuntimeInitialize( FieldInfo field );
    }
}