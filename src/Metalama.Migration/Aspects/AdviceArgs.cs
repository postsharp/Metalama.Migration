using System;
using Metalama.Framework.Aspects;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In PostSharp, this object exposed the run-time execution context to the advice. However, in Metalama, advice do not execute at run time.
    /// Instead, advice are templates that generate run-time code. This run-time code does not need helper objects to represent the execution context.
    /// </summary>
    public class AdviceArgs
    {
        public AdviceArgs( object instance ) { }

        protected AdviceArgs() { }

        /// <summary>
        /// In Metalama, use <see cref="meta"/>.<see cref="meta.This"/>.
        /// </summary>
        public object Instance { get; }

        /// <summary>
        /// There is no equivalent for this in Metalama.
        /// </summary>
        [Obsolete( "", true )]
        public DeclarationIdentifier DeclarationIdentifier { get; }
    }
}