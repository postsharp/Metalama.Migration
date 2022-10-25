using System;

#pragma warning disable IDE0060 // Remove unused parameter (metadata is used)

namespace PostSharp.Extensibility
{
    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = false, Inherited = false )]
    public sealed class AssemblyIdAttribute : Attribute
    {
        public AssemblyIdAttribute( int id )
        {
            AssemblyId = id;
        }

        public int AssemblyId { get; }
    }
}