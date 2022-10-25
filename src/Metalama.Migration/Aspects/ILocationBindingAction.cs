// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Aspects
{
    /// <summary>
    /// Exposes an <see cref="Execute{TValue}"/> method invoked by the <see cref="ILocationBinding.Execute{TPayload}"/> method,
    /// which allows to execute strongly-typed operations and avoid boxing required by the weakly typed <see cref="ILocationBinding"/> interface.
    /// </summary>
    /// <typeparam name="TPayload">Type of the payload of the <see cref="ILocationBindingAction{TPayload}.Execute{TValue}"/> method.</typeparam>
    public interface ILocationBindingAction<TPayload>
    {
        /// <summary>
        /// Method invoked by the <see cref="ILocationBinding.Execute{TPayload}"/> method.
        /// </summary>
        /// <typeparam name="TValue">Type of the value of the <see cref="ILocationBinding"/> object.</typeparam>
        /// <param name="binding">The typed <see cref="ILocationBinding"/>.</param>
        /// <param name="payload">Payload.</param>
        void Execute<TValue>(ILocationBinding<TValue> binding, ref TPayload payload);
    }
}
