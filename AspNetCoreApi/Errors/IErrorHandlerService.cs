using AspNetCoreApi.Contracts;
using AspNetCoreApi.Security;
using System;

namespace AspNetCoreApi.Errors
{
    /// <summary>
    /// Interface to Error Handler Service
    /// </summary>
    public interface IErrorHandlerService
    {
        /// <summary>
        /// Get error information base in input status code and error code.
        /// </summary>
        /// <param name="statusCode">
        /// Http Status Code
        /// </param>
        /// <param name="errorCode">
        /// Application Error Code
        /// </param>
        /// <param name="identity">
        /// LogonIdentity object instance.
        /// </param>
        /// <returns>
        /// An ErrorInfo object instance.
        /// </returns>
        //ErrorInfo GetErrorInformation(int statusCode, int errorCode);

        /// <summary>
        /// Gets error information based on input exception.
        /// </summary>
        /// <param name="ex">
        /// An Exception object instance.
        /// </param>
        /// <param name="identity">
        /// LogonIdentity object instance.
        /// </param>
        /// <returns>
        /// An ErrorInfo object instance.
        /// </returns> 
        ErrorInfo GetErrorInformation(Exception ex);
    }
}