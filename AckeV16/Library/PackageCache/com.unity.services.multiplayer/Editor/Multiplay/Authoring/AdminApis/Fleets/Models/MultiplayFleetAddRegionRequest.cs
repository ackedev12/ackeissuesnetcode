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
using Unity.Services.Multiplay.Authoring.Editor.AdminApis.Fleets.Http;



namespace Unity.Services.Multiplay.Authoring.Editor.AdminApis.Fleets.Models
{
    /// <summary>
    /// Request to add a region to a fleet with the provided configuration.
    /// </summary>
    [Preserve]
    [DataContract(Name = "multiplay.fleetAddRegionRequest")]
    internal class MultiplayFleetAddRegionRequest
    {
        /// <summary>
        /// Request to add a region to a fleet with the provided configuration.
        /// </summary>
        /// <param name="regionID">ID of the associated region.</param>
        /// <param name="minAvailableServers">Minimum number of servers to keep free for new game sessions.</param>
        /// <param name="maxServers">Maximum number of servers to host in the fleet region.</param>
        [Preserve]
        public MultiplayFleetAddRegionRequest(System.Guid regionID, long minAvailableServers, long maxServers)
        {
            RegionID = regionID;
            MinAvailableServers = minAvailableServers;
            MaxServers = maxServers;
        }

        /// <summary>
        /// ID of the associated region.
        /// </summary>
        [Preserve]
        [DataMember(Name = "regionID", IsRequired = true, EmitDefaultValue = true)]
        public System.Guid RegionID{ get; }

        /// <summary>
        /// Minimum number of servers to keep free for new game sessions.
        /// </summary>
        [Preserve]
        [DataMember(Name = "minAvailableServers", IsRequired = true, EmitDefaultValue = true)]
        public long MinAvailableServers{ get; }

        /// <summary>
        /// Maximum number of servers to host in the fleet region.
        /// </summary>
        [Preserve]
        [DataMember(Name = "maxServers", IsRequired = true, EmitDefaultValue = true)]
        public long MaxServers{ get; }

        /// <summary>
        /// Formats a MultiplayFleetAddRegionRequest into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (RegionID != null)
            {
                serializedModel += "regionID," + RegionID + ",";
            }
            serializedModel += "minAvailableServers," + MinAvailableServers.ToString() + ",";
            serializedModel += "maxServers," + MaxServers.ToString();
            return serializedModel;
        }

        /// <summary>
        /// Returns a MultiplayFleetAddRegionRequest as a dictionary of key-value pairs for use as a query parameter.
        /// </summary>
        /// <returns>Returns a dictionary of string key-value pairs.</returns>
        internal Dictionary<string, string> GetAsQueryParam()
        {
            var dictionary = new Dictionary<string, string>();

            if (RegionID != null)
            {
                var regionIDStringValue = RegionID.ToString();
                dictionary.Add("regionID", regionIDStringValue);
            }

            var minAvailableServersStringValue = MinAvailableServers.ToString();
            dictionary.Add("minAvailableServers", minAvailableServersStringValue);

            var maxServersStringValue = MaxServers.ToString();
            dictionary.Add("maxServers", maxServersStringValue);

            return dictionary;
        }
    }
}
