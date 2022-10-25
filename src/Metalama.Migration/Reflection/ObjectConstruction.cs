using System;
using System.Collections.Generic;
using System.Reflection;
using Metalama.Framework.Code.DeclarationBuilders;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="AttributeConstruction"/>.
    /// </summary>
    public sealed class ObjectConstruction
    {
#pragma warning disable CA1825 // Avoid zero-length array allocations. (API not available in .NET 4.0)

#pragma warning restore CA1825 // Avoid zero-length array allocations. (API not available in .NET 4.0)

        public ObjectConstruction( string typeName, params object[] constructorArguments )
        {
            throw new NotImplementedException();
        }

        public ObjectConstruction( Type type, params object[] constructorArguments )
        {
            throw new NotImplementedException();
        }

        public ObjectConstruction( ConstructorInfo constructor, params object[] constructorArguments )
        {
            throw new NotImplementedException();
        }

        public ObjectConstruction( CustomAttributeData customAttributeData )
        {
            throw new NotImplementedException();
        }

        public string TypeName { get; }

        public ConstructorInfo Constructor { get; }

        public IList<object> ConstructorArguments { get; }

        public IDictionary<string, object> NamedArguments { get; }
    }
}