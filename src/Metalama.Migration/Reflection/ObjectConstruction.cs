// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
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
        private static readonly object[] emptyArray = new object[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations. (API not available in .NET 4.0)


        private readonly string typeName;
        private readonly ConstructorInfo constructor;
        private readonly ReadOnlyCollection<object> constructorArguments;
        private readonly NamedArgumentsCollection namedArguments;


        /// <summary>
        ///   Initializes a new <see cref = "ObjectConstruction" /> by specifying a type name and a list of constructor arguments.
        /// </summary>
        /// <param name = "typeName">Name of the object type.</param>
        /// <param name = "constructorArguments">Arguments passed to the constructor.</param>
        public ObjectConstruction( string typeName, params object[] constructorArguments )
        {
            if ( string.IsNullOrEmpty( typeName ) ) throw new ArgumentNullException( nameof(typeName));
            this.typeName = typeName;
            this.constructorArguments = new ReadOnlyCollection<object>( constructorArguments ?? emptyArray );
            this.namedArguments = new NamedArgumentsCollection( this );
        }

        /// <summary>
        ///   Initializes a new <see cref = "ObjectConstruction" /> by specifying a type name and a list of constructor arguments.
        /// </summary>
        /// <param name = "type">Object type.</param>
        /// <param name = "constructorArguments">Arguments passed to the constructor.</param>
        public ObjectConstruction( Type type, params object[] constructorArguments )
        {
            if ( type == null ) throw new ArgumentNullException( nameof(type));
            this.typeName = type.AssemblyQualifiedName;
            this.constructorArguments = new ReadOnlyCollection<object>( constructorArguments ?? emptyArray );
            this.namedArguments = new NamedArgumentsCollection( this );
        }

        /// <summary>
        ///   Initializes a new type-safe <see cref = "ObjectConstruction" /> from a <see cref = "ConstructorInfo" />.
        /// </summary>
        /// <param name = "constructor">Constructor.</param>
        /// <param name = "constructorArguments">Arguments passed to the constructor.</param>
        public ObjectConstruction( ConstructorInfo constructor, params object[] constructorArguments )
        {
            // Trivial checks.
            if ( constructor == null ) throw new ArgumentNullException( nameof(constructor));
            this.constructor = constructor;
            this.typeName = this.constructor.DeclaringType.AssemblyQualifiedName;
            this.constructorArguments = new ReadOnlyCollection<object>( constructorArguments ?? emptyArray );
            this.namedArguments = new NamedArgumentsCollection( this );

            // Check compatibility of constructor arguments.
            ParameterInfo[] parameters = constructor.GetParameters();
            if ( parameters.Length != this.constructorArguments.Count )
            {
                throw new ArgumentException(
                    $"Constructor {constructor} of type {constructor.DeclaringType} expects {parameters.Length} argument(s)," +
                    $" but {this.constructorArguments.Count} argument(s) were provided." );
            }

            for ( int i = 0; i < parameters.Length; i++ )
            {
                VerifyValue( string.Format(CultureInfo.InvariantCulture, "constructorArguments[{0}]", i ), parameters[i].ParameterType,
                             constructorArguments[i] );
            }
        }

        /// <summary>
        ///   Initializes a new type-safe <see cref = "ObjectConstruction" /> from a <see cref = "CustomAttributeData" />
        /// </summary>
        /// <param name = "customAttributeData">A <see cref = "CustomAttributeData" /></param>
        public ObjectConstruction( CustomAttributeData customAttributeData )
        {
            if ( customAttributeData == null ) throw new ArgumentNullException( nameof(customAttributeData));

#if !LEGACY_CUSTOM_ATTRIBUTE_DATA
            Type[] constructorParametersTypes = new Type[customAttributeData.ConstructorArguments.Count];
            for (int i = 0; i < constructorParametersTypes.Length; i++)
            {
                constructorParametersTypes[0] = customAttributeData.ConstructorArguments[i].ArgumentType;
            }

            this.constructor = customAttributeData.AttributeType.GetConstructor( constructorParametersTypes );
#else
            this.constructor = customAttributeData.Constructor;
#endif

            object[] constructorArgumentsArray = new object[customAttributeData.ConstructorArguments.Count];
            for ( int i = 0; i < constructorArgumentsArray.Length; i++ )
            {
                constructorArgumentsArray[i] = customAttributeData.ConstructorArguments[0].Value;
            }

            this.constructorArguments = new ReadOnlyCollection<object>( constructorArgumentsArray );

            this.namedArguments = new NamedArgumentsCollection( this );
            foreach ( CustomAttributeNamedArgument namedArgument in customAttributeData.NamedArguments )
            {
#if !LEGACY_CUSTOM_ATTRIBUTE_DATA
                this.namedArguments.Add( namedArgument.MemberName, namedArgument.TypedValue.Value );
#else
                this.namedArguments.Add( namedArgument.MemberInfo.Name, namedArgument.TypedValue.Value );
#endif
            }
        }

        private static void VerifyValue( string name, Type type, object value )
        {
            if ( value == null )
            {
                if ( type.IsValueType() )
                    throw new ArgumentNullException( name );
            }
            else
            {
                Type expectedType = type;
                Type valueType = value.GetType();

                // If we have enumerations, we are tolerant with conversions between the enumeration
                // and the intrinsic type.
                if ( expectedType.IsEnum() ) expectedType = Enum.GetUnderlyingType( expectedType );
                if ( valueType.IsEnum() ) valueType = Enum.GetUnderlyingType( valueType );


                if ( !ReflectionHelper.SafeIsAssignableFrom(  expectedType, valueType ) )
                {
                    throw new ArgumentOutOfRangeException( name, string.Format(CultureInfo.InvariantCulture, "Expected value of type '{0}', got '{1}.",
                                                                                type, value.GetType() ) );
                }
            }
        }

        /// <summary>
        ///   Gets the assembly-qualified type name of the object.
        /// </summary>
        public string TypeName
        {
            get { return this.typeName; }
        }

        /// <summary>
        ///   Gets the custom attribute constructor.
        /// </summary>
        public ConstructorInfo Constructor
        {
            get { return this.constructor; }
        }

        /// <summary>
        ///   Gets the arguments passed to the custom attribute constructor.
        /// </summary>
        public IList<object> ConstructorArguments
        {
            get { return this.constructorArguments; }
        }

        /// <summary>
        ///   Gets the collection of named arguments.
        /// </summary>
        /// <remarks>
        ///   This collection is a dictionary associating the name of public a field or property of the
        ///   custom attributes to the value that should be assigned to it.
        /// </remarks>
        public IDictionary<string, object> NamedArguments
        {
            get { return this.namedArguments; }
        }

        private class NamedArgumentsCollection : IDictionary<string, object>
        {
            private readonly ObjectConstruction parent;
            private readonly Dictionary<string, object> dictionary = new Dictionary<string, object>();

            private void VerifyNamedValue( string name, object value )
            {
                if ( this.parent.constructor == null )
                    return;

                Type type;
                PropertyInfo property = this.parent.constructor.DeclaringType.GetProperty( name,
                                                                                           BindingFlags.Public |
                                                                                           BindingFlags.Instance );
                if ( property != null )
                {
                    type = property.PropertyType;
                }
                else
                {
                    FieldInfo field = this.parent.constructor.DeclaringType.GetField( name,
                                                                                      BindingFlags.Public |
                                                                                      BindingFlags.Instance );
                    if ( field != null )
                    {
                        type = field.FieldType;
                    }
                    else
                    {
                        throw new ArgumentException( string.Format(CultureInfo.InvariantCulture, "Cannot find a field or property named {0}.", name ) );
                    }
                }

                VerifyValue( "value", type, value );
            }

            public NamedArgumentsCollection( ObjectConstruction parent )
            {
                this.parent = parent;
            }

            public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
            {
                return this.dictionary.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public void Add( KeyValuePair<string, object> item )
            {
                this.Add( item.Key, item.Value );
            }

            public void Clear()
            {
                this.dictionary.Clear();
            }

            public bool Contains( KeyValuePair<string, object> item )
            {
                return this.dictionary.ContainsKey( item.Key );
            }

            public void CopyTo( KeyValuePair<string, object>[] array, int arrayIndex )
            {
                throw new NotImplementedException();
            }

            public bool Remove( KeyValuePair<string, object> item )
            {
                return this.dictionary.Remove( item.Key );
            }

            public int Count
            {
                get { return this.dictionary.Count; }
            }

            public bool IsReadOnly
            {
                get { return false; }
            }

            public bool ContainsKey( string key )
            {
                return this.dictionary.ContainsKey( key );
            }

            public void Add( string key, object value )
            {
                this.VerifyNamedValue( key, value );
                this.dictionary.Add( key, value );
            }

            public bool Remove( string key )
            {
                return this.dictionary.ContainsKey( key );
            }

            public bool TryGetValue( string key, out object value )
            {
                return this.dictionary.TryGetValue( key, out value );
            }

            public object this[ string key ]
            {
                get { return this.dictionary[key]; }
                set
                {
                    this.VerifyNamedValue( key, value );
                    this.dictionary[key] = value;
                }
            }

            public ICollection<string> Keys
            {
                get { return this.dictionary.Keys; }
            }

            public ICollection<object> Values
            {
                get { return this.Values; }
            }
        }
    }
}
