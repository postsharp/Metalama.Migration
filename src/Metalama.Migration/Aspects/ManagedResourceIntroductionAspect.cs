// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Aspect that, when applied to an assembly, adds a custom attribute to this assembly.
    /// </summary>
    /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoAspectProvider']/*" />
    public sealed class ManagedResourceIntroductionAspect : IManagedResourceIntroductionAspect, IAspectBuildSemantics
    {
        /// <summary>
        ///   Initializes a new <see cref = "ManagedResourceIntroductionAspect" /> by passing the data as a byte array.
        /// </summary>
        /// <param name = "name">Name of the managed resource.</param>
        /// <param name = "data">Content of the managed resource.</param>
        public ManagedResourceIntroductionAspect( string name, byte[] data )
        {
            if ( string.IsNullOrEmpty( name ) ) throw new ArgumentNullException( nameof(name));
            if ( data == null ) throw new ArgumentNullException( nameof(data));
            this.Name = name;
            this.Data = data;
            this.DataProvider = () => data;
        }
        
        /// <summary>
        ///   Initializes a new <see cref = "ManagedResourceIntroductionAspect" /> by passing a delegate for late evaluation of
        /// the resource content.
        /// </summary>
        /// <param name = "name">Name of the managed resource.</param>
        /// <param name = "dataProvider">A method that returns the data to be introduced. If the method returns <c>null</c>,
        /// the aspect will be ignored and no managed resource will be introduced.
        /// .</param>
        public ManagedResourceIntroductionAspect( string name, Func<byte[]> dataProvider )
        {
            if ( string.IsNullOrEmpty( name ) ) throw new ArgumentNullException( nameof(name));
            if ( dataProvider == null ) throw new ArgumentNullException( nameof(dataProvider));
            this.Name = name;
            this.DataProvider = dataProvider;
        }

        /// <summary>
        ///   Gets the name of the managed resource.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///   Gets the content of the managed resource.
        /// </summary>
        #pragma warning disable CA1819 // Properties should not return arrays (TODO)
        public byte[] Data { get; }
        #pragma warning restore CA1819 // Properties should not return arrays (TODO)

        /// <summary>
        /// Gets a delegate that provides content of the managed resource.
        /// </summary>
        public Func<byte[]> DataProvider { get; }

        bool IValidableAnnotation.CompileTimeValidate( object target ) => true;

        AspectConfiguration IAspectBuildSemantics.GetAspectConfiguration( object targetElement )
        {
            return new ManagedResourceIntroductionAspectConfiguration( this.Name, this.DataProvider );
        }
    }
}

