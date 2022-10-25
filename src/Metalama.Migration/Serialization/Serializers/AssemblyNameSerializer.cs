// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;

namespace PostSharp.Serialization.Serializers
{
    internal sealed class AssemblyNameSerializer : ReferenceTypeSerializer
    {
        public override object CreateInstance( Type type, IArgumentsReader constructorArguments )
        {
            return new AssemblyName( constructorArguments.GetValue<string>( "n" ) );
        }

        public override void DeserializeFields( object obj, IArgumentsReader initializationArguments )
        {
        }

        public override void SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments )
        {
            constructorArguments.SetValue( "n", ((AssemblyName)obj).FullName );
        }
    }
}