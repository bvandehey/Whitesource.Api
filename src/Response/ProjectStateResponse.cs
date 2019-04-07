using System;
using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class ProjectStateResponse : BaseResponse
    {
        public ProjectState ProjectState { get; set; }
    }
}
