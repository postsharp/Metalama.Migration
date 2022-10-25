using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// To escalate Metalama warnings into errors, use the same strategy as for C# or analyzer errors.
    /// </summary>
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