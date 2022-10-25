using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// There is no equivalent in Metalama.
    /// </summary>
    [Flags]
    public enum ReflectionSearchOptions
    {
        None = 0,

        IncludeDerivedTypes = 1,

        IncludeTypeElement = 2
    }
}