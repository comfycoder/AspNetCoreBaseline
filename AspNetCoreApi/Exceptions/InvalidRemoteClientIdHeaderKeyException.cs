//using System;
//using System.Runtime.Serialization;

//namespace AspNetCoreApi.Exceptions
//{
//    /// <summary>
//    /// Invalid Remote ClientId Header Key Exception
//    /// </summary>
//    [Serializable]
//    public class InvalidRemoteClientIdHeaderKeyException : Exception
//    {
//        /// <summary>
//        /// Default constructor
//        /// </summary>
//        public InvalidRemoteClientIdHeaderKeyException()
//        {
//        }

//        /// <summary>
//        /// Constructer that accepts a message
//        /// </summary>
//        /// <param name="message">
//        /// An error message.
//        /// </param>
//        public InvalidRemoteClientIdHeaderKeyException(string message) : base(message)
//        {
//        }

//        /// <summary>
//        /// Constructer that accepts a message and an inner exception
//        /// </summary>
//        /// <param name="message">
//        /// An error message.
//        /// </param>
//        /// <param name="innerException"></param>
//        public InvalidRemoteClientIdHeaderKeyException(string message, Exception innerException) : base(message, innerException)
//        {
//        }

//        /// <summary>
//        /// Constructor that accepts a SerializationInfo and StreamingContext object instances.
//        /// </summary>
//        /// <param name="info">
//        /// A SerializationInfo object instance.
//        /// </param>
//        /// <param name="context">
//        /// A SerializationInfo object instance.
//        /// </param>
//        protected InvalidRemoteClientIdHeaderKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
//        {
//        }
//    }
//}