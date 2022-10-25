﻿using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public interface IStateStore
    {
        T Get<T>() where T : class;

        void Set<T>( T value ) where T : class;

        T GetOrAdd<T>( Func<T> getter );

        T GetOrNew<T>() where T : new();
    }
}