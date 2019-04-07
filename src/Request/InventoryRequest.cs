using System;
using System.Collections.Generic;
using Whitesource.Api.Model;
using Whitesource.Api.Token;

namespace Whitesource.Api.Request
{
    internal class InventoryRequest : BaseRequest
    {
        public InventoryRequest(
            string requestType, 
            string userKey,
            ProjectToken projectToken = null, 
            bool includeInHouseData = true)
            : base(requestType, userKey, null, null, projectToken)
        {
            IncludeInHouseData = includeInHouseData;
        }

        public bool IncludeInHouseData { get; }
    }
}
