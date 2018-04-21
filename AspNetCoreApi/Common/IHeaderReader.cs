using System;

namespace AspNetCoreApi.CommonAspNetCoreApi.Common
{
    /// <summary>
    /// Reads incoming HTTP request header variables and provides 
    /// a means to get them for use in application code.
    /// </summary>
    public interface IHeaderReader
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="httpContextAccessor">
        /// An accessor injected into this module to provide access to the HttpContext.Request object.
        /// </param>
        string GetHeaderValue(string keyName);
    }
}