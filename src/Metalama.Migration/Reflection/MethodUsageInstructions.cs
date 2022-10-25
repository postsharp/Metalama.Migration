using System;

namespace PostSharp.Reflection
{
    [Flags]
    public enum MethodUsageInstructions
    {
        None,

        LoadField = 1,

        StoreField = 2,

        Call = 4,

        CallVirtual = 8,

        NewObject = 16,

        LoadFieldAddress = 32,

        LoadMetadata = 64,

        LoadMethodAddress = 128,

        LoadMethodAddressVirtual = 0x100,

        Cast = 0x200,

        IsInstance = 0x400,

        SizeOf = 0x800,

        NewArray = 0x1000
    }
}