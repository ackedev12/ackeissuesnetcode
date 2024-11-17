//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System.Threading.Tasks;
using System.Collections.Generic;
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Models;
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http;
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Orgs;

namespace Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Apis.Orgs
{
    /// <summary>
    /// Interface for the OrgsApiClient
    /// </summary>
    internal interface IOrgsApiClient
    {
            /// <summary>
            /// Async Operation.
            /// Gets organization details..
            /// </summary>
            /// <param name="request">Request object for GetOrg.</param>
            /// <param name="operationConfiguration">Configuration for GetOrg.</param>
            /// <returns>Task for a Response object containing status code, headers, and GetOrg200Response object.</returns>
            /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<GetOrg200Response>> GetOrgAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Orgs.GetOrgRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Gets organization Usage Details..
            /// </summary>
            /// <param name="request">Request object for GetOrgUsage.</param>
            /// <param name="operationConfiguration">Configuration for GetOrgUsage.</param>
            /// <returns>Task for a Response object containing status code, headers, and GetOrgUsage200Response object.</returns>
            /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<GetOrgUsage200Response>> GetOrgUsageAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Orgs.GetOrgUsageRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Update tos accepted on a organization.
            /// </summary>
            /// <param name="request">Request object for SaveTosAccepted.</param>
            /// <param name="operationConfiguration">Configuration for SaveTosAccepted.</param>
            /// <returns>Task for a Response object containing status code, headers, and GetOrg200Response object.</returns>
            /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<GetOrg200Response>> SaveTosAcceptedAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Orgs.SaveTosAcceptedRequest request, Configuration operationConfiguration = null);

    }

    ///<inheritdoc cref="IOrgsApiClient"/>
    internal class OrgsApiClient : BaseApiClient, IOrgsApiClient
    {
        private const int _baseTimeout = 10;
        private Configuration _configuration;
        /// <summary>
        /// Accessor for the client configuration object. This returns a merge
        /// between the current configuration and the global configuration to
        /// ensure the correct combination of headers and a base path (if it is
        /// set) are returned.
        /// </summary>
        public Configuration Configuration
        {
            get {
                // We return a merge between the current configuration and the
                // global configuration to ensure we have the correct
                // combination of headers and a base path (if it is set).
                Configuration globalConfiguration = new Configuration("https://services.unity.com", 10, 4, null);
                return Configuration.MergeConfigurations(_configuration, globalConfiguration);
            }
            set { _configuration = value; }
        }

        /// <summary>
        /// OrgsApiClient Constructor.
        /// </summary>
        /// <param name="httpClient">The HttpClient for OrgsApiClient.</param>
        /// <param name="configuration"> OrgsApiClient Configuration object.</param>
        public OrgsApiClient(IHttpClient httpClient,
            Configuration configuration = null) : base(httpClient)
        {
            // We don't need to worry about the configuration being null at
            // this stage, we will check this in the accessor.
            _configuration = configuration;


        }


        /// <summary>
        /// Async Operation.
        /// Gets organization details..
        /// </summary>
        /// <param name="request">Request object for GetOrg.</param>
        /// <param name="operationConfiguration">Configuration for GetOrg.</param>
        /// <returns>Task for a Response object containing status code, headers, and GetOrg200Response object.</returns>
        /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<GetOrg200Response>> GetOrgAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Orgs.GetOrgRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(GetOrg200Response)   },{"400", typeof(GetBucket400Response)   },{"401", typeof(GetBucket401Response)   },{"403", typeof(GetBucket403Response)   },{"404", typeof(GetBucket404Response)   },{"429", typeof(GetBucket429Response)   },{"500", typeof(GetBucket500Response)   },{"503", typeof(GetBucket503Response)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("GET",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            var handledResponse = ResponseHandler.HandleAsyncResponse<GetOrg200Response>(response, statusCodeToTypeMap);
            return new Response<GetOrg200Response>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// Gets organization Usage Details..
        /// </summary>
        /// <param name="request">Request object for GetOrgUsage.</param>
        /// <param name="operationConfiguration">Configuration for GetOrgUsage.</param>
        /// <returns>Task for a Response object containing status code, headers, and GetOrgUsage200Response object.</returns>
        /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<GetOrgUsage200Response>> GetOrgUsageAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Orgs.GetOrgUsageRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(GetOrgUsage200Response)   },{"400", typeof(GetBucket400Response)   },{"401", typeof(GetBucket401Response)   },{"403", typeof(GetBucket403Response)   },{"404", typeof(GetBucket404Response)   },{"429", typeof(GetBucket429Response)   },{"500", typeof(GetBucket500Response)   },{"503", typeof(GetBucket503Response)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("GET",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            var handledResponse = ResponseHandler.HandleAsyncResponse<GetOrgUsage200Response>(response, statusCodeToTypeMap);
            return new Response<GetOrgUsage200Response>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// Update tos accepted on a organization.
        /// </summary>
        /// <param name="request">Request object for SaveTosAccepted.</param>
        /// <param name="operationConfiguration">Configuration for SaveTosAccepted.</param>
        /// <returns>Task for a Response object containing status code, headers, and GetOrg200Response object.</returns>
        /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<GetOrg200Response>> SaveTosAcceptedAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Orgs.SaveTosAcceptedRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(GetOrg200Response)   },{"400", typeof(GetBucket400Response)   },{"401", typeof(GetBucket401Response)   },{"403", typeof(GetBucket403Response)   },{"404", typeof(GetBucket404Response)   },{"429", typeof(GetBucket429Response)   },{"500", typeof(GetBucket500Response)   },{"503", typeof(GetBucket503Response)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("PUT",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            var handledResponse = ResponseHandler.HandleAsyncResponse<GetOrg200Response>(response, statusCodeToTypeMap);
            return new Response<GetOrg200Response>(response, handledResponse);
        }

    }
}