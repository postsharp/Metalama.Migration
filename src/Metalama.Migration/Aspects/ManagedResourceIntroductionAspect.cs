// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Not implemented in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    public sealed class ManagedResourceIntroductionAspect : IManagedResourceIntroductionAspect, IAspectBuildSemantics
    {
        public ManagedResourceIntroductionAspect( string name, byte[] data )
        {
            if ( string.IsNullOrEmpty( name ) )
            {
                throw new ArgumentNullException( nameof(name) );
            }

            if ( data == null )
            {
                throw new ArgumentNullException( nameof(data) );
            }

            this.Name = name;
            this.Data = data;
            this.DataProvider = () => data;
        }

        public ManagedResourceIntroductionAspect( string name, Func<byte[]> dataProvider )
        {
            if ( string.IsNullOrEmpty( name ) )
            {
                throw new ArgumentNullException( nameof(name) );
            }

            if ( dataProvider == null )
            {
                throw new ArgumentNullException( nameof(dataProvider) );
            }

            this.Name = name;
            this.DataProvider = dataProvider;
        }

        public string Name { get; }

#pragma warning disable CA1819 // Properties should not return arrays (TODO)
        public byte[] Data { get; }
#pragma warning restore CA1819 // Properties should not return arrays (TODO)

        public Func<byte[]> DataProvider { get; }

        /// <inheritdoc/>
        bool IValidableAnnotation.CompileTimeValidate( object target ) => true;

        AspectConfiguration IAspectBuildSemantics.GetAspectConfiguration( object targetElement )
        {
            return new ManagedResourceIntroductionAspectConfiguration( this.Name, this.DataProvider );
        }
    }
}