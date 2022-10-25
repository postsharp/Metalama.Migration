// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Comparer of reflection types (<see cref = "Type" />) based on content, not reference.
    /// </summary>
#if !DEBUG
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
#endif
    public sealed class ReflectionTypeComparer : IEqualityComparer<Type>, IEqualityComparer<Type[]>
    {
        private readonly Type[] leftGenericTypeParameters;
        private readonly Type[] leftGenericMethodParameters;
        private readonly Type[] rightGenericTypeParameters;
        private readonly Type[] rightGenericMethodParameters;

        private ReflectionTypeComparer( Type[] leftGenericTypeParameters,
                                        Type[] leftGenericMethodParameters,
                                        Type[] rightGenericTypeParameters,
                                        Type[] rightGenericMethodParameters )
        {
            this.leftGenericTypeParameters = leftGenericTypeParameters;
            this.leftGenericMethodParameters = leftGenericMethodParameters;
            this.rightGenericTypeParameters = rightGenericTypeParameters;
            this.rightGenericMethodParameters = rightGenericMethodParameters;
        }


        /// <summary>
        ///   Singleton instance.
        /// </summary>
        private static readonly ReflectionTypeComparer instance = new ReflectionTypeComparer( null, null, null, null );

        /// <summary>
        ///   Gets an instance of <see cref = "ReflectionTypeComparer" /> that does not perform
        ///   substitution of generic parameters.
        /// </summary>
        /// <returns>An instance of <see cref = "ReflectionTypeComparer" />.</returns>
        public static ReflectionTypeComparer GetInstance()
        {
            return instance;
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
        public static ReflectionTypeComparer GetInstance( Type[] leftGenericTypeParameters,
                                                          Type[] leftGenericMethodParameters,
                                                          Type[] rightGenericTypeParameters,
                                                          Type[] rightGenericMethodParameters )
        {
            return new ReflectionTypeComparer( leftGenericTypeParameters, leftGenericMethodParameters,
                                               rightGenericTypeParameters, rightGenericMethodParameters );
        }

        private static bool XOr( bool x, bool y )
        {
            return (!x || !y) && (x || y);
        }

        private static Type SubstituteGenericParameter( Type type, Type[] genericTypeParameters,
                                                        Type[] genericMethodParameters )
        {
            if ( !type.IsGenericParameter )
                return type;

            Type[] genericParameters = type.GetDeclaringMethod() == null
                                           ? genericTypeParameters
                                           : genericMethodParameters;

            return genericParameters == null ? type : genericParameters[type.GenericParameterPosition];
        }

        /// <inheritdoc />
        public bool Equals( Type x, Type y )
        {
            // Test for null pointers.
            if ( XOr( x == null, y == null ) )
            {
                return false;
            }

            // Try to substitute generic parameters.
            Type xx = SubstituteGenericParameter( x, this.leftGenericTypeParameters, this.leftGenericMethodParameters );
            Type yy = SubstituteGenericParameter( y, this.rightGenericTypeParameters, this.rightGenericMethodParameters );

            // Compare references.
            if ( ReferenceEquals( xx, yy ) )
            {
                return true;
            }

            // Arrays and pointers.
            if ( xx.HasElementType )
            {
                if ( !yy.HasElementType )
                {
                    return false;
                }

                // Inner element.
                if ( !this.Equals( xx.GetElementType(), yy.GetElementType() ) )
                {
                    return false;
                }

                // Array
                if ( xx.IsArray )
                {
                    if ( !yy.IsArray )
                    {
                        return false;
                    }
                    if ( xx.GetArrayRank() != yy.GetArrayRank() )
                    {
                        return false;
                    }
                }
                else if ( yy.IsArray )
                {
                    return false;
                }

                if ( xx.IsPointer != yy.IsPointer )
                {
                    return false;
                }
                if ( xx.IsByRef != yy.IsByRef )
                {
                    return false;
                }

                return true;
            }
            else if ( yy.HasElementType )
            {
                return false;
            }

            // Generic parameters.
            if ( xx.IsGenericParameter )
            {
                if ( !yy.IsGenericParameter )
                {
                    return false;
                }

                if ( xx.GenericParameterPosition != yy.GenericParameterPosition )
                {
                    return false;
                }
       
                return true;
            }
            else if ( yy.IsGenericParameter )
            {
                return false;
            }

            // Generic intances
            if ( xx.IsGenericType() )
            {
                // We process generic instances and generic declarations together, 
                // because we have a substitution of generic parameters to generic arguments.

                if ( !yy.IsGenericType() )
                {
                    return false;
                }

                Type xTypeDef = xx.GetGenericTypeDefinition() ?? xx;
                Type yTypeDef = yy.GetGenericTypeDefinition() ?? yy;


                // Both are TypeSpecs.
                if ( !ReferenceEquals( xTypeDef, xx ) ||
                     !ReferenceEquals( yTypeDef, yy ) )
                {
                    if ( !this.Equals( xTypeDef, yTypeDef ) )
                    {
                        return false;
                    }

                    if ( !this.Equals( xx.GetGenericArguments(), yy.GetGenericArguments() ) )
                    {
                        return false;
                    }

                    return true;
                }
            }
            else if ( yy.IsGenericType() )
            {
                return false;
            }

            // Other are normal types.
            if ( xx.GetAssembly().FullName != yy.GetAssembly().FullName )
            {
                if ( !(xx.GetAssembly().FullName.Contains( "Version=255.255.255.255" ) && yy.GetAssembly().FullName.Contains( "Version=255.255.255.255" )) )
                {
                    return false;
                }
            }
            if ( xx.FullName != yy.FullName )
            {
                return false;
            }

            return true;
        }


        private static int CombineHash( int x, int y )
        {
            return ~(x << 4) & y;
        }

        private static void CombineHash( ref int x, int y )
        {
            x = CombineHash( x, y );
        }

        /// <inheritdoc />
        public int GetHashCode( Type obj )
        {
            if ( obj == null )
            {
                return 0;
            }
            else if ( obj.IsGenericParameter )
            {
                return obj.GenericParameterPosition;
            }
            else if ( obj.IsGenericType() && !obj.IsGenericTypeDefinition() )
            {
                int hash = 0;
                Type[] genericArgs = obj.GetGenericArguments();
                for ( int i = 0; i < genericArgs.Length; i++ )
                    CombineHash( ref hash, this.GetHashCode( genericArgs[i] ) );
                CombineHash( ref hash, this.GetHashCode( obj.GetGenericTypeDefinition() ) );
                return hash;
            }
            else if ( obj.HasElementType )
            {
                int hash = this.GetHashCode( obj.GetElementType() );
                if ( obj.IsArray )
                {
                    return CombineHash( hash, obj.GetArrayRank() );
                }
                else if ( obj.IsPointer )
                {
                    return CombineHash( hash, 69 );
                }
                else if ( obj.IsByRef )
                {
                    return CombineHash( hash, 96 );
                }
                else
                {
                    throw new ArgumentException( string.Format(CultureInfo.InvariantCulture, "Unexpected type kind: {0}", obj ) );
                }
            }
            else
            {
                string fullName = obj.FullName;
                return fullName == null ? 0 : fullName.GetHashCode();
            }
        }

        #region IEqualityComparer<Type[]> Members

        /// <inheritdoc />
        public bool Equals( Type[] x, Type[] y )
        {
            // Test for null pointers.
            if ( XOr( x == null, y == null ) )
            {
                return false;
            }
            if ( ReferenceEquals( x, y ) )
            {
                return true;
            }
            if ( x.Length != y.Length )
            {
                return false;
            }

            for ( int i = 0; i < x.Length; i++ )
            {
                if ( !this.Equals( x[i], y[i] ) )
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc />
        public int GetHashCode( Type[] types )
        {
            if ( types == null ) return 0;

            int hashCode = types.Length;

            for ( int i = 0; i < types.Length; i++ )
            {
                CombineHash( ref hashCode, this.GetHashCode( types[i] ) );
            }

            return hashCode;

        }

        #endregion
    }
}
