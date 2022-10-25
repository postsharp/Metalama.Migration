using System;

namespace PostSharp.Aspects.Configuration
{
    public sealed class OnExceptionAspectConfigurationAttribute : AspectConfigurationAttribute
    {
        public Type ExceptionType { get; set; }

        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new OnExceptionAspectConfiguration();
        }

        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration )
        {
            base.SetAspectConfiguration( aspectConfiguration );

            var onExceptionAspectConfiguration = (OnExceptionAspectConfiguration)
                aspectConfiguration;

            onExceptionAspectConfiguration.ExceptionType = TypeIdentity.FromType( ExceptionType );
        }
    }
}