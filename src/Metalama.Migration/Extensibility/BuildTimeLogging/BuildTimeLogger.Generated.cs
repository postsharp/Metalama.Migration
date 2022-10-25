// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
// THIS FILE IS T4-GENERATED.
// To edit, go to Logger.Generated.tt.
// To transform, run this: "C:\Program Files (x86)\Common Files\Microsoft Shared\TextTemplating\14.0\TextTransform.exe" BuildTimeLogger.Generated.tt
// The transformation is not automatic because we are in a shared project.



namespace PostSharp.Extensibility.BuildTimeLogging
{

	public partial class BuildTimeLogger
	{

			/// <summary>
        ///   Appends a string to the next message and formats it using a formatting string and 1 argument. 
        ///   The message is sent and flushed when the <see cref="WriteLine(string)"/> method is invoked.
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			public void Write<T1>( string format, T1 arg1 )
		{
			string message = SafeStringFormat( format, arg1 );
			this.InternalWrite( message );
		}

		/// <summary>
        ///   Writes a message given a formatting string and 1 argument. 
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			public void WriteLine<T1>( string format, T1 arg1 )
		{
			string message = SafeStringFormat( format, arg1 );
			this.InternalWriteLine( message );
		}

		/// <summary>
        /// Writes a message given a formatting string and 1 argument, and increases the indentation level. To decrease the indentation level, dispose the <see cref="BuildTimeLogActivity"/>
        /// returned by this method.
        /// </summary>
        /// <param name="format">Message.</param>
        /// <returns>An opaque object to be disposed at the end of the activity to decrease the indentation level.</returns>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			public BuildTimeLogActivity Activity<T1>( string format, T1 arg1 )
		{
			string message = SafeStringFormat( format, arg1 );
			return this.Activity( message );
		}

			/// <summary>
        ///   Appends a string to the next message and formats it using a formatting string and 2 arguments. 
        ///   The message is sent and flushed when the <see cref="WriteLine(string)"/> method is invoked.
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			public void Write<T1, T2>( string format, T1 arg1, T2 arg2 )
		{
			string message = SafeStringFormat( format, arg1, arg2 );
			this.InternalWrite( message );
		}

		/// <summary>
        ///   Writes a message given a formatting string and 2 arguments. 
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			public void WriteLine<T1, T2>( string format, T1 arg1, T2 arg2 )
		{
			string message = SafeStringFormat( format, arg1, arg2 );
			this.InternalWriteLine( message );
		}

		/// <summary>
        /// Writes a message given a formatting string and 2 arguments, and increases the indentation level. To decrease the indentation level, dispose the <see cref="BuildTimeLogActivity"/>
        /// returned by this method.
        /// </summary>
        /// <param name="format">Message.</param>
        /// <returns>An opaque object to be disposed at the end of the activity to decrease the indentation level.</returns>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			public BuildTimeLogActivity Activity<T1, T2>( string format, T1 arg1, T2 arg2 )
		{
			string message = SafeStringFormat( format, arg1, arg2 );
			return this.Activity( message );
		}

			/// <summary>
        ///   Appends a string to the next message and formats it using a formatting string and 3 arguments. 
        ///   The message is sent and flushed when the <see cref="WriteLine(string)"/> method is invoked.
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			public void Write<T1, T2, T3>( string format, T1 arg1, T2 arg2, T3 arg3 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3 );
			this.InternalWrite( message );
		}

