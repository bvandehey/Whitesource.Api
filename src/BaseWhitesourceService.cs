namespace Whitesource.Api
{
    /// <summary>
    /// The WhitesourceService is the main service for integrating with the Whitesource API.
    /// </summary>
    /// <seealso cref="WhitesourceServiceAsync"/>
    public abstract class BaseWhitesourceService
    {
        /// <summary>
        /// Creates an instance of the Whitesource API service.
        /// </summary>
        /// <param name="userKey">The Whitesource user key for accessing the API.</param>
        /// <param name="apiUrl">The URL to the API service or null to use the default.</param>
        protected BaseWhitesourceService(string userKey, string apiUrl)
        {
            UserKey = userKey;
            if (apiUrl != null)
                ApiUrl = apiUrl;
        }

        /// <summary>
        /// Gets the Whitesource user key for accessing the API.
        /// </summary>
        /// <value>The Whitesource user key.</value>
        public string UserKey { get; }

        /// <summary>
        /// Gets the URL for the Whitesource API.
        /// </summary>
        /// <value>The Whitesource API URL.</value>
        public string ApiUrl { get; } = "https://saas.whitesourcesoftware.com/api/v1.1";
    }
}
