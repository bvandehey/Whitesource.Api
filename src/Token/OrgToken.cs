namespace Whitesource.Api.Token
{
    /// <summary>
    /// The OrgToken class contains the Whitesource Organization token
    /// Implements the <see cref="Whitesource.Api.Token.BaseToken" />
    /// </summary>
    /// <seealso cref="Whitesource.Api.Token.BaseToken" />
    public class OrgToken : BaseToken
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrgToken"/> class.
        /// </summary>
        /// <param name="token">The token to assign to this instance.</param>
        public OrgToken(string token)
            : base(token)
        {
        }
    }
}
