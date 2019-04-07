#pragma warning disable CS1591
using System;

namespace Whitesource.Api.Model
{
    public class Vitals
    {
        public string ProductName { get; set; }
        public string PluginName { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string UploadedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
