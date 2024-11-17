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
    /// DeleteEntryBatchRequestInner model
    /// </summary>
    [Preserve]
    [DataContract(Name = "DeleteEntryBatch_request_inner")]
    internal class DeleteEntryBatchRequestInner
    {
        /// <summary>
        /// Creates an instance of DeleteEntryBatchRequestInner.
        /// </summary>
        /// <param name="entryid">entryid param</param>
        [Preserve]
        public DeleteEntryBatchRequestInner(System.Guid entryid)
        {
            Entryid = entryid;
        }

        /// <summary>
        /// Parameter entryid of DeleteEntryBatchRequestInner
        /// </summary>
        [Preserve]
        [DataMember(Name = "entryid", IsRequired = true, EmitDefaultValue = true)]
        public System.Guid Entryid{ get; }
    
        /// <summary>
        /// Formats a DeleteEntryBatchRequestInner into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Entryid != null)
            {
                serializedModel += "entryid," + Entryid;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a DeleteEntryBatchRequestInner as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Entryid != null)
            {
                var entryidStringValue = Entryid.ToString();
                dictionary.Add("entryid", entryidStringValue);
            }
            
            return dictionary;
        }
    }
}
