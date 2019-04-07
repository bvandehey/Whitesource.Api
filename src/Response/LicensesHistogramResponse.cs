using System;
using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class LicensesHistogramResponse : BaseResponse
    {
        public Dictionary<string, int> LicenseHistogram { get; set; }
    }
}
