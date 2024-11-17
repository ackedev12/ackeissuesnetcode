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
    /// An association between the fleet and a region.
    /// </summary>
    [Preserve]
    [DataContract(Name = "multiplay.fleetRegion")]
    internal class MultiplayFleetRegion
    {
        /// <summary>
        /// An association between the fleet and a region.
        /// </summary>
        /// <param name="id">ID of the fleet region.</param>
        /// <param name="regionID">ID of the associated region.</param>
        /// <param name="regionName">Name of the associated region.</param>
        /// <param name="scalingEnabled">Whether scaling is enabled for this fleet region.</param>
        /// <param name="status">Current status of the fleet.</param>
        /// <param name="minAvailableServers">Minimum number of servers to keep free for new game sessions.</param>
        /// <param name="maxServers">Maximum number of servers to host in the fleet region.</param>
        /// <param name="deleteTTL">A delete time-to-live in seconds.</param>
        /// <param name="shutdownTTL">A shutdown time-to-live in seconds.</param>
        /// <param name="disabledDeleteTTL">A disabled delete time-to-live in seconds.</param>
        [Preserve]
        public MultiplayFleetRegion(System.Guid id, System.Guid regionID, string regionName, bool scalingEnabled, StatusOptions status, long minAvailableServers, long maxServers, long deleteTTL = default, long shutdownTTL = default, long disabledDeleteTTL = default)
        {
            Id = id;
            RegionID = regionID;
            RegionName = regionName;
            ScalingEnabled = scalingEnabled;
            Status = status;
            MinAvailableServers = minAvailableServers;
            MaxServers = maxServers;
            DeleteTTL = deleteTTL;
            ShutdownTTL = shutdownTTL;
            DisabledDeleteTTL = disabledDeleteTTL;
        }

        /// <summary>
        /// ID of the fleet region.
        /// </summary>
        [Preserve]
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public System.Guid Id{ get; }

        /// <summary>
        /// ID of the associated region.
        /// </summary>
        [Preserve]
        [DataMember(Name = "regionID", IsRequired = true, EmitDefaultValue = true)]
        public System.Guid RegionID{ get; }

        /// <summary>
        /// Name of the associated region.
        /// </summary>
        [Preserve]
        [DataMember(Name = "regionName", IsRequired = true, EmitDefaultValue = true)]
        public string RegionName{ get; }

        /// <summary>
        /// Whether scaling is enabled for this fleet region.
        /// </summary>
        [Preserve]
        [DataMember(Name = "scalingEnabled", IsRequired = true, EmitDefaultValue = true)]
        public bool ScalingEnabled{ get; }

        /// <summary>
        /// Current status of the fleet.
        /// </summary>
        [Preserve]
        [JsonConverter(typeof(StringEnumConverter))]
        [DataMember(Name = "status", IsRequired = true, EmitDefaultValue = true)]
        public StatusOptions Status{ get; }

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
        /// A delete time-to-live in seconds.
        /// </summary>
        [Preserve]
        [DataMember(Name = "deleteTTL", EmitDefaultValue = false)]
        public long DeleteTTL{ get; }

        /// <summary>
        /// A shutdown time-to-live in seconds.
        /// </summary>
        [Preserve]
        [DataMember(Name = "shutdownTTL", EmitDefaultValue = false)]
        public long ShutdownTTL{ get; }

        /// <summary>
        /// A disabled delete time-to-live in seconds.
        /// </summary>
        [Preserve]
        [DataMember(Name = "disabledDeleteTTL", EmitDefaultValue = false)]
        public long DisabledDeleteTTL{ get; }

        /// <summary>
        /// Current status of the fleet.
        /// </summary>
        /// <value>Current status of the fleet.</value>
        [Preserve]
        [JsonConverter(typeof(StringEnumConverter))]
        public enum StatusOptions
        {
            /// <summary>
            /// Enum ONLINE for value: ONLINE
            /// </summary>
            [EnumMember(Value = "ONLINE")]
            ONLINE = 1,
            /// <summary>
            /// Enum DRAINING for value: DRAINING
            /// </summary>
            [EnumMember(Value = "DRAINING")]
            DRAINING = 2,
            /// <summary>
            /// Enum OFFLINE for value: OFFLINE
            /// </summary>
            [EnumMember(Value = "OFFLINE")]
            OFFLINE = 3
        }

        /// <summary>
        /// Formats a MultiplayFleetRegion into a string of key-value pairs for use as a path parameter.
        /// </summary>
        /// <returns>Returns a string representation of the key-value pairs.</returns>
        internal string SerializeAsPathParam()
        {
            var serializedModel = "";

            if (Id != null)
            {
                serializedModel += "id," + Id + ",";
            }
            if (RegionID != null)
            {
                serializedModel += "regionID," + RegionID + ",";
            }
            if (RegionName != null)
            {
                serializedModel += "regionName," + RegionName + ",";
            }
            serializedModel += "scalingEnabled," + ScalingEnabled.ToString() + ",";
            serializedModel += "status," + Status + ",";
            serializedModel += "minAvailableServers," + MinAvailableServers.ToString() + ",";
            serializedModel += "maxServers," + MaxServers.ToString() + ",";
            serializedModel += "deleteTTL," + DeleteTTL.ToString() + ",";
            serializedModel += "shutdownTTL," + ShutdownTTL.ToString() + ",";
            serializedModel += "disabledDeleteTTL," + DisabledDeleteTTL.ToString();
            return serializedModel;
        }

        /// <summary>
        /// Returns a MultiplayFleetRegion as a dictionary of key-value pairs for use as a query parameter.
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

            if (RegionID != null)
            {
                var regionIDStringValue = RegionID.ToString();
                dictionary.Add("regionID", regionIDStringValue);
            }

            if (RegionName != null)
            {
                var regionNameStringValue = RegionName.ToString();
                dictionary.Add("regionName", regionNameStringValue);
            }

            var scalingEnabledStringValue = ScalingEnabled.ToString();
            dictionary.Add("scalingEnabled", scalingEnabledStringValue);

            var statusStringValue = Status.ToString();
            dictionary.Add("status", statusStringValue);

            var minAvailableServersStringValue = MinAvailableServers.ToString();
            dictionary.Add("minAvailableServers", minAvailableServersStringValue);

            var maxServersStringValue = MaxServers.ToString();
            dictionary.Add("maxServers", maxServersStringValue);

            var deleteTTLStringValue = DeleteTTL.ToString();
            dictionary.Add("deleteTTL", deleteTTLStringValue);

            var shutdownTTLStringValue = ShutdownTTL.ToString();
            dictionary.Add("shutdownTTL", shutdownTTLStringValue);

            var disabledDeleteTTLStringValue = DisabledDeleteTTL.ToString();
            dictionary.Add("disabledDeleteTTL", disabledDeleteTTLStringValue);

            return dictionary;
        }
    }
}
