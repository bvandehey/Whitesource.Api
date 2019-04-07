namespace Whitesource.Api.Response
{
    internal class BaseResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public bool IsSuccessful
        {
            get { return ErrorCode == 0; }
        }
    }
}