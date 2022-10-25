// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Text;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Defines the semantics of aspects that require to be notified after
    /// a target object is cloned using <see cref="object.MemberwiseClone"/>.
    /// </summary>
    public interface ICloneAwareAspect : IInstanceScopedAspect
    {
        /// <summary>
        /// Method called after the an object enhanced by the current aspect has been
        /// cloned using <see cref="object.MemberwiseClone"/>. The <c>this</c>
        /// parameter refers to the new aspect instance in the cloned object.
        /// </summary>
        /// <param name="source">Aspect instance corresponding to the current
        /// aspect instance in the cloned target object.</param>
        /// <remarks>
        ///     <para>Prior to calling the current method, the aspect framework
        /// initializes the <paramref name="source"/> object using <see cref="IInstanceScopedAspect.CreateInstance"/> 
        /// and <see cref="IInstanceScopedAspect.RuntimeInitializeInstance"/>. That is, the aspect instance
        /// in the cloned object is <i>not</i> cloned from the source aspect instance, but from the prototype
        /// aspect instance.
        /// </para>
        /// </remarks>
        [HasInheritedAttribute, RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.StepOut)]
        void OnCloned( ICloneAwareAspect source );
    }
}
