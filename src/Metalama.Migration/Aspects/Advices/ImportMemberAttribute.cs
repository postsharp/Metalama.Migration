using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Custom attribute that, when applied to an instance field of an aspect class, determines
    ///   that this field should be bound to a method, event or property, of the
    ///   target class of this aspect. Valid types for fields are
    ///   a concrete <see cref = "Delegate" /> (to bind to a method),
    ///   <see cref = "Property{TValue}" /> or <see cref = "Property{TValue,TIndex}" />
    ///   (to bind to a property), or <see cref = "Event{T}" /> (to bind to an event).
    /// </summary>
    /// <remarks>
    ///   <para>Fields annotated with the <see cref = "ImportMemberAttribute" />
    ///     custom attribute must be public and must not be read only.</para>
    ///   <para>At runtime, these fields are assigned to a delegate (in case
    ///     of method binding) or a pair of delegates (in case of event or property
    ///     binding) allowing to invoke the imported member.</para>
    ///   <para>When <see cref="IsRequired"/> property is set to <c>true</c> and the target type does not contain a member of the required
    ///     name and signature, then a build error will be raised.</para>
    ///   <para>When multiple member names are specified, the first existing member satisfying all conditions is used.
    ///   </para>
    /// </remarks>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoIntroduceImportMembers']/*" />
    [AttributeUsage( AttributeTargets.Field, AllowMultiple = false )]
    public sealed class ImportMemberAttribute : Advice
    {
        /// <summary>
        ///   Initializes a new <see cref = "ImportMemberAttribute" /> and specifies several possible names for the member to import.
        /// </summary>
        /// <param name = "memberNames">Possible names of the member to import in the order of precedence.</param>
        public ImportMemberAttribute( params string[] memberNames )
        {
            MemberNames = memberNames;
        }

        /// <summary>
        /// Initializes a new <see cref="ImportMemberAttribute"/> and specifies a single name for the member to import.
        /// </summary>
        /// <param name="memberName">The name of the member to import.</param>
        public ImportMemberAttribute( string memberName )
        {
            MemberNames = new[] { memberName };
        }

        /// <summary>
        ///   Determines whether a build time error must be issued if the member to be
        ///   imported is absent. If <c>false</c>, the binding field will be <c>null</c>
        ///   in case the imported member is absent.
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        ///   Array of possible names of imported member in the order of precedence.
        /// </summary>
        public string[] MemberNames { get; }

        /// <summary>
        ///   Determines when the member should be imported: either before (<see cref = "ImportMemberOrder.BeforeIntroductions" />)
        ///   or after (<see cref = "ImportMemberOrder.AfterIntroductions" />) members have been introduced by the current aspect.
        ///   Default is <see cref = "ImportMemberOrder.BeforeIntroductions" />.
        /// </summary>
        /// <remarks>
        ///   Sometimes it makes sense for an aspect to import a member <i>after</i> the same aspect has introduced member.
        ///   This allows the aspect to invoke a member that could be overridden by later aspects.
        /// </remarks>
        public ImportMemberOrder Order { get; set; }
    }
}