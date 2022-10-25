using System;

namespace PostSharp.Aspects.Configuration
{
    [AttributeUsage( AttributeTargets.Class )]
    public class AspectConfigurationAttribute : Attribute
    {
        public int AspectPriority { get; set; }

        public Type SerializerType { get; set; }

        protected virtual AspectConfiguration CreateAspectConfiguration()
        {
            return new AspectConfiguration();
        }

        public AspectConfiguration GetAspectConfiguration()
        {
            throw new NotImplementedException();
        }

        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration )
        {
            throw new NotImplementedException();
        }
    }
}