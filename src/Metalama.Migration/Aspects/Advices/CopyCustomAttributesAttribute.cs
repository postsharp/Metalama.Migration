// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Custom attribute that, when applied on an aspect class, requires custom
    ///   attributes present on the aspect class to be copied to the target of this class.
    ///   When applied on an introduced member (see <see cref = "IntroduceMemberAttribute" />),
    ///   this custom attribute requires custom attributes present on the aspect member
    ///   to be copied to the introduced member.
    /// </summary>
    /// <seealso cref = "IntroduceMemberAttribute" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoIntroduceImportMembers']/*" />
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Event | AttributeTargets.Property | AttributeTargets.Method )]
    public sealed class CopyCustomAttributesAttribute : Advice
    {
        /// <summary>
        ///   Requires custom attributes present on the aspect class or aspect class member
        ///   to be copied to the aspect target or to the introduced member, respectively.
        /// </summary>
        /// <param name = "type">Base type of custom attributes to be copied.</param>
        public CopyCustomAttributesAttribute( Type type )
        {
            this.Types = new[] {type,};
        }

        /// <summary>
        ///   Requires custom attributes present on the aspect class or aspect class member
        ///   to be copied to the aspect target or to the introduced member, respectively.
        /// </summary>
        /// <param name = "types">Base types of custom attributes to be copied.</param>
        public CopyCustomAttributesAttribute( params Type[] types )
        {
            this.Types = types;
        }

        /// <summary>
        ///   Determines what should happen when a custom attribute of the same
        ///   type is already present on the target declaration.
        /// </summary>
        public CustomAttributeOverrideAction OverrideAction { get; set; }

        /// <summary>
        ///   Gets the list of custom attribute types to be copied.
        /// </summary>
        public Type[] Types { get; private set; }
    }
}