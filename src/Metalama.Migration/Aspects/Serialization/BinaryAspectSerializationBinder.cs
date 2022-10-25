// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Globalization;
using PostSharp.Reflection;
#if BINARY_FORMATTER
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    ///   Implementation of <see cref = "SerializationBinder" /> used at runtime when aspect instances
    ///   are deserialized. By overriding the default binder, you can resolve assembly names differently.
    ///   This can be useful if assemblies have been renamed or merged between PostSharp run and execution
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public class BinaryAspectSerializationBinder : SerializationBinder
    {
        private readonly Dictionary<string, Assembly> assemblyCache = new Dictionary<string, Assembly>( StringComparer.OrdinalIgnoreCase );
        private readonly Dictionary<string, Type> typeCache = new Dictionary<string, Type>();

        private readonly Dictionary<string, string> policies =
            new Dictionary<string, string>( StringComparer.OrdinalIgnoreCase );

        /// <summary>
        /// Initializes a new <seealso cref="BinaryAspectSerializationBinder"/>.
        /// </summary>
        public BinaryAspectSerializationBinder()
        {
        }

        /// <inheritdoc />
        public override Type BindToType( string assemblyName, string typeName )
        {
            if ( assemblyName == "<md>" )
                return (Type) BinaryAspectSerializer.CurrentMetadataDispenser.GetMetadata( int.Parse( typeName, NumberStyles.HexNumber, CultureInfo.InvariantCulture ) );

            // We fall back here if we are deserializing aspects compiled with an older version of PostSharp.

            string fullTypeName =  ReflectionHelper.GetAssemblyQualifiedTypeName(typeName, assemblyName).ToLowerInvariant();
            Type type;
            if ( !this.typeCache.TryGetValue( fullTypeName, out type ) )
            {
                lock ( this.typeCache )
                {
                    if ( !this.typeCache.TryGetValue( fullTypeName, out type ) )
                    {
                        Assembly assembly;
                        if ( !this.assemblyCache.TryGetValue( assemblyName, out assembly ) )
                        {
                            try
                            {
                                assembly = Assembly.Load( assemblyName );
                            }
                            catch ( FileNotFoundException )
                            {
                                string newAssemblyName;
                                if ( this.policies.TryGetValue( new AssemblyName( assemblyName ).Name, out newAssemblyName ) )
                                {
                                    assembly = Assembly.Load( newAssemblyName );
                                }
                                else throw;
                            }
                            this.assemblyCache.Add( assemblyName, assembly );
                        }

                        type = assembly.GetType( typeName );
                        this.typeCache.Add( fullTypeName, type );
                    }
                }
            }

            return type;
        }
    }
}

#endif