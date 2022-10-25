using System;

namespace PostSharp.Aspects.Advices
{
#pragma warning disable CA1710 // Identifiers should have correct suffix

    public abstract class Advice : Attribute
    {
        public string Description { get; set; }

        public int LinesOfCodeAvoided { get; set; }
    }
}