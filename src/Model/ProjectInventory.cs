using System.Collections.Generic;
using Whitesource.Api.Response;

#pragma warning disable CS1591
namespace Whitesource.Api.Model
{
    public class ProjectInventory
    {
        internal ProjectInventory(ProjectInventoryResponse response)
        {
            ProjectVitals = response.ProjectVitals;
            Libraries = response.Libraries;
        }

        public Vitals ProjectVitals { get; set; }
        public List<Library> Libraries { get; set; }
    }
}
