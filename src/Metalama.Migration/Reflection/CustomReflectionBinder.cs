using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

namespace PostSharp.Reflection
{
    public sealed class CustomReflectionBinder : Binder
    {
        [SuppressMessage( "Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes" )]
        public static readonly CustomReflectionBinder Instance =
            new();

        public override FieldInfo BindToField(
            BindingFlags bindingFlags,
            FieldInfo[] match,
            object value,
            CultureInfo culture )
        {
            throw new NotImplementedException();
        }

        public override MethodBase BindToMethod(
            BindingFlags bindingFlags,
            MethodBase[] match,
            ref object[] args,
            ParameterModifier[] modifiers,
            CultureInfo culture,
            string[] names,
            out object state )
        {
            throw new NotImplementedException();
        }

        public override object ChangeType( object value, Type type, CultureInfo culture )
        {
            throw new NotImplementedException();
        }

        public override void ReorderArgumentArray( ref object[] args, object state )
        {
            throw new NotImplementedException();
        }

        public override MethodBase SelectMethod(
            BindingFlags bindingFlags,
            MethodBase[] match,
            Type[] types,
            ParameterModifier[] modifiers )
        {
            MethodBase selectedMethod = null;

            foreach (var candidate in match)
            {
                var candidateParameters = candidate.GetParameters();

                if (candidateParameters.Length != types.Length)
                {
                    continue;
                }

                var isMatch = true;

                for (var i = 0; i < candidateParameters.Length; i++)
                {
                    if (!ReflectionTypeComparer.GetInstance().Equals( candidateParameters[i].ParameterType, types[i] ))
                    {
                        isMatch = false;

                        break;
                    }
                }

                if (!isMatch)
                {
                    continue;
                }

                if (selectedMethod != null)
                {
                    throw new AmbiguousMatchException();
                }

                selectedMethod = candidate;
            }

            return selectedMethod;
        }

        public override PropertyInfo SelectProperty(
            BindingFlags bindingFlags,
            PropertyInfo[] match,
            Type returnType,
            Type[] indexes,
            ParameterModifier[] modifiers )
        {
            throw new NotImplementedException();
        }
    }
}