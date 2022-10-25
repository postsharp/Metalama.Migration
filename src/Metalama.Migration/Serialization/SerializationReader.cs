﻿// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    internal sealed class SerializationReader
    {
        private readonly Dictionary<int, SerializationQueueItem<ObjRef>> referenceTypeInstances = new Dictionary<int, SerializationQueueItem<ObjRef>>();

        private readonly SerializationBinaryReader binaryReader;

        private readonly PortableFormatter formatter;
        private readonly bool shouldReportExceptionCause;

        private const byte version = 1;

        internal SerializationReader( Stream stream, PortableFormatter formatter, bool shouldReportExceptionCause )
        {
            this.formatter = formatter;
            this.shouldReportExceptionCause = shouldReportExceptionCause;
            this.binaryReader = new SerializationBinaryReader( new BinaryReader( stream ) );
        }

        public object Deserialize()
        {
            int v = this.binaryReader.ReadCompressedInteger();
            if ( v > version )
            {
                throw new NotSupportedException( "Unsupported formatter version!" );
            }
            
            int instanceId = 1;
            object rootObject = this.ReadObject( instanceId, true, null );
            //TODO: Consider refactoring. Should actually call read type and then decide whether to read object or call ReadValue.
            //But that's a lot of work. For now GetObjRef has a check to ignore instanceId for value types.

            for ( instanceId++; instanceId <= this.referenceTypeInstances.Count; instanceId++ )
            {
                this.InitializeObject( instanceId );
            }

            ISerializationCallback callback;
            if ((callback = rootObject as ISerializationCallback) != null)
            {
                callback.OnDeserialized();
            }

            foreach ( SerializationQueueItem<ObjRef> obj in this.referenceTypeInstances.Values )
            {
                if ((callback = obj.Value.Value as ISerializationCallback) != null && !ReferenceEquals( callback, rootObject ))
                {
                    callback.OnDeserialized();
                }
            }

            return rootObject;
        }

        private object ReadObject( int instanceId, bool initializeObject, SerializationCause cause )
        {
            if ( this.referenceTypeInstances.TryGetValue( instanceId, out SerializationQueueItem<ObjRef> item ) )
                return item.Value.Value;

            ObjRef objRef = this.GetObjRef( instanceId, cause );

            return this.ReadObjectInternal( objRef, instanceId, initializeObject );
        }

        private object ReadObjectInternal( ObjRef objRef, int instanceId, bool initializeObject )
        {
            if ( objRef.Value == null )
            {
                return null;
            }

            // object can be ValueType so we need to check IsInitialized
            if ( !objRef.IsInitialized && initializeObject )
            {
                this.InitializeObject( instanceId );
            }

            return objRef.Value;
        }

        private void InitializeObject( int instanceId )
        {
            SerializationQueueItem<ObjRef> item = this.referenceTypeInstances[instanceId];

            ObjRef objRef = item.Value;
            
            // object could be initialized in constructionData block
            if ( objRef.IsInitialized )
            {
                return;
            }

            objRef.IsInitialized = true;

            Type type = objRef.Value.GetType();
            if ( type.IsArray )
            {
                this.ReadArray( (Array)objRef.Value, item.Cause );
            }
            else
            {
                if ( objRef.IntrinsicType == SerializationIntrinsicType.Class )
                {
                    InstanceFields fields = this.ReadInstanceFields( type, false, item.Cause );

                    if ( objRef.Serializer.IsTwoPhase )
                    {
                        this.TryDeserializeFields( objRef.Serializer, ref objRef.Value, fields, item.Cause );
                    }
                }
                else
                {
                    // We have a primitive type.
                }
            }
        }

        private void TryDeserializeFields( ISerializer serializer, ref object value, InstanceFields fields, SerializationCause cause )
        {
            try
            {
                serializer.DeserializeFields( ref value, fields );
            }
            catch ( PortableSerializationException exception )
            {
                throw PortableSerializationException.CreateWithCause( "Deserialization", value.GetType(), exception, cause );
            }
        }

        private InstanceFields ReadInstanceFields( Type type, bool initializeObjects, SerializationCause cause )
        {
            int fieldCount = this.binaryReader.ReadCompressedInteger();

            if ( fieldCount == 0 )
            {
                return InstanceFields.Empty;
            }

            InstanceFields fields = new InstanceFields( type, this.formatter, fieldCount );

            for ( int i = 0; i < fieldCount; i++ )
            {
                string fieldName = this.binaryReader.ReadDottedString();

                SerializationCause newCause = this.shouldReportExceptionCause ? SerializationCause.WithTypedValue( cause, fieldName, type ) : null;
                object value = this.ReadTypedValue( initializeObjects, newCause );

                fields.Values.Add( fieldName, value );
            }

            return fields;
        }

        private void ReadType( out Type type, out SerializationIntrinsicType intrinsicType )
        {
            intrinsicType = (SerializationIntrinsicType)this.binaryReader.ReadByte();

            switch ( intrinsicType )
            {
                case SerializationIntrinsicType.None:
                    type = null;
                    break;

                case SerializationIntrinsicType.Byte:
                    type = typeof(byte);
                    break;

                case SerializationIntrinsicType.SByte:
                    type = typeof(sbyte);
                    break;

                case SerializationIntrinsicType.Int16:
                    type = typeof(short);
                    break;

                case SerializationIntrinsicType.Int32:
                    type = typeof(int);
                    break;

                case SerializationIntrinsicType.Int64:
                    type = typeof(long);
                    break;

                case SerializationIntrinsicType.UInt16:
                    type = typeof(ushort);
                    break;

                case SerializationIntrinsicType.UInt32:
                    type = typeof(uint);
                    break;

                case SerializationIntrinsicType.UInt64:
                    type = typeof(ulong);
                    break;

                case SerializationIntrinsicType.Single:
                    type = typeof(float);
                    break;

                case SerializationIntrinsicType.Double:
                    type = typeof(double);
                    break;

                case SerializationIntrinsicType.String:
                    type = typeof(string);
                    break;

                case SerializationIntrinsicType.DottedString:
                    type = typeof(DottedString);
                    break;

                case SerializationIntrinsicType.Boolean:
                    type = typeof(bool);
                    break;

                case SerializationIntrinsicType.Enum:
                    type = this.ReadNamedType();
                    if ( !type.IsEnum() )
                    {
                        throw new PortableSerializationException( string.Format(CultureInfo.InvariantCulture, "Type '{0}' is expected to be an enum type.", type ) );
                    }
                    break;

                case SerializationIntrinsicType.Struct:
                    type = this.ReadNamedType();
                    if ( !type.IsValueType() )
                    {
                        throw new PortableSerializationException( string.Format(CultureInfo.InvariantCulture, "Type '{0}' is expected to be a value type.", type ) );
                    }
                    break;

                case SerializationIntrinsicType.Class:
                    type = this.ReadNamedType();
                    if ( type.IsValueType() )
                    {
                        throw new PortableSerializationException( string.Format(CultureInfo.InvariantCulture, "Type '{0}' is expected to be a reference type.", type ) );
                    }
                    break;

                
                case SerializationIntrinsicType.Array:
                    int rank = this.binaryReader.ReadCompressedInteger();
                    Type elementType;
                    SerializationIntrinsicType elementIntrinsicType;
                    this.ReadType( out elementType, out elementIntrinsicType );
                    type = rank == 1 ? elementType.MakeArrayType() : elementType.MakeArrayType( rank );
                    break;

                case SerializationIntrinsicType.Char:
                    type = typeof(char);
                    break;

                case SerializationIntrinsicType.ObjRef:
                    type = typeof(object);
                    break;

                case SerializationIntrinsicType.Type:
                    type = typeof(Type);
                    break;

                case SerializationIntrinsicType.GenericTypeParameter:
                    type = this.ReadGenericTypeParameter();
                    break;

                case SerializationIntrinsicType.GenericMethodParameter:
                    type = this.ReadGenericMethodParameter();
                    break;

                default:
                    throw new PortableSerializationException($"Invalid type: {intrinsicType}.");
            }

         
        }

        private Type ReadNamedType()
        {
            SerializationIntrinsicTypeFlags flags = (SerializationIntrinsicTypeFlags) this.binaryReader.ReadByte();
            switch ( flags )
            {
                case SerializationIntrinsicTypeFlags.Default:
                    {
                        AssemblyTypeName typeName = this.ReadTypeName();
                        return this.GetType( typeName );
                    }

                case SerializationIntrinsicTypeFlags.Generic:
                    {
                        AssemblyTypeName typeName = this.ReadTypeName();
                        Type genericType = this.GetType(typeName);
                        int arity = this.binaryReader.ReadCompressedInteger();

                        if (arity > 0)
                        {
                            Type[] genericArguments = new Type[arity];
                            for (int i = 0; i < arity; i++)
                            {
                                genericArguments[i] = this.ReadType();
                            }
                            return genericType.MakeGenericType(genericArguments);
                        }
                        else
                        {
                            return genericType;
                        }
                    }

                    case SerializationIntrinsicTypeFlags.MetadataIndex:
                    {
                        int index = this.binaryReader.ReadCompressedInteger();
                        return (Type) this.formatter.MetadataDispenser.GetMetadata( index );
                    }

                default:
                    throw new PortableSerializationException();
            }
            
        }


        private Type ReadType()
        {
            Type type;
            SerializationIntrinsicType intrinsicType;
            this.ReadType( out type, out intrinsicType );
            return type;
        }

        private object ReadTypedValue( bool initializeObjects, SerializationCause cause )
        {
            SerializationIntrinsicType intrinsicType;
            Type type;

            this.ReadType( out type, out intrinsicType );

            if ( type == null )
            {
                return null;
            }

            object value = this.ReadValue( intrinsicType, type, initializeObjects, cause );
            return value;
        }

        private object ReadValue( SerializationIntrinsicType intrinsicType, Type type, bool initializeObject, SerializationCause cause )
        {
            if ( intrinsicType == SerializationIntrinsicType.None )
            {
                intrinsicType = SerializationIntrinsicTypeExtensions.GetIntrinsicType( type );
            }

            object value;
            switch ( intrinsicType )
            {
                case SerializationIntrinsicType.Byte:
                    value = this.binaryReader.ReadByte();
                    break;

                case SerializationIntrinsicType.SByte:
                    value = this.binaryReader.ReadSByte();
                    break;

                case SerializationIntrinsicType.Int16:
                    value = (short)this.binaryReader.ReadCompressedInteger();
                    break;

                case SerializationIntrinsicType.Int32:
                    value = (int)this.binaryReader.ReadCompressedInteger();
                    break;

                case SerializationIntrinsicType.Int64:
                    value = (long)this.binaryReader.ReadCompressedInteger();
                    break;

                case SerializationIntrinsicType.UInt16:
                    value = (ushort)this.binaryReader.ReadCompressedInteger();
                    break;

                case SerializationIntrinsicType.UInt32:
                    value = (uint)this.binaryReader.ReadCompressedInteger();
                    break;

                case SerializationIntrinsicType.UInt64:
                    value = (ulong)this.binaryReader.ReadCompressedInteger();
                    break;

                case SerializationIntrinsicType.Single:
                    value = this.binaryReader.ReadSingle();
                    break;

                case SerializationIntrinsicType.Double:
                    value = this.binaryReader.ReadDouble();
                    break;

                case SerializationIntrinsicType.String:
                    value = this.binaryReader.ReadString();
                    break;

                case SerializationIntrinsicType.DottedString:
                    value = this.binaryReader.ReadDottedString();
                    break;

                case SerializationIntrinsicType.Boolean:
                    value = this.binaryReader.ReadByte() != 0;
                    break;

                case SerializationIntrinsicType.Struct:
                    value = this.ReadStruct( type, cause );
                    break;

                case SerializationIntrinsicType.ObjRef:
                    value = this.ReadObjRef( initializeObject, cause );
                    break;

                case SerializationIntrinsicType.Char:
                    value = (char)this.binaryReader.ReadCompressedInteger();
                    break;

                case SerializationIntrinsicType.Type:
                    value = this.ReadType();
                    break;

                case SerializationIntrinsicType.Enum:
                    Integer enumValue = this.binaryReader.ReadCompressedInteger();
                    // explicite cast is needed due to check in Enum.ToObject (it throws if type is not numeric type)
                    value = enumValue.IsNegative ? Enum.ToObject( type, (long)enumValue ) : Enum.ToObject( type, (ulong)enumValue );
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(intrinsicType));
            }
            return value;
        }

        private Type ReadGenericTypeParameter()
        {
            Type declaringType = this.ReadType();
            int position = this.binaryReader.ReadCompressedInteger();
            return declaringType.GetGenericArguments()[position];
        }

        private Type ReadGenericMethodParameter()
        {
            MethodInfo declaringMethod = (MethodInfo)this.ReadMethod();
            int position = this.binaryReader.ReadCompressedInteger();
            return declaringMethod.GetGenericArguments()[position];
        }

        private MethodBase ReadMethod()
        {
            Type declaringType = this.ReadType();
            string methodName = this.binaryReader.ReadString();
            string methodSignature = this.binaryReader.ReadString();

            return ReflectionHelper.GetMethod( declaringType, methodName, methodSignature );
        }

        private Type GetType( AssemblyTypeName typeName )
        {
            return this.formatter.Binder.BindToType( typeName.TypeName, typeName.AssemblyName );
        }

        private void ReadArray( Array array, SerializationCause cause )
        {
            int[] indices = new int[array.Rank];

            this.ReadArrayElements( array, array.GetType().GetElementType(), indices, 0, cause );
        }

        private void ReadArrayElements( Array array, Type elementType, int[] indices, int currentDimension, SerializationCause cause )
        {
            int length = array.GetLength( currentDimension );
            int lowerBound = array.GetLowerBound( currentDimension );

            if ( currentDimension + 1 < indices.Length )
            {
                for ( int i = lowerBound; i < lowerBound + length; i++ )
                {
                    indices[currentDimension] = i;
                    this.ReadArrayElements( array, elementType, indices, currentDimension + 1, cause );
                }
            }
            else
            {
                SerializationIntrinsicType elementIntrinsicType = SerializationIntrinsicTypeExtensions.GetIntrinsicType( elementType, true );

                for ( int i = lowerBound; i < lowerBound + length; i++ )
                {
                    indices[currentDimension] = i;

                    SerializationCause newCause = this.shouldReportExceptionCause ? SerializationCause.WithIndices( cause, indices ) : null;
                    if ( SerializationIntrinsicTypeExtensions.IsPrimitiveIntrinsic( elementIntrinsicType ) )
                    {
                        array.SetValue( this.ReadValue( elementIntrinsicType, elementType, false, newCause ), indices );
                    }
                    else
                    {
                        array.SetValue( this.ReadTypedValue( false, newCause ), indices );
                    }
                }
            }
        }

        private object ReadObjRef( bool initializeObject, SerializationCause cause )
        {
            int instanceId = this.binaryReader.ReadCompressedInteger();

            return this.ReadObject( instanceId, initializeObject, cause );
        }

        private ObjRef GetObjRef( int instanceId, SerializationCause cause )
        {
            if ( this.referenceTypeInstances.TryGetValue( instanceId, out SerializationQueueItem<ObjRef> item ) )
                return item.Value;

            // Create an uninitialized instance for this type.
            this.ReadType( out Type type, out SerializationIntrinsicType intrinsicType );

            if ( cause == null && this.shouldReportExceptionCause )
                // This is the root.
                cause = SerializationCause.WithTypedValue( null, "root", type );

            if ( type == null )
                return ObjRef.Empty;

            object value;
            ISerializer serializer;
            if ( intrinsicType == SerializationIntrinsicType.Array )
            {
                int[] lengths = new int[type.GetArrayRank()];
                int[] lowerBounds = new int[type.GetArrayRank()];
                for ( int i = 0; i < lengths.Length; i++ )
                {
                    lengths[i] = this.binaryReader.ReadCompressedInteger();
                    lowerBounds[i] = this.binaryReader.ReadCompressedInteger();
                }

                value = Array.CreateInstance( type.GetElementType(), lengths, lowerBounds );

                serializer = null;
            }
            else if ( intrinsicType == SerializationIntrinsicType.Class || intrinsicType == SerializationIntrinsicType.Struct )
            {
                InstanceFields fields = this.ReadInstanceFields( type, true, cause );
                serializer = this.formatter.SerializerProvider.GetSerializer( type );

                value = this.TryCreateInstance( serializer, type, fields, cause );
            }
            else
            {
                value = this.ReadValue( intrinsicType, type, true, cause );
                serializer = null;
            }

            ObjRef objRef = new ObjRef( value, serializer, intrinsicType );

            if ( !type.IsValueType() )
            {
                this.referenceTypeInstances.Add( instanceId, new SerializationQueueItem<ObjRef>(objRef, cause));
            }
            else
            {
                // ValueTypes are always initialized
                objRef.IsInitialized = true;
            }

            return objRef;
        }

        private object TryCreateInstance( ISerializer serializer, Type type, InstanceFields fields, SerializationCause cause )
        {
            try
            {
                return serializer.CreateInstance( type, fields );
            }
            catch ( PortableSerializationException exception )
            {
                throw PortableSerializationException.CreateWithCause( "Deserialization", type, exception, cause );
            }
        }

        private object ReadStruct( Type type, SerializationCause cause )
        {
            InstanceFields fields = this.ReadInstanceFields( type, true, cause );

            ISerializer serializer = this.formatter.SerializerProvider.GetSerializer( type );

            object value = this.TryCreateInstance( serializer, type, fields, cause );
            
            this.TryDeserializeFields( serializer, ref value, fields, cause );

            return value;
        }

        private AssemblyTypeName ReadTypeName()
        {
            return new AssemblyTypeName( this.binaryReader.ReadDottedString(), this.binaryReader.ReadString() );
        }

        private sealed class InstanceFields : IArgumentsReader
        {
            public static readonly InstanceFields Empty = new InstanceFields();

            private readonly Type type;

            public readonly Dictionary<string, object> Values;

            private readonly PortableFormatter formatter;

            private InstanceFields()
            {
                this.type = null;
                this.formatter = null;
                this.Values = null;
            }

            public InstanceFields( Type type, PortableFormatter formatter, int capacity )
            {
                this.type = type;
                this.formatter = formatter;
                this.Values = new Dictionary<string, object>( capacity, StringComparer.Ordinal );
            }

            public bool TryGetValue<T>( string name, out T value, string scope = null )
            {
                if (this.Values == null)
                {
                    value = default(T);
                    return false;
                }

                object valueObj;

                if (scope != null)
                {
                    name = scope + "." + name;
                }

                if (!this.Values.TryGetValue(name, out valueObj))
                {
                    value = default(T);
                    return false;
                }

                if (valueObj == null)
                {
                    value = default(T);
                    return true;
                }

                ISerializer serializer = null;

                if (!typeof(T).HasElementType)
                {
                    this.formatter.SerializerProvider.TryGetSerializer(typeof(T), out serializer);
                }

                try
                {
                    if (serializer != null)
                    {
                        value = (T)serializer.Convert(valueObj, typeof(T));
                    }
                    else
                    {
                        value = (T)valueObj;

                    }
                    return true;
                }
                catch (Exception e)
                {
                    #if LEGACY_REFLECTION_API
                    Type GetElementType(Type type)
                    {
                        if (type.HasElementType)
                        {
                            return type.GetElementType();
                        }
                        else if (type.GetTypeDefinition() == typeof(Nullable<>))
                        {
                            return type.GetGenericArguments()[0];
                        }
                        else
                        {
                            return type;
                        }
                    }
#endif

                    string FormatTypeName(Type type)
                    {
#if LEGACY_REFLECTION_API
                        return type.AssemblyQualifiedName + " (" + GetElementType(type).Assembly.Location + ")";
#else
                        return type.AssemblyQualifiedName;
#endif
                    }


                    throw new PortableSerializationException(
                        string.Format(CultureInfo.InvariantCulture,
                            "Error reading value of key '{0}' in type '{1}': cannot convert type '{2}' into '{3}': {4}",
                            name,
                            this.type,
                            FormatTypeName( valueObj.GetType() ),
                            FormatTypeName( typeof(T) ),
                            e.Message),
                        e);
                }
            }

            public T GetValue<T>( string name, string scope = null )
            {
                T value;
                this.TryGetValue( name, out value, scope );
                return value;
            }

            public IMetadataDispenser MetadataDispenser { get { return this.formatter.MetadataDispenser;} }
        }

        private class ObjRef
        {
            public static readonly ObjRef Empty = new ObjRef();

            public object Value;

            public readonly SerializationIntrinsicType IntrinsicType;

            public readonly ISerializer Serializer;

            public bool IsInitialized;

            private ObjRef()
            {
                this.IntrinsicType = SerializationIntrinsicType.None;
            }

            public ObjRef( object value, ISerializer serializer, SerializationIntrinsicType intrinsicType )
            {
                this.Value = value;
                this.Serializer = serializer;
                this.IntrinsicType = intrinsicType;
                this.IsInitialized = false;
            }
        }
    }
}