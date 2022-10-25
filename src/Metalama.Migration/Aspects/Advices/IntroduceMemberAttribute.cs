using System;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Custom attribute that, when applied on a method, event or property of an aspect class, specifies
    ///   that this method, event or property should be introduced into the types to which the aspect is applied.
    /// </summary>
    /// <remarks>
    /// <para>
    ///   Methods, properties and events annotated with <see cref = "IntroduceMemberAttribute" /> must be public.
    /// </para>
    /// <para>
    ///  If the method, event or property is in a C# 8.0 nullable annotations context, its nullability information will
    /// be copied into the types as well. 
    /// </para>
    /// </remarks>
    /// <seealso cref = "CopyCustomAttributesAttribute" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoIntroduceImportMembers']/*" />
    [AttributeUsage(
        AttributeTargets.Event | AttributeTargets.Property | AttributeTargets.Method,
        AllowMultiple = false )]
    public sealed class IntroduceMemberAttribute : Advice
    {
        /// <summary>
        ///   Determines the visibility (<see cref = "Reflection.Visibility.Public" />, (<see cref = "Reflection.Visibility.Family" />, ...)
        ///   of the introduced member.
        /// </summary>
        public Visibility Visibility { get; set; }

        /// <summary>
        ///   Determines whether the introduced member should be virtual.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     Value of this property is ignored when the member to be introduced already exists in the aspect target type or its base type.
        ///   </para>
        /// </remarks>
        public bool IsVirtual { get; set; }

        /// <summary>
        ///   Determines whether the <see cref = "IsVirtual" /> property has been specified.
        /// </summary>
        public bool IsIsVirtualSpecified { get; }

        /// <summary>
        ///   Determines the action to be overtaken when the member to be introduced already exists
        ///   in the type to which the aspect is applied, or to a base type.
        /// </summary>
        public MemberOverrideAction OverrideAction { get; set; }
    }
}