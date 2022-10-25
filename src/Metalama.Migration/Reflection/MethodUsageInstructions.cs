using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Instructions whose operands can reference a declaration.
    /// </summary>
    /// <seealso cref="MethodUsageCodeReference"/>.
    [Flags]
    public enum MethodUsageInstructions
    {
        /// <summary>
        /// No instruction.
        /// </summary>
        None,

        /// <summary>
        /// Get field value.
        /// </summary>
        LoadField = 1,

        /// <summary>
        /// Set field value.
        /// </summary>
        StoreField = 2,

        /// <summary>
        /// Call to a static or sealed method.
        /// </summary>
        Call = 4,

        /// <summary>
        /// Call to a virtual method.
        /// </summary>
        CallVirtual = 8,

        /// <summary>
        /// Creation of a new instance (invoke the constructor).
        /// </summary>
        NewObject = 16,

        /// <summary>
        /// Get field address.
        /// </summary>
        LoadFieldAddress = 32,

        /// <summary>
        /// Load the metadata token (for instance <c>typeof</c>).
        /// </summary>
        LoadMetadata = 64,

        /// <summary>
        /// Load the address of a static or sealed method (delegate instantiation).
        /// </summary>
        LoadMethodAddress = 128,

        /// <summary>
        /// Load the address of a virtual method (delegate instantiation).
        /// </summary>
        LoadMethodAddressVirtual = 0x100,

        /// <summary>
        /// Type casting.
        /// </summary>
        Cast = 0x200,

        /// <summary>
        /// "Safe" type casting (<c>as</c> or <c>is</c> in C#).
        /// </summary>
        IsInstance = 0x400,

        /// <summary>
        /// Get the size of a value type (<c>sizeof</c> in C#).
        /// </summary>
        SizeOf = 0x800,

        /// <summary>
        /// Create a new array of a type.
        /// </summary>
        NewArray = 0x1000
    }
}