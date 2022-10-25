using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// This feature is not implemented in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public sealed class LinesOfCodeAvoidedAttribute : Attribute
    {
        public LinesOfCodeAvoidedAttribute( int lines )
        {
            Count = lines;
        }

        public int Count { get; }
    }
}