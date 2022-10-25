// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;

using PostSharp.Reflection;

namespace PostSharp.Serialization.Serializers
{
    internal sealed class FieldInfoSerializer : MetadataSerializer<FieldInfo>
    {
       
        protected override object CreateInstanceImpl( Type type, IArgumentsReader constructorArguments )
        {
            return ReflectionHelper.GetField(constructorArguments.GetValue<Type>("t"), constructorArguments.GetValue<string>("n"));
        }

        
        protected override void SerializeObjectImpl( object obj, IArgumentsWriter argumentsWriter )
        {
            argumentsWriter.SetValue("t", ((FieldInfo)obj).DeclaringType);
            argumentsWriter.SetValue("n", ((FieldInfo)obj).Name);
       
        }
    }
}