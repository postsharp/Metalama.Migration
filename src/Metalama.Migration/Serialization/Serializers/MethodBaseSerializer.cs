// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;

using PostSharp.Reflection;

namespace PostSharp.Serialization.Serializers
{
    internal abstract class MethodBaseSerializer<T> : MetadataSerializer<T> where T : MethodBase
    {
        protected override object CreateInstanceImpl( Type type, IArgumentsReader constructorArguments)
        {
            return ReflectionHelper.GetMethod(
                constructorArguments.GetValue<Type>( "t" ), constructorArguments.GetValue<string>( "n" ), constructorArguments.GetValue<string>( "s" ) );
        }
        
        protected override void SerializeObjectImpl(object obj, IArgumentsWriter constructorArguments)
        {
            constructorArguments.SetValue( "t", ((MethodBase)obj).DeclaringType );
            constructorArguments.SetValue( "n", ((MethodBase)obj).Name );
            constructorArguments.SetValue( "s", obj.ToString() );
        }
    }
}