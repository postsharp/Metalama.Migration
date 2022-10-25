// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Reflection
{
    /// <summary>
    /// Extensions for the <see cref="ParameterKind"/> class.
    /// </summary>
    public static class ParameterKindExtensions
    {
        /// <summary>
        /// Determines whether a parameter of a given <see cref="ParameterKind"/> has a meaningful input value.
        /// </summary>
        /// <param name="parameterKind"></param>
        /// <returns><c>true</c> if <paramref name="parameterKind"/> equals to <see cref="ParameterKind.InValue"/>, <see cref="ParameterKind.ByRefIn"/> or <see cref="ParameterKind.ByRefInOut"/>,
        /// otherwise <c>false</c>.</returns>
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

        /// <summary>
        /// Determines whether a parameter of a given <see cref="ParameterKind"/> has a meaningful output value (but is not the return parameter; in C#, that's <c>ref</c> and <c>out</c> parameters).
        /// </summary>
        /// <param name="parameterKind"></param>
        /// <returns><c>true</c> if <paramref name="parameterKind"/> equals to  <see cref="ParameterKind.ByRefOut"/> or <see cref="ParameterKind.ByRefInOut"/>,
        /// otherwise <c>false</c>.</returns>
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

        /// <summary>
        /// Determines whether a parameter of a given <see cref="ParameterKind"/> represents a return parameter.
        /// </summary>
        /// <returns><c>true</c> if <paramref name="parameterKind"/> equals to <see cref="ParameterKind.ReturnValue"/> or <see cref="ParameterKind.ReturnRef"/>,
        /// otherwise <c>false</c>.</returns>
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

        /// <summary>
        /// Determines whether a parameter of a given <see cref="ParameterKind"/> is passed by reference (but is not the return parameter).
        /// </summary>
        /// <param name="parameterKind"></param>
        /// <returns><c>true</c> if <paramref name="parameterKind"/> equals to <see cref="ParameterKind.ByRefIn"/>, <see cref="ParameterKind.ByRefOut"/> or <see cref="ParameterKind.ByRefInOut"/>,
        /// otherwise <c>false</c>.</returns>
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

        /// <summary>
        /// Determines whether a parameter is a "real" parameter, and not the return parameter.
        /// </summary>
        /// <param name="parameterKind"></param>
        /// <returns><c>true</c> if <paramref name="parameterKind"/> equals to <see cref="ParameterKind.InValue"/>, <see cref="ParameterKind.ByRefIn"/>, <see cref="ParameterKind.ByRefOut"/> or <see cref="ParameterKind.ByRefInOut"/>,
        /// otherwise <c>false</c>.</returns>
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
