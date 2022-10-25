namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Kind of inheritance of <see cref = "MulticastAttribute" />.
    /// </summary>
    public enum MulticastInheritance
    {
        /// <summary>
        ///   No inheritance.
        /// </summary>
        None,

        /// <summary>
        ///   The instance is inherited to children of the original element,
        ///   but multicasting is not applied to members of children.
        /// </summary>
        /// <remarks>
        ///   See https://doc.postsharp.net/multicast-inheritance.
        /// </remarks>
        Strict,

        /// <summary>
        ///   The instance is inherited to children of the original element
        ///   and multicasting is applied to members of children.
        /// </summary>
        /// <remarks>
        ///   See https://doc.postsharp.net/multicast-inheritance.
        /// </remarks>
        Multicast
    }
}