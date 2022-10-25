// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

using PostSharp.Reflection;

namespace PostSharp.Serialization.Serializers
{
    internal sealed class LocationInfoSerializer : MetadataSerializer<LocationInfo>
    {
        protected override object CreateInstanceImpl( Type type, IArgumentsReader constructorArguments )
        {
            return ReflectionHelper.GetLocation(
                constructorArguments.GetValue<Type>("t"),
                constructorArguments.GetValue<string>("n"),
                constructorArguments.GetValue<string>("s"),
                (LocationKind)constructorArguments.GetValue<int>("k"));
        }

        protected override void SerializeObjectImpl(
            object obj, IArgumentsWriter constructorArguments)
        {
            constructorArguments.SetValue( "t", ((LocationInfo)obj).DeclaringType );
            constructorArguments.SetValue( "n", ((LocationInfo)obj).Name );
            constructorArguments.SetValue( "s", obj.ToString() );
            constructorArguments.SetValue( "k", (int)((LocationInfo)obj).LocationKind );
        }
    }
}