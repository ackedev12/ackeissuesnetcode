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
    /// CcdHttperror model
    /// </summary>
    [Preserve]
    [DataContract(Name = "ccd.httperror")]
    internal class CcdHttperror
    {
        /// <summary>
        /// Creates an instance of CcdHttperror.
        /// </summary>
        /// <param name="code">0 - OK 1 - Invalid argument 2 - Out of range 3 - Unauthenticated 4 - Permission denied 5 - Not found 6 - Already exists 7 - Unknown error 8 - Internal error 9 - Invalid operation 10 - Organization Activation is needed 11 - You have an entry specified, but the matching file has not been uploaded, or the file size, or md5 hash of what was uploaded does not match 12 - too many requests</param>
        /// <param name="details">details param</param>
        /// <param name="reason">reason param</param>
        [Preserve]
        public CcdHttperror(CodeOptions code = default, List<string> details = default, string reason = default)
        {
            Code = code;
            Details = details;
            Reason = reason;
        }

        /// <summary>
        /// 0 - OK 1 - Invalid argument 2 - Out of range 3 - Unauthenticated 4 - Permission denied 5 - Not found 6 - Already exists 7 - Unknown error 8 - Internal error 9 - Invalid operation 10 - Organization Activation is needed 11 - You have an entry specified, but the matching file has not been uploaded, or the file size, or md5 hash of what was uploaded does not match 12 - too many requests
        /// </summary>
        [Preserve]
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "code", EmitDefaultValue = false)]
        public CodeOptions Code{ get; }

        /// <summary>
        /// Parameter details of CcdHttperror
        /// </summary>
        [Preserve]
        [DataMember(Name = "details", EmitDefaultValue = false)]
        public List<string> Details{ get; }

        /// <summary>
        /// Parameter reason of CcdHttperror
        /// </summary>
        [Preserve]
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public string Reason{ get; }

        /// <summary>
        /// 0 - OK 1 - Invalid argument 2 - Out of range 3 - Unauthenticated 4 - Permission denied 5 - Not found 6 - Already exists 7 - Unknown error 8 - Internal error 9 - Invalid operation 10 - Organization Activation is needed 11 - You have an entry specified, but the matching file has not been uploaded, or the file size, or md5 hash of what was uploaded does not match 12 - too many requests
        /// </summary>
        /// <value>0 - OK 1 - Invalid argument 2 - Out of range 3 - Unauthenticated 4 - Permission denied 5 - Not found 6 - Already exists 7 - Unknown error 8 - Internal error 9 - Invalid operation 10 - Organization Activation is needed 11 - You have an entry specified, but the matching file has not been uploaded, or the file size, or md5 hash of what was uploaded does not match 12 - too many requests</value>
        public enum CodeOptions
        {
            /// <summary>
            /// Enum _0 for value: 0
            /// </summary>
            _0 = 0,
            /// <summary>
            /// Enum _1 for value: 1
            /// </summary>
            _1 = 1,
            /// <summary>
            /// Enum _2 for value: 2
            /// </summary>
            _2 = 2,
            /// <summary>
            /// Enum _3 for value: 3
            /// </summary>
            _3 = 3,
            /// <summary>
            /// Enum _4 for value: 4
            /// </summary>
            _4 = 4,
            /// <summary>
            /// Enum _5 for value: 5
            /// </summary>
            _5 = 5,
            /// <summary>
            /// Enum _6 for value: 6
            /// </summary>
            _6 = 6,
            /// <summary>
            /// Enum _7 for value: 7
            /// </summary>
            _7 = 7,
            /// <summary>
            /// Enum _8 for value: 8
            /// </summary>
            _8 = 8,
            /// <summary>
            /// Enum _9 for value: 9
            /// </summary>
            _9 = 9,
            /// <summary>
            /// Enum _10 for value: 10
            /// </summary>
            _10 = 10,
            /// <summary>
            /// Enum _11 for value: 11
            /// </summary>
            _11 = 11,
            /// <summary>
            /// Enum _12 for value: 12
            /// </summary>
            _12 = 12
        }

        /// <summary>
        /// Formats a CcdHttperror into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            serializedModel += "code," + Code.ToString() + ",";
            if (Details != null)
            {
                serializedModel += "details," + Details.ToString() + ",";
            }
            if (Reason != null)
            {
                serializedModel += "reason," + Reason;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a CcdHttperror as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            var codeStringValue = Code.ToString();
            dictionary.Add("code", codeStringValue);

            if (Details != null)
            {
                var detailsStringValue = Details.ToString();
                dictionary.Add("details", detailsStringValue);
            }

            if (Reason != null)
            {
                var reasonStringValue = Reason.ToString();
                dictionary.Add("reason", reasonStringValue);
            }

            return dictionary;
        }
    }
}
