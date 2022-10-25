using System;

namespace PostSharp.Extensibility
{
    public interface IReflectionBindingManagerService : IService
    {
        string ResolveAssembly( Type type );
    }
}