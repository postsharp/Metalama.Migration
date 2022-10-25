// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PostSharp.Extensibility.BuildTimeLogging
{
    internal static class BuildTimeLoggingConfiguration
    {
        private static readonly HashSet<string> enabledCategories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<string, List<Action<string>>> whenEnabledActions = new Dictionary<string, List<Action<string>>>(StringComparer.OrdinalIgnoreCase );

        internal static bool IsEnabled(string category)
        {
            if ( !IsInitialized )
                throw new InvalidOperationException("Cannot call IsEnabled because Initialize has not been called. Use WhenEnabled.WhenEnabled");

            bool isEnabled = enabledCategories.Contains(category);

            return isEnabled;
        }

        internal static void WhenEnabled( string category, Action<string> action )
        {
            if ( enabledCategories.Contains(category))
            {
                action(category);
            }
            else
            {
                if ( !whenEnabledActions.TryGetValue(category, out List<Action<string>> actions )  )
                {
                    actions = new List<Action<string>>();
                    whenEnabledActions.Add(category, actions );
                }

                actions.Add(action );
            }
        }

        public static void Initialize( IEnumerable<string> categories = null )
        {
            if (IsInitialized)
                throw new InvalidOperationException("The configuration is frozen.");

            if ( categories != null )
            {
                foreach ( string category in categories )
                {
                    enabledCategories.Add(category);

                    if (whenEnabledActions.TryGetValue(category, out List<Action<string>> actions))
                    {
                        foreach (Action<string> action in actions)
                        {
                            action(category);
                        }
                    }
                }
            }

          

            IsInitialized = true;
        }


        public static bool IsInitialized { get; private set; }
    }
}

