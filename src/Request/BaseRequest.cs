using System;
using Whitesource.Api.Token;

namespace Whitesource.Api.Request
{
    internal class BaseRequest
    {
        public BaseRequest(
            string requestType,
            string userKey,
            OrgToken orgToken = null, 
            ProductToken productToken = null, 
            ProjectToken projectToken = null)
        {
            RequestType = requestType ?? throw new ArgumentNullException(nameof(requestType));
            UserKey = userKey;
            OrgToken = orgToken;
            ProductToken = productToken;
            ProjectToken = projectToken;
        }

        public string RequestType { get; }

        public string UserKey { get; }

        public string OrgToken { get; }

        public string ProductToken { get; }

        public string ProjectToken { get; }
    }
}
