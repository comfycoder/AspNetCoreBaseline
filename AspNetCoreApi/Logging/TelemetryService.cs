using Microsoft.ApplicationInsights;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace AspNetCoreApi.Logging
{
    /// <summary>
    /// Send events, metrics and other telemetry to the Application Insights service.
    /// </summary>
    public class TelemetryService : ITelemetryService
    {
        private readonly IConfiguration _config;
        private TelemetryClient _telemetry;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="telemetry"></param>
        public TelemetryService(IConfiguration config, TelemetryClient telemetry)
        {
            _config = config;
            _telemetry = telemetry;
        }

        /// <summary>
        /// Sends an EventTelemetry for display in Diagnostic Search and 
        /// aggregation in Metrics Explorer. (Azure Application Insights)
        /// </summary>
        /// <param name="eventName">
        /// A name for the event.
        /// </param>
        /// <param name="properties">
        /// (Optional) Named string values you can use to search and classify events.
        /// </param>
        /// <param name="metrics">
        /// (Optional) Measurements associated with this event.
        /// </param>
        public void TrackEvent(string eventName,
            IDictionary<string, string> properties = null,
            IDictionary<string, double> metrics = null)
        {
            _telemetry.TrackEvent(eventName, properties, metrics);
        }

        /// <summary>
        /// Send an ExceptionTelemetry for display in Diagnostic Search. 
        /// Create a separate ExceptionTelemetry instance for each call to 
        /// TrackException(ExceptionTelemetry). (Azure Application Insights)
        /// </summary>
        /// <param name="ex">
        /// The exception to log.
        /// </param>
        /// <param name="properties">
        /// (Optional) Named string values you can use to classify and search for this exception.
        /// </param>
        /// <param name="metrics">
        /// (Optional) Additional values associated with this exception.
        /// </param>
        public void TrackException(Exception ex,
            IDictionary<string, string> properties = null,
            IDictionary<string, double> metrics = null)
        {
            _telemetry.TrackException(ex, properties, metrics);
        }

        /// <summary>
        /// Send a trace message for display in Diagnostic Search. 
        /// Creates a separate TraceTelemetry instance for each call to 
        /// TrackTrace(TraceTelemetry). (Azure Application Insights)
        /// </summary>
        /// <param name="message">
        /// Message to display.
        /// </param>
        /// <param name="properties">
        /// (Optional) Named string values you can use to search and classify events.
        /// </param>
        public void TrackTrace(string message, IDictionary<string, string> properties = null)
        {
            _telemetry.TrackTrace(message, properties);
        }
    }
}
