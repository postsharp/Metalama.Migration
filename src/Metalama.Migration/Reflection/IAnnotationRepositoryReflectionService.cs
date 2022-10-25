// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Extensibility;

namespace PostSharp.Reflection
{
    internal interface IAnnotationRepositoryReflectionService : IService
    {
        CustomAttributeInstance[] GetCustomAttributesOfType( Type annotationType, ReflectionSearchOptions options );
        CustomAttributeInstance[] GetCustomAttributesOnTarget( object target );
        ObjectConstruction CreateCustomAttributeData( CustomAttributeInstance customAttributeInstance );
        Attribute CreateCustomAttributeObject( CustomAttributeInstance customAttributeInstance );
    }

}