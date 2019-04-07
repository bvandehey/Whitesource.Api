using System;
using System.Collections.Generic;
using Whitesource.Api.Model;
using Whitesource.Api.Token;

namespace Whitesource.Api.Request
{
    internal class ProjectTagRequest : BaseRequest
    {
        public ProjectTagRequest(
            string requestType, 
            string userKey,
            OrgToken orgToken, 
            string tagKey, 
            string tagValue)
            : base(requestType, userKey, orgToken, null, null)
        {
            TagKey = tagKey;
            TagValue = tagValue;
        }

        public string TagKey { get; }

        public string TagValue { get; }
    }
}
