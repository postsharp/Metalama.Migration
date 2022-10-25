// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   Specifies an aspect dependency matching aspects or advices having a given effect.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     All aspects (except the ones that have an empty implementation) have an effect on the program execution.
    ///     The current custom attribute allows to express dependencies to aspects according to their effect.
    ///   </para>
    ///   <para>The list of standard effects is given in class <see cref = "StandardEffects" />. All advices have
    ///     implicitly the effect <see cref = "StandardEffects.Custom" />. Most advices also have the effect
    ///     <see cref = "StandardEffects.ChangeControlFlow" />, because they are able to modify the control flow (for instance, 
    ///     skip the execution of the intercepted method or throwing an exception). An aspect or advice can declare
    ///     it does <i>not</i> have a given effect by using the <see cref = "WaiveAspectEffectAttribute" /> custom attribute.
    ///   </para>
    /// </remarks>
    /// <seealso cref = "StandardEffects" />
    /// <seealso cref = "WaiveAspectEffectAttribute" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    /// <remarks>
    /// </remarks>
    public sealed class AspectEffectDependencyAttribute : AspectDependencyAttribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "AspectEffectDependencyAttribute" /> and specifies a position.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        /// <param name = "position">Dependency position.</param>
        /// <param name = "effect">Effect (see <see cref = "StandardEffects" />).</param>
        public AspectEffectDependencyAttribute( AspectDependencyAction action, AspectDependencyPosition position,
                                                string effect )
            : base( action, position )
        {
            this.Effect = effect;
        }

        /// <summary>
        ///   Initializes a new <see cref = "AspectEffectDependencyAttribute" /> without specifying the position,
        ///   implicitly set to <see cref = "AspectDependencyPosition.Any" />.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        /// <param name = "effect">Effect (see <see cref = "StandardEffects" />).</param>
        public AspectEffectDependencyAttribute( AspectDependencyAction action, string effect )
            : base( action )
        {
            this.Effect = effect;
        }

        /// <summary>
        ///   Gets the effect that the aspects or advices must have in order to match the current dependency.
        /// </summary>
        public string Effect { get; private set; }
    }
}