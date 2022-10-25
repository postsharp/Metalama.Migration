// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Extensibility;

namespace PostSharp.Constraints
{
    internal class ArchitectureMessageSource : MessageSource
    {
        public static readonly ArchitectureMessageSource Instance = new ArchitectureMessageSource();

        private ArchitectureMessageSource() : base( "PostSharp.Architecture", new Dispenser() )
        {
        }

        private class Dispenser : MessageDispenser
        {
            public Dispenser() : base( "AR" )
            {
            }

            protected override string GetMessage( int number)
            {
                switch ( number - 100 )
                {
                    case 1:
                        return "Interface {0} cannot be implemented by {1} because of the [InternalImplement] constraint.";

                    case 2:
                        return "{0} {1} cannot be referenced from {2} {3} because of the [ComponentInternal] constraint.";

                    case 4:
                        return "Cannot use [Internal] on {0} {1} because the {0} is not public.";

                    case 5:
                        return "Cannot use {0} {1} in {2} {3} because it is an implementation detail and should not be used in user code.";

                    case 6:
                        return "The project {0} has a reference to {1} {2}, which is an experimental feature.";

                    case 7:
                        return "Cannot use [Protected] on {0} {1} because the {0} is not public.";

                    case 8:
                        return "Cannot use {0} {1} in {2} {3} because of the [Protected] constraint.";

                    case 9:
                        return
                            "Error in the [NamingConvention] constraint applied to {0}: the string \"{1}\" is not a valid pattern. It should contain a \"*\" or start with the \"regex:\" prefix.";

                    case 10:
                        return
                            "The type {0} does not respect the naming convention set on the base class or interface. The type name should match the \"{1}\" pattern.";

                    case 11:
                        return
                            "Cannot apply the {0} constraint to {1}: a ParameterValueConstraint cannot be applied to property parameters.";

                    default:
                        return null;
                }
            }
        }
    }

}