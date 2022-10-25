// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Reflection;
using PostSharp.Reflection.MethodBody;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Caches the instances of the most often used services.
    /// </summary>
    internal class ServiceCache
    {
        private readonly IProject project;

        private IAnnotationRepositoryReflectionService annotationRepositoryService;
        private IMethodUsageIndexReflectionService methodUsageIndexService;
        private ITypeHierarchyReflectionService typeHierarchyService;
        private IMemberTypeIndexReflectionService memberTypeIndexReflectionService;
        private IMethodBodyService syntaxReflectionService;
        private IReflectionHelperService reflectionHelperService;

        public ServiceCache( IProject project )
        {
            if ( project == null )
            {
                throw new ArgumentNullException( nameof(project));
            }

            this.project = project;
        }

        internal static ServiceCache Current
        {
            get
            {
                IProject project = PostSharpEnvironment.CurrentProject;
                if ( project == null )
                {
                    throw new InvalidOperationException( "The project instance is not available. You are probably running build-time only code in run-time." );
                }

                return project.StateStore.Get<ServiceCache>() ?? project.StateStore.GetOrAdd(() => new ServiceCache(project));
            }
        }

        public IAnnotationRepositoryReflectionService AnnotationRepositoryService
        {
            get
            {
                if ( this.annotationRepositoryService == null )
                {
                    this.annotationRepositoryService = this.project.GetService<IAnnotationRepositoryReflectionService>();
                }

                return this.annotationRepositoryService;
            }
        }

        public IMethodUsageIndexReflectionService IndexUsageService
        {
            get
            {
                if ( this.methodUsageIndexService == null )
                {
                    this.methodUsageIndexService = this.project.GetService<IMethodUsageIndexReflectionService>();
                }

                return this.methodUsageIndexService;
            }
        }

        public ITypeHierarchyReflectionService TypeHierarchyService
        {
            get
            {
                if ( this.typeHierarchyService == null )
                {
                    this.typeHierarchyService = this.project.GetService<ITypeHierarchyReflectionService>();
                }

                return this.typeHierarchyService;
            }
        }

        public IMemberTypeIndexReflectionService MemberTypeIndexService
        {
            get
            {
                if ( this.memberTypeIndexReflectionService == null )
                {
                    this.memberTypeIndexReflectionService = this.project.GetService<IMemberTypeIndexReflectionService>();
                }

                return this.memberTypeIndexReflectionService;
            }
        }

        public IMethodBodyService SyntaxReflectionService
        {
            get
            {
                if ( this.syntaxReflectionService == null )
                {
                    this.syntaxReflectionService = this.project.GetService<IMethodBodyService>();
                }

                return this.syntaxReflectionService;
            }
        }

        public IReflectionHelperService ReflectionHelperService
        {
            get
            {
                if ( this.reflectionHelperService == null )
                {
                    this.reflectionHelperService = this.project.GetService<IReflectionHelperService>();
                }

                return this.reflectionHelperService;
            }
        }
    }

}

