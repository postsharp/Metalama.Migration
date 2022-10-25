// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using PostSharp.Aspects.Internals;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Encapsulation of method arguments.
    /// </summary>
    /// <remarks>
    ///   <note>
    ///     As a result of optimizations, an <see cref = "Arguments" /> object may be shared between different 
    ///     advices. If an advice implementation needs to access an <see cref = "Arguments" /> object after it has given over
    ///     control, it should take a reference to a clone instead of the initial object itself.
    ///   </note>
    ///   <note>
    ///     Implementations of this type should be considered an implementation detail and should not be accessed
    ///     by user code.
    ///   </note>
    /// </remarks>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public class Arguments : IList<object>
#if CLONEABLE
                             , ICloneable
#endif
    {
        private readonly int count;

        /// <summary>
        ///   Empty list of <see cref = "Arguments" />.
        /// </summary>
        public static readonly Arguments Empty = new Arguments();

        private Arguments()
        {
        }

        internal Arguments( int count )
        {
            this.count = count;
        }


        /// <summary>
        ///   Gets the number of arguments encapsulated by the current object.
        /// </summary>
        public int Count
        {
            get { return this.count; }
        }


        /// <summary>
        ///   Gets the value of the argument at a given index.
        /// </summary>
        /// <param name = "index">Argument index.</param>
        /// <returns>The value of the argument at position <paramref name = "index" />.</returns>
        /// <exception cref = "ArgumentOutOfRangeException"><paramref name = "index" /> is lower than zero or greater or equal than <see cref = "Count" />.</exception>
        public virtual object GetArgument( int index )
        {
            throw new ArgumentOutOfRangeException( nameof(index));
        }


        /// <summary>
        ///   Gets or sets the value of an argument. Setting the value is only supported in specific situations. See <see cref="SetArgument"/> for details.  
        /// </summary>
        /// <param name = "index">Argument index.</param>
        /// <returns>The argument value.</returns>
        /// <exception cref = "ArgumentOutOfRangeException"><paramref name = "index" /> is lower than zero or greater or equal than <see cref = "Count" />.</exception>
        public object this[ int index ]
        {
            get { return this.GetArgument( index ); }
            set { this.SetArgument( index, value ); }
        }

        /// <summary>
        ///   Sets the value of the <c>ref</c> or <c>out</c> argument at a given index. Replacing an argument value is supported only in some advices
        ///   and is silently ignored in non-supported scenarios. See Remarks for details.
        /// </summary>
        /// <param name = "index">Argument index.</param>
        /// <param name = "value">New value of the ref or out argument at position <paramref name = "index" />.</param>
        /// <exception cref = "InvalidCastException"><paramref name = "value" /> is not assignable to parameter
        ///   at position <paramref name = "index" />.</exception>
        /// <exception cref = "ArgumentOutOfRangeException"><paramref name = "index" /> is lower than zero or greater or equal than <see cref = "Count" />.</exception>
        /// <remarks>
        /// <para>
        /// Replacing a parameter value is supported in the following scenarios:
        /// </para>
        /// <list type="bullet">
        ///    <item><description>In <see cref="OnMethodBoundaryAspect.OnSuccess"/> and <see cref="OnMethodBoundaryAspect.OnExit" /> advices, to replace
        ///             the value of <c>ref</c> and <c>out</c> parameters.</description></item>
        ///    <item><description>In any interception advice (such as <see cref="MethodInterceptionAspect.OnInvoke"/> or <see cref="LocationInterceptionAspect.OnSetValue"/>),
        ///     to set the value passed to the next node in the chain of responsibility, or the value of <c>ref</c> and <c>out</c> parameters.
        ///     </description></item>
        /// </list>
        /// <para>
        /// Setting the value in a different situation is unsupported and has unspecified behavior.
        /// </para>
        /// </remarks>
        public virtual void SetArgument( int index, object value )
        {
            throw new ArgumentOutOfRangeException( nameof(index));
        }

        /// <summary>
        ///   Copies all the argument values from the elements of <see cref = "Array" />.
        /// </summary>
        /// <param name = "array">The array that is the source of the argument values copied into the current <see cref = "Arguments" />.</param>
        /// <param name = "index">An integer that represents the index in <paramref name = "array" /> at which copying begins.</param>
        /// <exception cref = "ArgumentNullException"><paramref name = "array" /> is <c>null</c>.</exception>
        /// <exception cref = "ArgumentOutOfRangeException"><paramref name = "index" /> is lower than zero.</exception>
        /// <seealso cref = "CopyTo" />
        public virtual void CopyFrom( object[] array, int index )
        {
        }


        /// <summary>
        ///   Copies all arguments values to the specified <see cref = "Array" /> starting at the specified destination <see cref = "Array" /> index.
        /// </summary>
        /// <param name = "array">The array that is the destination of argument values copied from the current <see cref = "Arguments" />.</param>
        /// <param name = "index">An integer that represents the index in <paramref name = "array" /> at which copying begins</param>
        /// <seealso cref = "CopyFrom" />
        public virtual void CopyTo( object[] array, int index )
        {
        }

        /// <summary>
        ///   Converts the current argument list into an <see cref = "Array" />.
        /// </summary>
        /// <returns>An <see cref = "Array" /> whose elements are equal to the values encapsulated by the current <see cref = "Arguments" />.</returns>
        public object[] ToArray()
        {
            object[] array = new object[this.Count];
            this.CopyTo( array, 0 );
            return array;
        }

        /// <summary>
        ///   Returns a shallow copy of the current object.
        /// </summary>
        /// <returns>A shallow copy of the current object.</returns>
        public Arguments Clone()
        {
            return (Arguments) this.MemberwiseClone();
        }

#if CLONEABLE
        /// <inheritdoc />
        object ICloneable.Clone()
        {
            return this.Clone();
        }
#endif
        /// <summary>
        /// Creates a strongly-typed <see cref="Arguments"/> object representing 1 argument.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arg0"></param>
        /// <returns></returns>
        public static Arguments Create<T>( T arg0 )
        {
            return new Arguments<T> {Arg0 = arg0};
        }

        /// <summary>
        /// Creates a strongly-typed <see cref="Arguments"/> object representing 2 arguments.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <returns></returns>
        public static Arguments Create<T0,T1>(T0 arg0,T1 arg1)
        {
            return new Arguments<T0,T1> { Arg0 = arg0, Arg1 = arg1};
        }

        /// <summary>
        /// Creates a strongly-typed <see cref="Arguments"/> object representing 3 arguments.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        public static Arguments Create<T0, T1,T2>(T0 arg0, T1 arg1, T2 arg2)
        {
            return new Arguments<T0, T1, T2> { Arg0 = arg0, Arg1 = arg1, Arg2 = arg2};
        }

        /// <summary>
        /// Creates a strongly-typed <see cref="Arguments"/> object representing 4 arguments.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <returns></returns>
        public static Arguments Create<T0, T1, T2, T3>(T0 arg0, T1 arg1, T2 arg2, T3 arg3)
        {
            return new Arguments<T0, T1, T2, T3> { Arg0 = arg0, Arg1 = arg1, Arg2 = arg2, Arg3 = arg3};
        }


        /// <summary>
        /// Creates a strongly-typed <see cref="Arguments"/> object representing 5 arguments.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <returns></returns>
        public static Arguments Create<T0, T1, T2, T3, T4>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            return new Arguments<T0, T1, T2, T3, T4> { Arg0 = arg0, Arg1 = arg1, Arg2 = arg2, Arg3 = arg3, Arg4 = arg4 };
        }

        /// <summary>
        /// Creates a strongly-typed <see cref="Arguments"/> object representing 6 arguments.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="args5"></param>
        /// <returns></returns>
        public static Arguments Create<T0, T1, T2, T3, T4, T5>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 args5)
        {
            return new Arguments<T0, T1, T2, T3, T4, T5> { Arg0 = arg0, Arg1 = arg1, Arg2 = arg2, Arg3 = arg3, Arg4 = arg4, Arg5 = args5};
        }

        /// <summary>
        /// Creates a strongly-typed <see cref="Arguments"/> object representing 7 arguments.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="args5"></param>
        /// <param name="args6"></param>
        /// <returns></returns>
        public static Arguments Create<T0, T1, T2, T3, T4, T5, T6>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 args5, T6 args6)
        {
            return new Arguments<T0, T1, T2, T3, T4, T5, T6> { Arg0 = arg0, Arg1 = arg1, Arg2 = arg2, Arg3 = arg3, Arg4 = arg4, Arg5 = args5, Arg6 = args6};
        }

        /// <summary>
        /// Creates a strongly-typed <see cref="Arguments"/> object representing 8 arguments.
        /// </summary>
        /// <typeparam name="T0"></typeparam>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <typeparam name="T5"></typeparam>
        /// <typeparam name="T6"></typeparam>
        /// <typeparam name="T7"></typeparam>
        /// <param name="arg0"></param>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        /// <param name="arg4"></param>
        /// <param name="args5"></param>
        /// <param name="args6"></param>
        /// <param name="args7"></param>
        /// <returns></returns>
        public static Arguments Create<T0, T1, T2, T3, T4, T5, T6, T7>(T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 args5, T6 args6, T7 args7)
        {
            return new Arguments<T0, T1, T2, T3, T4, T5, T6, T7> { Arg0 = arg0, Arg1 = arg1, Arg2 = arg2, Arg3 = arg3, Arg4 = arg4, Arg5 = args5, Arg6 = args6, Arg7 = args7};
        }

        /// <summary>
        /// Creates a weakly-typed <see cref="Arguments"/> object representing any number of arguments.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static Arguments Create(params object[] array )
        {
            return new ArgumentsArray( array ); 
        }
        #region Implementation of IEnumerable

        /// <inheritdoc />
        public IEnumerator<object> GetEnumerator()
        {
            for ( int i = 0; i < this.count; i++ )
            {
                yield return this.GetArgument( i );
            }
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region Implementation of IList

        bool ICollection<object>.IsReadOnly
        {
            get { return true; }
        }

        bool ICollection<object>.Remove( object item )
        {
            throw new NotSupportedException();
        }

        int IList<object>.IndexOf( object item )
        {
            for ( int i = 0; i < this.count; i++ )
            {
                if ( Equals( item, this.GetArgument( i ) ) )
                    return i;
            }

            return -1;
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
            for ( int i = 0; i < this.count; i++ )
            {
                if ( Equals( item, this.GetArgument( i ) ) )
                    return true;
            }

            return false;
        }

        #endregion
    }
}