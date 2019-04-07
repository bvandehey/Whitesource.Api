using System;
using System.Collections.Generic;
using Whitesource.Api.Model;
using Whitesource.Api.Request;
using Whitesource.Api.Response;
using Whitesource.Api.Token;

namespace Whitesource.Api
{
    /// <summary>
    /// The WhitesourceService is the main service for integrating with the Whitesource API.
    /// </summary>
    /// <seealso cref="WhitesourceServiceAsync"/>
    public class WhitesourceService : BaseWhitesourceService
    {
        /// <summary>
        /// Creates an instance of the Whitesource API service.
        /// </summary>
        /// <param name="userKey">The Whitesource user key for accessing the API.</param>
        /// <param name="apiUrl">The URL to the API service or null to use the default.</param>
        public WhitesourceService(string userKey, string apiUrl = null)
            : base(userKey, apiUrl)
        {
        }

        #region Alerts
        /// <summary>
        /// Returns a list of alerts for a given organization.
        /// </summary>
        /// <param name="orgToken">The Whitesource organization token for the target organization.</param>
        /// <returns>Returns a list of alerts for the given organization token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Alert> GetOrganizationAlerts(OrgToken orgToken)
        {
            var request = new BaseRequest("getOrganizationAlerts", UserKey, orgToken:orgToken);
            var response = request.MakeRequest<AlertsResponse>(this);
            return response.Data.Alerts;
        }

        /// <summary>
        /// Returns a list of alerts for a given product.
        /// </summary>
        /// <param name="productToken">The Whitesource product token for the target product.</param>
        /// <returns>Returns a list of alerts for the given product token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Alert> GetProductAlerts(ProductToken productToken)
        {
            var request = new BaseRequest("getProductAlerts", UserKey, productToken:productToken);
            var response = request.MakeRequest<AlertsResponse>(this);
            return response.Data.Alerts;
        }

        /// <summary>
        /// Returns a list of alerts for a given project.
        /// </summary>
        /// <param name="projectToken">The Whitesource project token for the target project.</param>
        /// <returns>Returns a list of alerts for the given project token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Alert> GetProjectAlerts(ProjectToken projectToken)
        {
            var request = new BaseRequest("getProjectAlerts", UserKey, projectToken:projectToken);
            var response = request.MakeRequest<AlertsResponse>(this);
            return response.Data.Alerts;
        }

        /// <summary>
        /// Returns a list of alerts for a given project with the specified tag.
        /// </summary>
        /// <param name="orgToken">The Whitesource organization token for the target project.</param>
        /// <param name="tagKey">The project tag key to filter the projects.</param>
        /// <param name="tagValue">The project tag value to filter the projects.</param>
        /// <returns>Returns a list of alerts for the given organization token filter by the specified tag.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Alert> GetAlertsByProjectTag(OrgToken orgToken, string tagKey, string tagValue)
        {
            var request = new ProjectTagRequest("getAlertsByProjectTag", UserKey, orgToken:orgToken, tagKey:tagKey, tagValue:tagValue);
            var response = request.MakeRequest<AlertsResponse>(this);
            return response.Data.Alerts;
        }
        #endregion Alerts

        #region Alerts by Type
        /// <summary>
        /// Returns a list of alerts for a given organization with the specified type.
        /// </summary>
        /// <param name="orgToken">The Whitesource organization token for the target organization.</param>
        /// <param name="alertType">Type of the alert to use to filter the alerts.</param>
        /// <param name="fromDate">An optional parameter that filters alerts after this date.</param>
        /// <param name="toDate">An optional parameter that filters alerts before this date.</param>
        /// <returns>Returns a list of alerts for the given organization token filtered by the specified type.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Alert> GetOrganizationAlertsByType(OrgToken orgToken, string alertType, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var request = new AlertTypeRequest("getOrganizationAlertsByType", UserKey, orgToken:orgToken, alertType:alertType, fromDate: fromDate, toDate: toDate);
            var response = request.MakeRequest<AlertsResponse>(this);
            return response.Data.Alerts;
        }

