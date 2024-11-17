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
using Unity.Services.Matchmaker.Models;
using Unity.Services.Matchmaker.Http;
using Unity.Services.Authentication.Internal;
using Unity.Services.Matchmaker.Tickets;

namespace Unity.Services.Matchmaker.Apis.Tickets
{
    /// <summary>
    /// Interface for the TicketsApiClient
    /// </summary>
    internal interface ITicketsApiClient
    {
            /// <summary>
            /// Async Operation.
            /// Create a matchmaking ticket.
            /// </summary>
            /// <param name="request">Request object for CreateTicket.</param>
            /// <param name="operationConfiguration">Configuration for CreateTicket.</param>
            /// <returns>Task for a Response object containing status code, headers, and Models.CreateTicketResponse object.</returns>
            /// <exception cref="Unity.Services.Matchmaker.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<Models.CreateTicketResponse>> CreateTicketAsync(Unity.Services.Matchmaker.Tickets.CreateTicketRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Delete a matchmaking ticket.
            /// </summary>
            /// <param name="request">Request object for DeleteTicket.</param>
            /// <param name="operationConfiguration">Configuration for DeleteTicket.</param>
            /// <returns>Task for a Response object containing status code, headers.</returns>
            /// <exception cref="Unity.Services.Matchmaker.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response> DeleteTicketAsync(Unity.Services.Matchmaker.Tickets.DeleteTicketRequest request, Configuration operationConfiguration = null);

            /// <summary>
            /// Async Operation.
            /// Gets the status of a ticket match assignment in the matchmaker.
            /// </summary>
            /// <param name="request">Request object for GetTicketStatus.</param>
            /// <param name="operationConfiguration">Configuration for GetTicketStatus.</param>
            /// <returns>Task for a Response object containing status code, headers, and Models.TicketStatusResponse object.</returns>
            /// <exception cref="Unity.Services.Matchmaker.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
            Task<Response<Models.TicketStatusResponse>> GetTicketStatusAsync(Unity.Services.Matchmaker.Tickets.GetTicketStatusRequest request, Configuration operationConfiguration = null);

    }

    ///<inheritdoc cref="ITicketsApiClient"/>
    internal class TicketsApiClient : BaseApiClient, ITicketsApiClient
    {
        private IAccessToken _accessToken;
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
                Configuration globalConfiguration = new Configuration("https://matchmaker.services.api.unity.com", 10, 4, null);
                return Configuration.MergeConfigurations(_configuration, globalConfiguration);
            }
            set { _configuration = value; }
        }

        /// <summary>
        /// TicketsApiClient Constructor.
        /// </summary>
        /// <param name="httpClient">The HttpClient for TicketsApiClient.</param>
        /// <param name="accessToken">The Authentication token for the client.</param>
        /// <param name="configuration"> TicketsApiClient Configuration object.</param>
        public TicketsApiClient(IHttpClient httpClient,
            IAccessToken accessToken,
            Configuration configuration = null) : base(httpClient)
        {
            // We don't need to worry about the configuration being null at
            // this stage, we will check this in the accessor.
            _configuration = configuration;

            _accessToken = accessToken;
        }


        /// <summary>
        /// Async Operation.
        /// Create a matchmaking ticket.
        /// </summary>
        /// <param name="request">Request object for CreateTicket.</param>
        /// <param name="operationConfiguration">Configuration for CreateTicket.</param>
        /// <returns>Task for a Response object containing status code, headers, and Models.CreateTicketResponse object.</returns>
        /// <exception cref="Unity.Services.Matchmaker.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<Models.CreateTicketResponse>> CreateTicketAsync(Unity.Services.Matchmaker.Tickets.CreateTicketRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"201", typeof(Models.CreateTicketResponse)   },{"400", typeof(Models.ProblemDetails)   },{"429", typeof(Models.ProblemDetails)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("POST",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(_accessToken, finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            var handledResponse = ResponseHandler.HandleAsyncResponse<Models.CreateTicketResponse>(response, statusCodeToTypeMap);
            return new Response<Models.CreateTicketResponse>(response, handledResponse);
        }


        /// <summary>
        /// Async Operation.
        /// Delete a matchmaking ticket.
        /// </summary>
        /// <param name="request">Request object for DeleteTicket.</param>
        /// <param name="operationConfiguration">Configuration for DeleteTicket.</param>
        /// <returns>Task for a Response object containing status code, headers.</returns>
        /// <exception cref="Unity.Services.Matchmaker.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response> DeleteTicketAsync(Unity.Services.Matchmaker.Tickets.DeleteTicketRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200",  null },{"400", typeof(Models.ProblemDetails)   },{"429", typeof(Models.ProblemDetails)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("DELETE",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(_accessToken, finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            ResponseHandler.HandleAsyncResponse(response, statusCodeToTypeMap);
            return new Response(response);
        }


        /// <summary>
        /// Async Operation.
        /// Gets the status of a ticket match assignment in the matchmaker.
        /// </summary>
        /// <param name="request">Request object for GetTicketStatus.</param>
        /// <param name="operationConfiguration">Configuration for GetTicketStatus.</param>
        /// <returns>Task for a Response object containing status code, headers, and Models.TicketStatusResponse object.</returns>
        /// <exception cref="Unity.Services.Matchmaker.Http.HttpException">An exception containing the HttpClientResponse with headers, response code, and string of error.</exception>
        public async Task<Response<Models.TicketStatusResponse>> GetTicketStatusAsync(Unity.Services.Matchmaker.Tickets.GetTicketStatusRequest request,
            Configuration operationConfiguration = null)
        {
            var statusCodeToTypeMap = new Dictionary<string, System.Type>() { {"200", typeof(Models.TicketStatusResponse)   },{"400", typeof(Models.ProblemDetails)   },{"404", typeof(Models.ProblemDetails)   },{"429", typeof(Models.ProblemDetails)   } };

            // Merge the operation/request level configuration with the client level configuration.
            var finalConfiguration = Configuration.MergeConfigurations(operationConfiguration, Configuration);

            var response = await HttpClient.MakeRequestAsync("GET",
                request.ConstructUrl(finalConfiguration.BasePath),
                request.ConstructBody(),
                request.ConstructHeaders(_accessToken, finalConfiguration),
                finalConfiguration.RequestTimeout ?? _baseTimeout);

            var handledResponse = ResponseHandler.HandleAsyncResponse<Models.TicketStatusResponse>(response, statusCodeToTypeMap);
            return new Response<Models.TicketStatusResponse>(response, handledResponse);
        }

    }
}
