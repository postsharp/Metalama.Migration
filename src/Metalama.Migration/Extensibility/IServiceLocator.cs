using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="IServiceProvider"/>.
    /// </summary>
    public interface IServiceLocator : IService
    {
        T GetService<T>( bool throwing = true ) where T : class, IService;
    }
}