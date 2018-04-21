using System.Collections.Generic;

namespace MockRequestData
{
    /// <summary>
    /// Container class to manage mock headers.
    /// </summary>
    public class MockHeadersPolicy
    {
        /// <summary>
        /// Sets header values.
        /// </summary>
        public IDictionary<string, string> SetHeaders { get; } = new Dictionary<string, string>();

        /// <summary>
        /// Removes header values.
        /// </summary>
        public ISet<string> RemoveHeaders { get; } = new HashSet<string>();
    }
}
