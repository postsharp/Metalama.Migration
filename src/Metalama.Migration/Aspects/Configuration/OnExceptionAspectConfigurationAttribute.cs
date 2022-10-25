using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no declarative aspect configuration in Metalama.
    /// </summary>
    public sealed class OnExceptionAspectConfigurationAttribute : AspectConfigurationAttribute
    {
        public Type ExceptionType { get; set; }

        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new OnExceptionAspectConfiguration();
        }

        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration )
        {
            throw new NotImplementedException();
        }
    }
}