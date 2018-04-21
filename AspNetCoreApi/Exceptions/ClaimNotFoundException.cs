using System;
using System.Runtime.Serialization;

namespace AspNetCoreApi.Exceptions
{
    /// <summary>
    ///  Claim Not Found Exception
    /// </summary>
    [Serializable]
    public class ClaimNotFoundException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ClaimNotFoundException()
        {
        }

        /// <summary>
        /// Constructer that accepts a message
        /// </summary>
        /// <param name="message">
        /// An error message.
        /// </param>
        public ClaimNotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructer that accepts a message and an inner exception
        /// </summary>
        /// <param name="message">
        /// An error message.
        /// </param>
        /// <param name="innerException"></param>
        public ClaimNotFoundException(string message, Exception innerException) : base(message, innerException)
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
        protected ClaimNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}