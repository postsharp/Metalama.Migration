using System;
using System.Collections.Generic;

namespace PostSharp.Reflection
{
    public sealed class ReflectionTypeComparer : IEqualityComparer<Type>, IEqualityComparer<Type[]>
    {
        public static ReflectionTypeComparer GetInstance()
        {
            throw new NotImplementedException();
        }

        public static ReflectionTypeComparer GetInstance(
            Type[] leftGenericTypeParameters,
            Type[] leftGenericMethodParameters,
            Type[] rightGenericTypeParameters,
            Type[] rightGenericMethodParameters )
        {
            throw new NotImplementedException();
        }

        public bool Equals( Type x, Type y )
        {
            throw new NotImplementedException();
        }

        public int GetHashCode( Type obj )
        {
            throw new NotImplementedException();
        }

        #region IEqualityComparer<Type[]> Members

        public bool Equals( Type[] x, Type[] y )
        {
            throw new NotImplementedException();
        }

        public int GetHashCode( Type[] types )
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}