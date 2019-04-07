using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class DependenciesResponse : BaseResponse
    {
        public List<Dependency> Dependencies { get; set; }
    }
}
