using System.Reflection;

namespace PostSharp.Constraints
{
    public interface IReferentialConstraint : IConstraint
    {
        void ValidateCode( object target, Assembly assembly );
    }
}