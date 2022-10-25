using System;

namespace PostSharp.Extensibility
{
    public interface IStateStore
    {
        T Get<T>() where T : class;

        void Set<T>( T value ) where T : class;

        T GetOrAdd<T>( Func<T> getter );

        T GetOrNew<T>() where T : new();
    }
}