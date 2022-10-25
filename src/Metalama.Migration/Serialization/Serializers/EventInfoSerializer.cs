// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Globalization;
using System.Reflection;

using PostSharp.Reflection;

namespace PostSharp.Serialization.Serializers
{
    internal sealed class EventInfoSerializer : MetadataSerializer<EventInfo>
    {
        protected override object CreateInstanceImpl( Type type, IArgumentsReader constructorArguments )
        {
            Type declaringType = constructorArguments.GetValue<Type>( "t" );
            string eventName = constructorArguments.GetValue<string>( "n" );

            EventInfo eventInfo = declaringType.GetEvent(eventName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            if (eventInfo == null)
            {
                throw new MissingMemberException( string.Format( CultureInfo.InvariantCulture,  "Missing event: {0}.{1}.", declaringType, eventName));
            }

            return eventInfo;

        }

        protected override void SerializeObjectImpl(object obj, IArgumentsWriter argumentsWriter)
        {
            argumentsWriter.SetValue("t", ((EventInfo)obj).DeclaringType);
            argumentsWriter.SetValue("n", ((EventInfo)obj).Name);
        }
    }
}