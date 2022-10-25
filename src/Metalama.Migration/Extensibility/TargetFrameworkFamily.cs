// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Represents a variant of family (variant) of the .NET Framework, e.g. <see cref="NetCore"/>, <see cref="NetFramework"/>,
    /// <see cref="Silverlight"/> or <see cref="NetPortable"/>.
    /// </summary>
    internal struct TargetFrameworkFamily : IEquatable<TargetFrameworkFamily>
    {
        internal TargetFrameworkFamily( string value )
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the string identity of the current object.
        /// </summary>
        public string Value { get; }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        /// <summary>
        /// Determines whether the current object represents a null instance.
        /// </summary>
        public bool IsNull
        {
            get { return string.IsNullOrEmpty( this.Value ); }
        }

        public override string ToString()
        {
            return this.Value;
        }

        /// <inheritdoc />
        public override bool Equals( object obj )
        {
            if ( !(obj is TargetFrameworkFamily) )
                return false;
            return this.Equals( (TargetFrameworkFamily) obj );
        }

        /// <inheritdoc />
        public bool Equals( TargetFrameworkFamily other )
        {
            return this.Equals( other.Value );
        }

        /// <inheritdoc />
        public bool Equals( string other )
        {
            return string.Equals( this.Value, other, StringComparison.OrdinalIgnoreCase );
        }

        /// <summary>
        /// Determines whether two <see cref="TargetFrameworkFamily"/> instances are equal.
        /// </summary>
        /// <param name="x">A <see cref="TargetFrameworkFamily"/>.</param>
        /// <param name="y">A <see cref="TargetFrameworkFamily"/>.</param>
        /// <returns><c>true</c> if <paramref name="x"/> and <paramref name="y"/> are equal, otherwise  <c>false</c>.</returns>
        public static bool operator ==( TargetFrameworkFamily x, TargetFrameworkFamily y )
        {
            return x.Equals( y );
        }

        /// <summary>
        /// Determines whether two <see cref="TargetFrameworkFamily"/> instances are different.
        /// </summary>
        /// <param name="x">A <see cref="TargetFrameworkFamily"/>.</param>
        /// <param name="y">A <see cref="TargetFrameworkFamily"/>.</param>
        /// <returns><c>true</c> if <paramref name="x"/> and <paramref name="y"/> are different, otherwise  <c>false</c></returns>
        public static bool operator !=( TargetFrameworkFamily x, TargetFrameworkFamily y )
        {

            return !x.Equals( y );
        }

        /// <summary>
        /// Instance of <see cref="TargetFrameworkFamily"/> representing the full .NET Framework.
        /// </summary>
        public static readonly TargetFrameworkFamily NetFramework = new TargetFrameworkFamily( ".NETFramework" );

        /// <summary>
        /// Instance of <see cref="TargetFrameworkFamily"/> representing .NET Core and .NET Framework for Windows Store.
        /// </summary>
        public static readonly TargetFrameworkFamily NetCore = new TargetFrameworkFamily( ".NETCore" );

        /// <summary>
        /// Instance of <see cref="TargetFrameworkFamily"/> representing .NET Core Framework.
        /// </summary>
        public static readonly TargetFrameworkFamily NETCoreApp = new TargetFrameworkFamily( ".NETCoreApp" );

        /// <summary>
        /// Instance of <see cref="TargetFrameworkFamily"/> representing .NET Portable Class Library.
        /// </summary>
        public static readonly TargetFrameworkFamily NetPortable = new TargetFrameworkFamily( ".NETPortable" );

        /// <summary>
        /// Instance of <see cref="TargetFrameworkFamily"/> representing .NET Standard Class Library.
        /// </summary>
        public static readonly TargetFrameworkFamily NetStandard = new TargetFrameworkFamily( ".NETStandard" );

        /// <summary>
        /// Instance of <see cref="TargetFrameworkFamily"/> representing Silverlight.
        /// </summary>
        public static readonly TargetFrameworkFamily Silverlight = new TargetFrameworkFamily( "Silverlight" );

        /// <summary>
        /// Instance of <see cref="TargetFrameworkFamily"/> representing Xamarin.iOS.
        /// </summary>
        public static readonly TargetFrameworkFamily Xamarin_iOS = new TargetFrameworkFamily( "Xamarin.iOS" );

        /// <summary>
        /// Instance of <see cref="TargetFrameworkFamily"/> representing MonoAndroid.
        /// </summary>
        public static readonly TargetFrameworkFamily MonoAndroid = new TargetFrameworkFamily( "MonoAndroid" );

        /// <summary>
        /// Instance of <see cref="TargetFrameworkFamily"/> representing MonoTouch.
        /// </summary>
        public static readonly TargetFrameworkFamily MonoTouch = new TargetFrameworkFamily( "MonoTouch" );

        /// <summary>
        /// Instance of <see cref="TargetFrameworkFamily"/> representing Windows Phone (Silverlight).
        /// </summary>
        public static readonly TargetFrameworkFamily WindowsPhone = new TargetFrameworkFamily( "WindowsPhone" );
    }
}
