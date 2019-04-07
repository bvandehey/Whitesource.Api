using System;
using Whitesource.Api.Token;

namespace Whitesource.Api.Request
{
    internal class AlertTypeRequest : BaseRequest
    {
        public AlertTypeRequest(
            string requestType, 
            string userKey,
            OrgToken orgToken = null, 
            ProductToken productToken = null, 
            ProjectToken projectToken = null, 
            string alertType = null,
            DateTime? fromDate = null,
            DateTime? toDate = null)
            : base(requestType, userKey, orgToken, productToken, projectToken)
        {
            AlertType = alertType;
            FromDate = fromDate;
            ToDate = toDate;
        }

        public string AlertType { get; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
