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
    /// InlineResponse2007 model
    /// </summary>
    [Preserve]
    [DataContract(Name = "inline_response_200_7")]
    internal class InlineResponse2007
    {
        /// <summary>
        /// Creates an instance of InlineResponse2007.
        /// </summary>
        /// <param name="promotionId">promotionId param</param>
        [Preserve]
        public InlineResponse2007(System.Guid promotionId = default)
        {
            PromotionId = promotionId;
        }

        /// <summary>
        /// Parameter promotion_id of InlineResponse2007
        /// </summary>
        [Preserve]
        [DataMember(Name = "promotion_id", EmitDefaultValue = false)]
        public System.Guid PromotionId{ get; }

        /// <summary>
        /// Formats a InlineResponse2007 into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (PromotionId != null)
            {
                serializedModel += "promotion_id," + PromotionId;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a InlineResponse2007 as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (PromotionId != null)
            {
                var promotion_idStringValue = PromotionId.ToString();
                dictionary.Add("promotion_id", promotion_idStringValue);
            }

            return dictionary;
        }
    }
}
