using System;

namespace PostSharp.Extensibility
{
    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = true )]
    public sealed class EscalatePostSharpMessageAttribute : Attribute
    {
        public EscalatePostSharpMessageAttribute( string messageId )
        {
            throw new NotImplementedException();
        }

        public string MessageId { get; }
    }
}