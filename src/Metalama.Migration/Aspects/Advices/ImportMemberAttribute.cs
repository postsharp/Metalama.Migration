// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;
using Metalama.Framework.Code.SyntaxBuilders;
using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, members of the target declaration do not need to be imported into the aspect. Instead, the
    /// aspect accesses the target code using dynamic code or invokers. To generate code that calls a method, use <see cref="IMethod"/>.<see cref="IMethod.Invokers"/>.
    /// To generate code that accesses a field or property, use <see cref="IFieldOrProperty"/>.<see cref="IFieldOrProperty.Invokers"/>
    /// or <see cref="IFieldOrProperty"/>.<see cref="ExpressionFactory.ToExpression(Metalama.Framework.Code.IFieldOrProperty,Metalama.Framework.Code.IExpression?)"/>.<see cref="IExpression.Value"/>.
    /// </summary>
    /// <seealso href="template-dynamic-code"/>
    [AttributeUsage( AttributeTargets.Field )]
    public sealed class ImportMemberAttribute : Advice
    {
        public ImportMemberAttribute( params string[] memberNames )
        {
            throw new NotImplementedException();
        }

        public ImportMemberAttribute( string memberName )
        {
            throw new NotImplementedException();
        }

        public bool IsRequired { get; set; }

        public string[] MemberNames { get; }

        public ImportMemberOrder Order { get; set; }
    }
}