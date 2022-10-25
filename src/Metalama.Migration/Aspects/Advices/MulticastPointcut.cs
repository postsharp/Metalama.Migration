#pragma warning disable CA1710 // Identifiers should have correct suffix

using PostSharp.Extensibility;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Custom attribute that, when applied on an advice method, specifies to which elements of
    ///   code this advice applies, based on the kind, name and attributes of code elements.
    ///   Works similarly as <see cref = "MulticastAttribute" />.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoAddBehaviorsToMembers']/*" />
    public sealed class MulticastPointcut : Pointcut
    {
        /// <summary>
        ///   Gets or sets the expression specifying to which members 
        ///   the aspect extension applies.
        /// </summary>
        /// <value>
        ///   A wildcard or regular expression specifying to which members
        ///   this instance applies, or <c>null</c> this instance
        ///   applies either to all members whose kind is given in <see cref = "Targets" />.
        ///   Regular expressions should start with the <c>regex:</c> prefix.
        /// </value>
        public string MemberName { get; set; }

        /// <summary>
        ///   Gets or sets the kind of elements to which this aspect extension applies.
        /// </summary>
        public MulticastTargets Targets { get; set; }

        /// <summary>
        ///   Gets or sets the visibilities, scopes, virtualities, and implementation
        ///   of members to which this attribute applies.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     The <see cref = "MulticastAttributes" /> enumeration is a multi-part flag: there is one
        ///     part for visibility, one for scope, one for virtuality, and one for implementation.
        ///     If you specify one part, it will override the values defined on the custom attribute definition.
        ///   </para>
        /// </remarks>
        public MulticastAttributes Attributes { get; set; }
    }
}