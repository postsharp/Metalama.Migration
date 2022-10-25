using System;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global

    /// <summary>
    /// Binds types to names and names to types. Used by the <see cref="PortableFormatter"/>.
    /// </summary>
    public class PortableSerializationBinder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortableSerializationBinder"/> class.
        /// </summary>
        public PortableSerializationBinder()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a <see cref="Type"/> given a type name and an assembly name.
        /// </summary>
        /// <param name="typeName">The type name.</param>
        /// <param name="assemblyName">The assembly name.</param>
        /// <returns>The required <see cref="Type"/>.</returns>
        public virtual Type BindToType( string typeName, string assemblyName )
        {
            return Type.GetType( ReflectionHelper.GetAssemblyQualifiedTypeName( typeName, assemblyName ) );
        }

        /// <summary>
        /// Gets the name and the assembly name of a given <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/>.</param>
        /// <param name="typeName">At output, the name of <paramref name="type"/>.</param>
        /// <param name="assemblyName">At output, the name of <paramref name="assemblyName"/>.</param>
        public virtual void BindToName( Type type, out string typeName, out string assemblyName )
        {
            throw new NotImplementedException();
        }
    }
}