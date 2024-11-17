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
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Models;
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Http;
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Allocations;

namespace Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Apis.Allocations
{
    /// <summary>
    /// Interface for the AllocationsApiClient
    /// </summary>
    internal interface IAllocationsApiClient
    {
            /// <summary>
            /// Async Operation.
            /// View a test allocation.
            /// </summary>
            /// <param name="request">Request object for GetTestAllocation.</param>
            /// <param name="operationConfiguration">Configuration for GetTestAllocation.</param>
            /// <returns>Task for a Response object containing status code, headers, and TestAllocation object.</returns>
            /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<TestAllocation>> GetTestAllocationAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Allocations.GetTestAllocationRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// List a project&#39;s test allocations.
            /// </summary>
            /// <param name="request">Request object for ListTestAllocations.</param>
            /// <param name="operationConfiguration">Configuration for ListTestAllocations.</param>
            /// <returns>Task for a Response object containing status code, headers, and ListTestAllocationsResponse object.</returns>
            /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<ListTestAllocationsResponse>> ListTestAllocationsAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Allocations.ListTestAllocationsRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Queue a test allocation.
            /// </summary>
            /// <param name="request">Request object for ProcessTestAllocation.</param>
            /// <param name="operationConfiguration">Configuration for ProcessTestAllocation.</param>
            /// <returns>Task for a Response object containing status code, headers, and TestAllocateResponse object.</returns>
            /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<TestAllocateResponse>> ProcessTestAllocationAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Allocations.ProcessTestAllocationRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Remove a test allocation.
            /// </summary>
            /// <param name="request">Request object for ProcessTestDeallocation.</param>
            /// <param name="operationConfiguration">Configuration for ProcessTestDeallocation.</param>
            /// <returns>Task for a Response object containing status code, headers.</returns>
            /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response> ProcessTestDeallocationAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Allocations.ProcessTestDeallocationRequest request, Configuration operationConfiguration = null);

    }

    ///<inheritdoc cref="IAllocationsApiClient"/>
    internal class AllocationsApiClient : BaseApiClient, IAllocationsApiClient
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
        /// AllocationsApiClient Constructor.
        /// </summary>
        /// <param name="httpClient">The HttpClient for AllocationsApiClient.</param>
        /// <param name="configuration"> AllocationsApiClient Configuration object.</param>
        public AllocationsApiClient(IHttpClient httpClient,
            Configuration configuration = null) : base(httpClient)
        {
            // We don't need to worry about the configuration being null at
            // this stage, we will check this in the accessor.
            _configuration = configuration;


        }


        /// <summary>
        /// Async Operation.
        /// View a test allocation.
        /// </summary>
        /// <param name="request">Request object for GetTestAllocation.</param>
        /// <param name="operationConfiguration">Configuration for GetTestAllocation.</param>
        /// <returns>Task for a Response object containing status code, headers, and TestAllocation object.</returns>
        /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<TestAllocation>> GetTestAllocationAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Allocations.GetTestAllocationRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(TestAllocation)   },{"400", typeof(ListTestAllocations400Response)   },{"401", typeof(ListTestAllocations401Response)   },{"403", typeof(ListTestAllocations403Response)   },{"404", typeof(ListTestAllocations404Response)   },{"429", typeof(ListTestAllocations429Response)   },{"500", typeof(ListTestAllocations500Response)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("GET",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            var handledResponse = ResponseHandler.HandleAsyncResponse<TestAllocation>(response, statusCodeToTypeMap);
            return new Response<TestAllocation>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// List a project&#39;s test allocations.
        /// </summary>
        /// <param name="request">Request object for ListTestAllocations.</param>
        /// <param name="operationConfiguration">Configuration for ListTestAllocations.</param>
        /// <returns>Task for a Response object containing status code, headers, and ListTestAllocationsResponse object.</returns>
        /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<ListTestAllocationsResponse>> ListTestAllocationsAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Allocations.ListTestAllocationsRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(ListTestAllocationsResponse)   },{"400", typeof(ListTestAllocations400Response)   },{"401", typeof(ListTestAllocations401Response)   },{"403", typeof(ListTestAllocations403Response)   },{"404", typeof(ListTestAllocations404Response)   },{"429", typeof(ListTestAllocations429Response)   },{"500", typeof(ListTestAllocations500Response)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("GET",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            var handledResponse = ResponseHandler.HandleAsyncResponse<ListTestAllocationsResponse>(response, statusCodeToTypeMap);
            return new Response<ListTestAllocationsResponse>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// Queue a test allocation.
        /// </summary>
        /// <param name="request">Request object for ProcessTestAllocation.</param>
        /// <param name="operationConfiguration">Configuration for ProcessTestAllocation.</param>
        /// <returns>Task for a Response object containing status code, headers, and TestAllocateResponse object.</returns>
        /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<TestAllocateResponse>> ProcessTestAllocationAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Allocations.ProcessTestAllocationRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"202", typeof(TestAllocateResponse)   },{"400", typeof(ListTestAllocations400Response)   },{"401", typeof(ListTestAllocations401Response)   },{"403", typeof(ListTestAllocations403Response)   },{"404", typeof(ListTestAllocations404Response)   },{"429", typeof(ListTestAllocations429Response)   },{"500", typeof(ListTestAllocations500Response)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("POST",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            var handledResponse = ResponseHandler.HandleAsyncResponse<TestAllocateResponse>(response, statusCodeToTypeMap);
            return new Response<TestAllocateResponse>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// Remove a test allocation.
        /// </summary>
        /// <param name="request">Request object for ProcessTestDeallocation.</param>
        /// <param name="operationConfiguration">Configuration for ProcessTestDeallocation.</param>
        /// <returns>Task for a Response object containing status code, headers.</returns>
        /// <exception cref="Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response> ProcessTestDeallocationAsync(Unity.Services.Multiplay.Authoring.Editor.AdminApis.Allocations.Allocations.ProcessTestDeallocationRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"204",  null },{"400", typeof(ListTestAllocations400Response)   },{"401", typeof(ListTestAllocations401Response)   },{"403", typeof(ListTestAllocations403Response)   },{"404", typeof(ListTestAllocations404Response)   },{"429", typeof(ListTestAllocations429Response)   },{"500", typeof(ListTestAllocations500Response)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("DELETE",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            ResponseHandler.HandleAsyncResponse(response, statusCodeToTypeMap);
            return new Response(response);
        }

    }
}