using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System.Linq;
using System.Threading.Tasks;
using Whitesource.Api.Request;
using Whitesource.Api.Response;

namespace Whitesource.Api
{
    internal static class Extensions
    {
        internal static async Task<IRestResponse<T>> MakeRequestAsync<T>(this BaseRequest request, BaseWhitesourceService service) where T : BaseResponse, new()
        {
            var client = new RestClient(service.ApiUrl);
            var webRequest = new RestRequest(Method.POST);
            webRequest.AddHeader("cache-control", "no-cache");
            webRequest.AddHeader("Content-Type", "application/json");
            webRequest.AddParameter("application/json", request.ToJson(), ParameterType.RequestBody);
            var response = await client.ExecuteTaskAsync<T>(webRequest);
            if (response.Data.IsSuccessful)
                return response;
            throw new WhitesourceRequestException(response.Data);
        }

        internal static IRestResponse<T> MakeRequest<T>(this BaseRequest request, BaseWhitesourceService service) where T : BaseResponse, new()
        {
            var client = new RestClient(service.ApiUrl);
            var webRequest = new RestRequest(Method.POST);
            webRequest.AddHeader("cache-control", "no-cache");
            webRequest.AddHeader("Content-Type", "application/json");
            webRequest.AddParameter("application/json", request.ToJson(), ParameterType.RequestBody);
            var response = client.Execute<T>(webRequest, Method.POST);
            if (response.Data.IsSuccessful)
                return response;
            throw new WhitesourceRequestException(response.Data);
        }

        internal static async Task<byte[]> MakeRequestAsync(this BaseRequest request, BaseWhitesourceService service)
        {
            var client = new RestClient(service.ApiUrl);
            var webRequest = new RestRequest(Method.POST);
            webRequest.AddHeader("cache-control", "no-cache");
            webRequest.AddHeader("Content-Type", "application/json");
            webRequest.AddParameter("application/json", request.ToJson(), ParameterType.RequestBody);
            var response = await client.ExecuteTaskAsync(webRequest);
            var contentType = response.ContentType.ToLower().Split(';').FirstOrDefault();
            switch (contentType)
            {
                case "application/json":
                    var jsonContent = JsonConvert.DeserializeObject<BaseResponse>(response.Content);
                    throw new WhitesourceRequestException(jsonContent);
                case "application/zip":
                    return response.RawBytes;
                default:
                    throw new WhitesourceRequestException($"Unexpected content type: {contentType}");
            }
        }

        internal static byte[] MakeRequest(this BaseRequest request, BaseWhitesourceService service)
        {
            var client = new RestClient(service.ApiUrl);
            var webRequest = new RestRequest(Method.POST);
            webRequest.AddHeader("cache-control", "no-cache");
            webRequest.AddHeader("Content-Type", "application/json");
            webRequest.AddParameter("application/json", request.ToJson(), ParameterType.RequestBody);
            var response = client.DownloadData(webRequest);
            return response;
        }

        internal static string ToJson(this BaseRequest request)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };
            return JsonConvert.SerializeObject(request, serializerSettings);
        }
    }
}
