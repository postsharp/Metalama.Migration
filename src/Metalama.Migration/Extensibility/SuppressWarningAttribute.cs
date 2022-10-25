using System;

namespace PostSharp.Extensibility
{
    [AttributeUsage( AttributeTargets.All, AllowMultiple = true, Inherited = false )]
    public class SuppressWarningAttribute : Attribute
    {
        public SuppressWarningAttribute( string messageId )
        {
            MessageId = messageId;
        }

        public string MessageId { get; }

        public string Reason { get; set; }
    }
}