namespace PostSharp.Constraints
{
    public interface IScalarConstraint : IConstraint
    {
        void ValidateCode( object target );
    }
}