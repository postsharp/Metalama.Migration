using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    ///   Configuration of aspects of type <see cref = "ManagedResourceIntroductionAspect" />.
    /// </summary>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class ManagedResourceIntroductionAspectConfiguration : AspectConfiguration
    {
        /// <summary>
        ///   Initializes a new <see cref = "ManagedResourceIntroductionAspectConfiguration" />.
        /// </summary>
        /// <param name = "name">Name of the managed resource.</param>
        /// <param name = "data">Content of the managed resource.</param>
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

        /// <summary>
        ///   Initializes a new <see cref = "ManagedResourceIntroductionAspectConfiguration" />
        /// by passing a delegate for late evaluation of the resource content.
        /// </summary>
        /// <param name = "name">Name of the managed resource.</param>
        /// <param name = "dataProvider">A method that returns the data to be introduced. If the method returns <c>null</c>,
        /// the aspect will be ignored and no managed resource will be introduced.</param>
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

        /// <summary>
        ///   Gets the name of the managed resource.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///   Gets the content of the managed resource.
        /// </summary>
        [Obsolete( "Use DataProvider." )]
#pragma warning disable CA1819 // Properties should not return arrays (TODO)
        public byte[] Data { get; }
#pragma warning restore CA1819 // Properties should not return arrays (TODO)

        /// <summary>
        /// Gets a delegate that provides content of the managed resource.
        /// </summary>
        public Func<byte[]> DataProvider { get; }
    }
}