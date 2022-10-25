using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// A context that provides storage for arbitrary items.
    /// </summary>
    public interface IStateStore
    {
        /// <summary>
        /// Gets a value of a given type from the store.
        /// </summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <returns>The value whose type is <typeparamref name="T"/>, or <c>null</c> if the store
        /// does not contain such value.</returns>
        T Get<T>() where T : class;

        /// <summary>
        /// Adds a value to the store or replace it if a value of the same type already exists.
        /// </summary>
        /// <typeparam name="T">Type of the new value.</typeparam>
        /// <param name="value">The new value.</param>
        void Set<T>( T value ) where T : class;

        /// <summary>
        /// Gets a value from the cache or adds it if it does not exist yet.
        /// </summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <param name="getter">The delegate invoked if no value of type <typeparamref name="T"/> is
        /// present in the cache.</param>
        /// <returns>Either the value of type <typeparamref name="T"/> present in the cache,
        /// either the result of the <paramref name="getter"/> delegate.</returns>
        T GetOrAdd<T>( Func<T> getter );

        /// <summary>
        /// Gets a value from the cache or adds a default value if it does not exist yet.
        /// </summary>
        /// <typeparam name="T">Type of value.</typeparam>
        /// <returns>Either the value of type <typeparamref name="T"/> present in the cache,
        /// either a new object of type <typeparamref name="T"/>.</returns>
        T GetOrNew<T>() where T : new();
    }
}