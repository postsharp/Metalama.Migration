// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using PostSharp.Constraints;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Provides instances of classes implementing the <see cref="IActivator"/> interface. You should not use this class in user code.
    /// </summary>
    [Internal]
    public sealed class ActivatorProvider
    {
        readonly object sync = new object();
        readonly Dictionary<Assembly, IActivator> assemblyActivators = new Dictionary<Assembly, IActivator>();
        readonly Dictionary<Type,IActivator> typeActivators = new Dictionary<Type, IActivator>();

        internal ActivatorProvider()
        {
        }

        /// <summary>
        /// Gets an instance of a given class implementing the <see cref="IActivator"/> interface.
        /// </summary>
        /// <param name="type">A type implementing the <see cref="IActivator"/> interface.</param>
        /// <returns>An instance of type <paramref name="type"/>.</returns>
        public IActivator GetActivator(Type type)
        {
            lock ( this.sync )
            {
                IActivator activator;
                if ( this.typeActivators.TryGetValue( type, out activator ) )
                {
                    return activator;
                }

                Assembly[] requiredAssembly = new Assembly[1];
                ReflectionHelper.VisitTypeElements( type,
                                                    t =>
                                                    {
                                                        if ( !t.IsPrimitive() && !t.HasElementType && !(t.IsGenericType() && !t.IsGenericTypeDefinition()) &&
                                                             !ReflectionHelper.IsPublic( t ) )
                                                        {
                                                            if ( requiredAssembly[0] != null && requiredAssembly[0] != t.GetAssembly() )
                                                            {
                                                                   
                                                                throw new PortableSerializationException(
                                                                    string.Format(CultureInfo.InvariantCulture,
                                                                        "Cannot instantiate type '{0}' because there is no assembly from which the type is fully accessible.", type ) );
                                                            }

                                                            requiredAssembly[0] = t.GetAssembly();
                                                        }
                                                    } );

                if ( requiredAssembly[0] != null && requiredAssembly[0] != this.GetType().GetAssembly() )
                {
                    
                    activator = this.GetActivator( requiredAssembly[0] );
                    if ( activator == null )
                    {
                        if ( !PostSharpEnvironment.IsPostSharpRunning || PostSharpEnvironment.CurrentProject.TargetAssembly != requiredAssembly[0] )
                        {
                            throw new PortableSerializationException(
                                string.Format(CultureInfo.InvariantCulture, "Cannot instantiate type '{0}' because assembly '{1}' does not have an IActivator.", type, requiredAssembly[0] ) );
                        }
                        
                    }
                }
                else
                {
                    activator = null;
                }

                this.typeActivators.Add( type, activator );
                return activator;
            }
        }

        private IActivator GetActivator( Assembly assembly )
        {
            IActivator activator;
            if (this.assemblyActivators.TryGetValue(assembly, out activator))
            {
                return activator;
            }

            object[] attributes = assembly.GetCustomAttributes( typeof(ActivatorTypeAttribute), false );
            if ( attributes.Length > 0 )
            {
                activator = (IActivator) Activator.CreateInstance( ((ActivatorTypeAttribute) attributes[0]).ActivatorType );
            }
            else
            {
                activator = null;
            }

            this.assemblyActivators.Add( assembly, activator );

            return activator;

        }
    }
}
