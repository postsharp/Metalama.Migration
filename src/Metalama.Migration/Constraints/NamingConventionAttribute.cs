// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using PostSharp.Constraints;
using PostSharp.Extensibility;

namespace PostSharp.Constraints
{
    /// <summary>
    /// Custom attribute that, when applied to a target class or an interface, validates that classes and interfaces derived from this target class or interface
    /// respect a giving naming convention, i.e. that their names matches a given pattern.
    /// </summary>
    [MulticastAttributeUsage(MulticastTargets.Class|MulticastTargets.Interface, Inheritance = MulticastInheritance.Strict)]
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Interface|AttributeTargets.Assembly)]
    public sealed class NamingConventionAttribute : ScalarConstraint
    {
        private const string regexPrefix = "regex:";
        private readonly string pattern;

        /// <summary>
        /// Initializes a new <see cref="NamingConventionAttribute"/>.
        /// </summary>
        /// <param name="pattern">A wildcard pattern containing a <code>*</code>, or, if the parameter starts with the <code>regex:</code> prefix, a regular expression.</param>
        public NamingConventionAttribute( string pattern )
        {
            this.pattern = pattern;
        }

        /// <summary>
        /// Gets or sets the severity of messages reporting violations of the current naming convention.
        /// </summary>
        public SeverityType Severity { get; set; } = SeverityType.Warning;

        /// <inheritdoc />
        public override bool ValidateConstraint( object target )
        {
            Type targetType = (Type) target;
            if ( string.IsNullOrEmpty( this.pattern ) ||
                 !(this.pattern.StartsWith( regexPrefix, StringComparison.Ordinal ) || this.pattern.Contains( "*" )) )
            {
                ArchitectureMessageSource.Instance.Write(MessageLocation.Of( targetType ), SeverityType.Error, "AR0109", targetType, this.pattern );
                return false;
            }

            return true;
        }

        /// <inheritdoc />
        public override void ValidateCode( object target )
        {
            Type targetType = (Type)target;

            string regex;
            if ( this.pattern.StartsWith( regexPrefix, StringComparison.Ordinal ) )
            {
                regex = this.pattern.Substring( regexPrefix.Length );
            }
            else
            {
                regex = "^" + Regex.Escape( this.pattern ).Replace( "\\*", ".*" ).Replace( "<", "\\<" ).Replace( ">", "\\>" ) + "$";
            }

            if ( !Regex.IsMatch( targetType.Name, regex ) )
            {
                ArchitectureMessageSource.Instance.Write(MessageLocation.Of(targetType), this.Severity, "AR0110", targetType, this.pattern);
            }

            base.ValidateCode( target );
        }
    }
}
