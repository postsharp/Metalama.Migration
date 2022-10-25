namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression equivalent to the <c>cpblk</c> instruction.
    /// </summary>
    /// <remarks>
    /// <para>This expression type has no equivalent in C#.</para>
    /// </remarks>
    public interface ICopyBufferExpression : IExpression

    {
        /// <summary>
        /// Gets the source address.
        /// </summary>
        IExpression Source { get; }

        /// <summary>
        /// Gets the destination address.
        /// </summary>
        IExpression Destination { get; }

        /// <summary>
        /// Gets the number of bytes to be copied.
        /// </summary>
        IExpression Length { get; }

        /// <summary>
        /// Determines whether the buffers can be modified from a different thread.
        /// </summary>
        bool IsVolatile { get; }

        /// <summary>
        /// Gets the alignment of source and destination buffers.
        /// </summary>
        AddressAlignment Alignment { get; }
    }
}