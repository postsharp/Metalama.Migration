#pragma warning disable CA1028 // Enum Storage should be Int32

namespace PostSharp.Reflection
{
    public enum ParameterKind : byte
    {
        InValue,

        ByRefIn,

        ByRefOut,

        ByRefInOut,

        ReturnValue,

        ReturnRef
    }
}