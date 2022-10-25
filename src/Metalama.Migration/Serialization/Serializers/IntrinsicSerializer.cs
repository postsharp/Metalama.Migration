// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization.Serializers
{
    internal abstract class IntrinsicSerializer<T> : ISerializer
    {
        public abstract object Convert( object value, Type targetType );

        object ISerializer.CreateInstance( Type type, IArgumentsReader constructorArguments )
        {
            return constructorArguments.GetValue<T>("_");
        }

        void ISerializer.DeserializeFields( ref object obj, IArgumentsReader initializationArguments )
        {
        }

        void ISerializer.SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments )
        {
            constructorArguments.SetValue("_", (T)obj);
        }

        public bool IsTwoPhase
        {
            get { return false; }
        }

        protected void WriteType( SerializationBinaryWriter writer, SerializationIntrinsicType type )
        {
            writer.WriteByte( (byte) type );
        }
    }
}