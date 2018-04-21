using Microsoft.Extensions.Options;

namespace MockRequestData
{
    /// <summary>
    /// Mock HTTP request headers builder modules for enabling local developer security.
    /// </summary>
    public class MockHeadersBuilder
    {
        private readonly MockHeadersPolicy _policy = new MockHeadersPolicy();

        HeaderOptions _headerOptions;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="headerOptionsAccessor">
        /// An accessor injected into this module to provide access to the HeaderOptions accessor object.
        /// </param>
        public MockHeadersBuilder(IOptions<HeaderOptions> headerOptionsAccessor)
        {
            _headerOptions = headerOptionsAccessor.Value;
        }

        /// <summary>
        /// Method to add to the Startup middleware to mock heep requested headers during local development.
        /// </summary>
        /// <returns>
        /// MockHeadersBuilder object instance.
        /// </returns>
        public MockHeadersBuilder AddDefaultMockHeadersPolicy()
        {
            ClientId();
            ClientName();
            MessageId();
            TransactionId();
            Username();

            return this;
        }

        /// <summary>
        /// Setts the Client Id header value from appsettings.json.
        /// </summary>
        /// <returns>
        /// MockHeadersBuilder object instance.
        /// </returns>
        public MockHeadersBuilder ClientId()
        {
            _policy.SetHeaders["ClientId"] = _headerOptions.ClientId;
            return this;
        }

        /// <summary>
        /// Setts the Client Name header value from appsettings.json.
        /// </summary>
        /// <returns>
        /// MockHeadersBuilder object instance.
        /// </returns>
        public MockHeadersBuilder ClientName()
        {
            _policy.SetHeaders["ClientName"] = _headerOptions.ClientName;
            return this;
        }

        /// <summary>
        /// Setts the Source Id header value from appsettings.json.
        /// </summary>
        /// <returns>
        /// MockHeadersBuilder object instance.
        /// </returns>
        public MockHeadersBuilder MessageId()
        {
            _policy.SetHeaders["MessageID"] = _headerOptions.MessageId;
            return this;
        }

        /// <summary>
        /// Setts the Source Party Id header value from appsettings.json.
        /// </summary>
        /// <returns>
        /// MockHeadersBuilder object instance.
        /// </returns>
        public MockHeadersBuilder TransactionId()
        {
            _policy.SetHeaders["TransactionID"] = _headerOptions.TransactionId;
            return this;
        }

        /// <summary>
        /// Setts the CU Member Id header value from appsettings.json.
        /// </summary>
        /// <returns>
        /// MockHeadersBuilder object instance.
        /// </returns>
        public MockHeadersBuilder Username()
        {
            _policy.SetHeaders["Username"] = _headerOptions.Username;
            return this;
        }

        /// <summary>
        /// Adds a Mock header value by the input header name.
        /// </summary>
        /// <param name="header">
        /// Header name.
        /// </param>
        /// <param name="value">
        /// Header value.
        /// </param>
        /// <returns>
        /// MockHeadersBuilder object instance.
        /// </returns>
        public MockHeadersBuilder AddHeader(string header, string value)
        {
            _policy.SetHeaders[header] = value;
            return this;
        }

        /// <summary>
        /// Removes a Mock header value by the input header name.
        /// </summary>
        /// <param name="header">
        /// Header name.
        /// </param>
        /// <returns>
        /// MockHeadersBuilder object instance.
        /// </returns>
        public MockHeadersBuilder RemoveHeader(string header)
        {
            _policy.RemoveHeaders.Add(header);
            return this;
        }

        /// <summary>
        /// Builds the Mock headers.
        /// </summary>
        /// <returns>
        /// MockHeadersBuilder object instance.
        /// </returns>
        public MockHeadersPolicy Build()
        {
            return _policy;
        }
    }
}
