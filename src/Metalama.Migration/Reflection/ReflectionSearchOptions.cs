using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    [Flags]
    public enum ReflectionSearchOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Include relationships referencing a derived type (instead of exactly that type).
        /// </summary>
        IncludeDerivedTypes = 1,

        /// <summary>
        /// Include relationships referencing a type signature including the given type (instead of only the given type).
        /// </summary>
        IncludeTypeElement = 2
    }
}