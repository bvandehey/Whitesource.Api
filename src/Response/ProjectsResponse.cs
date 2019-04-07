using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class ProjectsResponse : BaseResponse
    {
        public List<Project> Projects { get; set; }
        public string Message { get; set; }
    }
}
