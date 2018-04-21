using System;
using System.Collections.Generic;

namespace AspNetCoreApi.Logging
{
    /// <summary>
    /// Send events, metrics and other telemetry to the Application Insights service.
    /// </summary>
    public interface ITelemetryService
    {
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
        void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);

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
        void TrackException(Exception ex, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);

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
        void TrackTrace(string message, IDictionary<string, string> properties = null);
    }
}