// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Completely specifies an aspect instance, including its target code element. An <see cref = "AspectInstance" />
    ///   contains either the aspect instance itself (<see cref = "Aspect" /> property), either information allowing to construct the aspect 
    ///   (<see cref = "AspectSpecification.AspectConstruction" />) and configure the weaver (<see cref = "AspectConfiguration" />).
    /// </summary>
    /// <see cref = "IAspectProvider" />
    /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoAspectProvider']/*" />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public sealed class AspectInstance : AspectSpecification
    {
        /// <summary>
        ///   Initializes a new <see cref = "AspectInstance" /> from a runtime aspect instance (<see cref = "IAspect" />).
        /// </summary>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "AspectInstance" />
        ///   is applied.</param>
        /// <param name = "aspect">The aspect runtime instance.</param>
        public AspectInstance( object targetElement, IAspect aspect ) : base( aspect, (AspectConfiguration) null )
        {
            this.TargetElement = targetElement;
            this.CheckTargetElement();
        }

        /// <summary>
        ///   Initializes a new <see cref = "AspectInstance" /> from a runtime aspect instance (<see cref = "IAspect" />)
        ///   and its <see cref = "AspectConfiguration" />.
        /// </summary>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "AspectInstance" />
        ///   is applied.</param>
        /// <param name = "aspect">The aspect runtime instance.</param>
        /// <param name = "aspectConfiguration">The aspect configuration (the type of this parameter should be equal to the
        ///   type configuration objects expected by the concrete <paramref name = "aspect" />).</param>
        public AspectInstance( object targetElement, IAspect aspect, AspectConfiguration aspectConfiguration )
            : base( aspect, aspectConfiguration )
        {
            this.TargetElement = targetElement;
            this.CheckTargetElement();
        }

        /// <summary>
        ///   Initializes a new <see cref = "AspectInstance" /> from an <see cref="ObjectConstruction"/>.
        /// </summary>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "AspectInstance" />
        ///   is applied.</param>
        /// <param name = "aspectConstruction">An <see cref = "ObjectConstruction" /> instructing how the aspect instance
        ///   should be constructed.</param>
        public AspectInstance(object targetElement, ObjectConstruction aspectConstruction) : base(aspectConstruction, null)
        {
            this.TargetElement = targetElement;
            this.CheckTargetElement();
        }

        /// <summary>
        ///   Initializes a new <see cref = "AspectInstance" /> from an <see cref="ObjectConstruction"/> and specifies an <see cref="AspectConfiguration"/> object.
        /// </summary>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "AspectInstance" />
        ///   is applied.</param>
        /// <param name = "aspectConstruction">An <see cref = "ObjectConstruction" /> instructing how the aspect instance
        ///   should be constructed.</param>
        /// <param name = "aspectConfiguration">An optional configuration object whose type corresponds to 
        ///   the aspect type.</param>
        public AspectInstance( object targetElement, ObjectConstruction aspectConstruction,
                               AspectConfiguration aspectConfiguration ) : base( aspectConstruction, aspectConfiguration )
        {
            this.TargetElement = targetElement;
            this.CheckTargetElement();
        }

        /// <summary>
        ///   Gets the code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "AspectInstance" />
        ///   is applied.
        /// </summary>
        public object TargetElement { get; private set; }

        /// <summary>
        /// Determines whether the <see cref="AspectInstance"/> should be represented as a stand-alone instance
        /// in PostSharp Tools for Visual Studio. If <c>false</c>, the current <see cref="AspectInstance"/>
        /// will be not be represented as a standalone node, and its advices will be merged with the ones provided 
        /// by the parent aspect (implementing <see cref="IAspectProvider"/>). The default value is <c>false</c>.
        /// </summary>
        public bool RepresentAsStandalone { get; set; }

        private void CheckTargetElement()
        {
            MethodBase targetMethod;
            FieldInfo targetField;
            Type targetType;
            PropertyInfo targetProperty;
            EventInfo targetEvent;
            ParameterInfo targetParameter;
            Assembly targetAssembly;
            LocationInfo targetLocation;

            object validatedTarget = this.TargetElement;
            if ( (targetLocation = validatedTarget as LocationInfo) != null )
            {
                validatedTarget = targetLocation.UnderlyingReflectionObject;
            }

            if ( (targetMethod = validatedTarget as MethodBase) != null )
            {
                if ( (targetMethod.IsGenericMethod && !targetMethod.IsGenericMethodDefinition) ||
                     (targetMethod.DeclaringType.IsGenericType() && !targetMethod.DeclaringType.IsGenericTypeDefinition()) )
                {
                    throw new ArgumentException(
                        "You cannot add an aspect to a generic method instance or to a method in a generic type instance. Add the aspect to the corresponding generic method definition." );
                }
            }
            else if ( (targetField = validatedTarget as FieldInfo) != null )
            {
                if ( (targetField.DeclaringType.IsGenericType() && !targetField.DeclaringType.IsGenericTypeDefinition()) )
                {
                    throw new ArgumentException(
                        "You cannot add an aspect to a field of a generic type instance. Add the aspect to the corresponding field in the generic type definition." );
                }
            }
            else if ( (targetType = validatedTarget as Type) != null )
            {
                if ( (targetType.IsGenericType() && !targetType.IsGenericTypeDefinition()) )
                {
                    throw new ArgumentException(
                        "You cannot add an aspect to a generic type instance. Add the aspect to the corresponding generic type definition." );
                }
            }
            else if ( (targetProperty = validatedTarget as PropertyInfo) != null )
            {
                MethodInfo getter = targetProperty.GetGetMethod( true );

                if ( getter == null )
                    throw new ArgumentException( "You cannot add an aspect to a property without getter." );

                if ( (getter.IsGenericMethod && !getter.IsGenericMethodDefinition) ||
                     (getter.DeclaringType.IsGenericType() && !getter.DeclaringType.IsGenericTypeDefinition()) )
                {
                    throw new ArgumentException(
                        "You cannot add an aspect to a generic property instance or to a property in a generic type instance. Add the aspect to the corresponding generic property definition." );
                }
            }
            else if ( (targetEvent = validatedTarget as EventInfo) != null )
            {
                MethodInfo adder = targetEvent.GetAddMethod( true );

                if ( adder == null )
                    throw new ArgumentException( "You cannot add an aspect to an event without adder." );

                if ( (adder.IsGenericMethod && !adder.IsGenericMethodDefinition) ||
                     (adder.DeclaringType.IsGenericType() && !adder.DeclaringType.IsGenericTypeDefinition()) )
                {
                    throw new ArgumentException(
                        "You cannot add an aspect to a generic event instance or to an event in a generic type instance. Add the aspect to the corresponding generic event definition." );
                }
            }
            else if ( (targetParameter = validatedTarget as ParameterInfo) != null )
            {
                MethodBase declaringMethod = targetParameter.Member as MethodBase;

                if ( declaringMethod == null )
                {
                    throw new ArgumentException( "Cannot add an aspect to a parameter of something else than a method." );
                }


                if ( (declaringMethod.IsGenericMethod && !declaringMethod.IsGenericMethodDefinition) ||
                     (declaringMethod.DeclaringType.IsGenericType() &&
                      !declaringMethod.DeclaringType.IsGenericTypeDefinition()) )
                {
                    throw new ArgumentException(
                        "You cannot add an aspect to a generic method instance or to a method in a generic type instance. Add the aspect to the corresponding generic method definition." );
                }
            }
            else if ( (targetAssembly = validatedTarget as Assembly) != null )
            {
                if ( targetAssembly != PostSharpEnvironment.Current.CurrentProject.TargetAssembly )
                {
                    throw new ArgumentException(
                        "You can add an aspect only to the current assembly." );
                }
            }
            else
            {
                throw new ArgumentException(
                    string.Format( CultureInfo.InvariantCulture, "Cannot apply an aspect to a {0}.", validatedTarget.GetType() ) );
            }
        }
    }
}

