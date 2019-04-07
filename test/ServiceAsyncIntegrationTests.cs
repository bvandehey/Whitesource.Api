using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using Whitesource.Api.Token;
using Xunit;

namespace Whitesource.Api.Tests
{
    public class ServiceAsyncIntegrationTests
    {
        private readonly OrgToken orgToken;
        private readonly ProductToken productToken;
        private readonly ProjectToken projectToken;
        private readonly string libraryUuid;
        private readonly WhitesourceServiceAsync service;

        public ServiceAsyncIntegrationTests()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.test.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();

            orgToken = new OrgToken(configuration.GetSection("whitesource:orgToken").Value);
            productToken = new ProductToken(configuration.GetSection("whitesource:productToken").Value);
            projectToken = new ProjectToken(configuration.GetSection("whitesource:projectToken").Value);
            libraryUuid = configuration.GetSection("whitesource:libraryUuid").Value;
            service = new WhitesourceServiceAsync(configuration.GetSection("whitesource:userKey").Value, configuration.GetSection("whitesource:url").Value);
        }

        [Fact]
        public async void GetOrganizationAlertsTest()
        {
            var products = await service.GetOrganizationAlertsAsync(orgToken);
            Assert.NotNull(products);
        }

        [Fact]
        public async void GetProductAlertsTest()
        {
            var alerts = await service.GetProductAlertsAsync(productToken);
            Assert.NotNull(alerts);
        }

        [Fact]
        public async void GetProjectAlertsTest()
        {
            var alerts = await service.GetProjectAlertsAsync(projectToken);
            Assert.NotNull(alerts);
        }

        [Fact]
        public async void GetAlertsByProjectTagTest()
        {
            var alerts = await service.GetAlertsByProjectTagAsync(orgToken, "TestTagKey", "TestTagValue");
            Assert.NotNull(alerts);
        }

        [Fact]
        public async void GetOrganizationAlertsByTypeTest()
        {
            var alerts = await service.GetOrganizationAlertsByTypeAsync(orgToken, "MULTIPLE_LIBRARY_VERSIONS", fromDate: DateTime.Today.AddYears(-2), toDate: DateTime.Today);
            Assert.NotNull(alerts);
        }

        [Fact]
        public async void GetOrganizationLicensesTest()
        {
            var libraries = await service.GetOrganizationLicensesAsync(orgToken);
            Assert.NotNull(libraries);
        }

        [Fact]
        public async void GetProductLicensesTest()
        {
            var libraries = await service.GetProductLicensesAsync(productToken);
            Assert.NotNull(libraries);
        }

        [Fact]
        public async void GetProjectLicensesTest()
        {
            var licenses = await service.GetProjectLicensesAsync(projectToken);
            Assert.NotNull(licenses);
        }

        [Fact]
        public async void GetProductLicenseHistogramAsyncTest()
        {
            var licenses = await service.GetProductLicenseHistogramAsync(productToken);
            Assert.NotNull(licenses);
        }

        [Fact]
        public async void GetProjectLicenseHistogramAsyncTest()
        {
            var licenses = await service.GetProjectLicenseHistogramAsync(projectToken);
            Assert.NotNull(licenses);
        }

        [Fact]
        public async void GetOrganizationLicenseHistogramAsyncTest()
        {
            var licenses = await service.GetOrganizationLicenseHistogramAsync(orgToken);
            Assert.NotNull(licenses);
        }


        [Fact]
        public async void GetLicensesTextZipAsyncTest()
        {
            var zipFileBytes = await service.GetLicensesTextZipAsync(productToken);
            Assert.True(zipFileBytes.Length > 0);
        }

        [Fact]
        public async void GetProductAlertsByTypeTest()
        {
            var alerts = await service.GetProductAlertsByTypeAsync(productToken, "MULTIPLE_LIBRARY_VERSIONS", toDate: DateTime.Today);
            Assert.NotNull(alerts);
        }

