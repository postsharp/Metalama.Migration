// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Text;
using PostSharp.Aspects.Dependencies;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Base class for advice instances, which can be provided dynamically by the aspect thanks to the <see cref="IAdviceProvider"/> interface.
    /// </summary>
    /// <remarks>
    /// <para>The only supported dynamic advice currently is <see cref="ImportLocationAdviceInstance"/>.</para>
    /// </remarks>
    public abstract class AdviceInstance
    {
        /// <summary>
        /// Gets the main field or method of the aspect class that the current <see cref="AdviceInstance"/> relates to.
        /// </summary>
        public abstract object MasterAspectMember { get; }

        /// <summary>
        /// A human-readable description of the current advice instance.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The number of lines of hand-written code avoided by this specific <see cref="AdviceInstance"/>.
        /// </summary>
        public int LinesOfCodeAvoided { get; set; }
    }
}
