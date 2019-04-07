using System.Collections.Generic;

#pragma warning disable CS1591
namespace Whitesource.Api.Model
{
    public class LibraryLocation
    {
        public string Name { get; set; }
        public int KeyId { get; set; }
        public string KeyUuid { get; set; }
        public List<Location> Locations { get; set; }
    }
}
