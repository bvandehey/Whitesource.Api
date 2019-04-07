using System.Collections.Generic;

#pragma warning disable CS1591
namespace Whitesource.Api.Model
{
    public class Library
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
        public string Languages { get; set; }
        public References References { get; set; }
        public List<License> Licenses { get; set; }
        public string Coordinates { get; set; }
        public List<Dependency> Dependencies { get; set; }
        public List<object> Vulnerabilities { get; set; }
        public bool Outdated { get; set; }
        public string MatchType { get; set; }
        public OutdatedModel OutdatedModel { get; set; }
    }
}
