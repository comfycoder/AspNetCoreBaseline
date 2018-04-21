namespace AspNetCoreApi.Contracts
{
    /// <summary>
    /// Error information that is returned to the service client.
    /// </summary>
    public class ErrorInfo
    {
        /// <summary>
        /// Http Status Code
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// This is a message that can be passed along to end-users, if needed.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// My Investment View API specific error code.
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Correlation message identifier.
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// Correlation transaction identifier.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// Link to public web site with My Investment View API error code documentation.
        /// </summary>
        public string MoreInformation { get; set; }
    }
}
