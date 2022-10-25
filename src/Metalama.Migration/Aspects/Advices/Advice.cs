using System;

namespace PostSharp.Aspects.Advices
{
#pragma warning disable CA1710 // Identifiers should have correct suffix

// TODO: Rename all types to respect the convention.

    public abstract class Advice : Attribute
    {
        public string Description { get; set; }

        public int LinesOfCodeAvoided { get; set; }
    }
}