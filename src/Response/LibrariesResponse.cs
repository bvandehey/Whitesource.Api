using System;
using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class LibrariesResponse : BaseResponse
    {
        public List<Library> Libraries { get; set; }
    }
}
