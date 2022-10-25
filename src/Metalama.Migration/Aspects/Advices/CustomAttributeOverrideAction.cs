namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Behavior of <see cref = "CopyCustomAttributesAttribute" /> when a custom
    ///   attribute of the same type already exists on the target declaration.
    /// </summary>
    /// <seealso cref = "CopyCustomAttributesAttribute" />
    public enum CustomAttributeOverrideAction
    {
        /// <summary>
        ///   Default (<see cref = "Fail" />).
        /// </summary>
        Default,

        /// <summary>
        ///   Emits an error message.
        /// </summary>
        Fail = Default,

        /// <summary>
        ///   Silently ignore this custom attribute (does not copy it, without
        ///   error message).
        /// </summary>
        Ignore,

        /// <summary>
        ///   Adds a new copy (possibly duplicate) of the custom attribute.
        /// </summary>
        Add,

        /// <summary>
        ///   Merges the existing custom attribute with the template custom attribute
        ///   by adding properties and fields. If the existing custom attribute defines
        ///   the same properties and fields as the template custom attribute, 
        ///   they are not overridden.
        /// </summary>
        /// <remarks>
        ///   Constructors arguments of the template custom attribute are 
        ///   ignored during merging.
        /// </remarks>
        MergeAddProperty,

        /// <summary>
        ///   Merges the existing custom attribute with the template custom attribute
        ///   by adding and replacing properties and fields. If the existing custom
        ///   attribute defines the same properties and fields as the template custom
        ///   attribute, they are replaced by the values defined in the template
        ///   custom attribute.
        /// </summary>
        /// <remarks>
        ///   Constructors arguments of the template custom attribute are 
        ///   ignored during merging.
        /// </remarks>
        MergeReplaceProperty
    }
}