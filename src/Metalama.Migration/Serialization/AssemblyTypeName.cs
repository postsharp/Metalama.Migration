namespace PostSharp.Serialization
{
    internal struct AssemblyTypeName
    {
        public AssemblyTypeName( string typeName, string assemblyName )
        {
            TypeName = typeName;
            AssemblyName = assemblyName;
        }

        public readonly string TypeName;
        public readonly string AssemblyName;
    }
}