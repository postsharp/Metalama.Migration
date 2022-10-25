using System;

namespace PostSharp.Reflection
{
    [Flags]
    public enum ReflectionSearchOptions
    {
        None = 0,

        IncludeDerivedTypes = 1,

        IncludeTypeElement = 2
    }
}