using System;

namespace PostSharp.Aspects
{
    [Flags]
    public enum SemanticallyAdvisedMethodKinds
    {
        None = 0,

        Async = 1 << 0,

        ReturnsAwaitable = 1 << 1,

        Iterator = 1 << 2,

        ReturnsEnumerable = 1 << 3,

        AsyncIterator = 1 << 4,

        Default = Async | ReturnsAwaitable | Iterator | AsyncIterator,

        All = Default | ReturnsEnumerable
    }
}