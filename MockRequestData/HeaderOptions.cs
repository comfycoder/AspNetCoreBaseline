using System;

namespace MockRequestData
{
    public class HeaderOptions
    {
        /// <summary>
        /// API key of the remote client application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Service account name of the remote client application.
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Data Processor Source – A string name provided by CUNA Mutual Financial Group (CMFG) 
        /// that identifies the source of the CU member information. 
        /// Note: This name may indicate either the credit union itself or their data processor.
        /// </summary>
        public string MessageId { get; set; }

        /// <summary>
        /// CU ID from Source – A unique identifier assigned to the credit union 
        /// by either CMFG or the credit union's data processor.
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// CU Member ID – A unique identifier assigned to the CU member by either 
        /// the credit union or their data processor.
        /// </summary>
        public string Username { get; set; }
    }
}
