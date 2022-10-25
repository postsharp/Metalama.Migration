// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

#if BINARY_FORMATTER
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    ///   Implementation of <see cref = "AspectSerializer" /> based on the
    ///   <see cref = "BinaryFormatter" /> provided by the full version
    ///   of the .NET Framework.
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public class BinaryAspectSerializer : AspectSerializer
    {
        private static ISurrogateSelector surrogateSelector = new CustomSurrogateSelector();
        private static readonly SerializationBinder binder = new BinaryAspectSerializationBinder();
        [ThreadStatic] private static IMetadataDispenser currentMetadataDispenser;

        
        internal static IMetadataDispenser CurrentMetadataDispenser { get { return currentMetadataDispenser; }}

      

        /// <inheritdoc />
        protected override IAspect[] Deserialize( Stream stream, IMetadataDispenser metadataDispenser )
        {
            if ( stream == null ) throw new ArgumentNullException(nameof(stream));
            

            try
            {
                currentMetadataDispenser = metadataDispenser;

                BinaryFormatter binaryFormatter = new BinaryFormatter
                                                  {
                                                      Binder = binder,
                                                      SurrogateSelector = surrogateSelector
                                                  };

#pragma warning disable SYSLIB0011 // BinaryFormatter is obsolete since .NET 5.0
                object o = binaryFormatter.Deserialize( stream );
#pragma warning restore SYSLIB0011 // BinaryFormatter is obsolete since .NET 5.0

                IAspect[] array = (IAspect[]) o;

                return array;
            }
            catch ( Exception e )
            {
                Trace.TraceError( "Error deserializing PostSharp aspects: " + e.ToString() );
                throw;
            }
            finally
            {
                currentMetadataDispenser = null;
            }
        }

        
        /// <inheritdoc />
        public override void Serialize( IAspect[] aspects, Stream stream, IMetadataEmitter metadataEmitter )
        {
            if ( aspects == null ) throw new ArgumentNullException(nameof(aspects));
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (metadataEmitter == null) throw new ArgumentNullException(nameof(metadataEmitter));

            IMetadataBasedSerializationBinderProvider provider = PostSharpEnvironment.CurrentProject.GetService<IMetadataBasedSerializationBinderProvider>();
            SerializationBinder serializationBinder = provider.GetSerializationBinder( metadataEmitter );

            BinaryFormatter binaryFormatter = new BinaryFormatter { Binder = serializationBinder, SurrogateSelector = surrogateSelector};

            IMetadataAwareSurrogateSelector metadataAwareSurrogateSelector = binaryFormatter.SurrogateSelector as IMetadataAwareSurrogateSelector;
            if ( metadataAwareSurrogateSelector != null )
            {
                metadataAwareSurrogateSelector.SetMetadataEmitter( metadataEmitter );
            }

#pragma warning disable SYSLIB0011 // BinaryFormatter is obsolete since .NET 5.0
            binaryFormatter.Serialize( stream, aspects );
#pragma warning restore SYSLIB0011 // BinaryFormatter is obsolete since .NET 5.0

            if ( metadataAwareSurrogateSelector != null)
            {
                metadataAwareSurrogateSelector.SetMetadataEmitter(null);
            }
        }

      

        

        /// <summary>
        /// Adds an item to the chain of surrogate selectors
        /// used during the process of serializing aspects.
        /// </summary>
        /// <param name="selector">A new surrogate selector.</param>
        public static void ChainSurrogateSelector( ISurrogateSelector selector )
        {
            if ( selector == null ) throw new ArgumentNullException( nameof(selector));

            if ( surrogateSelector == null )
            {
                surrogateSelector = selector;
            }
            else
            {
                surrogateSelector.ChainSelector( selector );
            }
        }

#if !DEBUG
        [DebuggerStepThrough]
        [DebuggerNonUserCode]
#endif

        private sealed class CustomSurrogateSelector : SurrogateSelector, IMetadataAwareSurrogateSelector
        {
            private readonly FieldInfoSerializationSurrogate fieldInfoSerializationSurrogate = new FieldInfoSerializationSurrogate();
            private readonly DelegateSerializationSurrogate delegateSerializationSurrogate = new DelegateSerializationSurrogate();
            //private readonly ParameterInfoSerializationSurrogate parameterInfoSerializationSurrogate = new ParameterInfoSerializationSurrogate();
            private MetadataSerializationSurrogate metadataSerializationSurrogate;

            void IMetadataAwareSurrogateSelector.SetMetadataEmitter( IMetadataEmitter metadataEmitter )
            {
                if ( metadataEmitter != null )
                {
                    this.metadataSerializationSurrogate = new MetadataSerializationSurrogate( metadataEmitter );
                }
                else
                {
                    this.metadataSerializationSurrogate = null;
                }
            }

            [SecurityCritical]
            public override ISerializationSurrogate GetSurrogate( Type type, StreamingContext context, out ISurrogateSelector selector )
            {

                selector = this.GetNextSelector();

                if ( ReflectionHelper.SafeIsAssignableFrom( typeof(FieldInfo), type ) )
                {
                    if ( PostSharpEnvironment.IsPostSharpRunning )
                    {
                        return this.fieldInfoSerializationSurrogate;
                    }
                }
                else if ( ReflectionHelper.SafeIsAssignableFrom( typeof(MemberInfo), type )
                            || type == typeof(LocationInfo)
                            || ReflectionHelper.SafeIsAssignableFrom( typeof(ParameterInfo), type ) )
                {
                    if ( PostSharpEnvironment.IsPostSharpRunning )
                    {

                        if ( this.metadataSerializationSurrogate != null )
                            return this.metadataSerializationSurrogate;
                    }
                    else
                    {
                        return new RuntimeSurrogate();
                    }

                }
                else if ( ReflectionHelper.SafeIsAssignableFrom( typeof(Delegate), type ) )
                {
                    return this.delegateSerializationSurrogate;
                }

                return base.GetSurrogate( type, context, out selector );
            }

            
        }

#if !DEBUG
        [DebuggerStepThrough]
        [DebuggerNonUserCode]
#endif

        private class RuntimeSurrogate : ISerializationSurrogate
        {
            [SecurityCritical]
            void ISerializationSurrogate.GetObjectData( object obj, SerializationInfo info, StreamingContext context )
            {
                throw new NotSupportedException();
            }

            [SecurityCritical]
            object ISerializationSurrogate.SetObjectData( object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector )
            {
                object realObject = BinaryAspectSerializer.CurrentMetadataDispenser.GetMetadata(info.GetInt32( "index" ));
                return realObject;
            }
        }

        private class FieldInfoSerializationSurrogate : ISerializationSurrogate
        {
            [SecurityCritical]
            public void GetObjectData( object obj, SerializationInfo info, StreamingContext context )
            {
                FieldInfo field = (FieldInfo) obj;

                if ( field != null )
                {
                    Message.Write( MessageLocation.Of( PostSharpEnvironment.CurrentProject.TargetAssembly ),
                                   SeverityType.Error, "LA0111",
                                   "Cannot serialize the FieldInfo '{0}.{1}' into an aspect, because a field can be transformed into a property by the weaver. Use a LocationInfo instead.",
                                   field.DeclaringType.FullName, field.Name );
                }
            }

            [SecurityCritical]
            public object SetObjectData( object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector )
            {
                throw new NotSupportedException();
            }
        }

        [Serializable]
        private class MetadataSerializationSurrogate : ISerializationSurrogate
        {
            private readonly IMetadataEmitter emitter;


            public MetadataSerializationSurrogate( IMetadataEmitter emitter )
            {
                this.emitter = emitter;
            }

            [SecurityCritical]
            public void GetObjectData( object obj, SerializationInfo info, StreamingContext context )
            {
                info.SetType( typeof(MetadataSerializationHolder) );
                info.AddValue( "index", this.emitter.GetMetadataIndex( obj ) );
            }

            [SecurityCritical]
            public object SetObjectData( object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector )
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// This surrogate checks that we do not try to serialize any delegate fields of the aspect class.
        /// If the delegate field has non-null value, then a build error should be raised.
        /// </summary>
        private class DelegateSerializationSurrogate : ISerializationSurrogate
        {
            [SecurityCritical]
            public void GetObjectData( object obj, SerializationInfo info, StreamingContext context )
            {
                if ( obj != null )
                {
                    Message.Write( MessageLocation.Unknown, SeverityType.Error, "LA0149",
                        "Cannot serialize delegate type {0}, fields of a delegate type inside the aspect class must be marked as [NonSerialized].", obj.GetType() );
                }
            }

            [SecurityCritical]
            public object SetObjectData( object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector )
            {
                return null;
            }
        }
    }
}

#endif