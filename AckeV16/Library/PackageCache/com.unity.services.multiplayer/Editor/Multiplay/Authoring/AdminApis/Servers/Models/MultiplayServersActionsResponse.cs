//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Servers.Http;



namespace Unity.Services.Multiplay.Authoring.Editor.AdminApis.Servers.Models
{
    /// <summary>
    /// Response from triggering a action.
    /// </summary>
    [Preserve]
    [DataContract(Name = "multiplay.servers.actionsResponse")]
    internal class MultiplayServersActionsResponse
    {
        /// <summary>
        /// Response from triggering a action.
        /// </summary>
        /// <param name="success">Indicates whether the action was triggered successfully.</param>
        [Preserve]
        public MultiplayServersActionsResponse(bool success)
        {
            Success = success;
        }

        /// <summary>
        /// Indicates whether the action was triggered successfully.
        /// </summary>
        [Preserve]
        [DataMember(Name = "success", IsRequired = true, EmitDefaultValue = true)]
        public bool Success{ get; }

        /// <summary>
        /// Formats a MultiplayServersActionsResponse into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            serializedModel += "success," + Success.ToString();
            return serializedModel;
        }

        /// <summary>
        /// Returns a MultiplayServersActionsResponse as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            var successStringValue = Success.ToString();
            dictionary.Add("success", successStringValue);

            return dictionary;
        }
    }
}
