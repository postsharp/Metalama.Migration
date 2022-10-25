using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use the same mechanism as for suppressing C# or analyzer warnings.
    /// </summary>
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