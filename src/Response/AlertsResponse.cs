using System;
using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class AlertsResponse : BaseResponse
    {
        public List<Alert> Alerts { get; set; }
    }
}
