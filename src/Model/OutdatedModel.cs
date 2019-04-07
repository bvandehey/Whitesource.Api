#pragma warning disable CS1591
namespace Whitesource.Api.Model
{
    public class OutdatedModel
    {
        public string OutdatedLibraryDate { get; set; }
        public string NewestVersion { get; set; }
        public string NewestLibraryDate { get; set; }
        public int VersionsInBetween { get; set; }
    }
}
