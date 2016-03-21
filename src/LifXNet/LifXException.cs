using System;

namespace LifXNet
{
    /// <summary>
    /// The exception that is thrown when an error occurs in the LifXNet library.
    /// </summary>
    public class LifXNetException : Exception
    {
        /// <summary>
        /// Constructs a new LifXException with the given message.
        /// </summary>
        /// <param name="message">The message.</param>
        public LifXNetException(string message) : base(message) { }

        /// <summary>
        /// Constructs a new LifXException with a message using the given format and values.
        /// </summary>
        /// <param name="format">The message format.</param>
        /// <param name="values">The values in the message.</param>
        public LifXNetException(string format, params object[] values) : this(string.Format(format, values)) { }
    }
}
