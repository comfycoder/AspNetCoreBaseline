using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MockRequestData
{
    /// <summary>
    /// Middleware module to add and remove mock header values to/from the http request pipeline.
    /// </summary>
    public class MockHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly MockHeadersPolicy _policy;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="next">
        /// Next delegate method in the request processing pipeline.
        /// </param>
        /// <param name="policy">
        /// Mock header policy container class instance.
        /// </param>
        public MockHeadersMiddleware(RequestDelegate next, MockHeadersPolicy policy)
        {
            _next = next;
            _policy = policy;
        }

        /// <summary>
        /// Middleware Invoke method.
        /// </summary>
        /// <param name="context">
        /// HttpContect instance.
        /// </param>
        /// <returns>
        /// Task
        /// </returns>
        public async Task Invoke(HttpContext context)
        {
            IHeaderDictionary headers = context.Request.Headers;

            foreach (var headerValuePair in _policy.SetHeaders)
            {
                headers[headerValuePair.Key] = headerValuePair.Value;
            }

            foreach (var header in _policy.RemoveHeaders)
            {
                headers.Remove(header);
            }

            await _next(context);
        }
    }
}
