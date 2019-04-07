using System;

#pragma warning disable CS1591
namespace Whitesource.Api.Model
{
    public class ProjectState
    {
        public string LastProcess { get; set; }
        public bool InProgress { get; set; }
        public DateTime Date { get; set; }
    }
}
