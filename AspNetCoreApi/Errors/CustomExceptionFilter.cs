using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using AspNetCoreApi.Contracts;
using Newtonsoft.Json;
using AspNetCoreApi.Common;

namespace AspNetCoreApi.Errors
{
    /// <summary>
    /// Handles other uncaught exceptions.
    /// </summary>
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IRequestMetadata _requestMetadata;
        private readonly IErrorHandlerService _errorHandlerService;

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomExceptionFilter(IRequestMetadata requestMetadata, IErrorHandlerService errorHandlerService)
        {
            _requestMetadata = requestMetadata;

            _errorHandlerService = errorHandlerService;
        }

        /// <summary>
        /// Main exception handler method.
        /// </summary>
        /// <param name="context">
        /// An instance of an ExceptionContext object.
        /// </param>
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;

            var response = context.HttpContext.Response;

            context.ExceptionHandled = true;

            var errorInfo = _errorHandlerService.GetErrorInformation(ex);

            response.StatusCode = errorInfo.Status;

            response.ContentType = "application/json";

            var errorResponse = new ErrorResponse
            {
                Error = errorInfo
            };

            var error = JsonConvert.SerializeObject(errorResponse);

            response.WriteAsync(error);
        }
    }
}
