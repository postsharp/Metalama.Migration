// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
#if SERIALIZABLE
using System;
using System.Runtime.Serialization;
using System.Security;

namespace PostSharp.Aspects.Serialization
{
    [Serializable]
    internal sealed class MetadataSerializationHolder : ISerializable,  IObjectReference
    {
        private readonly int index;

        public MetadataSerializationHolder()
        {
            
        }

#pragma warning disable IDE0060, CA1801 // Remove unused parameter 
        public MetadataSerializationHolder(SerializationInfo info, StreamingContext context)
#pragma warning restore IDE0060, CA1801 // Remove unused parameter 
        {
            this.index = info.GetInt32( "index" );
        }

        [SecurityCritical]
        public void GetObjectData( SerializationInfo info, StreamingContext context )
        {
            throw new NotSupportedException();
        }

        [SecurityCritical]
        public object GetRealObject( StreamingContext context )
        {
            object realObject = BinaryAspectSerializer.CurrentMetadataDispenser.GetMetadata(this.index);
            return realObject;
        }
    }
}
#endif
