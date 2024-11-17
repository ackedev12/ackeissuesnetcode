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
    /// ListBucketAccessTokens200ResponseInner model
    /// </summary>
    [Preserve]
    [DataContract(Name = "ListBucketAccessTokens_200_response_inner")]
    internal class ListBucketAccessTokens200ResponseInner
    {
        /// <summary>
        /// Creates an instance of ListBucketAccessTokens200ResponseInner.
        /// </summary>
        /// <param name="created">created param</param>
        /// <param name="description">description param</param>
        /// <param name="id">id param</param>
        /// <param name="releaseid">If not specified, the access token will be valid for all releases in the bucket.</param>
        /// <param name="token">token param</param>
        [Preserve]
        public ListBucketAccessTokens200ResponseInner(DateTime created = default, string description = default, System.Guid id = default, System.Guid releaseid = default, string token = default)
        {
            Created = created;
            Description = description;
            Id = id;
            Releaseid = releaseid;
            Token = token;
        }

        /// <summary>
        /// Parameter created of ListBucketAccessTokens200ResponseInner
        /// </summary>
        [Preserve]
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public DateTime Created{ get; }
        
        /// <summary>
        /// Parameter description of ListBucketAccessTokens200ResponseInner
        /// </summary>
        [Preserve]
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description{ get; }
        
        /// <summary>
        /// Parameter id of ListBucketAccessTokens200ResponseInner
        /// </summary>
        [Preserve]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public System.Guid Id{ get; }
        
        /// <summary>
        /// If not specified, the access token will be valid for all releases in the bucket.
        /// </summary>
        [Preserve]
        [DataMember(Name = "releaseid", EmitDefaultValue = false)]
        public System.Guid Releaseid{ get; }
        
        /// <summary>
        /// Parameter token of ListBucketAccessTokens200ResponseInner
        /// </summary>
        [Preserve]
        [DataMember(Name = "token", EmitDefaultValue = false)]
        public string Token{ get; }
    
        /// <summary>
        /// Formats a ListBucketAccessTokens200ResponseInner into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Created != null)
            {
                serializedModel += "created," + Created.ToString() + ",";
            }
            if (Description != null)
            {
                serializedModel += "description," + Description + ",";
            }
            if (Id != null)
            {
                serializedModel += "id," + Id + ",";
            }
            if (Releaseid != null)
            {
                serializedModel += "releaseid," + Releaseid + ",";
            }
            if (Token != null)
            {
                serializedModel += "token," + Token;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a ListBucketAccessTokens200ResponseInner as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Created != null)
            {
                var createdStringValue = Created.ToString();
                dictionary.Add("created", createdStringValue);
            }
            
            if (Description != null)
            {
                var descriptionStringValue = Description.ToString();
                dictionary.Add("description", descriptionStringValue);
            }
            
            if (Id != null)
            {
                var idStringValue = Id.ToString();
                dictionary.Add("id", idStringValue);
            }
            
            if (Releaseid != null)
            {
                var releaseidStringValue = Releaseid.ToString();
                dictionary.Add("releaseid", releaseidStringValue);
            }
            
            if (Token != null)
            {
                var tokenStringValue = Token.ToString();
                dictionary.Add("token", tokenStringValue);
            }
            
            return dictionary;
        }
    }
}
