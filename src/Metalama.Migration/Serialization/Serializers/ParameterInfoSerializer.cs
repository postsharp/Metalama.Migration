// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;

namespace PostSharp.Serialization.Serializers
{
    internal sealed class ParameterInfoSerializer : MetadataSerializer<ParameterInfo>
    {
        protected override object CreateInstanceImpl( Type type, IArgumentsReader constructorArguments)
        {
            MethodBase memberInfo = constructorArguments.GetValue<MethodBase>( "m" );
            return memberInfo.GetParameters()[constructorArguments.GetValue<int>( "o" )];
        }

        protected override void SerializeObjectImpl(object obj, IArgumentsWriter constructorArguments)
        {
            ParameterInfo parameterInfo = (ParameterInfo)obj;
            constructorArguments.SetValue( "m", parameterInfo.Member );
            constructorArguments.SetValue( "o", parameterInfo.Position );
        }
    }
}