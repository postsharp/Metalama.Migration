// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Serialization
{
    struct AssemblyTypeName
    {
        public AssemblyTypeName( string typeName, string assemblyName )
        {
            this.TypeName = typeName;
            this.AssemblyName = assemblyName;
        }

        public readonly string TypeName;
        public readonly string AssemblyName;
    }
}
