using System;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Constraints
{
    /// <summary>
    /// Not implemented yet in Metalama, but it will be.
    /// </summary>
    public sealed class ComponentInternalAttribute : ReferenceConstraint
    {
        public ComponentInternalAttribute()
        {
            Severity = SeverityType.Warning;
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