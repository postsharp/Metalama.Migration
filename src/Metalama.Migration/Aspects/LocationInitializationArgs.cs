using System;
using PostSharp.Aspects.Internals;

namespace PostSharp.Aspects
{
    public sealed class LocationInitializationArgs : LocationLevelAdviceArgs
    {
        /// <exclude />
        public LocationInitializationArgs( object instance, object backingFieldValue )
            : base( instance )
        {
            throw new NotImplementedException();
        }

        public override object Value { get; set; }
    }
}