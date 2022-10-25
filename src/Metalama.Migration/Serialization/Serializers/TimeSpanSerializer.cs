// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization.Serializers
{
    internal sealed class TimeSpanSerializer : ValueTypeSerializer<TimeSpan>
    {
        public override void SerializeObject( TimeSpan value, IArgumentsWriter writer )
        {
            writer.SetValue( "t", value.Ticks );
        }

        public override TimeSpan DeserializeObject( IArgumentsReader reader )
        {
            return new TimeSpan( reader.GetValue<long>( "t" ) );
        }
    }
}