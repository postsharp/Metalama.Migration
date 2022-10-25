using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Assembly )]
    public sealed class AllowFreeInstancesAttribute : Attribute
    {
        public AllowFreeInstancesAttribute( string featureName )
        {
            FeatureName = featureName;
        }

        public AllowFreeInstancesAttribute( string featureName, int count )
        {
            FeatureName = featureName;
            FreeInstanceCount = count;
        }

        public string FeatureName { get; }

        public int? FreeInstanceCount { get; }

        public bool ApplyToType { get; set; }
    }
}