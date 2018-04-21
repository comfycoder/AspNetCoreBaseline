using Microsoft.AspNetCore.Http;
using AspNetCoreApi.CommonAspNetCoreApi.Common;
using System.Linq;

namespace AspNetCoreApi.Common
{
    /// <summary>
    /// Read JWT claims.
    /// </summary>
    public class ClaimReader : IClaimReader
    {
        private readonly HttpContext _httpContext;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        public ClaimReader(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        /// <summary>
        /// Get a claim string value by the input claim type name.
        /// </summary>
        /// <param name="claimType">
        /// Name of the claim type.
        /// </param>
        /// <returns>
        /// Claim value as a string.
        /// </returns>
        public string GetClaimStringValue(string claimType)
        {
            string result = null;

            var user = _httpContext.User;

            var claim = user.Claims.Where(c => c.Type == claimType).FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(claim.Value))
            {
                result = claim.Value;
            }

            return result;
        }

        /// <summary>
        /// Get a claim integer value by the input claim type name.
        /// </summary>
        /// <param name="claimType">
        /// Name of the claim type.
        /// </param>
        /// <returns>
        /// Claim value as an integer.
        /// </returns>
        public int GetClaimIntValue(string claimType)
        {
            int result = 0;

            var user = _httpContext.User;

            var claim = user.Claims.Where(c => c.Type == claimType).FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(claim.Value))
            {
                int.TryParse(claim.Value, out result);
            }

            return result;
        }

        /// <summary>
        /// Get a claim boolean value by the input claim type name.
        /// </summary>
        /// <param name="claimType">
        /// Name of the claim type.
        /// </param>
        /// <returns>
        /// Claim value as a boolean.
        /// </returns>
        public bool GetClaimBooleanValue(string claimType)
        {
            bool result = false;

            var user = _httpContext.User;

            var claim = user.Claims.Where(c => c.Type == claimType).FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(claim.Value))
            {
                var value = claim.Value.ToLower();

                switch (value)
                {
                    case "true":
                    case "yes":
                    case "on":
                    case "1":
                        result = true;
                        break;

                    case "false":
                    case "no":
                    case "off":
                    case "0":
                        result = false;
                        break;
                }
            }

            return result;
        }
    }
}
