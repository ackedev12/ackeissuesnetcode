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
using Unity.Services.Lobbies.Http;



namespace Unity.Services.Lobbies.Models
{
    /// <summary>
    /// The body of a Query request which defines how to sort and filter results, how many results to return, etc.
    /// </summary>
    [Preserve]
    [DataContract(Name = "QueryRequest")]
    public class QueryRequest
    {
        /// <summary>
        /// The body of a Query request which defines how to sort and filter results, how many results to return, etc.
        /// </summary>
        /// <param name="count">The number of results to return.</param>
        /// <param name="skip">The number of results to skip before selecting results to return.</param>
        /// <param name="sampleResults">Whether a random sample of results that match the search filter should be returned.</param>
        /// <param name="filter">A list of filters which can be used to narrow down which lobbies to return.</param>
        /// <param name="order">A list of orders which define how the results should be ordered in the response.</param>
        /// <param name="continuationToken">A continuation token that can be passed to subsequent query requests to fetch the next page of results.</param>
        [Preserve]
        public QueryRequest(int? count = 10, int? skip = 0, bool sampleResults = false, List<QueryFilter> filter = default, List<QueryOrder> order = default, string continuationToken = default)
        {
            Count = count;
            Skip = skip;
            SampleResults = sampleResults;
            Filter = filter;
            Order = order;
            ContinuationToken = continuationToken;
        }

        /// <summary>
        /// The number of results to return.
        /// </summary>
        [Preserve]
        [DataMember(Name = "count", EmitDefaultValue = false)]
        public int? Count{ get; }

        /// <summary>
        /// The number of results to skip before selecting results to return.
        /// </summary>
        [Preserve]
        [DataMember(Name = "skip", EmitDefaultValue = false)]
        public int? Skip{ get; }

        /// <summary>
        /// Whether a random sample of results that match the search filter should be returned.
        /// </summary>
        [Preserve]
        [DataMember(Name = "sampleResults", EmitDefaultValue = true)]
        public bool SampleResults{ get; }

        /// <summary>
        /// A list of filters which can be used to narrow down which lobbies to return.
        /// </summary>
        [Preserve]
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        public List<QueryFilter> Filter{ get; }

        /// <summary>
        /// A list of orders which define how the results should be ordered in the response.
        /// </summary>
        [Preserve]
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public List<QueryOrder> Order{ get; }

        /// <summary>
        /// A continuation token that can be passed to subsequent query requests to fetch the next page of results.
        /// </summary>
        [Preserve]
        [DataMember(Name = "continuationToken", EmitDefaultValue = false)]
        public string ContinuationToken{ get; }

        /// <summary>
        /// Formats a QueryRequest into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Count != null)
            {
                serializedModel += "count," + Count.ToString() + ",";
            }
            if (Skip != null)
            {
                serializedModel += "skip," + Skip.ToString() + ",";
            }
            serializedModel += "sampleResults," + SampleResults.ToString() + ",";
            if (Filter != null)
            {
                serializedModel += "filter," + Filter.ToString() + ",";
            }
            if (Order != null)
            {
                serializedModel += "order," + Order.ToString() + ",";
            }
            if (ContinuationToken != null)
            {
                serializedModel += "continuationToken," + ContinuationToken;
            }
            return serializedModel;
        }

        /// <summary>
        /// Returns a QueryRequest as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (Count != null)
            {
                var countStringValue = Count.ToString();
                dictionary.Add("count", countStringValue);
            }

            if (Skip != null)
            {
                var skipStringValue = Skip.ToString();
                dictionary.Add("skip", skipStringValue);
            }

            var sampleResultsStringValue = SampleResults.ToString();
            dictionary.Add("sampleResults", sampleResultsStringValue);

            if (ContinuationToken != null)
            {
                var continuationTokenStringValue = ContinuationToken.ToString();
                dictionary.Add("continuationToken", continuationTokenStringValue);
            }

            return dictionary;
        }
    }
}
