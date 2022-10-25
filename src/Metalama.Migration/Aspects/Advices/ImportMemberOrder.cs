namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Enumeration of moments when members should be imported into an aspect.
    /// </summary>
    /// <seealso cref = "ImportMemberAttribute" />
    public enum ImportMemberOrder
    {
        /// <summary>
        ///   <see cref = "AfterIntroductions" />
        /// </summary>
        Default,

        /// <summary>
        ///   Before the aspect introduces its own members. This is similar to calling the overridden method using the
        ///   <c>base</c> keyword in C#. The overridden method implementation is always selected, even if the method
        ///   is virtual.
        /// </summary>
        BeforeIntroductions,

        /// <summary>
        ///   After the aspect introduces its own members. Note that importing a member introduced by the current
        ///   aspect makes sense only if the member has been introduced as virtual; in this case, the
        ///   the imported member is dynamically resolved using the virtual table of the target object.
        /// </summary>
        AfterIntroductions = Default
    }
}