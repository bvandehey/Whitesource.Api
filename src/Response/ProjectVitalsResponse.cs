using System;
using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class ProjectVitalsResponse : BaseResponse
    {
        public List<Vitals> ProjectVitals { get; set; }
    }
}
