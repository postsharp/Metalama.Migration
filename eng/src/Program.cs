// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Engineering.BuildTools;
using PostSharp.Engineering.BuildTools.Build.Model;
using PostSharp.Engineering.BuildTools.Build.Solutions;
using PostSharp.Engineering.BuildTools.Dependencies.Definitions;
using Spectre.Console.Cli;
using MetalamaDependencies = PostSharp.Engineering.BuildTools.Dependencies.Definitions.MetalamaDependencies.V2024_1;

var product = new Product( MetalamaDependencies.MetalamaMigration )
{
    Solutions = [new DotNetSolution( "src\\Metalama.Migration.sln" ) { CanFormatCode = true }],
    PublicArtifacts = Pattern.Create( "Metalama.Migration.$(PackageVersion).nupkg" ),
    Dependencies = [DevelopmentDependencies.PostSharpEngineering, MetalamaDependencies.MetalamaExtensions],
    MainVersionDependency = MetalamaDependencies.Metalama
};

var commandApp = new CommandApp();

commandApp.AddProductCommands( product );

return commandApp.Run( args );