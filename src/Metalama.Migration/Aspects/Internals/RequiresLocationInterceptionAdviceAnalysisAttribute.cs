// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [Internal]
    public sealed class RequiresLocationInterceptionAdviceAnalysisAttribute : RequiresAdviceAnalysisAttribute
    {
        //
        // If you annotate an advice (a standalone advice or in an aspect) with this attribute, it means that the advice analyzer
        // will look through all applications of that advice to a method to see if various properties of <see cref="LocationInterceptionArgs"/>
        // are used in that method. If not, that will enable PostSharp to not emit code that would load data into those properties.
        // (not as xmldoc because we don't want documentation on end-user-visible elements)
        //
    }
}