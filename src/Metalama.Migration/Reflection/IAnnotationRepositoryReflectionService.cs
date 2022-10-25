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