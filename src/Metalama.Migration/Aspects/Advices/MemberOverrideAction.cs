// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Enumeration of actions to be overtaken by the <see cref = "IntroduceMemberAttribute" /> aspect extension
    ///   when the member to be introduced already exists in the aspect target type or its base type.
    /// </summary>
    public enum MemberOverrideAction
    {
        /// <summary>
        ///   <see cref = "Fail" />
        /// </summary>
        Default,

        /// <summary>
        ///   Emits a build time error.
        /// </summary>
        Fail = Default,

        /// <summary>
        ///   Silently ignore the member introduction.
        /// </summary>
        Ignore = 1,

        /// <summary>
        ///   Tries to override the member, and fails if it is impossible (i.e. if the existing member is defined
        ///   in a base type and is sealed or non-virtual).
        /// </summary>
        OverrideOrFail,
        /// <summary>
        ///   Tries to override the member, and silently ignore if it is impossible (i.e. if the existing member is defined
        ///   in a base type and is sealed or non-virtual).
        /// </summary>
        OverrideOrIgnore
    }
}
