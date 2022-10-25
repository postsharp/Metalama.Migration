// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   List of standard effects.
    /// </summary>
    /// <remarks>
    ///   <para>See <see cref = "AspectEffectDependencyAttribute" /> for a discussion of effects.</para>
    ///   <para>This list is not meant to be extended by vendors providing concrete aspects (implementing some business
    ///     functionality). Roles should be used to categorized the business effect of concrete aspects. However, if you
    ///     implement a new kind of abstract aspect  (for instance member suppression), you may need to define new effects.
    ///   </para>
    ///   <para>
    ///     In that case, we at <c>PostSharp</c> encourage you contact us to define a new role string. If you define a
    ///     new role string, we recommend you clearly define it so that users of your aspect can express dependencies
    ///     with their own aspects, or third-party aspects.</para>
    /// </remarks>
    /// <seealso cref = "AspectEffectDependencyAttribute" />
    /// <seealso cref = "WaiveAspectEffectAttribute" />
    /// <seealso cref = "StandardRoles" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public static class StandardEffects
    {
        /// <summary>
        ///   Import of a type member.
        /// </summary>
        public const string MemberImport = "MemberImport";

        /// <summary>
        ///   Introduction of a custom attribute.
        /// </summary>
        public const string CustomAttributeIntroduction = "CustomAttributeIntroduction";

        /// <summary>
        ///   Introduction of an interface.
        /// </summary>
        public const string InterfaceIntroduction = "InterfaceIntroduction";

        /// <summary>
        ///   Introduction of a type member.
        /// </summary>
        public const string MemberIntroduction = "MemberIntroduction";

        /// <summary>
        ///   Custom effect (implemented in an aspect advice). All advices have this effect by default,
        ///   unless they are annotated by <see cref = "WaiveAspectEffectAttribute" />.
        /// </summary>
        public const string Custom = "Custom";

        /// <summary>
        ///   Change the flow control (for instance by having the possibility to skip execution of an
        ///   intercepted method).
        /// </summary>
        public const string ChangeControlFlow = "ChangeControlFlow";

        /// <summary>
        ///   Gets a string representing the effect of introducing a member into a type.
        /// </summary>
        /// <param name = "memberName">Name of the introduced member.</param>
        /// <returns>A string that, by convention, represents the introduction of a member named
        ///   <paramref name = "memberName" /> into a type.</returns>
        public static string GetMemberIntroductionEffect( string memberName )
        {
            return MemberIntroduction + ":" + memberName;
        }

        /// <summary>
        ///   Gets a string representing the effect of importing a member into from the target
        ///   type into the aspect.
        /// </summary>
        /// <param name = "memberName">Name of the imported member.</param>
        /// <returns>A string that, by convention, represents the import of a member named
        ///   <paramref name = "memberName" /> from the target type into the aspect.</returns>
        public static string GetMemberImportEffect( string memberName )
        {
            return MemberImport + ":" + memberName;
        }

        /// <summary>
        ///   Gets a string representing the effect of introducing an interface into a type.
        /// </summary>
        /// <param name = "typeName">Name of the introduced interface.</param>
        /// <returns>A string that, by convention, represents the introduction of an interface named
        ///   <paramref name = "typeName" /> into a type.</returns>
        public static string GetInterfaceIntroductionEffect( string typeName )
        {
            return InterfaceIntroduction + ":" + typeName;
        }
    }
}