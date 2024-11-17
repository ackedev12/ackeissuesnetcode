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
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Http;



namespace Unity.Services.Multiplay.Authoring.Editor.AdminApis.Ccd.Models
{
    /// <summary>
    /// GetOrgUsage200Response model
    /// </summary>
    [Preserve]
    [DataContract(Name = "GetOrgUsage_200_response")]
    internal class GetOrgUsage200Response
    {
        /// <summary>
        /// Creates an instance of GetOrgUsage200Response.
        /// </summary>
        /// <param name="id">id param</param>
        /// <param name="startTime">startTime param</param>
        /// <param name="usage">usage param</param>
        [Preserve]
        public GetOrgUsage200Response(string id = default, DateTime startTime = default, List<GetOrgUsage200ResponseUsageInner> usage = default)
        {
            Id = id;
            StartTime = startTime;
            Usage = usage;
        }

        /// <summary>
        /// Parameter id of GetOrgUsage200Response
        /// </summary>
        [Preserve]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id{ get; }
        
        /// <summary>
        /// Parameter start_time of GetOrgUsage200Response
        /// </summary>
        [Preserve]
        [DataMember(Name = "start_time", EmitDefaultValue = false)]
        public DateTime StartTime{ get; }
        
        /// <summary>
        /// Parameter usage of GetOrgUsage200Response
        /// </summary>
        [Preserve]
        [DataMember(Name = "usage", EmitDefaultValue = false)]
        public List<GetOrgUsage200ResponseUsageInner> Usage{ get; }
    
        /// <summary>
        /// Formats a GetOrgUsage200Response into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Id != null)
            {
                serializedModel += "id," + Id + ",";
            }
            if (StartTime != null)
            {
                serializedModel += "start_time," + StartTime.ToString() + ",";
            }
            if (Usage != null)
            {
                serializedModel += "usage," + Usage.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a GetOrgUsage200Response as a dictionary of key-value pairs for use as a query parameter.
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
            
            if (StartTime != null)
            {
                var start_timeStringValue = StartTime.ToString();
                dictionary.Add("start_time", start_timeStringValue);
            }
            
            return dictionary;
        }
    }
}