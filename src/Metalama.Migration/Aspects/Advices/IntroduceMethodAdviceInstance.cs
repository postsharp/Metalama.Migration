// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Represents an advice that introduces a method of the aspect class into the target class.
    /// </summary>
    /// <seealso cref="IAdviceProvider"/>
    /// <see cref="IntroduceMemberAttribute"/>
    public sealed class IntroduceMethodAdviceInstance : IntroduceMemberAdviceInstance
    {
        private readonly MethodInfo method;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntroduceMethodAdviceInstance"/> class.
        /// </summary>
        /// <param name="method">A public method of the aspect class.</param>
        /// <param name="visibility">Visibility of the introduced method.</param>
        /// <param name="isVirtual"><c>true</c> if the introduced method should be virtual, <c>false</c> if it should be non-virtual (or sealed, if the method is overriding another one),
        /// or <c>null</c> if the method should be virtual only if the overridden method is also virtual. See <see cref="IntroduceMemberAdviceInstance.IsVirtual"/> for details.</param>
        /// <param name="overrideAction">Determines the action to be overtaken when the member to be introduced already exists
        ///   in the type to which the aspect is applied, or to a base type.
        /// </param>
        public IntroduceMethodAdviceInstance( MethodInfo method, Visibility visibility, bool? isVirtual, MemberOverrideAction overrideAction ) 
            : base(visibility, isVirtual, overrideAction)
        {
            if ( method == null )
                throw new ArgumentNullException(nameof(method));

            this.method = method;
        }

        /// <inheritdoc />
        public override object MasterAspectMember
        {
            get { return this.method; }
        }

    }
}
