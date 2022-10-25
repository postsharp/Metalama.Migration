using System;
using System.Collections.Generic;

namespace PostSharp.Extensibility.BuildTimeLogging
{
    public sealed partial class BuildTimeLogger
    {
        public void WriteLine( string message )
        {
            throw new NotImplementedException();
        }

        public void WriteLine( string message, object[] args )
        {
            throw new NotImplementedException();
        }

        public void Write( string message )
        {
            throw new NotImplementedException();
        }

        public void Write( string message, object[] args )
        {
            throw new NotImplementedException();
        }

        public BuildTimeLogActivity Activity( string message )
        {
            throw new NotImplementedException();
        }

        public static BuildTimeLogger GetInstance( string category )
        {
            throw new NotImplementedException();
        }

        public static void Initialize( IEnumerable<string> enabledCategories = null ) => throw new NotImplementedException();

        public static bool IsInitialized => throw new NotImplementedException();
    }
}