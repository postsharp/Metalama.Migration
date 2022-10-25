// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Serialization.Serializers
{
    internal sealed class AssemblySerializer : ReferenceTypeSerializer
    {
        public override object CreateInstance( Type type, IArgumentsReader constructorArguments )
        {
            return ReflectionApiWrapper.LoadAssembly( constructorArguments.GetValue<string>( "n" ) ); // TODO: should we load serialized assembly
        }

        public override void DeserializeFields( object obj, IArgumentsReader initializationArguments )
        {
        }

        public override void SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments )
        {
            constructorArguments.SetValue( "n", ((Assembly)obj).FullName );
        }
    }
}