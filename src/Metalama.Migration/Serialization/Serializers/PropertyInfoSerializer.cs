// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;

using PostSharp.Reflection;

namespace PostSharp.Serialization.Serializers
{
    internal sealed class PropertyInfoSerializer : MetadataSerializer<PropertyInfo>
    {
        protected override object CreateInstanceImpl( Type type, IArgumentsReader constructorArguments)
        {
            return ReflectionHelper.GetProperty(
                constructorArguments.GetValue<Type>( "t" ), constructorArguments.GetValue<string>( "n" ), constructorArguments.GetValue<string>( "s" ) );
        }

        protected override void SerializeObjectImpl(object obj, IArgumentsWriter constructorArguments)
        {
            constructorArguments.SetValue( "t", ((PropertyInfo)obj).DeclaringType );
            constructorArguments.SetValue( "n", ((PropertyInfo)obj).Name );
            constructorArguments.SetValue( "s", obj.ToString() );
        }
    }
}