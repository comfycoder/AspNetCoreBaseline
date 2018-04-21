using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreApi.Common
{
    public interface IRequestMetadata
    {
        /// <summary>
        /// Internal routine providing safe reading of header values.
        /// </summary>
        /// <param name="keyName">
        /// Name of an HTTP request header variable.
        /// </param>
        /// <returns>
        /// An an HTTP request header variable value.
        /// </returns>
        string GetHeaderValue(string keyName);
        RequestMetadata GetMetadata();
        Dictionary<string, string> GetMetadataDictionary();

        string ApplicationName { get; set; }
        /// <summary>
        /// API key of the remote client application.
        /// </summary>
        string ClientId { get; set; }
        /// <summary>
        /// Service account name of the remote client application.
        /// </summary>
        string ClientName { get; set; }
        string MachineName { get; set; }
        /// <summary>
        /// Data Processor Source – A string name provided by CUNA Mutual Financial Group (CMFG) 
        /// that identifies the source of the CU member information. 
        /// Note: This name may indicate either the credit union itself or their data processor.
        /// </summary>
        string MessageId { get; set; }
        string RemoteIPAddress { get; set; }
        /// <summary>
        /// CU ID from Source – A unique identifier assigned to the credit union 
        /// by either CMFG or the credit union's data processor.
        /// </summary>
        string TransactionId { get; set; }
        /// <summary>
        /// CU Member ID – A unique identifier assigned to the CU member by either 
        /// the credit union or their data processor.
        /// </summary>
        string Username { get; set; }
    }

    public class RequestMetadata : IRequestMetadata
    {
        readonly IHostingEnvironment _env;
        readonly IHttpContextAccessor _httpContextAccessor;

        public string MachineName { get; set; }

        public string RemoteIPAddress { get; set; }

        public string ApplicationName { get; set; }

        /// <summary>
        /// API key of the remote client application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Service account name of the remote client application.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Data Processor Source – A string name provided by CUNA Mutual Financial Group (CMFG) 
        /// that identifies the source of the CU member information. 
        /// Note: This name may indicate either the credit union itself or their data processor.
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// CU ID from Source – A unique identifier assigned to the credit union 
        /// by either CMFG or the credit union's data processor.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// CU Member ID – A unique identifier assigned to the CU member by either 
        /// the credit union or their data processor.
        /// </summary>
        public string Username { get; set; }

        public RequestMetadata(IHostingEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _env = env;
        }

        public RequestMetadata GetMetadata()
        {
            this.MachineName = Environment.MachineName;
            this.RemoteIPAddress = _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            this.ApplicationName = _env.ApplicationName;
            this.ClientId = GetHeaderValue("ClientId");
            this.ClientName = GetHeaderValue("ClientName");
            this.MessageId = GetHeaderValue("MessageID");
            this.TransactionId = GetHeaderValue("TransactionID");
            this.Username = GetHeaderValue("Username");

            return this;
        }

        public Dictionary<string, string> GetMetadataDictionary()
        {
            var properties = new Dictionary<string, string>();

            var metadata = GetMetadata();

            if (metadata != null)
            {
                properties.Add("Identity_ClientId", this.ClientId);
                properties.Add("Identity_ClientName", this.ClientName);
                properties.Add("Identity_Username", this.Username);

                properties.Add("Correlation_MessageId", this.MessageId);
                properties.Add("Correlation_TransactionId", this.TransactionId);
            }

            return properties;
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

            if (_httpContextAccessor?.HttpContext != null)
            {
                if (String.IsNullOrWhiteSpace(value) && !String.IsNullOrWhiteSpace(keyName))
                {
                    IHeaderDictionary headersDictionary = _httpContextAccessor.HttpContext?.Request?.Headers;

                    if (headersDictionary != null && headersDictionary.Keys.Contains(keyName))
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
