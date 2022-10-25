// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;

namespace PostSharp.Aspects
{
    ///<summary>
    ///  Wraps a <see cref = "Type" /> or a type name.
    ///</summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public class TypeIdentity
    {
        private readonly Type type;

        private TypeIdentity( Type type )
        {
            this.type = type;
        }

        /// <summary>
        ///   Wraps a <see cref = "Type" /> into a <see cref = "TypeIdentity" />.
        /// </summary>
        /// <param name = "type">A <see cref = "Type" />.</param>
        /// <returns>A <see cref = "TypeIdentity" /> wrapping <paramref cref = "type" />.</returns>
        public static TypeIdentity FromType( Type type )
        {
            return type != null ? new TypeIdentity( type ) : null;
        }

        /// <summary>
        ///   Wraps an array of <see cref = "Type" /> into an array of <see cref = "TypeIdentity" />.
        /// </summary>
        /// <param name = "types">An array of <see cref = "Type" />.</param>
        /// <returns>An array of <see cref = "TypeIdentity" /> wrapping <paramref name = "types" />.</returns>
        public static TypeIdentity[] FromTypes( Type[] types )
        {
            if ( types == null ) return null;

            TypeIdentity[] typeIdentities = new TypeIdentity[types.Length];

            for ( int i = 0; i < types.Length; i++ )
                typeIdentities[i] = new TypeIdentity( types[i] );

            return typeIdentities;
        }


        /// <summary>
        ///   Gets the wrapped <see cref = "Type" />, or <c>null</c> it the <see cref = "TypeName" /> property is set.
        /// </summary>
        public Type Type
        {
            get { return this.type; }
        }

        /// <summary>
        ///   Converts a <see cref = "TypeIdentity" /> into a <see cref = "System.Type" />.
        /// </summary>
        /// <returns></returns>
        public Type ToType()
        {
            return this.type ?? Type.GetType( this.typeName );
        }


        private readonly string typeName;

        private TypeIdentity( string typeName )
        {
            this.typeName = typeName;
        }

        /// <summary>
        ///   Wraps a type name into a <see cref = "TypeIdentity" />.
        /// </summary>
        /// <param name = "typeName">The type name.</param>
        /// <returns>A <see cref = "TypeIdentity" /> wrapping the type name.</returns>
        public static TypeIdentity FromTypeName( string typeName )
        {
            return typeName != null ? new TypeIdentity( typeName ) : null;
        }

        /// <summary>
        ///   Wraps an array of type names into an array of <see cref = "TypeIdentity" />.
        /// </summary>
        /// <param name = "typeNames">An array of type names.</param>
        /// <returns>An array of <see cref = "TypeIdentity" /> wrapping <paramref name = "typeNames" />.</returns>
        public static TypeIdentity[] FromTypeNames( string[] typeNames )
        {
            if ( typeNames == null ) return null;

            TypeIdentity[] typeIdentities = new TypeIdentity[typeNames.Length];

            for ( int i = 0; i < typeNames.Length; i++ )
                typeIdentities[i] = new TypeIdentity( typeNames[i] );

            return typeIdentities;
        }


        /// <summary>
        ///   Gets the wrapped type name, or <c>null</c> it the <see cref = "Type" /> property is set.
        /// </summary>
        public string TypeName
        {
            get { return this.typeName; }
        }
    }
}