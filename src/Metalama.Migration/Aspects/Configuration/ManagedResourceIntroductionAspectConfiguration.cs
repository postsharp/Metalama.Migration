using System;

namespace PostSharp.Aspects.Configuration
{
    public sealed class ManagedResourceIntroductionAspectConfiguration : AspectConfiguration
    {
        public ManagedResourceIntroductionAspectConfiguration( string name, byte[] data )
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
#pragma warning disable 618
            Data = data;
#pragma warning restore 618
            DataProvider = () => data;
        }

        public ManagedResourceIntroductionAspectConfiguration( string name, Func<byte[]> dataProvider )
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

        [Obsolete( "Use DataProvider." )]
#pragma warning disable CA1819 // Properties should not return arrays (TODO)
        public byte[] Data { get; }
#pragma warning restore CA1819 // Properties should not return arrays (TODO)

        public Func<byte[]> DataProvider { get; }
    }
}