using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace AspNetCoreApi.CommonAspNetCoreApi.Common
{
    /// <summary>
    /// Reads incoming HTTP request header variables and provides 
    /// a means to get them for use in application code.
    /// </summary>
    public class HeaderReader : IHeaderReader
    {
        HttpContext _httpContext = null;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="httpContextAccessor">
        /// An accessor injected into this module to provide access to the HttpContext.Request object.
        /// </param>
        public HeaderReader(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor != null)
            {
                _httpContext = httpContextAccessor.HttpContext;
            }
        }

        /// <summary>
        /// Internal routine providing safe reading of header values.
        /// </summary>
        /// <param name="keyName">
        /// Name of an HTTP request header variable.
        /// </param>
        /// <returns>
        /// An an HTTP request header variable value.
        /// </returns>
        public string GetHeaderValue(string keyName)
        {
            string value = string.Empty;

            if (_httpContext != null)
            {
                if (String.IsNullOrWhiteSpace(value) && !String.IsNullOrWhiteSpace(keyName))
                {
                    IHeaderDictionary headersDictionary = _httpContext.Request.Headers;

                    if (headersDictionary.Keys.Contains(keyName))
                    {
                        var headers = headersDictionary[keyName];

                        if (headers.Any())
                        {
                            value = headers[0];
                        }
                    }
                }
            }

            return value;
        }
    }
}
