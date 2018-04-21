namespace AspNetCoreApi.CommonAspNetCoreApi.Common
{
    /// <summary>
    /// Read JWT claims.
    /// </summary>
    public interface IClaimReader
    {
        /// <summary>
        /// Get a claim boolean value by the input claim type name.
        /// </summary>
        /// <param name="claimType">
        /// Name of the claim type.
        /// </param>
        /// <returns>
        /// Claim value as a boolean.
        /// </returns>
        bool GetClaimBooleanValue(string claimType);

        /// <summary>
        /// Get a claim integer value by the input claim type name.
        /// </summary>
        /// <param name="claimType">
        /// Name of the claim type.
        /// </param>
        /// <returns>
        /// Claim value as an integer.
        /// </returns>
        int GetClaimIntValue(string claimType);

        /// <summary>
        /// Get a claim string value by the input claim type name.
        /// </summary>
        /// <param name="claimType">
        /// Name of the claim type.
        /// </param>
        /// <returns>
        /// Claim value as a string.
        /// </returns>
        string GetClaimStringValue(string claimType);
    }
}