        [Fact]
        public async void GetProjectAlertsByTypeTest()
        {
            var alerts = await service.GetProjectAlertsByTypeAsync(projectToken, "MULTIPLE_LIBRARY_VERSIONS", toDate:DateTime.Today);
            Assert.NotNull(alerts);
        }

        [Fact]
        public async void GetAllProductsTest()
        {
            var products = await service.GetAllProductsAsync(orgToken);
            Assert.NotNull(products);
        }

        [Fact]
        public async void GetAllProjectsTest()
        {
            var projects = await service.GetAllProjectsAsync(productToken);
            Assert.NotNull(projects);
        }

        [Fact]
        public async void GetProductLibraryLocationsTest()
        {
            var libraryLocations = await service.GetProductLibraryLocationsAsync(productToken);
            Assert.NotNull(libraryLocations);
        }

        [Fact]
        public async void GetProjectLibraryLocationsTest()
        {
            var libraryLocations = await service.GetProjectLibraryLocationsAsync(projectToken);
            Assert.NotNull(libraryLocations);
        }

        [Fact]
        public async void GetProjectHierarchyTest()
        {
            var libraryLocations = await service.GetProjectHierarchyAsync(projectToken, false);
            Assert.NotNull(libraryLocations);
        }

        [Fact]
        public async void GetProjectInventoryTest()
        {
            var projectInventory = await service.GetProjectInventoryAsync(projectToken, false);
            Assert.NotNull(projectInventory);
            Assert.NotNull(projectInventory.ProjectVitals);
            Assert.NotNull(projectInventory.Libraries);
        }

        [Fact]
        public async void GetProjectStateTest()
        {
            var projectState = await service.GetProjectStateAsync(projectToken);
            Assert.NotNull(projectState);
            Assert.True(projectState.Date != DateTime.MinValue);
        }

        [Fact]
        public async void GetLibrarySourceFilesTest()
        {
            var sourceFiles = await service.GetLibrarySourceFilesAsync(projectToken, libraryUuid);
            Assert.NotNull(sourceFiles);
        }

        [Fact]
        public async void GetProjectLibraryDependenciesTest()
        {
            var dependencies = await service.GetProjectLibraryDependenciesAsync(projectToken, libraryUuid);
            Assert.NotNull(dependencies);
        }

        [Fact]
        public async void GetOrganizationProjectVitalsTest()
        {
            var vitals = await service.GetOrganizationProjectVitalsAsync(orgToken);
            Assert.NotNull(vitals);
            Assert.True(vitals.First().CreationDate != DateTime.MinValue);
        }

        [Fact]
        public async void GetOrganizationProductVitalsTest()
        {
            var vitals = await service.GetOrganizationProductVitalsAsync(orgToken);
            Assert.NotNull(vitals);
            Assert.True(vitals.First().CreationDate != DateTime.MinValue);
        }

        [Fact]
        public async void GetProductProjectVitalsTest()
        {
            var vitals = await service.GetProductProjectVitalsAsync(productToken);
            Assert.NotNull(vitals);
            Assert.True(vitals.First().CreationDate != DateTime.MinValue);
        }

        [Fact]
        public async void GetProjectVitalsTest()
        {
            var vitals = await service.GetProjectVitalsAsync(projectToken);
            Assert.NotNull(vitals);
            Assert.True(vitals.First().CreationDate != DateTime.MinValue);
        }

        [Fact]
        public async void GetAllProductsInvalidOrgTokenThrowsException()
        {
            await Assert.ThrowsAsync<WhitesourceRequestException>(() => service.GetAllProductsAsync(new OrgToken("DummyOrgToken")));
        }

        [Fact]
        public async void GetAllProjectsInvalidProductTokenThrowsException()
        {
            await Assert.ThrowsAsync<WhitesourceRequestException>(() => service.GetAllProjectsAsync(new ProductToken("DummyProductToken")));
        }
    }
}
