using System;
using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class SourceFilesResponse : BaseResponse
    {
        public List<SourceFile> SourceFiles { get; set; }
    }
}
