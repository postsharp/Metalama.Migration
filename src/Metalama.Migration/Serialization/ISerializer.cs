using System;
using PostSharp.Constraints;

namespace PostSharp.Serialization
{
    [InternalImplement]
    public interface ISerializer
    {
        object Convert( object value, Type targetType );

        object CreateInstance( Type type, IArgumentsReader constructorArguments );

        void DeserializeFields( ref object obj, IArgumentsReader initializationArguments );

        void SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments );

        bool IsTwoPhase { get; }
    }
}