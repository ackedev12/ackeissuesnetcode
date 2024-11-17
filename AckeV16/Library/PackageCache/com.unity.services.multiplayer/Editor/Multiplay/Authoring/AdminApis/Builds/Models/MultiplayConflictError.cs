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
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Builds.Http;



namespace Unity.Services.Multiplay.Authoring.Editor.AdminApis.Builds.Models
{
    /// <summary>
    /// A conflict error providing a list of conflicts blocking an operation.
    /// </summary>
    [Preserve]
    [DataContract(Name = "multiplay.conflictError")]
    internal class MultiplayConflictError
    {
        /// <summary>
        /// A conflict error providing a list of conflicts blocking an operation.
        /// </summary>
        /// <param name="title">title param</param>
        /// <param name="status">status param</param>
        /// <param name="details">A list of conflicts blocking an operation.</param>
        [Preserve]
        public MultiplayConflictError(string title, int status, List<ConflictItem> details)
        {
            Title = title;
            Status = status;
            Details = details;
        }

        /// <summary>
        /// Parameter title of MultiplayConflictError
        /// </summary>
        [Preserve]
        [DataMember(Name = "title", IsRequired = true, EmitDefaultValue = true)]
        public string Title{ get; }
        
        /// <summary>
        /// Parameter status of MultiplayConflictError
        /// </summary>
        [Preserve]
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
        public int Status{ get; }
        
        /// <summary>
        /// A list of conflicts blocking an operation.
        /// </summary>
        [Preserve]
        [DataMember(Name = "details", IsRequired = true, EmitDefaultValue = true)]
        public List<ConflictItem> Details{ get; }
    
        /// <summary>
        /// Formats a MultiplayConflictError into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Title != null)
            {
                serializedModel += "title," + Title + ",";
            }
            serializedModel += "status," + Status.ToString() + ",";
            if (Details != null)
            {
                serializedModel += "details," + Details.ToString();
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a MultiplayConflictError as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Title != null)
            {
                var titleStringValue = Title.ToString();
                dictionary.Add("title", titleStringValue);
            }
            
            var statusStringValue = Status.ToString();
            dictionary.Add("status", statusStringValue);
            
            return dictionary;
        }
    }
}
