// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="RefKindExtensions"/>.
    /// </summary>
    public static class ParameterKindExtensions
    {
        public static bool IsInputParameter( this ParameterKind parameterKind )
        {
            switch ( parameterKind )
            {
                case ParameterKind.InValue:
                case ParameterKind.ByRefIn:
                case ParameterKind.ByRefInOut:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsOutputParameter( this ParameterKind parameterKind )
        {
            switch ( parameterKind )
            {
                case ParameterKind.ByRefOut:
                case ParameterKind.ByRefInOut:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsReturn( this ParameterKind parameterKind )
        {
            switch ( parameterKind )
            {
                case ParameterKind.ReturnValue:
                case ParameterKind.ReturnRef:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsByRefParameter( this ParameterKind parameterKind )
        {
            switch ( parameterKind )
            {
                case ParameterKind.ByRefIn:
                case ParameterKind.ByRefOut:
                case ParameterKind.ByRefInOut:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsParameter( this ParameterKind parameterKind )
        {
            switch ( parameterKind )
            {
                case ParameterKind.ByRefIn:
                case ParameterKind.ByRefOut:
                case ParameterKind.ByRefInOut:
                case ParameterKind.InValue:
                    return true;

                default:
                    return false;
            }
        }
    }
}