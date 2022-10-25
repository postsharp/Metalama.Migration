using System;
using System.Diagnostics;

namespace PostSharp.Aspects
{
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public class TypeIdentity
    {
        public static TypeIdentity FromType( Type type )
        {
            throw new NotImplementedException();
        }

        public static TypeIdentity[] FromTypes( Type[] types )
        {
            throw new NotImplementedException();
        }

        public Type Type { get; }

        public Type ToType()
        {
            throw new NotImplementedException();
        }

        public static TypeIdentity FromTypeName( string typeName )
        {
            throw new NotImplementedException();
        }

        public static TypeIdentity[] FromTypeNames( string[] typeNames )
        {
            throw new NotImplementedException();
        }

        public string TypeName { get; }
    }
}