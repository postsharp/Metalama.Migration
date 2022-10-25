// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Aspects
{
    /// <summary>
    /// Exposes an <see cref="Execute{TValue}"/> method invoked by the <see cref="LocationInterceptionArgs.Execute{TPayload}"/> method,
    /// which allows to execute strongly-typed operations and avoid boxing required by the weakly typed <see cref="ILocationInterceptionArgs"/> interface.
    /// </summary>
    /// <typeparam name="TPayload">Type of the payload of the <see cref="Execute{TValue}"/> method.</typeparam>
    public interface ILocationInterceptionArgsAction<TPayload>
    {
        /// <summary>
        /// Method invoked by the <see cref="LocationInterceptionArgs.Execute{TPayload}"/> method.
        /// </summary>
        /// <typeparam name="TValue">Type of the value of the <see cref="LocationInterceptionArgs"/> object.</typeparam>
        /// <param name="args">The typed <see cref="LocationInterceptionArgs"/>.</param>
        /// <param name="payload">Payload passed to the <see cref="LocationInterceptionArgs.Execute{TPayload}"/> method.</param>
        void Execute<TValue>(ILocationInterceptionArgs<TValue> args, ref TPayload payload);
    }
}
