using System;

#pragma warning disable IDE0060 // Remove unused parameter (metadata is used)

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Assembly )]
    public sealed class AssemblyIdAttribute : Attribute
    {
        public AssemblyIdAttribute( int id )
        {
            AssemblyId = id;
        }

        public int AssemblyId { get; }
    }
}