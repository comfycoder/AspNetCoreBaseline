using System;
using System.Runtime.Serialization;

namespace AspNetCoreApi.Exceptions
{
    /// <summary>
    /// Missing Claim Value Exception
    /// </summary>
    [Serializable]
    public class MissingClaimValueException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MissingClaimValueException()
        {
        }

        /// <summary>
        /// Constructer that accepts a message
        /// </summary>
        /// <param name="message">
        /// An error message.
        /// </param>
        public MissingClaimValueException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructer that accepts a message and an inner exception
        /// </summary>
        /// <param name="message">
        /// An error message.
        /// </param>
        /// <param name="innerException"></param>
        public MissingClaimValueException(string message, Exception innerException) : base(message, innerException)
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
        protected MissingClaimValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}