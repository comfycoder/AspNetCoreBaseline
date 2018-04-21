using System;
using System.Runtime.Serialization;

namespace AspNetCoreApi.Exceptions
{
    /// <summary>
    /// Header Key Not Found Exception
    /// </summary>
    [Serializable]
    public class HeaderKeyNotFoundException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public HeaderKeyNotFoundException()
        {
        }

        /// <summary>
        /// Constructer that accepts a message
        /// </summary>
        /// <param name="message">
        /// An error message.
        /// </param>
        public HeaderKeyNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructer that accepts a message and an inner exception
        /// </summary>
        /// <param name="message">
        /// An error message.
        /// </param>
        /// <param name="innerException"></param>
        public HeaderKeyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Constructor that accepts a SerializationInfo and StreamingContext object instances.
        /// </summary>
        /// <param name="info">
        /// A SerializationInfo object instance.
        /// </param>
        /// <param name="context">
        /// A SerializationInfo object instance.
        /// </param>
        protected HeaderKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}