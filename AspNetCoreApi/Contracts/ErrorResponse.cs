namespace AspNetCoreApi.Contracts
{
    /// <summary>
    /// Error Response.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Error information returned when an Exception occurs in the My Investment View API.
        /// </summary>
        public ErrorInfo Error { get; set; }


        /// <summary>
        /// Default contructor.
        /// </summary>
        public ErrorResponse()
        {
            this.Error = null;
        }

        /// <summary>
        /// Constructor with inputs.
        /// </summary>
        /// <param name="error">
        /// Error information returned when an Exception occurs in the My Investment View API.
        /// </param>
        /// <param name="complianceMessage">
        /// Compliance message text that must be visually displayed in a credit union's 
        /// application along with the financial account information return in the response.
        /// </param>
        public ErrorResponse(ErrorInfo error)
        {
            this.Error = error;
        }
    }
}
