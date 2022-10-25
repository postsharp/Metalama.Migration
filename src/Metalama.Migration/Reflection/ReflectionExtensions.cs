// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Provides utility methods to work with the <c>System.Reflection</c> namespace.
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Gets the <see cref="PropertyInfo"/> whose a given field is the backing field from the current type or base types.
        /// </summary>
        /// <param name="field">A field.</param>
        /// <returns>The <see cref="PropertyInfo"/> representing the property whose <paramref name="field"/> is the backing field, or <c>null</c>
        /// if <paramref name="field"/> is not the backing field of an automatic property.</returns>
        public static PropertyInfo GetAutomaticProperty( this FieldInfo field )
        {
            return GetAutomaticProperty( field, true );
        }

        internal static string GetAutomaticPropertyName( string fieldName )
        {
            return ReflectionHelper.GetReflectionHelperService().GetAutomaticPropertyName( fieldName );
        }

        /// <summary>
        /// Gets the <see cref="PropertyInfo"/> whose a given field is the backing field and specifies whether base types should be considered.
        /// </summary>
        /// <param name="field">A field.</param>
        /// <param name="inherit"><c>true</c> if the property should be looked for in the base, otherwise <c>false</c>.</param>
        /// <returns>The <see cref="PropertyInfo"/> representing the property whose <paramref name="field"/> is the backing field, or <c>null</c>
        /// if <paramref name="field"/> is not the backing field of an automatic property.</returns>
        public static PropertyInfo GetAutomaticProperty( this FieldInfo field, bool inherit )
        {
            string propertyName = GetAutomaticPropertyName( field.Name );
            if ( propertyName != null )
            {
                BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
                if ( !inherit )
                {
                    flags |= BindingFlags.DeclaredOnly;
                }
                return field.DeclaringType.GetProperty( propertyName, flags );
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Determines whether a given property is an automatic property.
        /// </summary>
        /// <param name="propertyInfo">A property.</param>
        /// <returns><c>true</c> if <paramref name="propertyInfo"/> represents an automatic property, otherwise <c>false</c>.</returns>
        public static bool IsAutomaticProperty( this PropertyInfo propertyInfo )
        {
            return GetBackingField( propertyInfo ) != null;
        }

        /// <summary>
        /// Gets the backing field of a given property.
        /// </summary>
        /// <param name="propertyInfo">A property.</param>
        /// <returns>The <see cref="FieldInfo"/> representing the backing field of <paramref name="propertyInfo"/>, or <c>null</c> if <paramref name="propertyInfo"/>
        /// is not an automatic property.</returns>
        public static FieldInfo GetBackingField( this PropertyInfo propertyInfo )
        {
            return ReflectionHelper.GetReflectionHelperService().GetBackingField( propertyInfo );
        }

        /// <summary>
        /// Gets the kind of state machine (for example, <see cref="StateMachineKind.Async"/>, <see cref="StateMachineKind.Iterator"/> or <see cref="StateMachineKind.None"/>) that implements a given method.
        /// </summary>
        /// <param name="method">A method.</param>
        /// <returns>A <see cref="StateMachineKind"/> value, or <see cref="StateMachineKind.None"/> if <paramref name="method"/> is not implemented by a state machine.</returns>
        public static StateMachineKind GetStateMachineKind(this MethodInfo method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            return ReflectionHelper.GetReflectionHelperService().GetStateMachineKind(method);
        }

        /// <summary>
        /// Gets the public (or kick-off) method given a <c>MoveNext</c> method.
        /// </summary>
        /// <param name="method">The move next method.</param>
        /// <returns>The public (kick-off method) corresponding to <paramref name="method"/>.</returns>
        public static MethodInfo GetStateMachinePublicMethod( this MethodInfo method )
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            return ReflectionHelper.GetReflectionHelperService().GetStateMachinePublicMethod(method);
        }
    }
}
