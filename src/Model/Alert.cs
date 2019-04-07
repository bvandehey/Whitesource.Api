using System;

#pragma warning disable CS1591
namespace Whitesource.Api.Model
{
    public class Alert
    {
        public Vulnerability Vulnerability { get; set; }
        public string Type { get; set; }
        public string Level { get; set; }
        public Library Library { get; set; }
        public string Project { get; set; }
        public int ProjectId { get; set; }
        public string ProjectToken { get; set; }
        public bool DirectDependency { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }

}
