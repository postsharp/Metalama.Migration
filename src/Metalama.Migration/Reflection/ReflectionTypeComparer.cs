using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Comparer of reflection types (<see cref = "Type" />) based on content, not reference.
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public sealed class ReflectionTypeComparer : IEqualityComparer<Type>, IEqualityComparer<Type[]>
    {
        /// <summary>
        ///   Gets an instance of <see cref = "ReflectionTypeComparer" /> that does not perform
        ///   substitution of generic parameters.
        /// </summary>
        /// <returns>An instance of <see cref = "ReflectionTypeComparer" />.</returns>
        public static ReflectionTypeComparer GetInstance()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Gets an instance of <see cref = "ReflectionTypeComparer" /> that performs
        ///   substitution of generic parameters.
        /// </summary>
        /// <param name = "leftGenericMethodParameters">Array of types to be substituted to the
        ///   generic method parameters of the left member.</param>
        /// <param name = "leftGenericTypeParameters">Array of types to be substituted to the
        ///   generic type parameters of the left member.</param>
        /// <param name = "rightGenericMethodParameters">Array of types to be substituted to the
        ///   generic method parameters of the right member.</param>
        /// <param name = "rightGenericTypeParameters">Array of types to be substituted to the
        ///   generic type parameters of the right member.</param>
        /// <returns>An instance of <see cref = "ReflectionTypeComparer" />.</returns>
        public static ReflectionTypeComparer GetInstance(
            Type[] leftGenericTypeParameters,
            Type[] leftGenericMethodParameters,
            Type[] rightGenericTypeParameters,
            Type[] rightGenericMethodParameters )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Equals( Type x, Type y )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int GetHashCode( Type obj )
        {
            throw new NotImplementedException();
        }

        #region IEqualityComparer<Type[]> Members

        /// <inheritdoc />
        public bool Equals( Type[] x, Type[] y )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public int GetHashCode( Type[] types )
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}