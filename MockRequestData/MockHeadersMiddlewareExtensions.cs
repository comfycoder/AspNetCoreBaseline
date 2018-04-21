using Microsoft.AspNetCore.Builder;

namespace MockRequestData
{
    /// <summary>
    /// Middleware used to add mock headers into the http request pipeline.
    /// </summary>
    public static class MockHeadersMiddlewareExtensions
    {
        /// <summary>
        /// Adds mock headers into the http request pipeline.
        /// </summary>
        /// <param name="app">
        /// ApplicationBuilder object instance.
        /// </param>
        /// <param name="builder">
        /// MockHeadersBuild object instance.
        /// </param>
        /// <returns>
        /// Updated ApplicationBuilder object instance.
        /// </returns>
        public static IApplicationBuilder UseMockHeadersMiddleware(this IApplicationBuilder app, MockHeadersBuilder builder)
        {
            MockHeadersPolicy policy = builder.Build();

            return app.UseMiddleware<MockHeadersMiddleware>(policy);
        }
    }
}
