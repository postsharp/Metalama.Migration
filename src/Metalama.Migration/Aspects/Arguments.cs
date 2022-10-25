using System;
using System.Collections;
using System.Collections.Generic;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code.Advised;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Parameters"/>.<see cref="IAdvisedParameterList.Values"/>.
    /// </summary>
    public class Arguments : IList<object>, ICloneable

    {
        public static readonly Arguments Empty = new();

        public int Count { get; }

        public virtual object GetArgument( int index )
        {
            throw new ArgumentOutOfRangeException( nameof(index) );
        }

        public object this[ int index ]
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public virtual void SetArgument( int index, object value )
        {
            throw new ArgumentOutOfRangeException( nameof(index) );
        }

        public virtual void CopyFrom( object[] array, int index ) { }

        public virtual void CopyTo( object[] array, int index ) { }

        public object[] ToArray()
        {
            var array = new object[Count];
            CopyTo( array, 0 );

            return array;
        }

        public Arguments Clone()
        {
            return (Arguments)MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public static Arguments Create<T>( T arg0 )
        {
            throw new NotImplementedException();
        }

        public static Arguments Create<T0, T1>( T0 arg0, T1 arg1 )
        {
            throw new NotImplementedException();
        }

        public static Arguments Create<T0, T1, T2>( T0 arg0, T1 arg1, T2 arg2 )
        {
            throw new NotImplementedException();
        }

        public static Arguments Create<T0, T1, T2, T3>( T0 arg0, T1 arg1, T2 arg2, T3 arg3 )
        {
            throw new NotImplementedException();
        }

        public static Arguments Create<T0, T1, T2, T3, T4>( T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4 )
        {
            throw new NotImplementedException();
        }

        public static Arguments Create<T0, T1, T2, T3, T4, T5>( T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 args5 )
        {
            throw new NotImplementedException();
        }

        public static Arguments Create<T0, T1, T2, T3, T4, T5, T6>( T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 args5, T6 args6 )
        {
            throw new NotImplementedException();
        }

        public static Arguments Create<T0, T1, T2, T3, T4, T5, T6, T7>( T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 args5, T6 args6, T7 args7 )
        {
            throw new NotImplementedException();
        }

        public static Arguments Create( params object[] array )
        {
            throw new NotImplementedException();
        }

        #region Implementation of IEnumerable

        public IEnumerator<object> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IList

        bool ICollection<object>.IsReadOnly { get; }

        bool ICollection<object>.Remove( object item )
        {
            throw new NotImplementedException();
        }

        int IList<object>.IndexOf( object item )
        {
            throw new NotImplementedException();
        }

        void IList<object>.Insert( int index, object item )
        {
            throw new NotSupportedException();
        }

        void IList<object>.RemoveAt( int index )
        {
            throw new NotSupportedException();
        }

        void ICollection<object>.Add( object item )
        {
            throw new NotSupportedException();
        }

        void ICollection<object>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<object>.Contains( object item )
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}