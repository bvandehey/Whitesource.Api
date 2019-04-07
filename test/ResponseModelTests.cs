using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using Whitesource.Api.Response;
using Xunit;

namespace Whitesource.Api.Tests
{
    public class ResponseModelTests
    {
        [Fact]
        public void AlertsResponseJsonImportTest()
        {
            var response = LoadJsonFile<AlertsResponse>(@"AlertsResponse.json");
            Assert.Collection(response.Alerts,
                item => Assert.Contains("Newtonsoft.Json-11.0.2.21924.dll", item.Library.ArtifactId),
                item => Assert.Contains("System.Web.Mvc-5.2.30128.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("log4net-1.2.13.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("Common.Logging.Log4Net1213-3.3.1.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("Swashbuckle.Core-1.0.0.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("LightInject.Web-1.0.0.7.dll", item.Library.ArtifactId),
                item => Assert.Contains("WebActivatorEx-2.1.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("System.Web.Razor-3.0.30128.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("LightInject-4.0.1.dll", item.Library.ArtifactId),
                item => Assert.Contains("Common.Logging.Core-3.3.1.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("GraphQL-2.0.0.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("LightInject.Mvc-1.0.0.4.dll", item.Library.ArtifactId),
                item => Assert.Contains("GraphQL-Parser-3.0.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("System.Web.Webpages.Deployment-3.0.30128.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("System.Web.Webpages.Razor-3.0.30128.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("System.Web.Helpers-3.0.30128.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("LightInject.WebApi-1.0.0.4.dll", item.Library.ArtifactId),
                item => Assert.Contains("System.Web.Webpages-3.0.30128.0.dll", item.Library.ArtifactId),
                item => Assert.Contains("Common.Logging-3.3.1.0.dll", item.Library.ArtifactId)
            );

            Assert.Equal(18, response.Alerts.Where(t => t.Type == "NEW_MAJOR_VERSION").Count());
        }

        [Fact]
        public void ProductsResponseJsonImportTest()
        {
            var response = LoadJsonFile<ProductsResponse>(@"ProductsResponse.json");
            Assert.Equal("Success", response.Message);
            Assert.Collection(response.Products,
                item => Assert.Contains("Product 1", item.ProductName),
                item => Assert.Contains("Product 2", item.ProductName),
                item => Assert.Contains("Product 3", item.ProductName),
                item => Assert.Contains("Product 4", item.ProductName)
            );
        }

        [Fact]
        public void ProjectsResponseJsonImportTest()
        {
            var response = LoadJsonFile<ProjectsResponse>(@"ProjectsResponse.json");
            Assert.Equal("Success", response.Message);
            Assert.Collection(response.Projects,
                item => Assert.Contains("Project 1", item.ProjectName),
                item => Assert.Contains("Project 2", item.ProjectName),
                item => Assert.Contains("Project 3", item.ProjectName),
                item => Assert.Contains("Project 4", item.ProjectName),
                item => Assert.Contains("Project 5", item.ProjectName)
            );
        }

        [Fact]
        public void ProjectLicensesResponseJsonImportTest()
        {
            var response = LoadJsonFile<LicensesResponse>(@"ProjectLicensesResponse.json");
            Assert.Collection(response.Libraries,
                item => Assert.Contains("LightInject.WebApi-1.0.0.4.dll", item.ArtifactId),
                item => Assert.Contains("System.Web.Webpages-3.0.30128.0.dll", item.ArtifactId),
                item => Assert.Contains("Swashbuckle.Core-1.0.0.0.dll", item.ArtifactId),
                item => Assert.Contains("LightInject.Mvc-1.0.0.4.dll", item.ArtifactId),
                item => Assert.Contains("LightInject.Web-1.0.0.7.dll", item.ArtifactId),
                item => Assert.Contains("System.Web.Webpages.Deployment-3.0.30128.0.dll", item.ArtifactId),
                item => Assert.Contains("Newtonsoft.Json-11.0.2.21924.dll", item.ArtifactId),
                item => Assert.Contains("Common.Logging-3.3.1.0.dll", item.ArtifactId),
                item => Assert.Contains("Common.Logging.Log4Net1213-3.3.1.0.dll", item.ArtifactId),
                item => Assert.Contains("System.Web.Http.WebHost-5.2.30128.0.dll", item.ArtifactId),
                item => Assert.Contains("System.Web.Webpages.Razor-3.0.30128.0.dll", item.ArtifactId),
                item => Assert.Contains("GraphQL-2.0.0.0.dll", item.ArtifactId),
                item => Assert.Contains("Microsoft.Web.Infrastructure-1.0.20105.407.dll", item.ArtifactId),
                item => Assert.Contains("System.Web.Http-5.2.30128.0.dll", item.ArtifactId),
                item => Assert.Contains("System.Net.Http.Formatting-5.2.30128.0.dll", item.ArtifactId),
                item => Assert.Contains("WebActivatorEx-2.1.0.dll", item.ArtifactId),
                item => Assert.Contains("Common.Logging.Core-3.3.1.0.dll", item.ArtifactId),
                item => Assert.Contains("LightInject-4.0.1.dll", item.ArtifactId),
                item => Assert.Contains("System.Web.Razor-3.0.30128.0.dll", item.ArtifactId),
                item => Assert.Contains("log4net-1.2.13.0.dll", item.ArtifactId),
                item => Assert.Contains("GraphQL-Parser-3.0.0.dll", item.ArtifactId),
                item => Assert.Contains("System.Web.Mvc-5.2.30128.0.dll", item.ArtifactId),
                item => Assert.Contains("System.Web.Helpers-3.0.30128.0.dll", item.ArtifactId)
            );

            Assert.Equal(21, response.Libraries.Where(t => t.Licenses.Any()).Count());
        }

        [Fact]
        public void LibraryLocationsResponseJsonImportTest()
        {
            var response = LoadJsonFile<LibraryLocationsResponse>(@"LibraryLocationsResponse.json");
            Assert.Equal(302, response.LibraryLocations.Where(t => t.Locations.Any()).Count());
        }

        [Fact]
        public void ProjectInventoryResponseJsonImportTest()
        {
            var response = LoadJsonFile<ProjectInventoryResponse>(@"ProjectInventoryResponse.json");
            Assert.NotNull(response.Libraries);
            Assert.NotNull(response.ProjectVitals);
            Assert.Equal(23, response.Libraries.Count());
        }

        [Fact]
        public void SourceFilesResponseJsonImportTest()
        {
            var response = LoadJsonFile<SourceFilesResponse>(@"SourceFilesResponse.json");
            Assert.NotNull(response.SourceFiles);
            Assert.Single(response.SourceFiles);
        }

        [Fact]
        public void ProjectStateResponseJsonImportTest()
        {
            var response = LoadJsonFile<ProjectStateResponse>(@"ProjectStateResponse.json");
            Assert.NotNull(response.ProjectState);
            Assert.True(response.ProjectState.Date != DateTime.MinValue);
        }

        [Fact]
        public void ProjectLibraryDependenciesResponseJsonImportTest()
        {
            var response = LoadJsonFile<DependenciesResponse>(@"ProjectLibraryDependencies.json");
            Assert.NotNull(response.Dependencies);
            Assert.Equal(2, response.Dependencies.Count());
        }

        public static T LoadJsonFile<T>(string filename) where T : new()
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine("SampleData", filename)));
        }
    }
}
