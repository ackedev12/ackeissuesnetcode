
//-----------------------------------------------------------------------------
// <auto-generated>
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------

using System;

namespace Unity.Services.Multiplayer.Editor.Matchmaker.Authoring.AdminApi.Shared
{
    /// <summary>
    /// API Exception
    /// </summary>
    class ApiException : Exception
    {
        /// <summary>
        /// Gets the response
        /// </summary>
        /// <value>The response</value>
        public ApiResponse Response { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="response">The response</param>
        public ApiException(ApiResponse response)
            : base($"{response.ErrorType}\n{response.ErrorText}\nStatusCode: '{response.StatusCode}'")
        {
            this.Response = response;
        }
    }
}