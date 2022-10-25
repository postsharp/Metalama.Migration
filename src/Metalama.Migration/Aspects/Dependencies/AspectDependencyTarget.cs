// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   Enumeration of targets (<see cref = "AspectDependencyTarget.Default" /> or <see cref = "AspectDependencyTarget.Type" />)
    ///   to which the aspect dependency apply.
    /// </summary>
    /// <remarks>
    ///   <para>This property is meaningful only for aspects that apply to type members. For aspects that 
    ///     apply to types, type-level and default-level dependencies are the same thing.</para>
    ///   <para>Member-level aspects may have semantics that actually apply at type level (for instance
    ///     member introductions and imports). By setting the dependency target to
    ///     <see cref = "AspectDependencyTarget.Type" />, you can specify that the aspect dependency applies
    ///     to type-level semantics. Otherwise, it will apply to member-level semantics.</para>
    /// </remarks>
    public enum AspectDependencyTarget
    {
        /// <summary>
        ///   Natural target of the aspect.
        /// </summary>
        Default,

        /// <summary>
        ///   Declaring type of the natural target of the aspect.
        /// </summary>
        Type
    }
}
