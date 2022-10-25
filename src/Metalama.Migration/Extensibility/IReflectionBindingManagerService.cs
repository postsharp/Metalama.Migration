using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public interface IReflectionBindingManagerService : IService
    {
        string ResolveAssembly( Type type );
    }
}