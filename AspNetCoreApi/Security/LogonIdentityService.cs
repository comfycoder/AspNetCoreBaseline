using AspNetCoreApi.Common;
using AspNetCoreApi.Exceptions;
using System;

namespace AspNetCoreApi.Security
{
    /// <summary>
    /// Logon Identity Service
    /// </summary>
    public class LogonIdentityService : ILogonIdentityService
    {
        readonly IRequestMetadata _requestMetadata;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="headerReader">
        /// An instance of a header reader module.
        /// </param>
        /// <param name="claimReader">
        /// Claim Reader
        /// </param>
        /// <param name="myInvestmentViewService">
        /// My Investment View Service
        /// </param>
        public LogonIdentityService(
            IRequestMetadata requestMetadata
        )
        {
            _requestMetadata = requestMetadata;
        }

        /// <summary>
        /// Gets and identity object for the CU Member and indicates whether they have been authorized.
        /// </summary>
        /// <returns></returns>
        public LogonIdentity GetLogonIdentity()
        {
            LogonIdentity logonIdentity = null;

            bool isAuthorized = false;

            // Read the service account user claim
            var clientName = _requestMetadata.ClientName;
            if (string.IsNullOrWhiteSpace(clientName))
            {
                throw new MissingSourcePartyIdException();
            }

            var username = _requestMetadata.Username;
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new MissingCUMemberIdException();
            }

            if (!string.IsNullOrWhiteSpace(clientName) &&
                !string.IsNullOrWhiteSpace(username))
            {
                isAuthorized = true;

                logonIdentity = new LogonIdentity(isAuthorized, clientName, username);
            }

            if (logonIdentity == null)
            {
                isAuthorized = false;

                logonIdentity = new LogonIdentity(isAuthorized, clientName, username);
            }

            return logonIdentity;
        }
    }
}
