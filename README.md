# Whitesource API v1.1 (.NET)
Overview
This is an implementation of the WhiteSource HTTP v1.1 API which is available for WhiteSource customers 
who are licensed to use it. The APIs can be accessed by the organization's administrator(s). 

This document describes the WhiteSource HTTP API v1.1. The API URL can be obtained by copying 
the 'WhiteSource Server URL', which can be retrieved from your 'Profile' page on the 'Server URLs' 
panel. Then, add the path '/api/v1.1' to it. For example: https://saas.whitesourcesoftware.com/api/v1.1.

The API is simply an HTTP endpoint implementing a JSON speaking web service and handling POST requests. 
Like the service itself, communication is secured with SSL.

The documentation for the API can be count [here](https://whitesource.atlassian.net/wiki/spaces/WD/pages/34046170/HTTP+API+v1.1).

The following API calls have been implemented:
- getOrganizationAlerts
- getProductAlerts
- getProjectAlerts
- getAlertsByProjectTag
- getOrganizationAlertsByType
- getProductAlertsByType
- getProjectAlertsByType
- getOrganizationLicenses
- getProductLicenses
- getProjectLicenses
- getOrganizationLicenseHistogram
- getProductLicenseHistogram
- getProjectLicenseHistogram
- getAllProducts
- getAllProjects
- getOrganizationProjectVitals
- getOrganizationProductVitals
- getProductProjectVitals
- getProjectVitals
- getProductLibraryLocations
- getProjectLibraryLocations
- getProjectHierarchy
- getProjectInventory
- getProjectState
- getLibrarySourceFiles
- getProjectLibraryDependencies
- getLicensesTextZip

