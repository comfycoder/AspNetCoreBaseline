namespace AspNetCoreApi.Errors
{
    /// <summary>
    /// Error Codes enumeration.
    /// </summary>
    public class ErrorCodes
    {
        /// <summary>
        /// Bad Request
        /// </summary>
        public const int BadRequest = 400;

        /// <summary>
        /// Unauthorized credit union or member.
        /// </summary>
        public const int Unauthorized = 401;

        /// <summary>
        /// Missing client identifier.
        /// </summary>
        public const int MissingClientId = 1000;

        /// <summary>
        /// Invalid client identifier.
        /// </summary>
        public const int InvalidClientId = 1001;

        /// <summary>
        /// Missing source party identifier.
        /// </summary>
        public const int MissingSourcePartyId = 1002;

        /// <summary>
        /// Missing credit union member identifier.
        /// </summary>
        public const int MissingCUMemberId = 1003;

        /// <summary>
        /// Credit union member lookup failed.
        /// </summary>
        public const int CUMemberLookupFailed = 1004;

        /// <summary>
        /// Missing financial account identifier.
        /// </summary>
        public const int MissingFinancialAccountId = 1100;
    }
}
