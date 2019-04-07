namespace Whitesource.Api.Token
{
    /// <summary>
    /// The BaseToken is an abstract class that is used as the basic for the <see cref="OrgToken" />,
    /// <see cref="ProductToken" /> and <see cref="ProjectToken" />. Having distinct classes for the
    /// different types of tokens allows the compiler to prevent passing the wrong type of token
    /// to a method.
    /// </summary>
    public abstract class BaseToken
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseToken"/> class.
        /// </summary>
        /// <param name="token">The token to assign to this instance.</param>
        protected BaseToken(string token)
        {
            Token = token;
        }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>The token.</value>
        public string Token { get; set; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="BaseToken"/> to <see cref="System.String"/>.
        /// </summary>
        /// <param name="token">The token to convert to a string.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(BaseToken token)
        {
            if (token == null)
                return null;
            return token.Token;
        }

        // 
        /// <summary>
        /// Returns a <see cref="System.String" /> of the token associated with this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> string of the token associated with this instance.</returns>
        public override string ToString()
        {
            return Token;
        }
    }
}
