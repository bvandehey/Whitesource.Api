namespace Whitesource.Api.Token
{
    /// <summary>
    /// The ProductToken class contains the Whitesource Product token
    /// Implements the <see cref="Whitesource.Api.Token.BaseToken" />
    /// </summary>
    /// <seealso cref="Whitesource.Api.Token.BaseToken" />
    public class ProductToken : BaseToken
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductToken"/> class.
        /// </summary>
        /// <param name="token">The token to assign to this instance.</param>
        public ProductToken(string token)
            : base(token)
        {
        }
    }
}
