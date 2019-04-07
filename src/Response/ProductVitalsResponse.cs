using System;
using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class ProductVitalsResponse : BaseResponse
    {
        public List<Vitals> ProductVitals { get; set; }
    }
}
