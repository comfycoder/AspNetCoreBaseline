namespace AspNetCoreApi.CommonAspNetCoreApi.Common
{
    /// <summary>
    /// Types of claims.
    /// </summary>
    public class ClaimType
    {
        /// <summary>
        /// The issuer of the token.
        /// </summary>
        public const string Issuer = "iss";

        /// <summary>
        /// The subject of the token.
        /// </summary>
        public const string Subject = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";

        /// <summary>
        /// The audience of the token.
        /// </summary>
        public const string Audience = "aud";

        /// <summary>
        /// This will probably be the registered claim most often used. 
        /// This will define the expiration in NumericDate value. 
        /// The expiration MUST be after the current date/time.
        /// </summary>
        public const string Expiration = "exp";

        /// <summary>
        /// Defines the time before which the JWT MUST NOT be accepted for processing.
        /// </summary>
        public const string NotBefore = "nbf";

        /// <summary>
        /// The time the JWT was issued. 
        /// Can be used to determine the age of the JWT.
        /// </summary>
        public const string IssuedAt = "iat";

        /// <summary>
        /// Unique identifier for the JWT. Can be used to prevent the JWT from being replayed. 
        /// This is helpful for a one time use token.
        /// </summary>
        public const string JwtIdentifier = "jti";

        /// <summary>
        /// User or service account use to login to this service.
        /// </summary>
        public const string UserAccount = "claim_user";
    }
}
