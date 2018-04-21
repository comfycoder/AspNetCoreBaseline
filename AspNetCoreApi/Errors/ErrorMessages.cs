namespace AspNetCoreApi.Errors
{
    /// <summary>
    /// String constants for error messages returned from the My Investment View API.
    /// </summary>
    public  class ErrorMessages
    {
        /// <summary>
        /// Missing financial account identifier.
        /// </summary>
        public const string MissingFinancialAccountId = "Missing financial account identifier.";

        /// <summary>
        /// User has not been authorized
        /// </summary>
        public const string Unauthorized = "User not authorized.";

        /// <summary>
        /// Method has not been implemented
        /// </summary>
        public const string NotImplemented = "The method has not been implemented.";

        /// <summary>
        /// An unhandled error condition
        /// </summary>
        public const string InternalServerError = "An unhandled error condition has occurred.";


        /// <summary>
        /// User record not found message.
        /// </summary>
        public const string NotFoundUser = "Unable to find the record.";

        /// <summary>
        /// Missing input credit union application client identifier
        /// </summary>
        public const string MissingClientId = "Missing input credit union application client identifier.";

        /// <summary>
        /// Invalid input credit union application client identifier.
        /// </summary>
        public const string InvalidClientId = "Invalid input credit union application client identifier. Must be in Guid format.";

        /// <summary>
        /// Missing input source party identifier.
        /// </summary>
        public const string MissingSourcePartyId = "Missing input source party identifier.";

        /// <summary>
        /// Missing input credit union member identifier.
        /// </summary>
        public const string MissingCUMemberId = "Missing input credit union member identifier.";

        /// <summary>
        /// Credit union member lookup failed.
        /// </summary>
        public const string CUMemberLookupFailed = "Credit union member lookup failed.";

        /// <summary>
        /// Header key value not found.
        /// </summary>
        public const string HeaderKeyNotFound = "Missing required header information.";
    }
}
