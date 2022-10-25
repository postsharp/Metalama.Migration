// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using PostSharp.Extensibility;


// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
#if NET35
[assembly: AssemblyTitle("PostSharp (.NET Framework 3.5)")]
[assembly: AssemblyDescription("PostSharp Run-Time Distributable (.NET Framework 3.5)")]
#elif NET45
[assembly: AssemblyTitle("PostSharp (.NET Framework 4.5)")]
[assembly: AssemblyDescription("PostSharp Run-Time Distributable (.NET Framework 4.5)")]
#elif NETSTANDARD1_3
[assembly: AssemblyTitle("PostSharp (.NET Standard 1.3)")]
[assembly: AssemblyDescription("PostSharp Run-Time Distributable (.NET Standard 1.3)")]
#elif NETSTANDARD2_0
[assembly: AssemblyTitle("PostSharp (.NET Standard 2.0)")]
[assembly: AssemblyDescription("PostSharp Run-Time Distributable (.NET Standard 2.0)")]
#elif NET5_0
[assembly: AssemblyTitle("PostSharp (.NET 5.0)")]
[assembly: AssemblyDescription("PostSharp Run-Time Distributable (.NET 5.0)")]
#elif NET6_0
[assembly: AssemblyTitle("PostSharp (.NET 6.0)")]
[assembly: AssemblyDescription("PostSharp Run-Time Distributable (.NET 6.0)")]
#else
// The following link is intentionally not commented out, so the build fails if the target platform is unknown.
// In such case, check your platform and add it here, eventually.
https://docs.microsoft.com/en-us/dotnet/core/tutorials/libraries#how-to-multitarget
#endif




// Setting ComVisible to false makes the types in the current assembly not visible 
// to COM components.  If you need to access a type in the current assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible( false )]
[assembly: Guid( "2B881EF9-3DE5-4C54-BC61-494671AEFA36" )]

#if DEFAULT_DEPENDENCY_ATTRIBUTE
// Hint for NGen
[assembly: DefaultDependency( LoadHint.Always )]
#endif

// Security
[assembly: AllowPartiallyTrustedCallers]

[assembly: CLSCompliant( true )]


// Make PostSharp.Sdk a friend assembly.

[assembly:
    InternalsVisibleTo(
        "PostSharp.Compiler.Engine, PublicKey=002400000480000094000000060200000024000052534131000400000100010029a210ad0342b29ebf859a2b9bacfda9bc786bc6a8de8ad14c0fe24b5645188b3595cad82b3d9a3c1319e2abe49ab0ffeed8358d16fef234af601315f39258539c9006391a699ca15542a0595df441f039a5f411b0b3138a2a472f63043a49ebb45118b1649da88bc59f295ad58801a5f9100fcf3091eaea883d17811edc49a8"
        )]
[assembly:
    InternalsVisibleTo(
        "PostSharp.Compiler.Roslyn, PublicKey=002400000480000094000000060200000024000052534131000400000100010029a210ad0342b29ebf859a2b9bacfda9bc786bc6a8de8ad14c0fe24b5645188b3595cad82b3d9a3c1319e2abe49ab0ffeed8358d16fef234af601315f39258539c9006391a699ca15542a0595df441f039a5f411b0b3138a2a472f63043a49ebb45118b1649da88bc59f295ad58801a5f9100fcf3091eaea883d17811edc49a8"
        )]
[assembly:
    InternalsVisibleTo(
        "PostSharp.Compiler.Common, PublicKey=002400000480000094000000060200000024000052534131000400000100010029a210ad0342b29ebf859a2b9bacfda9bc786bc6a8de8ad14c0fe24b5645188b3595cad82b3d9a3c1319e2abe49ab0ffeed8358d16fef234af601315f39258539c9006391a699ca15542a0595df441f039a5f411b0b3138a2a472f63043a49ebb45118b1649da88bc59f295ad58801a5f9100fcf3091eaea883d17811edc49a8"
        )]
[assembly:
    InternalsVisibleTo(
        "PostSharp.Compiler.Hosting, PublicKey=002400000480000094000000060200000024000052534131000400000100010029a210ad0342b29ebf859a2b9bacfda9bc786bc6a8de8ad14c0fe24b5645188b3595cad82b3d9a3c1319e2abe49ab0ffeed8358d16fef234af601315f39258539c9006391a699ca15542a0595df441f039a5f411b0b3138a2a472f63043a49ebb45118b1649da88bc59f295ad58801a5f9100fcf3091eaea883d17811edc49a8"
        )]
[assembly:
    InternalsVisibleTo(
        "PostSharp.Compiler.Settings, PublicKey=002400000480000094000000060200000024000052534131000400000100010029a210ad0342b29ebf859a2b9bacfda9bc786bc6a8de8ad14c0fe24b5645188b3595cad82b3d9a3c1319e2abe49ab0ffeed8358d16fef234af601315f39258539c9006391a699ca15542a0595df441f039a5f411b0b3138a2a472f63043a49ebb45118b1649da88bc59f295ad58801a5f9100fcf3091eaea883d17811edc49a8"
        )]
#if NETFRAMEWORK
[assembly:
    InternalsVisibleTo(
        "PostSharp.Core.Test.NetFramework, PublicKey=002400000480000094000000060200000024000052534131000400000100010029a210ad0342b29ebf859a2b9bacfda9bc786bc6a8de8ad14c0fe24b5645188b3595cad82b3d9a3c1319e2abe49ab0ffeed8358d16fef234af601315f39258539c9006391a699ca15542a0595df441f039a5f411b0b3138a2a472f63043a49ebb45118b1649da88bc59f295ad58801a5f9100fcf3091eaea883d17811edc49a8"
        )]
#elif NETSTANDARD || NETCOREAPP
[assembly:
    InternalsVisibleTo(
        "PostSharp.Core.Test.NetCore, PublicKey=002400000480000094000000060200000024000052534131000400000100010029a210ad0342b29ebf859a2b9bacfda9bc786bc6a8de8ad14c0fe24b5645188b3595cad82b3d9a3c1319e2abe49ab0ffeed8358d16fef234af601315f39258539c9006391a699ca15542a0595df441f039a5f411b0b3138a2a472f63043a49ebb45118b1649da88bc59f295ad58801a5f9100fcf3091eaea883d17811edc49a8"
        )]
#endif



[assembly: HasInheritedAttribute]
