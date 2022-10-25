// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Provides some utility method for the current namespace.
    /// </summary>
    public static class SerializationServices
    {

        /// <summary>
        /// Checks whether a given <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>, <see cref="FieldInfo"/>, <see cref="PropertyInfo"/>,
        /// <see cref="EventInfo"/> or <see cref="Type"/> can be safely serialized.
        /// </summary>
        /// <param name="memberInfo">The declaration to be serialized.</param>
        /// <returns><c>null</c> if <paramref name="memberInfo"/> can be safely serialized, otherwise an exception where the text describes
        /// the reason why the declaration is not serializable.</returns>
        public static PortableSerializationException GetSerializationException( MemberInfo memberInfo )
        {
            return GetSerializationException( (object) memberInfo );
        }

        /// <summary>
        /// Checks whether a given <see cref="LocationInfo"/> can be safely serialized.
        /// </summary>
        /// <param name="locationInfo">The declaration to be serialized.</param>
        /// <returns><c>null</c> if <paramref name="locationInfo"/> can be safely serialized, otherwise an exception where the text describes
        /// the reason why the declaration is not serializable.</returns>
        public static PortableSerializationException GetSerializationException(LocationInfo locationInfo)
        {
            return GetSerializationException((object) locationInfo);
        }

        /// <summary>
        /// Checks whether a given <see cref="ParameterInfo"/> can be safely serialized.
        /// </summary>
        /// <param name="parameterInfo">The declaration to be serialized.</param>
        /// <returns><c>null</c> if <paramref name="parameterInfo"/> can be safely serialized, otherwise an exception where the text describes
        /// the reason why the declaration is not serializable.</returns>
        public static PortableSerializationException GetSerializationException(ParameterInfo parameterInfo)
        {
            return GetSerializationException((object) parameterInfo);
        }

        internal static PortableSerializationException GetSerializationException(object metadata)
        {

#if !GAC
            throw new NotSupportedException("This method is supported at build time only.");
#else

            if (!PostSharpEnvironment.IsPostSharpRunning)
            {
                throw new NotSupportedException("This method is supported at build time only.");
            }

            // TODO: Validate generic method/type instances.

            // Validate that we are able to serialize this item.
            Type declaringType;
            MemberInfo declaringMember;
            ReflectionHelper.GetMemberInfo(metadata, out declaringType, out declaringMember);

            if (declaringType != null && !declaringType.Assembly.CanInternalsBeReferenced())
            {
                if (declaringMember != null && !ReflectionHelper.IsExported(declaringMember))
                {
                    return new PortableSerializationException(
                        string.Format(CultureInfo.InvariantCulture, "Cannot serialize {0} '{1}.{2}' because it is an internal member of a system assembly.",
                                       metadata.GetType().Name,
                                       declaringType.FullName, declaringMember.Name));
                }
                else if (!ReflectionHelper.IsExported(declaringType))
                {
                    if (!declaringType.IsPublic && !declaringType.IsNestedFamily)
                        return new PortableSerializationException(
                            string.Format(CultureInfo.InvariantCulture, "Cannot serialize type '{0}' because it is an internal type of a system assembly.", declaringType ));
                   
                }
            }

            return null;
#endif

        }
    }
}
