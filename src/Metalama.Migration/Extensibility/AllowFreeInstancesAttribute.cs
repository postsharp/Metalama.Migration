using System;

namespace PostSharp.Extensibility
{
    /// <exclude/>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Assembly, AllowMultiple = false )]
    [Obsolete( "Licensing is now based on hard-coded assembly name." )]
    public sealed class AllowFreeInstancesAttribute : Attribute
    {
        /// <exclude/>
        public AllowFreeInstancesAttribute( string featureName )
        {
            FeatureName = featureName;
        }

        /// <exclude/>
        public AllowFreeInstancesAttribute( string featureName, int count )
        {
            FeatureName = featureName;
            FreeInstanceCount = count;
        }

        /// <exclude/>
        public string FeatureName { get; }

        /// <exclude/>
        public int? FreeInstanceCount { get; }

        /// <exclude/>
        public bool ApplyToType { get; set; }
    }
}