using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.LamaNonSerializedAttribute"/>.
    /// </summary>
    [AttributeUsage( AttributeTargets.Field )]
    public sealed class PNonSerializedAttribute : Attribute { }
}