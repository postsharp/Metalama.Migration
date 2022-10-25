// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using PostSharp.Aspects.Advices;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
#if BINARY_FORMATTER
using System.Runtime.Serialization.Formatters.Binary;
#endif
using PostSharp.Serialization;


namespace PostSharp.Aspects
{
    /// <summary>
    /// Aspect that, when applied on a type, introduces one or many new interfaces
    /// into that type. 
    /// </summary>
    /// <remarks>
    /// <note>
    ///   Consider using a composite aspect and introducing an interface using <see cref="IntroduceMemberAttribute"/> 
    ///  instead of using a <see cref="CompositionAspect"/>.
    /// </note>
    /// <para>
    /// The <see cref="GetPublicInterfaces"/> method 
    /// is invoked at build time. At runtime, the method <see cref="CreateImplementationObject"/>
    /// should return an object implementing all interfaces.
    /// </para>
    /// <para>
    /// Use the <see cref="Post"/>.<see cref="Post.Cast{SourceType,TargetType}"/>
    /// method to cast the enhanced type to the newly implemented interface. This
    /// cast is verified during post-compilation.
    /// </para>
    /// <para>
    ///     Properties <see cref="OverrideAction"/> and <see cref="AncestorOverrideAction"/> determine
    /// what should happen if the target type already implements the interface directly or indirectly.
    /// </para>
    /// <para>
    ///  By default, the object implementing the interface is stored as a serializable field. If the property
    /// <see cref="NonSerializedImplementation"/> is set to <c>true</c>, this field will be marked
    /// as <see cref="System.NonSerializedAttribute"/>.
    /// </para>
    /// <br/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
    /// <seealso cref="PostSharp.Aspects.Advices.IntroduceInterfaceAttribute"/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='seeAlsoIntroducingInterfaces']/*"/>
    /// 
#if SERIALIZABLE
    [Serializable]
#endif
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [AttributeUsage( AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct,
        AllowMultiple = true, Inherited = false )]
    [MulticastAttributeUsage( MulticastTargets.Class | MulticastTargets.Struct, AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [AspectConfigurationAttributeType( typeof(CompositionAspectConfigurationAttribute) )]
    [Serializer(null)]
    public abstract class CompositionAspect : TypeLevelAspect, ICompositionAspect
    {
        /// <summary>
        ///   Method invoked at runtime, during the initialization of instances of the target type,
        ///   to create the composed object.
        /// </summary>
        /// <returns>The composed object. This interface should implement the interfaces specified
        ///   by the <see cref = "GetPublicInterfaces" /> method.</returns>
        /// <remarks>
        ///   This method is invoked during at runtime after the base constructor has executed, and before
        ///   the constructor of the current type is executed.
        /// </remarks>
        public abstract object CreateImplementationObject( AdviceArgs args );


#if SERIALIZABLE
        [NonSerialized] 
#endif
        [PNonSerialized]
        private InterfaceOverrideAction? overrideAction;

#if SERIALIZABLE
        [NonSerialized] 
#endif
        [PNonSerialized]
        private InterfaceOverrideAction? ancestorOverrideAction;

#if SERIALIZABLE
        [NonSerialized] 
#endif
        [PNonSerialized]
        private bool? nonSerializedImplementation;

#if SERIALIZABLE
        [NonSerialized] 
#endif
        [PNonSerialized]
        private bool? generateImplementationAccessor;

        /// <summary>
        ///   Gets the array of interfaces that should be introduced publicly into
        ///   the target type of the current aspect.
        /// </summary>
        /// <param name = "targetType"><see cref = "Type" /> to which the current aspect is applied.</param>
        /// <returns>The array of interfaces that should be introduced publicly into <see cref = "Type" />
        ///   <paramref name = "targetType" />, or <c>null</c> if no interface should
        ///   be introduced publicly.</returns>
        protected virtual Type[] GetPublicInterfaces( Type targetType )
        {
            return null;
        }


        /// <summary>
        ///   Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when one of the interfaces returned by the <see cref = "GetPublicInterfaces" /> method
        ///   is already implemented by the type to which the current aspect is applied.
        /// </summary>
        /// <seealso cref = "AncestorOverrideAction" />
        protected InterfaceOverrideAction OverrideAction
        {
            get { return this.overrideAction ?? InterfaceOverrideAction.Fail; }
            set { this.overrideAction = value; }
        }

        /// <summary>
        ///   Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when an <i>ancestor</i> of one of the interfaces returned by <see cref = "GetPublicInterfaces" />
        ///   is already implemented by the type to which the current aspect is applied.
        /// </summary>
        /// <seealso cref = "OverrideAction" />
        protected InterfaceOverrideAction AncestorOverrideAction
        {
            get { return this.ancestorOverrideAction ?? InterfaceOverrideAction.Fail; }
            set { this.ancestorOverrideAction = value; }
        }

        /// <summary>
        ///   Determines whether the field containing the interface implementation (and storing the object returned by
        ///   <see cref = "CreateImplementationObject" />) should be excluded from serialization by <see cref = "BinaryFormatter" />.
        ///   The same effect is typically obtained by applying the <see cref = "NonSerializedAttribute" /> custom attribute to the field.
        /// </summary>
        protected bool NonSerializedImplementation
        {
            get { return this.nonSerializedImplementation ?? false; }
            set { this.nonSerializedImplementation = value; }
        }
       
        /// <summary>
        ///   This property has no effect.
        /// </summary>
        protected bool GenerateImplementationAccessor
        {
            get { return this.generateImplementationAccessor ?? false; }
            set { this.generateImplementationAccessor = value; }
        }

        /// <inheritdoc />
        protected sealed override AspectConfiguration CreateAspectConfiguration()
        {
            return new CompositionAspectConfiguration();
        }

        /// <inheritdoc />
        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration, Type targetType )
        {
            CompositionAspectConfiguration configuration = (CompositionAspectConfiguration) aspectConfiguration;
            configuration.OverrideAction = this.overrideAction;
            configuration.AncestorOverrideAction = this.ancestorOverrideAction;
            configuration.NonSerializedImplementation = this.nonSerializedImplementation;
            configuration.PublicInterfaces = TypeIdentity.FromTypes( this.GetPublicInterfaces( targetType ) );

        }


    }
}