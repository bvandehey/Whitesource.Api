using System;
using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class ProjectInventoryResponse : BaseResponse
    {
        public Vitals ProjectVitals { get; set; }
        public List<Library> Libraries { get; set; }
    }
}
