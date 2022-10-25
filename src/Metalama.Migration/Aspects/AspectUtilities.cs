using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent to this class in Metalama.
    /// </summary>
    public sealed class AspectUtilities
    {
        public static void InitializeCurrentAspects()
        {
            throw new NotSupportedException( "The caller of this method should be transformed by PostSharp." );
        }
    }
}