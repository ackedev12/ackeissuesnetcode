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
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Environments;

namespace Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Apis.Environments
{
    /// <summary>
    /// Interface for the EnvironmentsApiClient
    /// </summary>
    internal interface IEnvironmentsApiClient
    {
            /// <summary>
            /// Async Operation.
            /// Gets environment details..
            /// </summary>
            /// <param name="request">Request object for GetEnvironment.</param>
            /// <param name="operationConfiguration">Configuration for GetEnvironment.</param>
            /// <returns>Task for a Response object containing status code, headers, and ListEnvironmentsByProject200ResponseInner object.</returns>
            /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<ListEnvironmentsByProject200ResponseInner>> GetEnvironmentAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Environments.GetEnvironmentRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Get environments for project.
            /// </summary>
            /// <param name="request">Request object for ListEnvironmentsByProject.</param>
            /// <param name="operationConfiguration">Configuration for ListEnvironmentsByProject.</param>
            /// <returns>Task for a Response object containing status code, headers, and List&lt;ListEnvironmentsByProject200ResponseInner&gt; object.</returns>
            /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<List<ListEnvironmentsByProject200ResponseInner>>> ListEnvironmentsByProjectAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Environments.ListEnvironmentsByProjectRequest request, Configuration operationConfiguration = null);

    }

    ///<inheritdoc cref="IEnvironmentsApiClient"/>
    internal class EnvironmentsApiClient : BaseApiClient, IEnvironmentsApiClient
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
        /// EnvironmentsApiClient Constructor.
        /// </summary>
        /// <param name="httpClient">The HttpClient for EnvironmentsApiClient.</param>
        /// <param name="configuration"> EnvironmentsApiClient Configuration object.</param>
        public EnvironmentsApiClient(IHttpClient httpClient,
            Configuration configuration = null) : base(httpClient)
        {
            // We don't need to worry about the configuration being null at
            // this stage, we will check this in the accessor.
            _configuration = configuration;


        }


        /// <summary>
        /// Async Operation.
        /// Gets environment details..
        /// </summary>
        /// <param name="request">Request object for GetEnvironment.</param>
        /// <param name="operationConfiguration">Configuration for GetEnvironment.</param>
        /// <returns>Task for a Response object containing status code, headers, and ListEnvironmentsByProject200ResponseInner object.</returns>
        /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<ListEnvironmentsByProject200ResponseInner>> GetEnvironmentAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Environments.GetEnvironmentRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(ListEnvironmentsByProject200ResponseInner)   },{"400", typeof(GetBucket400Response)   },{"401", typeof(GetBucket401Response)   },{"403", typeof(GetBucket403Response)   },{"404", typeof(GetBucket404Response)   },{"429", typeof(GetBucket429Response)   },{"500", typeof(GetBucket500Response)   },{"503", typeof(GetBucket503Response)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("GET",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            var handledResponse = ResponseHandler.HandleAsyncResponse<ListEnvironmentsByProject200ResponseInner>(response, statusCodeToTypeMap);
            return new Response<ListEnvironmentsByProject200ResponseInner>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// Get environments for project.
        /// </summary>
        /// <param name="request">Request object for ListEnvironmentsByProject.</param>
        /// <param name="operationConfiguration">Configuration for ListEnvironmentsByProject.</param>
        /// <returns>Task for a Response object containing status code, headers, and List&lt;ListEnvironmentsByProject200ResponseInner&gt; object.</returns>
        /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<List<ListEnvironmentsByProject200ResponseInner>>> ListEnvironmentsByProjectAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Environments.ListEnvironmentsByProjectRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(List<ListEnvironmentsByProject200ResponseInner>)   },{"400", typeof(GetBucket400Response)   },{"401", typeof(GetBucket401Response)   },{"403", typeof(GetBucket403Response)   },{"404", typeof(GetBucket404Response)   },{"429", typeof(GetBucket429Response)   },{"500", typeof(GetBucket500Response)   },{"503", typeof(GetBucket503Response)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("GET",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            var handledResponse = ResponseHandler.HandleAsyncResponse<List<ListEnvironmentsByProject200ResponseInner>>(response, statusCodeToTypeMap);
            return new Response<List<ListEnvironmentsByProject200ResponseInner>>(response, handledResponse);
        }

    }
}
