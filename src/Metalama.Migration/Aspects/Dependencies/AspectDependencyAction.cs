// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   Enumeration of the different kinds of relationships of specified by aspect dependencies.
    /// </summary>
    /// <remarks>
    ///   <para>The combined values of <see cref = "AspectDependencyAction" /> and <see cref = "AspectDependencyPosition" /> is interpreted
    ///     as follows:</para>
    ///   <table>
    ///     <tr>   <th>Action</th>   <th>Position</th>   <th>Description</th>  </tr>
    ///     <tr>   
    ///       <td><see cref = "AspectDependencyAction.Order" /></td>
    ///       <td><see cref = "AspectDependencyPosition.After" /></td>
    ///       <td>The current aspect or advice should be positioned <i>after</i> the other aspect or advice
    ///         matched by the custom attribute.</td>
    ///     </tr>
    ///     <tr>   
    ///       <td><see cref = "AspectDependencyAction.Order" /></td>
    ///       <td><see cref = "AspectDependencyPosition.Before" /></td>
    ///       <td>The current aspect or advice should be positioned <i>before</i> the other aspect or advice
    ///         matched by the custom attribute.</td>
    ///     </tr>
    ///     <tr>   
    ///       <td><see cref = "AspectDependencyAction.Require" /></td>
    ///       <td><see cref = "AspectDependencyPosition.Any" /></td>
    ///       <td>The current aspect or advice requires another aspect or advice
    ///         matched by the custom attribute, at any position.</td>
    ///     </tr>
    ///     <tr>   
    ///       <td><see cref = "AspectDependencyAction.Require" /></td>
    ///       <td><see cref = "AspectDependencyPosition.After" /></td>
    ///       <td>The current aspect or advice requires another aspect or advice
    ///         matched by the custom attribute positioned <i>after</i> the current one.</td>
    ///     </tr>
    ///     <tr>   
    ///       <td><see cref = "AspectDependencyAction.Require" /></td>
    ///       <td><see cref = "AspectDependencyPosition.Before" /></td>
    ///       <td>The current aspect or advice requires another aspect or advice
    ///         matched by the custom attribute positioned <i>before</i> the current one.</td>
    ///     </tr>
    ///     <tr>   
    ///       <td><see cref = "AspectDependencyAction.Conflict" /></td>
    ///       <td><see cref = "AspectDependencyPosition.Any" /></td>
    ///       <td>The current aspect or advice conflicts with any aspect or advice
    ///         matched by the custom attribute, at any position.</td>
    ///     </tr>
    ///     <tr>   
    ///       <td><see cref = "AspectDependencyAction.Conflict" /></td>
    ///       <td><see cref = "AspectDependencyPosition.After" /></td>
    ///       <td>The current aspect or advice conflicts with any aspect or advice
    ///         matched by the custom attribute, if positioned <i>after</i> the current one.</td>
    ///     </tr>  
    ///     <tr>   
    ///       <td><see cref = "AspectDependencyAction.Conflict" /></td>
    ///       <td><see cref = "AspectDependencyPosition.Before" /></td>
    ///       <td>The current aspect or advice conflicts with any aspect or advice
    ///         matched by the custom attribute, if positioned <i>before</i> the current one.</td>
    ///     </tr>   
    ///     <tr>   
    ///       <td><see cref = "AspectDependencyAction.Commute" /></td>
    ///       <td></td>
    ///       <td>The current aspect or advice commute with any other aspect or advice
    ///         matched by the custom attribute.
    ///       </td></tr>
    ///   </table>
    /// </remarks>
    public enum AspectDependencyAction
    {
        /// <summary>
        ///   The dependency is ignored.
        /// </summary>
        None,

        /// <summary>
        ///   The dependency specifies an order relationship.
        /// </summary>
        Order,

        /// <summary>
        ///   The dependency specifies that the current aspect or advice requires
        ///   another aspect or advice.
        /// </summary>
        Require,

        /// <summary>
        ///   The dependency specifies that the current aspect or advice
        ///   conflicts with another aspect or advice.
        /// </summary>
        Conflict,

        /// <summary>
        ///   The dependency specifies that the current aspect or advice
        ///   commutes with another aspect or advice.
        /// </summary>
        Commute
    }
}
