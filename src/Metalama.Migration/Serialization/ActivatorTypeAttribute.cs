using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    [AttributeUsage( AttributeTargets.Assembly )]
    public sealed class ActivatorTypeAttribute : Attribute
    {
        public ActivatorTypeAttribute( Type activatorType )
        {
            ActivatorType = activatorType;
        }

        public Type ActivatorType { get; }
    }
}