        /// <summary>Returns a list of alerts for a given product with the specified type.</summary>
        /// <param name="productToken">The Whitesource product token for the target product.</param>
        /// <param name="alertType">The alert type to use to filter the alerts.</param>
        /// <param name="fromDate">An optional parameter that filters alerts after this date.</param>
        /// <param name="toDate">An optional parameter that filters alerts before this date.</param>
        /// <returns>Returns a list of alerts for the given product token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Alert> GetProductAlertsByType(ProductToken productToken, string alertType, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var request = new AlertTypeRequest("getProductAlertsByType", UserKey, productToken:productToken, alertType:alertType, fromDate: fromDate, toDate: toDate);
            var response = request.MakeRequest<AlertsResponse>(this);
            return response.Data.Alerts;
        }

        /// <summary>
        /// Returns a list of alerts for a given project with the specified type.
        /// </summary>
        /// <param name="projectToken">The Whitesource project token for the target project.</param>
        /// <param name="alertType">The alert type to use to filter the alerts.</param>
        /// <param name="fromDate">An optional parameter that filters alerts after this date.</param>
        /// <param name="toDate">An optional parameter that filters alerts before this date.</param>
        /// <returns>Returns a list of alerts for the given project token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Alert> GetProjectAlertsByType(ProjectToken projectToken, string alertType, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var request = new AlertTypeRequest("getProjectAlertsByType", UserKey, projectToken: projectToken, alertType: alertType, fromDate:fromDate, toDate:toDate);
            var response = request.MakeRequest<AlertsResponse>(this);
            return response.Data.Alerts;
        }
        #endregion Alerts by Type

        #region Licenses
        /// <summary>
        /// Returns a list of libraries and their licenses for a given organization.
        /// </summary>
        /// <param name="orgToken">The Whitesource organization token for the target organization.</param>
        /// <returns>Returns a list of libraries and their licenses for the given organization token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Library> GetOrganizationLicenses(OrgToken orgToken)
        {
            var request = new BaseRequest("getOrganizationLicenses", UserKey, orgToken: orgToken);
            var response = request.MakeRequest<LicensesResponse>(this);
            return response.Data.Libraries;
        }

        /// <summary>
        /// Returns a list of libraries and their licenses for a given product.
        /// </summary>
        /// <param name="productToken">The Whitesource product token for the target product.</param>
        /// <returns>Returns a list of libraries and their licenses for the given product token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Library> GetProductLicenses(ProductToken productToken)
        {
            var request = new BaseRequest("getProductLicenses", UserKey, productToken: productToken);
            var response = request.MakeRequest<LicensesResponse>(this);
            return response.Data.Libraries;
        }

        /// <summary>
        /// Returns a list of libraries and their licenses for a given product.
        /// </summary>
        /// <param name="projectToken">The Whitesource project token for the target project.</param>
        /// <returns>Returns a list of libraries and their licenses for the given product token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Library> GetProjectLicenses(ProjectToken projectToken)
        {
            var request = new BaseRequest("getProjectLicenses", UserKey, projectToken: projectToken);
            var response = request.MakeRequest<LicensesResponse>(this);
            return response.Data.Libraries;
        }
        #endregion Licenses

        #region License Histogram
        /// <summary>
        /// Returns a dictionary of licenses and counts for a given organization.
        /// </summary>
        /// <param name="orgToken">The Whitesource organization token for the target organization.</param>
        /// <returns>Returns a dictionary of licenses and counts for a given organization.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public Dictionary<string, int> GetOrganizationLicenseHistogram(OrgToken orgToken)
        {
            var request = new BaseRequest("getOrganizationLicenseHistogram", UserKey, orgToken: orgToken);
            var response = request.MakeRequest<LicensesHistogramResponse>(this);
            return response.Data.LicenseHistogram;
        }

        /// <summary>
        /// Returns a dictionary of licenses and counts for a given product.
        /// </summary>
        /// <param name="productToken">The Whitesource product token for the target product.</param>
        /// <returns>Returns a dictionary of licenses and counts for a given product.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public Dictionary<string, int> GetProductLicenseHistogram(ProductToken productToken)
        {
            var request = new BaseRequest("getProductLicenseHistogram", UserKey, productToken:productToken);
            var response = request.MakeRequest<LicensesHistogramResponse>(this);
            return response.Data.LicenseHistogram;
        }

        /// <summary>
        /// Returns a dictionary of licenses and counts for a given project.
        /// </summary>
        /// <param name="projectToken">The Whitesource project token for the target project.</param>
        /// <returns>Returns a dictionary of licenses and counts for a given project.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public Dictionary<string, int> GetProjectLicenseHistogram(ProjectToken projectToken)
        {
            var request = new BaseRequest("getProjectLicenseHistogram", UserKey, projectToken:projectToken);
            var response = request.MakeRequest<LicensesHistogramResponse>(this);
            return response.Data.LicenseHistogram;
        }
        #endregion License Histogram

        #region Organization Vitals
        // TODO: Get All Organizations
        #endregion Organization Vitals

        #region Project / Product Vitals
        /// <summary>
        /// Returns a list of products for a given organization.
        /// </summary>
        /// <param name="orgToken">The Whitesource organization token for the target organization.</param>
        /// <returns>Returns a list of products for the given organization token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Product> GetAllProducts(OrgToken orgToken)
        {
            var request = new BaseRequest("getAllProducts", UserKey, orgToken: orgToken);
            var response = request.MakeRequest<ProductsResponse>(this);
            return response.Data.Products;
        }

        /// <summary>
        /// Returns a list of projects for a given product.
        /// </summary>
        /// <param name="productToken">The Whitesource product token for the target product.</param>
        /// <returns>Returns a list of projects for the given product token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Project> GetAllProjects(ProductToken productToken)
        {
            var request = new BaseRequest("getAllProjects", UserKey, productToken: productToken);
            var response = request.MakeRequest<ProjectsResponse>(this);
            return response.Data.Projects;
        }

        /// <summary>
        /// Get basic information regarding all projects within the organization: name, token, creation date and last updated date.
        /// </summary>
        /// <param name="orgToken">The Whitesource organization token for the target organization.</param>
        /// <returns>Returns a list of projects for the given product token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Vitals> GetOrganizationProjectVitals(OrgToken orgToken)
        {
            var request = new BaseRequest("getOrganizationProjectVitals", UserKey, orgToken: orgToken);
            var response = request.MakeRequest<ProjectVitalsResponse>(this);
            return response.Data.ProjectVitals;
        }

        /// <summary>
        /// Get basic information regarding all products within the organization: name, token, creation date and last updated date.
        /// </summary>
        /// <param name="orgToken">The Whitesource organization token for the target organization.</param>
        /// <returns>Returns the vitals within the organization for all products.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Vitals> GetOrganizationProductVitals(OrgToken orgToken)
        {
            var request = new BaseRequest("getOrganizationProductVitals", UserKey, orgToken: orgToken);
            var response = request.MakeRequest<ProductVitalsResponse>(this);
            return response.Data.ProductVitals;
        }

        /// <summary>
        /// Get basic information regarding all projects for a specific product: name, token, creation date and last updated date.
        /// </summary>
        /// <param name="productToken">The Whitesource product token for the target product.</param>
        /// <returns>Returns the vitals within the organization for all products.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Vitals> GetProductProjectVitals(ProductToken productToken)
        {
            var request = new BaseRequest("getProductProjectVitals", UserKey, productToken: productToken);
            var response = request.MakeRequest<ProjectVitalsResponse>(this);
            return response.Data.ProjectVitals;
        }

        /// <summary>
        /// Get basic information for a specific project: name, token, creation date and last updated date.
        /// </summary>
        /// <param name="projectToken">The project token.</param>
        /// <returns>Returns the vitals within the organization for all products.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Vitals> GetProjectVitals(ProjectToken projectToken)
        {
            var request = new BaseRequest("getProjectVitals", UserKey, projectToken: projectToken);
            var response = request.MakeRequest<ProjectVitalsResponse>(this);
            return response.Data.ProjectVitals;
        }
        #endregion Project / Product Vitals

        #region Library Locations
        /// <summary>
        /// Returns a list of library locations for a given product.
        /// </summary>
        /// <param name="productToken">The Whitesource product token for the target product.</param>
        /// <returns>Returns a list of library locations for the given product token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<LibraryLocation> GetProductLibraryLocations(ProductToken productToken)
        {
            var request = new BaseRequest("getProductLibraryLocations", UserKey, productToken: productToken);
            var response = request.MakeRequest<LibraryLocationsResponse>(this);
            return response.Data.LibraryLocations;
        }

        /// <summary>
        /// Returns a list of library locations for a given project.
        /// </summary>
        /// <param name="projectToken">The Whitesource project token for the target project.</param>
        /// <returns>Returns a list of library locations for the given project token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<LibraryLocation> GetProjectLibraryLocations(ProjectToken projectToken)
        {
            var request = new BaseRequest("getProjectLibraryLocations", UserKey, projectToken: projectToken);
            var response = request.MakeRequest<LibraryLocationsResponse>(this);
            return response.Data.LibraryLocations;
        }
        #endregion Library Locations

        #region Project API Requests
        /// <summary>
        /// Returns the library hierarchy for a given project.
        /// </summary>
        /// <param name="projectToken">The project token.</param>
        /// <param name="includeInHouseData">An optional parameter to determine whether in-house data should be included 
        /// in the hierarchy. The default is <c>true</c> which means to include the in-house data.</param>
        /// <returns>Returns a the library hierarchy for the given project token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Library> GetProjectHierarchy(ProjectToken projectToken, bool includeInHouseData = true)
        {
            var request = new InventoryRequest("getProjectHierarchy", UserKey, projectToken, includeInHouseData);
            var response = request.MakeRequest<LibrariesResponse>(this);
            return response.Data.Libraries;
        }

        /// <summary>
        /// Returns the library inventory for a given project.
        /// </summary>
        /// <param name="projectToken">The project token.</param>
        /// <param name="includeInHouseData">An optional parameter to determine whether in-house data should be included 
        /// in the hierarchy. The default is <c>true</c> which means to include the in-house data.</param>
        /// <returns>Returns the library inventory for the given project token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public ProjectInventory GetProjectInventory(ProjectToken projectToken, bool includeInHouseData = true)
        {
            var request = new InventoryRequest("getProjectInventory", UserKey, projectToken, includeInHouseData);
            var response = request.MakeRequest<ProjectInventoryResponse>(this);
            return new ProjectInventory(response.Data);
        }

        /// <summary>
        /// Returns the state for a given project.
        /// </summary>
        /// <param name="projectToken">The project token.</param>
        /// <returns>Returns the project state for the given project token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public ProjectState GetProjectState(ProjectToken projectToken)
        {
            var request = new BaseRequest("getProjectState", UserKey, projectToken: projectToken);
            var response = request.MakeRequest<ProjectStateResponse>(this);
            return response.Data.ProjectState;
        }

        /// <summary>
        /// Returns the source files for a library within a given project.
        /// </summary>
        /// <param name="projectToken">The project token.</param>
        /// <param name="uuid">The UUID for the library to retrieve source files for.</param>
        /// <returns>Returns the source files for a library within the given project token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<SourceFile> GetLibrarySourceFiles(ProjectToken projectToken, string uuid)
        {
            var request = new ProjectUuidRequest("getLibrarySourceFiles", UserKey, projectToken, uuid);
            var response = request.MakeRequest<SourceFilesResponse>(this);
            return response.Data.SourceFiles;
        }

        /// <summary>
        /// Returns the dependencies for a library within a given project.
        /// </summary>
        /// <param name="projectToken">The project token.</param>
        /// <param name="uuid">The UUID for the library to retrieve the dependencies for.</param>
        /// <returns>Returns the source files for a library within the given project token.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public List<Dependency> GetProjectLibraryDependencies(ProjectToken projectToken, string uuid)
        {
            var request = new ProjectUuidRequest("getProjectLibraryDependencies", UserKey, projectToken, uuid);
            var response = request.MakeRequest<DependenciesResponse>(this);
            return response.Data.Dependencies;
        }
        #endregion Project API Requests

        #region Misc
        /// <summary>
        /// Returns a zipfile containing the text of all of licenses for a given product.
        /// </summary>
        /// <param name="productToken">The Whitesource product token for the target product.</param>
        /// <returns>Returns a zipfile containing the text of all of licenses for a given product.</returns>
        /// <exception cref="WhitesourceRequestException">Thrown if an exception occurs calling Whitesource service.</exception>
        public byte[] GetLicensesTextZip(ProductToken productToken)
        {
            var request = new BaseRequest("getLicensesTextZip", UserKey, productToken: productToken);
            var response = request.MakeRequest(this);
            return response;
        }
        #endregion Misc
    }
}
