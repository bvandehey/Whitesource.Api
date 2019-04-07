namespace Whitesource.Api.Token
{
    /// <summary>
    /// The ProjectToken class contains the Whitesource Project token
    /// Implements the <see cref="Whitesource.Api.Token.BaseToken" />
    /// </summary>
    /// <seealso cref="Whitesource.Api.Token.BaseToken" />
    public class ProjectToken : BaseToken
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectToken"/> class.
        /// </summary>
        /// <param name="token">The token to assign to this instance.</param>
        public ProjectToken(string token)
            : base(token)
        {
        }
    }
}
