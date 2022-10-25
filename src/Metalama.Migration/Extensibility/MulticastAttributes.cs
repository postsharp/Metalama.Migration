using System;
using System.Diagnostics.CodeAnalysis;

namespace PostSharp.Extensibility
{
    [Flags]
    [SuppressMessage( "Microsoft.Usage", "CA2217:DoNotMarkEnumsWithFlags" )]
#pragma warning disable CA1008 // Enums should have zero value named None.
    public enum MulticastAttributes
    {
        Default = 0,

        Private = 1 << 1,

        Protected = 1 << 2,

        Internal = 1 << 3,

        InternalAndProtected = 1 << 4,

        InternalOrProtected = 1 << 5,

        Public = 1 << 6,

        AnyVisibility = Private | Protected | Internal | InternalAndProtected | InternalOrProtected | Public,

        Static = 1 << 7,

        Instance = 1 << 8,

        AnyScope = Static | Instance,

        Abstract = 1 << 9,

        NonAbstract = 1 << 10,

        AnyAbstraction = Abstract | NonAbstract,

        Virtual = 1 << 11,

        NonVirtual = 1 << 12,

        AnyVirtuality = NonVirtual | Virtual,

        Managed = 1 << 13,

        NonManaged = 1 << 14,

        AnyImplementation = Managed | NonManaged,

        Literal = 1 << 15,

        NonLiteral = 1 << 16,

        AnyLiterality = Literal | NonLiteral,

        InParameter = 1 << 17,

        CompilerGenerated = 1 << 18,

        UserGenerated = 1 << 19,

        AnyGeneration = CompilerGenerated | UserGenerated,

        OutParameter = 1 << 20,

        RefParameter = 1 << 21,

        AnyParameter = InParameter | OutParameter | RefParameter,

        All =
            AnyVisibility | AnyVirtuality | AnyScope | AnyImplementation | AnyLiterality | AnyAbstraction |
            AnyGeneration | AnyParameter
    }
}