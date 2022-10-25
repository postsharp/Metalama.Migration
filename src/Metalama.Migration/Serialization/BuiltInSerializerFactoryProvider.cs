// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

using PostSharp.Reflection;
using PostSharp.Serialization.Serializers;

namespace PostSharp.Serialization
{
    internal sealed class BuiltInSerializerFactoryProvider : SerializerFactoryProvider
    {
        public BuiltInSerializerFactoryProvider(ActivatorProvider activatorProvider)
            : base( new ReflectionSerializationProvider(activatorProvider), activatorProvider )
        {
            // intrinsic types
            this.AddSerializer<bool, BooleanSerializer>();
            this.AddSerializer<byte, ByteSerializer>();
            this.AddSerializer<char, CharSerializer>();
            this.AddSerializer<short, Int16Serializer>();
            this.AddSerializer<int, Int32Serializer>();
            this.AddSerializer<long, Int64Serializer>();
            this.AddSerializer<ushort, UInt16Serializer>();
            this.AddSerializer<uint, UInt32Serializer>();
            this.AddSerializer<ulong, UInt64Serializer>();
            this.AddSerializer<sbyte, SByteSerializer>();
            this.AddSerializer<float, SingleSerializer>();
            this.AddSerializer<decimal, DecimalSerializer>();
            this.AddSerializer<string, StringSerializer>();
            this.AddSerializer<double, DoubleSerializer>();

            this.AddSerializer<DateTime, DateTimeSerializer>();
            this.AddSerializer<TimeSpan, TimeSpanSerializer>();
            this.AddSerializer<DottedString, DottedStringSerializer>();
            this.AddSerializer<Guid, GuidSerializer>();
            this.AddSerializer<DeclarationIdentifier,DeclarationIdentifierSerializer>();
            this.AddSerializer<CultureInfo, CultureInfoSerializer>();

            // reflection types
            this.AddSerializer<Type, TypeSerializer>();
            this.AddSerializer<MethodInfo, MethodInfoSerializer>();
            this.AddSerializer<ConstructorInfo, ConstructorInfoSerializer>();
            this.AddSerializer<PropertyInfo, PropertyInfoSerializer>();
            this.AddSerializer<FieldInfo, FieldInfoSerializer>();
            this.AddSerializer<EventInfo, EventInfoSerializer>();
            this.AddSerializer<Assembly, AssemblySerializer>();
            this.AddSerializer<AssemblyName, AssemblyNameSerializer>();
            this.AddSerializer<LocationInfo, LocationInfoSerializer>();
            this.AddSerializer<ParameterInfo, ParameterInfoSerializer>();

            // collections
            this.AddSerializer( typeof(List<>), typeof(ListSerializer<>) );
            this.AddSerializer( typeof(Dictionary<,>), typeof(DictionarySerializer<,>) );
            this.MakeReadOnly();
        }

        public override Type GetSurrogateType( Type objectType )
        {
            return GetAbstractReflectionType( objectType ) ?? objectType;
        }

        public override ISerializerFactory GetSerializerFactory( Type objectType )
        {
            return base.GetSerializerFactory( GetAbstractReflectionType( objectType ) ?? objectType );
        }

        public static Type GetAbstractReflectionType( Type type )
        {
            if ( ReflectionHelper.SafeIsAssignableFrom( typeof(MethodInfo), type ) )
            {
                return typeof(MethodInfo);
            }

            if (ReflectionHelper.SafeIsAssignableFrom(typeof(ConstructorInfo), type))
            {
                return typeof(ConstructorInfo);
            }

            if ( ReflectionHelper.SafeIsAssignableFrom( typeof(FieldInfo), type ) )
            {
                return typeof(FieldInfo);
            }

            if ( ReflectionHelper.SafeIsAssignableFrom( typeof(Assembly), type ) )
            {
                return typeof(Assembly);
            }

            if ( ReflectionHelper.SafeIsAssignableFrom( typeof(EventInfo), type ) )
            {
                return typeof(EventInfo);
            }

            if ( ReflectionHelper.SafeIsAssignableFrom( typeof(ParameterInfo), type ) )
            {
                return typeof(ParameterInfo);
            }

            if ( ReflectionHelper.SafeIsAssignableFrom( typeof(PropertyInfo), type ) )
            {
                return typeof(PropertyInfo);
            }

   
            return null;
        }
    }
}