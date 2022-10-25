using System;

namespace PostSharp.Extensibility
{
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false )]
    [Obsolete( "Licensing is now based on hard-coded assembly name." )]
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