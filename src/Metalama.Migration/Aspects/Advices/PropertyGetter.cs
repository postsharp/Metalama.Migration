// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Defines the signature of methods implementing the <see cref = "Property{TValue}.Get" />
    ///   semantic of a parameterless property.
    /// </summary>
    /// <typeparam name = "TValue">Property value type.</typeparam>
    /// <returns>The property value.</returns>
    /// <seealso cref = "Property{TValue}" />
    public delegate TValue PropertyGetter<TValue>();
}
