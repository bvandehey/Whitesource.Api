#pragma warning disable CS1591
namespace Whitesource.Api.Model
{
    public class TopFix
    {
        public string Vulnerability { get; set; }
        public string Type { get; set; }
        public string Origin { get; set; }
        public string Url { get; set; }
        public string FixResolution { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
        public string ExtraData { get; set; }
    }
}
