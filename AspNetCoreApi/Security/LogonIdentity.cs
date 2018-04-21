using System;

namespace AspNetCoreApi.Security
{
    /// <summary>
    /// Authenticated user identity module for the CU Member.
    /// </summary>
    public class LogonIdentity
    {
        /// <summary>
        /// Indicates whether the Credit Union Member user has been granted permission 
        /// to obtain their financial account information.
        /// </summary>
        public bool IsAuthorized { get; private set; }

        /// <summary>
        /// Remote client service account.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// User identifier.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LogonIdentity()
        {
            IsAuthorized = false;
            ClientName = null;
            Username = null;
        }

        public LogonIdentity(bool isAuthorized, string clientName, string username)
        {
            IsAuthorized = isAuthorized;
            ClientName = clientName;
            Username = username;
        }
    }
}
