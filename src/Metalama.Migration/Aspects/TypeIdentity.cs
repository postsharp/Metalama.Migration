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
        /// <summary>
        ///   Wraps a <see cref = "Type" /> into a <see cref = "TypeIdentity" />.
        /// </summary>
        /// <param name = "type">A <see cref = "Type" />.</param>
        /// <returns>A <see cref = "TypeIdentity" /> wrapping <paramref cref = "type" />.</returns>
        public static TypeIdentity FromType( Type type )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Wraps an array of <see cref = "Type" /> into an array of <see cref = "TypeIdentity" />.
        /// </summary>
        /// <param name = "types">An array of <see cref = "Type" />.</param>
        /// <returns>An array of <see cref = "TypeIdentity" /> wrapping <paramref name = "types" />.</returns>
        public static TypeIdentity[] FromTypes( Type[] types )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Gets the wrapped <see cref = "Type" />, or <c>null</c> it the <see cref = "TypeName" /> property is set.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        ///   Converts a <see cref = "TypeIdentity" /> into a <see cref = "System.Type" />.
        /// </summary>
        /// <returns></returns>
        public Type ToType()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Wraps a type name into a <see cref = "TypeIdentity" />.
        /// </summary>
        /// <param name = "typeName">The type name.</param>
        /// <returns>A <see cref = "TypeIdentity" /> wrapping the type name.</returns>
        public static TypeIdentity FromTypeName( string typeName )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Wraps an array of type names into an array of <see cref = "TypeIdentity" />.
        /// </summary>
        /// <param name = "typeNames">An array of type names.</param>
        /// <returns>An array of <see cref = "TypeIdentity" /> wrapping <paramref name = "typeNames" />.</returns>
        public static TypeIdentity[] FromTypeNames( string[] typeNames )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Gets the wrapped type name, or <c>null</c> it the <see cref = "Type" /> property is set.
        /// </summary>
        public string TypeName { get; }
    }
}