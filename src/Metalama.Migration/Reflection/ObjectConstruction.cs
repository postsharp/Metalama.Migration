using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Specifies how an object should be constructed, i.e. specifies the constructor to be
    ///   used, the arguments to be passed to this constructor, and the fields or properties to
    ///   be set.
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public sealed class ObjectConstruction
    {
#pragma warning disable CA1825 // Avoid zero-length array allocations. (API not available in .NET 4.0)

#pragma warning restore CA1825 // Avoid zero-length array allocations. (API not available in .NET 4.0)

        /// <summary>
        ///   Initializes a new <see cref = "ObjectConstruction" /> by specifying a type name and a list of constructor arguments.
        /// </summary>
        /// <param name = "typeName">Name of the object type.</param>
        /// <param name = "constructorArguments">Arguments passed to the constructor.</param>
        public ObjectConstruction( string typeName, params object[] constructorArguments )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Initializes a new <see cref = "ObjectConstruction" /> by specifying a type name and a list of constructor arguments.
        /// </summary>
        /// <param name = "type">Object type.</param>
        /// <param name = "constructorArguments">Arguments passed to the constructor.</param>
        public ObjectConstruction( Type type, params object[] constructorArguments )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Initializes a new type-safe <see cref = "ObjectConstruction" /> from a <see cref = "ConstructorInfo" />.
        /// </summary>
        /// <param name = "constructor">Constructor.</param>
        /// <param name = "constructorArguments">Arguments passed to the constructor.</param>
        public ObjectConstruction( ConstructorInfo constructor, params object[] constructorArguments )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Initializes a new type-safe <see cref = "ObjectConstruction" /> from a <see cref = "CustomAttributeData" />
        /// </summary>
        /// <param name = "customAttributeData">A <see cref = "CustomAttributeData" /></param>
        public ObjectConstruction( CustomAttributeData customAttributeData )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Gets the assembly-qualified type name of the object.
        /// </summary>
        public string TypeName { get; }

        /// <summary>
        ///   Gets the custom attribute constructor.
        /// </summary>
        public ConstructorInfo Constructor { get; }

        /// <summary>
        ///   Gets the arguments passed to the custom attribute constructor.
        /// </summary>
        public IList<object> ConstructorArguments { get; }

        /// <summary>
        ///   Gets the collection of named arguments.
        /// </summary>
        /// <remarks>
        ///   This collection is a dictionary associating the name of public a field or property of the
        ///   custom attributes to the value that should be assigned to it.
        /// </remarks>
        public IDictionary<string, object> NamedArguments { get; }
    }
}