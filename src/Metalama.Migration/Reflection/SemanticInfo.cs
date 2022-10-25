﻿// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Flags]
    public enum Semantics : long
    {
        InstanceConstructor = 1 << 0,

        StaticConstructor = 1 << 1,

        DefaultConstructor = 1 << 22,

        Event = 1L << 32,

        OtherCompilerGeneratedEvent = 1L << 33,

        EventAdder = 1 << 2,

        EventRemover = 1 << 3,

        EventRaiser = 1 << 16,

        AnyEventAccessor = EventAdder | EventRemover | EventRaiser,

        PropertyGetter = 1 << 4,

        PropertySetter = 1 << 5,

        AnyPropertyAccessor = PropertyGetter | PropertySetter,

        Operator = 1 << 6,

        AnonymousMethod = 1 << 7,

        LocalFunction = 1 << 8,

        Method = 1 << 9,

        OtherCompilerGeneratedMethod = 1 << 20,

        Finalizer = 1 << 13,

        OtherSpecialMethod = 1 << 17,

        OtherCompilerGeneratedField = 1 << 21,

        Field = 1 << 10,

        PropertyBackingField = 1 << 18,

        EventBackingField = 1 << 19,

        AnonymousMethodCacheField = 1 << 11,

        Property = 1 << 12,

        OtherCompilerGeneratedProperty = 1 << 31,

        Type = 1 << 23,

        ComClass = 1 << 14,

        CompilerGeneratedTypeMember = 1 << 15,

        CompilerGeneratedMethodParameter = 1 << 24,

        Parameter = 1 << 25,

        OtherDeclaration = 1 << 26,

        CodeContractsField = 1 << 27,

        AsyncStateMachineType = 1 << 28,

        IteratorStateMachineType = 1 << 29,

        OtherCompilerGeneratedType = 1 << 30
    }

    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public struct SemanticInfo
    {
        public Semantics Semantic { get; }

        public bool IsCompilerGenerated { get; }

        public bool IsSelectable { get; }

        public string DisplayName { get; }
    }
}