		/// <summary>
        ///   Writes a message given a formatting string and 3 arguments. 
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			public void WriteLine<T1, T2, T3>( string format, T1 arg1, T2 arg2, T3 arg3 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3 );
			this.InternalWriteLine( message );
		}

		/// <summary>
        /// Writes a message given a formatting string and 3 arguments, and increases the indentation level. To decrease the indentation level, dispose the <see cref="BuildTimeLogActivity"/>
        /// returned by this method.
        /// </summary>
        /// <param name="format">Message.</param>
        /// <returns>An opaque object to be disposed at the end of the activity to decrease the indentation level.</returns>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			public BuildTimeLogActivity Activity<T1, T2, T3>( string format, T1 arg1, T2 arg2, T3 arg3 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3 );
			return this.Activity( message );
		}

			/// <summary>
        ///   Appends a string to the next message and formats it using a formatting string and 4 arguments. 
        ///   The message is sent and flushed when the <see cref="WriteLine(string)"/> method is invoked.
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			public void Write<T1, T2, T3, T4>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4 );
			this.InternalWrite( message );
		}

		/// <summary>
        ///   Writes a message given a formatting string and 4 arguments. 
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			public void WriteLine<T1, T2, T3, T4>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4 );
			this.InternalWriteLine( message );
		}

		/// <summary>
        /// Writes a message given a formatting string and 4 arguments, and increases the indentation level. To decrease the indentation level, dispose the <see cref="BuildTimeLogActivity"/>
        /// returned by this method.
        /// </summary>
        /// <param name="format">Message.</param>
        /// <returns>An opaque object to be disposed at the end of the activity to decrease the indentation level.</returns>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			public BuildTimeLogActivity Activity<T1, T2, T3, T4>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4 );
			return this.Activity( message );
		}

			/// <summary>
        ///   Appends a string to the next message and formats it using a formatting string and 5 arguments. 
        ///   The message is sent and flushed when the <see cref="WriteLine(string)"/> method is invoked.
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			/// <typeparam name="T5">Type of the 5-th parameter.</typeparam>
		/// <param name="arg5">Value of the 5-th parameter.</param>
			public void Write<T1, T2, T3, T4, T5>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4, arg5 );
			this.InternalWrite( message );
		}

		/// <summary>
        ///   Writes a message given a formatting string and 5 arguments. 
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			/// <typeparam name="T5">Type of the 5-th parameter.</typeparam>
		/// <param name="arg5">Value of the 5-th parameter.</param>
			public void WriteLine<T1, T2, T3, T4, T5>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4, arg5 );
			this.InternalWriteLine( message );
		}

		/// <summary>
        /// Writes a message given a formatting string and 5 arguments, and increases the indentation level. To decrease the indentation level, dispose the <see cref="BuildTimeLogActivity"/>
        /// returned by this method.
        /// </summary>
        /// <param name="format">Message.</param>
        /// <returns>An opaque object to be disposed at the end of the activity to decrease the indentation level.</returns>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			/// <typeparam name="T5">Type of the 5-th parameter.</typeparam>
		/// <param name="arg5">Value of the 5-th parameter.</param>
			public BuildTimeLogActivity Activity<T1, T2, T3, T4, T5>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4, arg5 );
			return this.Activity( message );
		}

			/// <summary>
        ///   Appends a string to the next message and formats it using a formatting string and 6 arguments. 
        ///   The message is sent and flushed when the <see cref="WriteLine(string)"/> method is invoked.
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			/// <typeparam name="T5">Type of the 5-th parameter.</typeparam>
		/// <param name="arg5">Value of the 5-th parameter.</param>
			/// <typeparam name="T6">Type of the 6-th parameter.</typeparam>
		/// <param name="arg6">Value of the 6-th parameter.</param>
			public void Write<T1, T2, T3, T4, T5, T6>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4, arg5, arg6 );
			this.InternalWrite( message );
		}

		/// <summary>
        ///   Writes a message given a formatting string and 6 arguments. 
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			/// <typeparam name="T5">Type of the 5-th parameter.</typeparam>
		/// <param name="arg5">Value of the 5-th parameter.</param>
			/// <typeparam name="T6">Type of the 6-th parameter.</typeparam>
		/// <param name="arg6">Value of the 6-th parameter.</param>
			public void WriteLine<T1, T2, T3, T4, T5, T6>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4, arg5, arg6 );
			this.InternalWriteLine( message );
		}

		/// <summary>
        /// Writes a message given a formatting string and 6 arguments, and increases the indentation level. To decrease the indentation level, dispose the <see cref="BuildTimeLogActivity"/>
        /// returned by this method.
        /// </summary>
        /// <param name="format">Message.</param>
        /// <returns>An opaque object to be disposed at the end of the activity to decrease the indentation level.</returns>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			/// <typeparam name="T5">Type of the 5-th parameter.</typeparam>
		/// <param name="arg5">Value of the 5-th parameter.</param>
			/// <typeparam name="T6">Type of the 6-th parameter.</typeparam>
		/// <param name="arg6">Value of the 6-th parameter.</param>
			public BuildTimeLogActivity Activity<T1, T2, T3, T4, T5, T6>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4, arg5, arg6 );
			return this.Activity( message );
		}

			/// <summary>
        ///   Appends a string to the next message and formats it using a formatting string and 7 arguments. 
        ///   The message is sent and flushed when the <see cref="WriteLine(string)"/> method is invoked.
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			/// <typeparam name="T5">Type of the 5-th parameter.</typeparam>
		/// <param name="arg5">Value of the 5-th parameter.</param>
			/// <typeparam name="T6">Type of the 6-th parameter.</typeparam>
		/// <param name="arg6">Value of the 6-th parameter.</param>
			/// <typeparam name="T7">Type of the 7-th parameter.</typeparam>
		/// <param name="arg7">Value of the 7-th parameter.</param>
			public void Write<T1, T2, T3, T4, T5, T6, T7>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4, arg5, arg6, arg7 );
			this.InternalWrite( message );
		}

		/// <summary>
        ///   Writes a message given a formatting string and 7 arguments. 
        /// </summary>
        /// <param name = "format">Message formatting string.</param>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			/// <typeparam name="T5">Type of the 5-th parameter.</typeparam>
		/// <param name="arg5">Value of the 5-th parameter.</param>
			/// <typeparam name="T6">Type of the 6-th parameter.</typeparam>
		/// <param name="arg6">Value of the 6-th parameter.</param>
			/// <typeparam name="T7">Type of the 7-th parameter.</typeparam>
		/// <param name="arg7">Value of the 7-th parameter.</param>
			public void WriteLine<T1, T2, T3, T4, T5, T6, T7>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4, arg5, arg6, arg7 );
			this.InternalWriteLine( message );
		}

		/// <summary>
        /// Writes a message given a formatting string and 7 arguments, and increases the indentation level. To decrease the indentation level, dispose the <see cref="BuildTimeLogActivity"/>
        /// returned by this method.
        /// </summary>
        /// <param name="format">Message.</param>
        /// <returns>An opaque object to be disposed at the end of the activity to decrease the indentation level.</returns>
				/// <typeparam name="T1">Type of the 1-th parameter.</typeparam>
		/// <param name="arg1">Value of the 1-th parameter.</param>
			/// <typeparam name="T2">Type of the 2-th parameter.</typeparam>
		/// <param name="arg2">Value of the 2-th parameter.</param>
			/// <typeparam name="T3">Type of the 3-th parameter.</typeparam>
		/// <param name="arg3">Value of the 3-th parameter.</param>
			/// <typeparam name="T4">Type of the 4-th parameter.</typeparam>
		/// <param name="arg4">Value of the 4-th parameter.</param>
			/// <typeparam name="T5">Type of the 5-th parameter.</typeparam>
		/// <param name="arg5">Value of the 5-th parameter.</param>
			/// <typeparam name="T6">Type of the 6-th parameter.</typeparam>
		/// <param name="arg6">Value of the 6-th parameter.</param>
			/// <typeparam name="T7">Type of the 7-th parameter.</typeparam>
		/// <param name="arg7">Value of the 7-th parameter.</param>
			public BuildTimeLogActivity Activity<T1, T2, T3, T4, T5, T6, T7>( string format, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7 )
		{
			string message = SafeStringFormat( format, arg1, arg2, arg3, arg4, arg5, arg6, arg7 );
			return this.Activity( message );
		}

	


	}
}


