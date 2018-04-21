using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using AspNetCoreApi.Logging;
using AspNetCoreApi.Contracts;
using AspNetCoreApi.Exceptions;
using System;
using System.Collections.Generic;
using AspNetCoreApi.Common;

namespace AspNetCoreApi.Errors
{
    /// <summary>
    /// Error Handler Service
    /// </summary>
    public class ErrorHandlerService : IErrorHandlerService
    {
        private readonly IConfiguration _config;
        readonly IRequestMetadata _requestMetadata;
        private readonly ITelemetryService _telemetryService;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="telemetryService"></param>
        public ErrorHandlerService(IConfiguration config, ITelemetryService telemetryService, IRequestMetadata requestMetadata)
        {
            _requestMetadata = requestMetadata;
            _config = config;
            _telemetryService = telemetryService;
        }

        /// <summary>
        /// Populates an error infor object.
        /// </summary>
        /// <param name="status">
        /// An Http Status Code.
        /// </param>
        /// <param name="developerMessage">
        /// An error message to support developer troubleshooting.
        /// </param>
        /// <param name="message">
        /// An error message description.
        /// </param>
        /// <param name="errorCode">
        /// An application error code number.
        /// </param>        
        /// <returns>
        /// An ErrorInfo object instance.
        /// </returns>
        private ErrorInfo SetErrorInformation(int status, string message, int errorCode)
        {
            _requestMetadata.GetMetadata();

            var errorInfo = new ErrorInfo
            {
                Status = status,
                Message = message,
                ErrorCode = errorCode,
                MessageId = _requestMetadata.MessageId,
                TransactionId = _requestMetadata.TransactionId,
                MoreInformation = _config["ApiOptions:DocumentationUrl"] + errorCode
            };

            return errorInfo;
        }

        /// <summary>
        /// Set additional properties for the telemetry object.
        /// </summary>
        /// <param name="errorInfo">
        /// An ErrorInfo object instance.
        /// </param>
        /// <param name="identity">
        /// And (optional) LogonIdentity object instance.
        /// </param>
        /// <returns>
        /// A string Dictionary object with the newly set additional telemetry properties.
        /// </returns>
        private Dictionary<string, string> SetTelemetryProperties(ErrorInfo errorInfo)
        {
            var properties = new Dictionary<string, string>
            {
                { "Error_Status", errorInfo.Status.ToString() },
                { "Error_Code", errorInfo.ErrorCode.ToString() },
                { "Error_Message", errorInfo.Message }
            };

            if (_requestMetadata != null)
            {
                properties.Add("Identity_ClientName", _requestMetadata.ClientName);
                properties.Add("Identity_Username", _requestMetadata.Username);
                properties.Add("Identity_MessageId", _requestMetadata.MessageId);
                properties.Add("Identity_TransactionId", _requestMetadata.TransactionId);
            }

            return properties;
        }

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
        public ErrorInfo GetErrorInformation(Exception ex)
        {
            var errorInfo = new ErrorInfo();

            var exceptionType = ex.GetType();

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                errorInfo = SetErrorInformation(StatusCodes.Status401Unauthorized, 
                    ErrorMessages.Unauthorized, StatusCodes.Status401Unauthorized);
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                errorInfo = SetErrorInformation(StatusCodes.Status501NotImplemented, 
                    ErrorMessages.NotImplemented, StatusCodes.Status501NotImplemented);
            }
            else if (exceptionType == typeof(InvalidClientIdException))
            {
                errorInfo = SetErrorInformation(StatusCodes.Status401Unauthorized, 
                    ErrorMessages.InvalidClientId, ErrorCodes.InvalidClientId);
            }
            else if (exceptionType == typeof(MissingSourcePartyIdException))
            {
                errorInfo = SetErrorInformation(StatusCodes.Status401Unauthorized, 
                    ErrorMessages.MissingSourcePartyId, ErrorCodes.MissingSourcePartyId);
            }
            else if (exceptionType == typeof(MissingCUMemberIdException))
            {
                errorInfo = SetErrorInformation(StatusCodes.Status401Unauthorized, 
                    ErrorMessages.MissingCUMemberId, ErrorCodes.MissingCUMemberId);
            }
            else if (exceptionType == typeof(CUMemberLookupException))
            {
                errorInfo = SetErrorInformation(StatusCodes.Status409Conflict, 
                    ErrorMessages.CUMemberLookupFailed, ErrorCodes.CUMemberLookupFailed);
            }
            else
            {
                errorInfo = SetErrorInformation(StatusCodes.Status500InternalServerError, 
                    ErrorMessages.InternalServerError, StatusCodes.Status500InternalServerError);
            }

            var message = $"Http Status Code: {errorInfo.Status}; Error Code: {errorInfo.ErrorCode}; Message: {errorInfo.Message}";

            var newEx = new ApplicationException(message, ex);

            var telemetryProperties = SetTelemetryProperties(new ErrorInfo());

            _telemetryService.TrackException(newEx, telemetryProperties);

            return errorInfo;
        }

        /// <summary>
        /// Get error information base in input status code and error code.
        /// </summary>
        /// <param name="statusCode">
        /// Http Status Code
        /// </param>
        /// <param name="errorCode">
        /// Application Error Code
        /// </param>
        /// <returns>
        /// An ErrorInfo object instance.
        /// </returns>
        //public ErrorInfo GetErrorInformation(int statusCode, int errorCode)
        //{
        //    var errorInfo = new ErrorInfo();

        //    switch (errorCode)
        //    {
        //        case ErrorCodes.Unauthorized:
        //            errorInfo = SetErrorInformation(statusCode, 
        //                ErrorMessages.Unauthorized, errorCode);
        //            break;
        //    }

        //    var message = $"Http Status Code: {errorInfo.Status}; Error Code: {errorInfo.ErrorCode}; Message: {errorInfo.Message}";

        //    var ex = new ApplicationException(message);

        //    var telemetryProperties = SetTelemetryProperties(errorInfo);

        //    _telemetryService.TrackException(ex, telemetryProperties);

        //    return errorInfo;
        //}
    }
}
