// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Extensibility;
using PostSharp.Reflection;
using System;

namespace PostSharp.Constraints
{
    /// <summary>
    /// Not implemented yet in Metalama, but it will be.
    /// </summary>
    public sealed class ComponentInternalAttribute : ReferenceConstraint
    {
        public ComponentInternalAttribute()
        {
            this.Severity = SeverityType.Warning;
        }

        public SeverityType Severity { get; set; }

        public ComponentInternalAttribute( params Type[] friendTypes )
            : this()
        {
            throw new NotImplementedException();
        }

        public ComponentInternalAttribute( params string[] friendNamespaces )
            : this()
        {
            throw new NotImplementedException();
        }

        protected override void ValidateReference( ICodeReference codeReference )
        {
            throw new NotImplementedException();
        }
    }
}