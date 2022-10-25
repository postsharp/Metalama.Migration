using System;

namespace PostSharp.Aspects
{
    public interface ITypeLevelAspect : IAspect
    {
        void RuntimeInitialize( Type type );
    }
}