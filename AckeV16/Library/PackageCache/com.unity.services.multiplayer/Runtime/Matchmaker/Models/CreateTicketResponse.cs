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
using Unity.Services.Matchmaker.Http;



namespace Unity.Services.Matchmaker.Models
{
    /// <summary>
    /// CreateTicketResponse model
    /// </summary>
    [Preserve]
    [DataContract(Name = "CreateTicketResponse")]
    public class CreateTicketResponse
    {
        /// <summary>
        /// Creates an instance of CreateTicketResponse.
        /// </summary>
        /// <param name="id">id param</param>
        [Preserve]
        public CreateTicketResponse(string id = default)
        {
            Id = id;
        }

        /// <summary>
        /// Creates an instance of CreateTicketResponse.
        /// </summary>
        /// <param name="id">id param</param>
        /// <param name="abTestingResult">abTestingResult param</param>
        [Preserve]
        [JsonConstructor]
        public CreateTicketResponse(string id = default, AbTestingResult abTestingResult = default)
        {
            Id = id;
            AbTestingResult = abTestingResult;
        }

        /// <summary>
        /// Parameter id of CreateTicketResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id{ get; }

        /// <summary>
        /// Parameter abTestingResult of CreateTicketResponse
        /// </summary>
        [Preserve]
        [DataMember(Name = "abTestingResult", EmitDefaultValue = false)]
        public AbTestingResult AbTestingResult{ get; }

        /// <summary>
        /// Formats a CreateTicketResponse into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Id != null)
            {
                serializedModel += "id," + Id + ",";
            }
            if (AbTestingResult != null)
            {
                serializedModel += "abTestingResult," + AbTestingResult.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a CreateTicketResponse as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Id != null)
            {
                var idStringValue = Id.ToString();
                dictionary.Add("id", idStringValue);
            }

            return dictionary;
        }
    }
}