namespace AspNetCoreApi.Security
{
    /// <summary>
    /// Interface for the LogonIdentityService module.
    /// </summary>
    public interface ILogonIdentityService
    {
        /// <summary>
        /// Interface for the GetLogonIdentity method.
        /// </summary>
        /// <returns></returns>
        LogonIdentity GetLogonIdentity();
    }
}