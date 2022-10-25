using System;

namespace PostSharp.Aspects
{
    public sealed class AspectUtilities
    {
        public static void InitializeCurrentAspects()
        {
            throw new NotSupportedException( "The caller of this method should be transformed by PostSharp." );
        }
    }
}