using System;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
// ReSharper disable ClassWithVirtualMembersNeverInherited.Global

    public class PortableSerializationBinder
    {
        public PortableSerializationBinder()
        {
            throw new NotImplementedException();
        }

        public virtual Type BindToType( string typeName, string assemblyName )
        {
            return Type.GetType( ReflectionHelper.GetAssemblyQualifiedTypeName( typeName, assemblyName ) );
        }

        public virtual void BindToName( Type type, out string typeName, out string assemblyName )
        {
            throw new NotImplementedException();
        }
    }
}