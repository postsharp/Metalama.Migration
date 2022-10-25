// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Constraints;

#pragma warning disable CA1051 // Do not declare visible instance fields.
#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Internals
{
    /// <summary>
    ///   Implementation of <see cref = "Arguments" /> representing a list of 2 arguments.
    /// </summary>
    /// <typeparam name = "TArg0">Type of the first argument.</typeparam>
    /// <typeparam name = "TArg1">Type of the second argument.</typeparam>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public class Arguments<TArg0, TArg1> : Arguments
    {
        private const int count = 2;

        /// <summary>
        ///   First argument.
        /// </summary>
        public TArg0 Arg0;

        /// <summary>
        ///   Second argument.
        /// </summary>
        public TArg1 Arg1;

        /// <summary>
        ///   Initializes a new <see cref = "Arguments{TArg0,TArg1}" />.
        /// </summary>
        public Arguments()
            : base( count )
        {
        }


        /// <inheritdoc />
        public override object GetArgument( int index )
        {
            switch ( index )
            {
                case 0:
                    return this.Arg0;

                case 1:
                    return this.Arg1;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void SetArgument( int index, object value )
        {
            switch ( index )
            {
                case 0:
                    this.Arg0 = (TArg0) value;
                    break;

                case 1:
                    this.Arg1 = (TArg1) value;
                    break;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void CopyTo( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            array[index] = this.Arg0;
            array[index + 1] = this.Arg1;
        }

        /// <inheritdoc />
        public override void CopyFrom( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            this.Arg0 = (TArg0) array[index];
            this.Arg1 = (TArg1) array[index + 1];
        }
    }

    /// <summary>
    ///   Implementation of <see cref = "Arguments" /> representing a list of 3 arguments.
    /// </summary>
    /// <typeparam name = "TArg0">Type of the first argument.</typeparam>
    /// <typeparam name = "TArg1">Type of the second argument.</typeparam>
    /// <typeparam name = "TArg2">Type of the third argument.</typeparam>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public class Arguments<TArg0, TArg1, TArg2> : Arguments
    {
        private const int count = 3;

        /// <summary>
        ///   First argument.
        /// </summary>
        public TArg0 Arg0;

        /// <summary>
        ///   Second argument.
        /// </summary>
        public TArg1 Arg1;

        /// <summary>
        ///   Third argument.
        /// </summary>
        public TArg2 Arg2;

        /// <summary>
        ///   Initializes a new <see cref = "Arguments{TArg0,TArg1,TArg2}" />.
        /// </summary>
        public Arguments()
            : base( count )
        {
        }

        /// <inheritdoc />
        public override object GetArgument( int index )
        {
            switch ( index )
            {
                case 0:
                    return this.Arg0;

                case 1:
                    return this.Arg1;

                case 2:
                    return this.Arg2;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void SetArgument( int index, object value )
        {
            switch ( index )
            {
                case 0:
                    this.Arg0 = (TArg0) value;
                    break;

                case 1:
                    this.Arg1 = (TArg1) value;
                    break;

                case 2:
                    this.Arg2 = (TArg2) value;
                    break;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void CopyTo( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            array[index] = this.Arg0;
            array[index + 1] = this.Arg1;
            array[index + 2] = this.Arg2;
        }

        /// <inheritdoc />
        public override void CopyFrom( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            this.Arg0 = (TArg0) array[index];
            this.Arg1 = (TArg1) array[index + 1];
            this.Arg2 = (TArg2) array[index + 2];
        }
    }

    /// <summary>
    ///   Implementation of <see cref = "Arguments" /> representing a list of 4 arguments.
    /// </summary>
    /// <typeparam name = "TArg0">Type of the first argument.</typeparam>
    /// <typeparam name = "TArg1">Type of the second argument.</typeparam>
    /// <typeparam name = "TArg2">Type of the third argument.</typeparam>
    /// <typeparam name = "TArg3">Type of the fourth argument.</typeparam>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public class Arguments<TArg0, TArg1, TArg2, TArg3> : Arguments
    {
        private const int count = 4;

        /// <summary>
        ///   First argument.
        /// </summary>
        public TArg0 Arg0;

        /// <summary>
        ///   Second argument.
        /// </summary>
        public TArg1 Arg1;

        /// <summary>
        ///   Third argument.
        /// </summary>
        public TArg2 Arg2;

        /// <summary>
        ///   Fourth argument.
        /// </summary>
        public TArg3 Arg3;


        /// <summary>
        ///   Initializes a new <see cref = "Arguments{TArg0,TArg1,TArg2,TArg3}" />.
        /// </summary>
        public Arguments()
            : base( count )
        {
        }

        /// <inheritdoc />
        public override object GetArgument( int index )
        {
            switch ( index )
            {
                case 0:
                    return this.Arg0;

                case 1:
                    return this.Arg1;

                case 2:
                    return this.Arg2;

                case 3:
                    return this.Arg3;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void SetArgument( int index, object value )
        {
            switch ( index )
            {
                case 0:
                    this.Arg0 = (TArg0) value;
                    break;

                case 1:
                    this.Arg1 = (TArg1) value;
                    break;

                case 2:
                    this.Arg2 = (TArg2) value;
                    break;

                case 3:
                    this.Arg3 = (TArg3) value;
                    break;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void CopyTo( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            array[index] = this.Arg0;
            array[index + 1] = this.Arg1;
            array[index + 2] = this.Arg2;
            array[index + 3] = this.Arg3;
        }

        /// <inheritdoc />
        public override void CopyFrom( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            this.Arg0 = (TArg0) array[index];
            this.Arg1 = (TArg1) array[index + 1];
            this.Arg2 = (TArg2) array[index + 2];
            this.Arg3 = (TArg3) array[index + 3];
        }
    }

    /// <summary>
    ///   Implementation of <see cref = "Arguments" /> representing a list of 5 arguments.
    /// </summary>
    /// <typeparam name = "TArg0">Type of the first argument.</typeparam>
    /// <typeparam name = "TArg1">Type of the second argument.</typeparam>
    /// <typeparam name = "TArg2">Type of the third argument.</typeparam>
    /// <typeparam name = "TArg3">Type of the fourth argument.</typeparam>
    /// <typeparam name = "TArg4">Type of the fifth argument.</typeparam>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public class Arguments<TArg0, TArg1, TArg2, TArg3, TArg4> : Arguments
    {
        private const int count = 5;

        /// <summary>
        ///   First argument.
        /// </summary>
        public TArg0 Arg0;

        /// <summary>
        ///   Second argument.
        /// </summary>
        public TArg1 Arg1;

        /// <summary>
        ///   Third argument.
        /// </summary>
        public TArg2 Arg2;

        /// <summary>
        ///   Fourth argument.
        /// </summary>
        public TArg3 Arg3;

        /// <summary>
        ///   Fifth argument.
        /// </summary>
        public TArg4 Arg4;

        /// <summary>
        ///   Initializes a new <see cref = "Arguments{TArg0,TArg1,TArg2,TArg3,TArg4}" />.
        /// </summary>
        public Arguments()
            : base( count )
        {
        }

        /// <inheritdoc />
        public override object GetArgument( int index )
        {
            switch ( index )
            {
                case 0:
                    return this.Arg0;

                case 1:
                    return this.Arg1;

                case 2:
                    return this.Arg2;

                case 3:
                    return this.Arg3;

                case 4:
                    return this.Arg4;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void SetArgument( int index, object value )
        {
            switch ( index )
            {
                case 0:
                    this.Arg0 = (TArg0) value;
                    break;

                case 1:
                    this.Arg1 = (TArg1) value;
                    break;

                case 2:
                    this.Arg2 = (TArg2) value;
                    break;

                case 3:
                    this.Arg3 = (TArg3) value;
                    break;

                case 4:
                    this.Arg4 = (TArg4) value;
                    break;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void CopyTo( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            array[index] = this.Arg0;
            array[index + 1] = this.Arg1;
            array[index + 2] = this.Arg2;
            array[index + 3] = this.Arg3;
            array[index + 4] = this.Arg4;
        }

        /// <inheritdoc />
        public override void CopyFrom( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            this.Arg0 = (TArg0) array[index];
            this.Arg1 = (TArg1) array[index + 1];
            this.Arg2 = (TArg2) array[index + 2];
            this.Arg3 = (TArg3) array[index + 3];
            this.Arg4 = (TArg4) array[index + 4];
        }
    }

    /// <summary>
    ///   Implementation of <see cref = "Arguments" /> representing a list of 6 arguments.
    /// </summary>
    /// <typeparam name = "TArg0">Type of the first argument.</typeparam>
    /// <typeparam name = "TArg1">Type of the second argument.</typeparam>
    /// <typeparam name = "TArg2">Type of the third argument.</typeparam>
    /// <typeparam name = "TArg3">Type of the fourth argument.</typeparam>
    /// <typeparam name = "TArg4">Type of the fifth argument.</typeparam>
    /// <typeparam name = "TArg5">Type of the sixth argument.</typeparam>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public class Arguments<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> :
        Arguments
    {
        private const int count = 6;

        /// <summary>
        ///   First argument.
        /// </summary>
        public TArg0 Arg0;

        /// <summary>
        ///   Second argument.
        /// </summary>
        public TArg1 Arg1;

        /// <summary>
        ///   Third argument.
        /// </summary>
        public TArg2 Arg2;

        /// <summary>
        ///   Fourth argument.
        /// </summary>
        public TArg3 Arg3;

        /// <summary>
        ///   Fifth argument.
        /// </summary>
        public TArg4 Arg4;

        /// <summary>
        ///   Sixth argument.
        /// </summary>
        public TArg5 Arg5;

        /// <summary>
        ///   Initializes a new <see cref = "Arguments{TArg0,TArg1,TArg2,TArg3,TArg4,TArg5}" />.
        /// </summary>
        public Arguments()
            : base( count )
        {
        }

        /// <inheritdoc />
        public override object GetArgument( int index )
        {
            switch ( index )
            {
                case 0:
                    return this.Arg0;

                case 1:
                    return this.Arg1;

                case 2:
                    return this.Arg2;

                case 3:
                    return this.Arg3;

                case 4:
                    return this.Arg4;

                case 5:
                    return this.Arg5;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void SetArgument( int index, object value )
        {
            switch ( index )
            {
                case 0:
                    this.Arg0 = (TArg0) value;
                    break;

                case 1:
                    this.Arg1 = (TArg1) value;
                    break;

                case 2:
                    this.Arg2 = (TArg2) value;
                    break;

                case 3:
                    this.Arg3 = (TArg3) value;
                    break;

                case 4:
                    this.Arg4 = (TArg4) value;
                    break;

                case 5:
                    this.Arg5 = (TArg5) value;
                    break;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void CopyTo( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            array[index] = this.Arg0;
            array[index + 1] = this.Arg1;
            array[index + 2] = this.Arg2;
            array[index + 3] = this.Arg3;
            array[index + 4] = this.Arg4;
            array[index + 5] = this.Arg5;
        }

        /// <inheritdoc />
        public override void CopyFrom( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            this.Arg0 = (TArg0) array[index];
            this.Arg1 = (TArg1) array[index + 1];
            this.Arg2 = (TArg2) array[index + 2];
            this.Arg3 = (TArg3) array[index + 3];
            this.Arg4 = (TArg4) array[index + 4];
            this.Arg5 = (TArg5) array[index + 5];
        }
    }

    /// <summary>
    ///   Implementation of <see cref = "Arguments" /> representing a list of 7 arguments.
    /// </summary>
    /// <typeparam name = "TArg0">Type of the first argument.</typeparam>
    /// <typeparam name = "TArg1">Type of the second argument.</typeparam>
    /// <typeparam name = "TArg2">Type of the third argument.</typeparam>
    /// <typeparam name = "TArg3">Type of the fourth argument.</typeparam>
    /// <typeparam name = "TArg4">Type of the fifth argument.</typeparam>
    /// <typeparam name = "TArg5">Type of the sixth argument.</typeparam>
    /// <typeparam name = "TArg6">Type of the seventh argument.</typeparam>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public class Arguments<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> :
        Arguments
    {
        private const int count = 7;

        /// <summary>
        ///   First argument.
        /// </summary>
        public TArg0 Arg0;

        /// <summary>
        ///   Second argument.
        /// </summary>
        public TArg1 Arg1;

        /// <summary>
        ///   Third argument.
        /// </summary>
        public TArg2 Arg2;

        /// <summary>
        ///   Fourth argument.
        /// </summary>
        public TArg3 Arg3;

        /// <summary>
        ///   Fifth argument.
        /// </summary>
        public TArg4 Arg4;

        /// <summary>
        ///   Sixth argument.
        /// </summary>
        public TArg5 Arg5;

        /// <summary>
        ///   Seventh argument.
        /// </summary>
        public TArg6 Arg6;


        /// <summary>
        ///   Initializes a new <see cref = "Arguments{TArg0,TArg1,TArg2,TArg3,TArg4,TArg5,TArg6}" />.
        /// </summary>
        public Arguments()
            : base( count )
        {
        }

        /// <inheritdoc />
        public override object GetArgument( int index )
        {
            switch ( index )
            {
                case 0:
                    return this.Arg0;

                case 1:
                    return this.Arg1;

                case 2:
                    return this.Arg2;

                case 3:
                    return this.Arg3;

                case 4:
                    return this.Arg4;

                case 5:
                    return this.Arg5;

                case 6:
                    return this.Arg6;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void SetArgument( int index, object value )
        {
            switch ( index )
            {
                case 0:
                    this.Arg0 = (TArg0) value;
                    break;

                case 1:
                    this.Arg1 = (TArg1) value;
                    break;

                case 2:
                    this.Arg2 = (TArg2) value;
                    break;

                case 3:
                    this.Arg3 = (TArg3) value;
                    break;

                case 4:
                    this.Arg4 = (TArg4) value;
                    break;

                case 5:
                    this.Arg5 = (TArg5) value;
                    break;

                case 6:
                    this.Arg6 = (TArg6) value;
                    break;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void CopyTo( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            array[index] = this.Arg0;
            array[index + 1] = this.Arg1;
            array[index + 2] = this.Arg2;
            array[index + 3] = this.Arg3;
            array[index + 4] = this.Arg4;
            array[index + 5] = this.Arg5;
            array[index + 6] = this.Arg6;
        }

        /// <inheritdoc />
        public override void CopyFrom( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            this.Arg0 = (TArg0) array[index];
            this.Arg1 = (TArg1) array[index + 1];
            this.Arg2 = (TArg2) array[index + 2];
            this.Arg3 = (TArg3) array[index + 3];
            this.Arg4 = (TArg4) array[index + 4];
            this.Arg5 = (TArg5) array[index + 5];
            this.Arg6 = (TArg6) array[index + 6];
        }
    }

    /// <summary>
    ///   Implementation of <see cref = "Arguments" /> representing a list of 8 arguments.
    /// </summary>
    /// <typeparam name = "TArg0">Type of the first argument.</typeparam>
    /// <typeparam name = "TArg1">Type of the second argument.</typeparam>
    /// <typeparam name = "TArg2">Type of the third argument.</typeparam>
    /// <typeparam name = "TArg3">Type of the fourth argument.</typeparam>
    /// <typeparam name = "TArg4">Type of the fifth argument.</typeparam>
    /// <typeparam name = "TArg5">Type of the sixth argument.</typeparam>
    /// <typeparam name = "TArg6">Type of the seventh argument.</typeparam>
    /// <typeparam name = "TArg7">Type of the eighth argument.</typeparam>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public class Arguments<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> :
        Arguments
    {
        private const int count = 8;

        /// <summary>
        ///   First argument.
        /// </summary>
        public TArg0 Arg0;

        /// <summary>
        ///   Second argument.
        /// </summary>
        public TArg1 Arg1;

        /// <summary>
        ///   Third argument.
        /// </summary>
        public TArg2 Arg2;

        /// <summary>
        ///   Fourth argument.
        /// </summary>
        public TArg3 Arg3;

        /// <summary>
        ///   Fifth argument.
        /// </summary>
        public TArg4 Arg4;

        /// <summary>
        ///   Sixth argument.
        /// </summary>
        public TArg5 Arg5;

        /// <summary>
        ///   Seventh argument.
        /// </summary>
        public TArg6 Arg6;


        /// <summary>
        ///   Eighth argument.
        /// </summary>
        public TArg7 Arg7;


        /// <summary>
        ///   Initializes a new <see cref = "Arguments{TArg0,TArg1,TArg2,TArg3,TArg4,TArg5,TArg6,TArg7}" />.
        /// </summary>
        public Arguments()
            : base( count )
        {
        }

        /// <inheritdoc />
        public override object GetArgument( int index )
        {
            switch ( index )
            {
                case 0:
                    return this.Arg0;

                case 1:
                    return this.Arg1;

                case 2:
                    return this.Arg2;

                case 3:
                    return this.Arg3;

                case 4:
                    return this.Arg4;

                case 5:
                    return this.Arg5;

                case 6:
                    return this.Arg6;

                case 7:
                    return this.Arg7;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void SetArgument( int index, object value )
        {
            switch ( index )
            {
                case 0:
                    this.Arg0 = (TArg0) value;
                    break;

                case 1:
                    this.Arg1 = (TArg1) value;
                    break;

                case 2:
                    this.Arg2 = (TArg2) value;
                    break;

                case 3:
                    this.Arg3 = (TArg3) value;
                    break;

                case 4:
                    this.Arg4 = (TArg4) value;
                    break;

                case 5:
                    this.Arg5 = (TArg5) value;
                    break;

                case 6:
                    this.Arg6 = (TArg6) value;
                    break;

                case 7:
                    this.Arg7 = (TArg7) value;
                    break;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void CopyTo( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            array[index] = this.Arg0;
            array[index + 1] = this.Arg1;
            array[index + 2] = this.Arg2;
            array[index + 3] = this.Arg3;
            array[index + 4] = this.Arg4;
            array[index + 5] = this.Arg5;
            array[index + 6] = this.Arg6;
            array[index + 7] = this.Arg7;
        }

        /// <inheritdoc />
        public override void CopyFrom( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            this.Arg0 = (TArg0) array[index];
            this.Arg1 = (TArg1) array[index + 1];
            this.Arg2 = (TArg2) array[index + 2];
            this.Arg3 = (TArg3) array[index + 3];
            this.Arg4 = (TArg4) array[index + 4];
            this.Arg5 = (TArg5) array[index + 5];
            this.Arg6 = (TArg6) array[index + 6];
            this.Arg7 = (TArg7) array[index + 7];
        }
    }
}