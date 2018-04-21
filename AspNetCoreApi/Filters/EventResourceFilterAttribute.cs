using AspNetCoreApi.Common;
using AspNetCoreApi.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace AspNetCoreApi.Filters
{
    public class EventResourceFilterAttribute : Attribute, IResourceFilter
    {
        readonly ITelemetryService _telemetry;
        readonly IRequestMetadata _requestMetadata;

        public EventResourceFilterAttribute(
            ITelemetryService telemetry,
            IRequestMetadata requestMetadata
        )
        {
            _requestMetadata = requestMetadata;
            _telemetry = telemetry;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var displayName = context?.ActionDescriptor?.AttributeRouteInfo?.Name;

            if (!string.IsNullOrWhiteSpace(displayName))
            {
                var properties = _requestMetadata.GetMetadataDictionary();

                _telemetry.TrackEvent(displayName, properties);
            }
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            
        }
    }
}
