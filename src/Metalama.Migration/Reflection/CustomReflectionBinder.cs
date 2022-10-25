// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

#if LEGACY_REFLECTION_API

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Custom implementation of a reflection <see cref = "Binder" /> that select
    ///   methods based on exact matches using the <see cref = "ReflectionTypeComparer" />.
    /// </summary>
    public sealed class CustomReflectionBinder : Binder
    {
        /// <summary>
        ///   Singleton instance.
        /// </summary>
        [SuppressMessage( "Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes" )] public static readonly CustomReflectionBinder Instance =
            new CustomReflectionBinder();

        private CustomReflectionBinder()
        {
        }

        /// <inheritdoc />
        public override FieldInfo BindToField( BindingFlags bindingFlags, FieldInfo[] match, object value,
                                               CultureInfo culture )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override MethodBase BindToMethod( BindingFlags bindingFlags, MethodBase[] match, ref object[] args,
                                                 ParameterModifier[] modifiers, CultureInfo culture, string[] names,
                                                 out object state )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override object ChangeType( object value, Type type, CultureInfo culture )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void ReorderArgumentArray( ref object[] args, object state )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override MethodBase SelectMethod( BindingFlags bindingFlags, MethodBase[] match, Type[] types,
                                                 ParameterModifier[] modifiers )
        {
            MethodBase selectedMethod = null;

            foreach ( MethodBase candidate in match )
            {
                ParameterInfo[] candidateParameters = candidate.GetParameters();

                if ( candidateParameters.Length != types.Length )
                {
                    continue;
                }

                bool isMatch = true;
                for ( int i = 0; i < candidateParameters.Length; i++ )
                {
                    if ( !ReflectionTypeComparer.GetInstance().Equals( candidateParameters[i].ParameterType, types[i] ) )
                    {
                        isMatch = false;
                        break;
                    }
                }

                if ( !isMatch )
                {
                    continue;
                }

                if ( selectedMethod != null )
                {
                    throw new AmbiguousMatchException();
                }

                selectedMethod = candidate;
            }

            return selectedMethod;
        }

        /// <inheritdoc />
        public override PropertyInfo SelectProperty( BindingFlags bindingFlags, PropertyInfo[] match, Type returnType,
                                                     Type[] indexes, ParameterModifier[] modifiers )
        {
            throw new NotImplementedException();
        }
    }
}

#endif