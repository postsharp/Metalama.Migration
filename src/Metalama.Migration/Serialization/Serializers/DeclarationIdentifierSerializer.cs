// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Reflection;

namespace PostSharp.Serialization.Serializers
{
    internal sealed class DeclarationIdentifierSerializer : ValueTypeSerializer<DeclarationIdentifier>
    {
        public override void SerializeObject(DeclarationIdentifier value, IArgumentsWriter writer)
        {
            writer.SetValue("v", value.Value);
        }

        public override DeclarationIdentifier DeserializeObject(IArgumentsReader reader)
        {
            return new DeclarationIdentifier(reader.GetValue<long>("v"));
        }
    }
}
