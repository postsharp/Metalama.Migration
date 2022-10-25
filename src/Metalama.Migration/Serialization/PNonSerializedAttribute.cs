using System;

namespace PostSharp.Serialization
{
    [AttributeUsage( AttributeTargets.Field )]
    public sealed class PNonSerializedAttribute : Attribute { }
}