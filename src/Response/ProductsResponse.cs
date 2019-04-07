using System.Collections.Generic;
using Whitesource.Api.Model;

namespace Whitesource.Api.Response
{
    internal class ProductsResponse : BaseResponse
    {
        public List<Product> Products { get; set; }
        public string Message { get; set; }
    }
}
