using System;
using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class LibraryLocationsResponse : BaseResponse
    {
        public List<LibraryLocation> LibraryLocations { get; set; }
    }
}
