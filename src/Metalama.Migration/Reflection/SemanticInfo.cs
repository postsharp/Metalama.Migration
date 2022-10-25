using System;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Enumerates the possible semantics of a declaration in the source programming language.
    /// For instance an MSIL method can be in C# a property getter, an operator, an anonymous method, and so on.
    /// </summary>
    [Flags]
    public enum Semantics : long
    {
        /// <summary>
        /// Explicitly-defined instance constructor.
        /// </summary>
        InstanceConstructor = 1 << 0,

        /// <summary>
        /// Static constructor.
        /// </summary>
        StaticConstructor = 1 << 1,

        /// <summary>
        /// Default instance constructor (compiler-implemented).
        /// </summary>
        DefaultConstructor = 1 << 22,

        /// <summary>
        /// Normal event.
        /// </summary>
        Event = 1L << 32,

        /// <summary>
        /// Any compiler-generated event that does not have another semantic in the current enumeration.
        /// </summary>
        OtherCompilerGeneratedEvent = 1L << 33,

        /// <summary>
        /// Event adder.
        /// </summary>
        EventAdder = 1 << 2,

        /// <summary>
        /// Event remover.
        /// </summary>
        EventRemover = 1 << 3,

        /// <summary>
        /// Event raiser (does not exist in C#).
        /// </summary>
        EventRaiser = 1 << 16,

        /// <summary>
        /// Event adder, remover, or raiser.
        /// </summary>
        AnyEventAccessor = EventAdder | EventRemover | EventRaiser,

        /// <summary>
        /// Property getter.
        /// </summary>
        PropertyGetter = 1 << 4,

        /// <summary>
        /// Property setter.
        /// </summary>
        PropertySetter = 1 << 5,

        /// <summary>
        /// Property getter or setter.
        /// </summary>
        AnyPropertyAccessor = PropertyGetter | PropertySetter,

        /// <summary>
        /// Operator (unary, binary, implicit, or explicit).
        /// </summary>
        Operator = 1 << 6,

        /// <summary>
        /// Anonymous method.
        /// </summary>
        AnonymousMethod = 1 << 7,

        /// <summary>
        /// Local function.
        /// </summary>
        LocalFunction = 1 << 8,

        /// <summary>
        /// Normal method.
        /// </summary>
        Method = 1 << 9,

        /// <summary>
        /// Any compiler-generated method that does not have another semantic in the current enumeration.
        /// </summary>
        OtherCompilerGeneratedMethod = 1 << 20,

        /// <summary>
        /// Finalizer.
        /// </summary>
        Finalizer = 1 << 13,

        /// <summary>
        /// Any special method (with either the <see cref="MethodAttributes.SpecialName"/> or <see cref="MethodAttributes.RTSpecialName"/> set)
        /// that does not have a semantic in the current enumeration.
        /// </summary>
        OtherSpecialMethod = 1 << 17,

        /// <summary>
        /// Any compiler-generated field that does not have another semantic in the current enumeration.
        /// </summary>
        OtherCompilerGeneratedField = 1 << 21,

        /// <summary>
        /// Normal field.
        /// </summary>
        Field = 1 << 10,

        /// <summary>
        /// Field backing an automatic property.
        /// </summary>
        PropertyBackingField = 1 << 18,

        /// <summary>
        /// Field backing an automatic event.
        /// </summary>
        EventBackingField = 1 << 19,

        /// <summary>
        /// Compiler-generated field used as a cache for anonymous methods.
        /// </summary>
        AnonymousMethodCacheField = 1 << 11,

        /// <summary>
        /// Normal property.
        /// </summary>
        Property = 1 << 12,

        /// <summary>
        /// Any compiler-generated property that does not have another semantic in the current enumeration.
        /// </summary>
        OtherCompilerGeneratedProperty = 1 << 31,

        /// <summary>
        /// Normal type.
        /// </summary>
        Type = 1 << 23,

        /// <summary>
        /// VB COM Class.
        /// </summary>
        ComClass = 1 << 14,

        /// <summary>
        /// Any member of a compiler-generated type.
        /// </summary>
        CompilerGeneratedTypeMember = 1 << 15,

        /// <summary>
        /// Any parameter of a compiler-generated method.
        /// </summary>
        CompilerGeneratedMethodParameter = 1 << 24,

        /// <summary>
        /// Parameter.
        /// </summary>
        Parameter = 1 << 25,

        /// <summary>
        /// Any declaration not represented in this enumeration.
        /// </summary>
        OtherDeclaration = 1 << 26,

        /// <summary>
        /// Field supporting Code Contracts.
        /// </summary>
        CodeContractsField = 1 << 27,

        /// <summary>
        /// Type implementing an async state machine.
        /// </summary>
        AsyncStateMachineType = 1 << 28,

        /// <summary>
        /// Type implementing an iterator state machine.
        /// </summary>
        IteratorStateMachineType = 1 << 29,

        /// <summary>
        /// Any compiler-generated type that does not have another semantic in the current enumeration.
        /// </summary>
        OtherCompilerGeneratedType = 1 << 30
    }

    /// <summary>
    /// Provides information about the semantic of a declaration in the source programming language.
    /// For instance an MSIL method can be in C# a property getter, an operator, an anonymous method, and so on.
    /// </summary>
#pragma warning disable CA1815 // Override equals and operator equals on value types
    public struct SemanticInfo
    {
        /// <summary>
        /// Gets the semantic of the MSIL method in the source language.
        /// </summary>
        public Semantics Semantic { get; }

        /// <summary>
        /// Determines whether the declaration is compiler-generated.
        /// </summary>
        public bool IsCompilerGenerated { get; }

        /// <summary>
        /// Determines whether the declaration can be safely selected in a pointcut using the standard <c>System.Reflection</c> API.
        /// </summary>
        /// <remarks>
        /// This property is <c>false</c> for declarations such as anonymous methods or local functions because their MSIL implementation
        /// can move from one type to another because of a mere change of the method body in C#. It is also <c>false</c> for
        /// implementation details such as anonymous method cache fields, or closure types, which should never be advised.
        /// </remarks>
        public bool IsSelectable { get; }

        /// <summary>
        /// Gets a human-readable description of the <see cref="Semantic"/> property.
        /// </summary>
        public string DisplayName { get; }
    }
}