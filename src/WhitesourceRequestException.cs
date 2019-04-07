using System;
using System.Runtime.Serialization;
using Whitesource.Api.Response;

namespace Whitesource.Api
{
    /// <summary>
    /// The WhitesourceRequestException is raised when an error occurs when
    /// communicating with the Whitesource API.
    /// Implements the <see cref="System.Exception" />
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class WhitesourceRequestException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WhitesourceRequestException"/> class.
        /// </summary>
        public WhitesourceRequestException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhitesourceRequestException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public WhitesourceRequestException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhitesourceRequestException"/> class.
        /// </summary>
        /// <param name="response">The error response that contains the error information.</param>
        internal WhitesourceRequestException(BaseResponse response)
            : base(response.ErrorMessage)
        {
            this.ErrorCode = response.ErrorCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WhitesourceRequestException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected WhitesourceRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        /// Gets the error code associated with this exception.
        /// </summary>
        /// <value>The error code associated with this exception.</value>
        public int ErrorCode { get; }
    }
}