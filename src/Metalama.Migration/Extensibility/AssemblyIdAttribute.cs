using System;

#pragma warning disable IDE0060 // Remove unused parameter (metadata is used)

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Assigns a unique identifier to an assembly. This assembly identifier is used
    ///   to generate unique attribute identifiers.
    /// </summary>
    /// <remarks>
    ///   By default, the assembly identifier is computed from the module name
    ///   (by using the first 4 bytes of the MD5 sum of the module name).
    /// </remarks>
    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = false, Inherited = false )]
    public sealed class AssemblyIdAttribute : Attribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "AssemblyIdAttribute" />.
        /// </summary>
        /// <param name = "id">Assembly identifier.</param>
        public AssemblyIdAttribute( int id )
        {
            AssemblyId = id;
        }

        /// <summary>
        /// Gets the assembly id.
        /// </summary>
        public int AssemblyId { get; }
    }
}