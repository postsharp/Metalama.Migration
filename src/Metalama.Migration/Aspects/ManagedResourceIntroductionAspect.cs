using System;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    public sealed class ManagedResourceIntroductionAspect : IManagedResourceIntroductionAspect, IAspectBuildSemantics
    {
        public ManagedResourceIntroductionAspect( string name, byte[] data )
        {
            if (string.IsNullOrEmpty( name ))
            {
                throw new ArgumentNullException( nameof(name) );
            }

            if (data == null)
            {
                throw new ArgumentNullException( nameof(data) );
            }

            Name = name;
            Data = data;
            DataProvider = () => data;
        }

        public ManagedResourceIntroductionAspect( string name, Func<byte[]> dataProvider )
        {
            if (string.IsNullOrEmpty( name ))
            {
                throw new ArgumentNullException( nameof(name) );
            }

            if (dataProvider == null)
            {
                throw new ArgumentNullException( nameof(dataProvider) );
            }

            Name = name;
            DataProvider = dataProvider;
        }

        public string Name { get; }

#pragma warning disable CA1819 // Properties should not return arrays (TODO)
        public byte[] Data { get; }
#pragma warning restore CA1819 // Properties should not return arrays (TODO)

        public Func<byte[]> DataProvider { get; }

        bool IValidableAnnotation.CompileTimeValidate( object target ) => true;

        AspectConfiguration IAspectBuildSemantics.GetAspectConfiguration( object targetElement )
        {
            return new ManagedResourceIntroductionAspectConfiguration( Name, DataProvider );
        }
    }
}