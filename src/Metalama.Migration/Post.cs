namespace PostSharp
{
    /// <summary>
    ///   Provides some methods that are transformed during post-compilation.
    /// </summary>
    public static class Post
    {
        /// <summary>
        ///   At post-compile time, casts an instance of a type into another.
        ///   A post-compile time error is reported if the source type cannot be
        ///   assigned to the target type.
        /// </summary>
        /// <typeparam name = "TSource">Source type.</typeparam>
        /// <typeparam name = "TTarget">Target type.</typeparam>
        /// <param name = "o">Instance to be casted.</param>
        /// <returns>The object <paramref name = "o" /> casted as <typeparamref name = "TTarget" />.</returns>
        /// <remarks>
        ///   The purpose of this method is to make a source code compilable even when
        ///   an interface will be implemented at post-compile time.
        ///   PostSharp ensures that <typeparamref name = "TTarget" /> is assignable from
        ///   <typeparamref name = "TSource" />. If yes, the call to this method is
        ///   simply suppressed. If types are not assignable, a build error is issued.
        /// </remarks>
        public static TTarget Cast<TSource, TTarget>( TSource o )
            where TSource : class
            where TTarget : class
        {
            return (TTarget)(object)o;
        }

        /// <summary>
        ///   Determines whether the calling program has been transformed by PostSharp. Calls to this property are replaced
        /// at build time.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the calling program has been transformed by PostSharp, otherwise
        ///   <c>false</c>.
        /// </value>
        public static bool IsTransformed { get; }

#pragma warning disable IDE0060, CA1801 // Remove unused parameter
        /// <summary>
        /// Gets a mutable reference from a read-only <c>in</c> reference. Calls to this method are replaced
        /// at build time. 
        /// </summary>
        /// <param name="reference">A read-only reference.</param>
        /// <typeparam name="T">Reference type.</typeparam>
        /// <returns>Exactly <paramref name="reference"/>.</returns>
        public static ref T GetMutableRef<T>( in T reference )
#pragma warning restore IDE0060, CA1801 // Remove unused parameter
        {
            // Dummy code to make things compile.
            return ref DefaultValue<T>.Value;
        }

        /// <summary>
        ///   When used to retrieve the value of a field, forces the compiler to retrieve a copy
        ///   of the field value instead of an address to this field. This allows to call
        ///   instance methods of value-type fields without loading the field address.
        /// </summary>
        /// <typeparam name = "T">Type of the value to retrieve (this type parameter can generally be omitted).</typeparam>
        /// <param name = "value">Value.</param>
        /// <returns><paramref name = "value" />, exactly.</returns>
        public static T GetValue<T>( T value ) where T : struct
        {
            return value;
        }

        private static class DefaultValue<T>
        {
            public static T Value;
        }
    }
}