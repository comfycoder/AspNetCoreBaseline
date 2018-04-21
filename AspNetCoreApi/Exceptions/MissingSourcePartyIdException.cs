using System;
using System.Runtime.Serialization;

namespace AspNetCoreApi.Exceptions
{
    /// <summary>
    /// Missing Source Party Id Exception
    /// </summary>
    [Serializable]
    public class MissingSourcePartyIdException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MissingSourcePartyIdException()
        {
        }

        /// <summary>
        /// Constructer that accepts a message
        /// </summary>
        /// <param name="message">
        /// An error message.
        /// </param>
        public MissingSourcePartyIdException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructer that accepts a message and an inner exception
        /// </summary>
        /// <param name="message">
        /// An error message.
        /// </param>
        /// <param name="innerException"></param>
        public MissingSourcePartyIdException(string message, Exception innerException) : base(message, innerException)
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
        protected MissingSourcePartyIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}