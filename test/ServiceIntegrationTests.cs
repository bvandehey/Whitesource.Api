using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using Whitesource.Api.Token;
using Xunit;

namespace Whitesource.Api.Tests
{
    public class ServiceIntegrationTests
    {
        private readonly OrgToken OrgToken;
        private readonly ProductToken ProductToken;
        private readonly ProjectToken ProjectToken;
        private readonly string LibraryUuid;
        private readonly WhitesourceService service;

        public ServiceIntegrationTests()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.test.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();

            OrgToken = new OrgToken(configuration.GetSection("whitesource:orgToken").Value);
            ProductToken = new ProductToken(configuration.GetSection("whitesource:productToken").Value);
            ProjectToken = new ProjectToken(configuration.GetSection("whitesource:projectToken").Value);
            LibraryUuid = configuration.GetSection("whitesource:libraryUuid").Value;
            service = new WhitesourceService(configuration.GetSection("whitesource:userKey").Value, configuration.GetSection("whitesource:url").Value);
        }

        [Fact]
        public  void GetOrganizationAlertsTest()
        {
            var products = service.GetOrganizationAlerts(OrgToken);
            Assert.NotNull(products);
        }

        [Fact]
        public  void GetProductAlertsTest()
        {
            var alerts = service.GetProductAlerts(ProductToken);
            Assert.NotNull(alerts);
        }

        [Fact]
        public  void GetProjectAlertsTest()
        {
            var alerts = service.GetProjectAlerts(ProjectToken);
            Assert.NotNull(alerts);
        }

        [Fact]
        public  void GetAlertsByProjectTagTest()
        {
            var alerts = service.GetAlertsByProjectTag(OrgToken, "TestTagKey", "TestTagValue");
            Assert.NotNull(alerts);
        }

        [Fact]
        public  void GetOrganizationAlertsByTypeTest()
        {
            var alerts = service.GetOrganizationAlertsByType(OrgToken, "MULTIPLE_LIBRARY_VERSIONS", fromDate: DateTime.Today.AddYears(-2), toDate: DateTime.Today);
            Assert.NotNull(alerts);
        }

        [Fact]
        public  void GetOrganizationLicensesTest()
        {
            var libraries = service.GetOrganizationLicenses(OrgToken);
            Assert.NotNull(libraries);
        }

        [Fact]
        public  void GetProductLicensesTest()
        {
            var libraries = service.GetProductLicenses(ProductToken);
            Assert.NotNull(libraries);
        }

        [Fact]
        public  void GetProjectLicensesTest()
        {
            var licenses = service.GetProjectLicenses(ProjectToken);
            Assert.NotNull(licenses);
        }

        [Fact]
        public  void GetProductLicenseHistogramTest()
        {
            var licenses = service.GetProductLicenseHistogram(ProductToken);
            Assert.NotNull(licenses);
        }

        [Fact]
        public  void GetProjectLicenseHistogramTest()
        {
            var licenses = service.GetProjectLicenseHistogram(ProjectToken);
            Assert.NotNull(licenses);
        }

        [Fact]
        public  void GetOrganizationLicenseHistogramTest()
        {
            var licenses = service.GetOrganizationLicenseHistogram(OrgToken);
            Assert.NotNull(licenses);
        }


        [Fact]
        public  void GetLicensesTextZipTest()
        {
            var zipFileBytes = service.GetLicensesTextZip(ProductToken);
            Assert.True(zipFileBytes.Length > 0);
        }

        [Fact]
        public  void GetProductAlertsByTypeTest()
        {
            var alerts = service.GetProductAlertsByType(ProductToken, "MULTIPLE_LIBRARY_VERSIONS", toDate: DateTime.Today);
            Assert.NotNull(alerts);
        }

        [Fact]
        public  void GetProjectAlertsByTypeTest()
        {
            var alerts = service.GetProjectAlertsByType(ProjectToken, "MULTIPLE_LIBRARY_VERSIONS", toDate:DateTime.Today);
            Assert.NotNull(alerts);
        }

        [Fact]
        public  void GetAllProductsTest()
        {
            var products = service.GetAllProducts(OrgToken);
            Assert.NotNull(products);
        }

        [Fact]
        public  void GetAllProjectsTest()
        {
            var projects = service.GetAllProjects(ProductToken);
            Assert.NotNull(projects);
        }

        [Fact]
        public  void GetProductLibraryLocationsTest()
        {
            var libraryLocations = service.GetProductLibraryLocations(ProductToken);
            Assert.NotNull(libraryLocations);
        }

        [Fact]
        public  void GetProjectLibraryLocationsTest()
        {
            var libraryLocations = service.GetProjectLibraryLocations(ProjectToken);
            Assert.NotNull(libraryLocations);
        }

        [Fact]
        public  void GetProjectHierarchyTest()
        {
            var libraryLocations = service.GetProjectHierarchy(ProjectToken, false);
            Assert.NotNull(libraryLocations);
        }

        [Fact]
        public  void GetProjectInventoryTest()
        {
            var projectInventory = service.GetProjectInventory(ProjectToken, false);
            Assert.NotNull(projectInventory);
            Assert.NotNull(projectInventory.ProjectVitals);
            Assert.NotNull(projectInventory.Libraries);
        }

        [Fact]
        public  void GetProjectStateTest()
        {
            var projectState = service.GetProjectState(ProjectToken);
            Assert.NotNull(projectState);
            Assert.True(projectState.Date != DateTime.MinValue);
        }

        [Fact]
        public  void GetLibrarySourceFilesTest()
        {
            var sourceFiles = service.GetLibrarySourceFiles(ProjectToken, LibraryUuid);
            Assert.NotNull(sourceFiles);
        }

        [Fact]
        public  void GetProjectLibraryDependenciesTest()
        {
            var dependencies = service.GetProjectLibraryDependencies(ProjectToken, LibraryUuid);
            Assert.NotNull(dependencies);
        }

        [Fact]
        public  void GetOrganizationProjectVitalsTest()
        {
            var vitals = service.GetOrganizationProjectVitals(OrgToken);
            Assert.NotNull(vitals);
            Assert.True(vitals.First().CreationDate != DateTime.MinValue);
        }

        [Fact]
        public  void GetOrganizationProductVitalsTest()
        {
            var vitals = service.GetOrganizationProductVitals(OrgToken);
            Assert.NotNull(vitals);
            Assert.True(vitals.First().CreationDate != DateTime.MinValue);
        }

        [Fact]
        public  void GetProductProjectVitalsTest()
        {
            var vitals = service.GetProductProjectVitals(ProductToken);
            Assert.NotNull(vitals);
            Assert.True(vitals.First().CreationDate != DateTime.MinValue);
        }

        [Fact]
        public  void GetProjectVitalsTest()
        {
            var vitals = service.GetProjectVitals(ProjectToken);
            Assert.NotNull(vitals);
            Assert.True(vitals.First().CreationDate != DateTime.MinValue);
        }

        [Fact]
        public  void GetAllProductsInvalidOrgTokenThrowsException()
        {
            Assert.Throws<WhitesourceRequestException>(() => service.GetAllProducts(new OrgToken("DummyOrgToken")));
        }

        [Fact]
        public  void GetAllProjectsInvalidProductTokenThrowsException()
        {
            Assert.Throws<WhitesourceRequestException>(() => service.GetAllProjects(new ProductToken("DummyProductToken")));
        }
    }
}
