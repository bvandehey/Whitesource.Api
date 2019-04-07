using System.Collections.Generic;

#pragma warning disable CS1591
namespace Whitesource.Api.Model
{
    public class Dependency
    {
        public string KeyUuid { get; set; }
        public int KeyId { get; set; }
        public string Filename { get; set; }
        public string Name { get; set; }
        public string GroupId { get; set; }
        public string ArtifactId { get; set; }
        public string Version { get; set; }
        public string Sha1 { get; set; }
        public string Type { get; set; }
        public string Coordinates { get; set; }
        public string Classifier { get; set; }
        public string Scope { get; set; }
        public string Extension { get; set; }
        public List<object> Dependencies { get; set; }
        public List<License> Licenses { get; set; }

    }
}
