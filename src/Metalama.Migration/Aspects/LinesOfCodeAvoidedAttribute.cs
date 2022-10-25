using System;

namespace PostSharp.Aspects
{
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
    public sealed class LinesOfCodeAvoidedAttribute : Attribute
    {
        public LinesOfCodeAvoidedAttribute( int lines )
        {
            Count = lines;
        }

        public int Count { get; }
    }
}