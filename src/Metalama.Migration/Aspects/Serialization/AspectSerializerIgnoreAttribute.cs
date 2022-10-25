using System;

namespace PostSharp.Aspects.Serialization
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field )]
    internal sealed class AspectSerializerIgnoreAttribute : Attribute { }
}