using PostSharp.Extensibility;

namespace PostSharp.Constraints
{
    [RequirePostSharp( null, "ArchitectureConstraint" )]
    public interface IConstraint
    {
        bool ValidateConstraint( object target );
    }
}