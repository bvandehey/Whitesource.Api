using System;
using System.Collections.Generic;
using Whitesource.Api.Model;
using Whitesource.Api.Token;

namespace Whitesource.Api.Request
{
    internal class ProjectUuidRequest : BaseRequest
    {
        public ProjectUuidRequest(
            string requestType, 
            string userKey,
            ProjectToken projectToken, 
            string keyUuid)
            : base(requestType, userKey, null, null, projectToken)
        {
            KeyUuid = keyUuid;
        }

        public string KeyUuid { get; }
    }
}
