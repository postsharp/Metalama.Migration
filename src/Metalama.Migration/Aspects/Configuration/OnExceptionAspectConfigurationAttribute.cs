using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    ///   Custom attribute that, when applied on a class implementing <see cref = "IOnExceptionAspect" />,
    ///   defines the configuration of that aspect.
    /// </summary>
    /// <seealso cref = "OnExceptionAspect" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class OnExceptionAspectConfigurationAttribute : AspectConfigurationAttribute
    {
        /// <summary>
        ///   Gets or sets the type of exceptions that are caught by this aspect.
        /// </summary>
        /// <remarks>
        ///   If this property is <c>null</c>, any <see cref = "Exception" /> shall be caught.
        /// </remarks>
        public Type ExceptionType { get; set; }

        /// <inheritdoc />
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new OnExceptionAspectConfiguration();
        }

        /// <inheritdoc />
        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration )
        {
            base.SetAspectConfiguration( aspectConfiguration );

            var onExceptionAspectConfiguration = (OnExceptionAspectConfiguration)
                aspectConfiguration;

            onExceptionAspectConfiguration.ExceptionType = TypeIdentity.FromType( ExceptionType );
        }
    }
}